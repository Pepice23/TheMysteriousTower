namespace TheMysteriousTower.Services.Interfaces;

public interface IEnemyService
{
    #region Events
    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    event Action? OnChange;
    #endregion

    #region Properties
    /// <summary>
    /// Current enemy image path
    /// </summary>
    string EnemyImage { get; set; }

    /// <summary>
    /// Current enemy HP and max HP
    /// </summary>
    int HP { get; set; }
    int MaxHP { get; set; }

    /// <summary>
    /// Current boss time
    /// </summary>
    int CurrentBossTime { get; set; }

    #endregion
}