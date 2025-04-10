namespace TheMysteriousTower.Services.Interfaces;

public interface IPlayerService
{
    #region Events

    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    event Action? OnChange;

    #endregion

    #region Properties

    int Level { get; set; }
    int Experience { get; set; }
    int MaxExperience { get; set; }
    int TotalDamage { get; set; }
    int Gold { get; set; }

    #endregion

    #region Methods

    void GainXP();

    #endregion
}