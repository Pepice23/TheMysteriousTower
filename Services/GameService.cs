using TheMysteriousTower.Helpers;
using TheMysteriousTower.Services.Interfaces;

namespace TheMysteriousTower.Services;

/// <summary>
/// Manages the game state and progression logic
/// </summary>
public class GameService : IGameService
{
    #region Events
    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    public event Action? OnChange;
    #endregion

    #region Properties
    /// <summary>
    /// Current background image path
    /// </summary>
    public string BackgroundImage { get; set; } = "/images/backgrounds/bg1.png";

    /// <summary>
    /// Current floor number in the tower
    /// </summary>
    public byte FloorNumber { get; set; } = 1;

    /// <summary>
    /// Current enemy number on the floor
    /// </summary>
    public byte CurrentEnemy { get; set; } = 1;

    /// <summary>
    /// Maximum number of enemies per floor
    /// </summary>
    public byte MaxEnemy { get; set; } = 7;
    #endregion

    #region Floor Management
    /// <summary>
    /// Advances to the next floor, updates background, and resets enemy count
    /// </summary>
    public void IncrementFloor()
    {
        FloorNumber++;
        SetBackgroundImage();
        ResetEnemy();
        SetMaxEnemy();
        OnChange?.Invoke();
    }

    private void SetMaxEnemy()
    {
        if (FloorNumber < 10)
        {
            MaxEnemy = 7;
        }
        else if (FloorNumber < 30)
        {
            MaxEnemy = 10;
        }
        else
        {
            MaxEnemy = 15;
        }
    }

    private void SetBackgroundImage()
    {
        BackgroundImage = ImageUtility.GetRandomImageFromFolder("images/backgrounds") ?? "";
        OnChange?.Invoke();
    }

    #endregion

    #region Enemy Management
    /// <summary>
    /// Increments the current enemy counter
    /// </summary>
    public void IncrementEnemy()
    {
        CurrentEnemy++;
        OnChange?.Invoke();
    }

    /// <summary>
    /// Resets the enemy counter to 1
    /// </summary>
    public void ResetEnemy()
    {
        CurrentEnemy = 1;
        OnChange?.Invoke();
    }
    #endregion
}
