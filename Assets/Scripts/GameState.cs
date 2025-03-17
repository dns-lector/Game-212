
public class GameState
{
    public static float gameTime24 { get; set; } = 12.0f;
    public static float maxCoinSpawnDistance { get; set; } = 30.0f;
    public static float coinSpawnProbability { get; set; } = 0.5f;
    public static float radarVisibleRadius { get; set; } = 30.0f;
    public static float maxStamina { get; set; } = 10.0f;

    #region isClockVisible
    private static bool _isClockVisible = false;
    public static bool isClockVisible {
        get => _isClockVisible;
        set
        {
            if (_isClockVisible != value)
            {
                _isClockVisible = value;
                GameEventController.EmitEvent(nameof(GameState), nameof(isClockVisible));
            }
        }
    }
    #endregion

    #region isCompassVisible
    private static bool _isCompassVisible = false;
    public static bool isCompassVisible {
        get => _isCompassVisible;
        set
        {
            if (_isCompassVisible != value)
            {
                _isCompassVisible = value;
                GameEventController.EmitEvent(nameof(GameState), nameof(isCompassVisible));
            }
        }
    }
    #endregion

    public static bool isRadarVisible { get; set; } = true;
    public static bool isHintsVisible { get; set; } = true;




}
