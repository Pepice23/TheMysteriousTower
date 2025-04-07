namespace TheMysteriousTower.Services.Interfaces;

/// <summary>
/// Defines the contract for game state management and progression
/// </summary>
public interface IGameService
{
    #region Events
    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    event Action? OnChange;
    #endregion

    #region Properties
    /// <summary>
    /// Current background image path
    /// </summary>
    string BackgroundImage { get; set; }

    /// <summary>
    /// Current floor number in the tower
    /// </summary>
    byte FloorNumber { get; set; }

    /// <summary>
    /// Current enemy number on the floor
    /// </summary>
    byte CurrentEnemy { get; set; }

    /// <summary>
    /// Maximum number of enemies per floor
    /// </summary>
    byte MaxEnemy { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Advances to the next floor, updates background, and resets enemy count
    /// </summary>
    void IncrementFloor();

    /// <summary>
    /// Increments the current enemy counter
    /// </summary>
    void IncrementEnemy();

    /// <summary>
    /// Resets the enemy counter to 1
    /// </summary>
    void ResetEnemy();
    #endregion
}