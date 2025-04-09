namespace TheMysteriousTower.Services;

using TheMysteriousTower.Services.Interfaces;

public class PlayerService : IPlayerService
{

    #region Events
    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    public event Action? OnChange;
    #endregion

    #region Properties
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    public int MaxExperience { get; set; } = 100;
    public int TotalDamage { get; set; } = 10;
    public int Gold { get; set; } = 0;
    #endregion

}
