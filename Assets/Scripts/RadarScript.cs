using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarScript : MonoBehaviour
{
    private Transform character;
    private Image screen;
    private Image samplePoint;
    private List<CoinPoint> coinPoints = new();
    [SerializeField]
    private float activeZoneRatio = 0.85f;
    [SerializeField]
    private float maxVisibleDistance = 35f;

    void Start()
    {
        character = GameObject.Find("Character").transform;
        screen = transform.Find("Screen").GetComponent<Image>();
        samplePoint = transform.Find("Screen/Point").GetComponent<Image>();

        Transform coin = GameObject.Find("Coin").transform;
        coinPoints.Add(new CoinPoint
        {
            coin = coin,
            point = GameObject.Instantiate(samplePoint)
        });

        samplePoint.gameObject.SetActive(false);

        GameEventController.AddListener("SpawnCoin", OnCoinSpawnEvent);
        GameEventController.AddListener("Disappear", OnDisappearEvent);
    }

    void Update()
    {
        float screenWidth = screen.rectTransform.rect.width;
        float maxRadius = screenWidth * activeZoneRatio * 0.5f;

        foreach (CoinPoint cp in coinPoints)
        {
            Vector3 d = cp.coin.position - character.position;
            if (d.magnitude > maxVisibleDistance)
            {
                cp.point.gameObject.SetActive(false);
            }
            else
            {
                if (!cp.point.gameObject.activeInHierarchy) cp.point.gameObject.SetActive(true);
                Vector3 f = Camera.main.transform.forward;
                d.y = 0f;
                f.y = 0f;
                float angle = Vector3.SignedAngle(f, d, Vector3.down);

                float r = maxRadius * d.magnitude / maxVisibleDistance;

                cp.point.rectTransform.localPosition = new Vector3(
                    -r * Mathf.Sin(angle * Mathf.Deg2Rad),
                    r * Mathf.Cos(angle * Mathf.Deg2Rad)
                );
            }
        }
            
    }

    private void OnDisappearEvent(string type, object payload)
    {
        if (payload.Equals("Coin"))
        {
            coin = null;
        }
    }
    private void OnCoinSpawnEvent(string type, object payload)
    {
        if (payload is GameObject newCoin)
        {
            this.coin = newCoin.transform;
        }
    }

    private void OnDestroy()
    {
        GameEventController.RemoveListener("SpawnCoin", OnCoinSpawnEvent);
        GameEventController.RemoveListener("Disappear", OnDisappearEvent);
    }

    private class CoinPoint
    {
        public Transform coin { get; set; }
        public Image point { get; set; }
    }
}
