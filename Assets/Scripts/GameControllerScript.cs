using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    void Start()
    {
        GameEventController.AddListener("Disappear", OnGameEvent);
    }

    private void OnGameEvent(string type, object payload)
    {
        Debug.Log(type + " " + payload);
    }

    private void OnDestroy()
    {
        GameEventController.RemoveListener("Disappear", OnGameEvent);
    }
}
