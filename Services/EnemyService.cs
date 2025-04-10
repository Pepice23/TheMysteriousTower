using TheMysteriousTower.Services.Interfaces;

namespace TheMysteriousTower.Services;

public class EnemyService : IEnemyService
{
    #region Events

    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    public event Action? OnChange;

    #endregion

    #region Properties

    /// <summary>
    /// Current enemy image path
    /// </summary>
    public string EnemyImage { get; set; } = "/images/enemies/enemy1.png";

    /// <summary>
    /// Current enemy HP and max HP
    /// </summary>
    public int HP { get; set; } = 100;

    public int MaxHP { get; set; } = 100;

    /// <summary>
    /// Current boss time
    /// </summary>
    public int CurrentBossTime { get; set; } = 30;

    #endregion
}