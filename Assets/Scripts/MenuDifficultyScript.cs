using UnityEngine;
using UnityEngine.UI;

public class MenuDifficultyScript : MonoBehaviour
{
    private Toggle clockToggle;
    private Toggle compassToggle;

    void Start()
    {
        Transform layout1 = transform.Find("Content/GameDifficulty/Layout1");

        clockToggle = layout1.Find("ClockToggle").GetComponent<Toggle>();
        clockToggle.isOn = GameState.isCompassVisible;

        compassToggle = layout1.Find("CompassToggle").GetComponent<Toggle>();
        compassToggle.isOn = GameState.isCompassVisible;
    }

    void Update()
    {
        
    }

    public void OnClockToggle(bool value)
    {
        GameState.isClockVisible = value;
    }

    public void OnCompassToggle(bool value)
    {
        GameState.isCompassVisible = value;
    }
}
