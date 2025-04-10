using TheMysteriousTower.Services.Interfaces;

namespace TheMysteriousTower.Services;

public class PlayerService(IGameService gameService) : IPlayerService
{
    private readonly Random _random = new();

    #region Events

    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    public event Action? OnChange;

    #endregion

    #region Properties

    public int Level { get; set; } = 1;
    public int Experience { get; set; }
    public int MaxExperience { get; set; } = 100;
    public int TotalDamage { get; set; } = 10;
    public int Gold { get; set; } = 0;

    #endregion

    /// <summary>
    /// Calculates XP gained from defeating an enemy based on player's current MaxExperience
    /// </summary>
    /// <param name="isBoss">Whether the defeated enemy is a boss</param>
    /// <returns>Amount of XP gained</returns>
    private int CalculateEnemyXp(bool isBoss)
    {
        // Boss gives 20% of max XP
        if (isBoss) return (int)(MaxExperience * 0.2);

        // Calculate the base XP per regular enemy
        // Total regular enemies = MaxEnemy - 1 (excluding boss)
        var regularEnemies = gameService.MaxEnemy - 1;
        // Each regular enemy gives a portion of the remaining 80% XP
        var baseXp = (int)(MaxExperience * 0.8 / regularEnemies);

        // Add some variance (-20% to +20%)
        var varianceFactor = 0.8 + _random.NextDouble() * 0.4; // 0.8 to 1.2

        return (int)(baseXp * varianceFactor);
    }

    /// <summary>
    /// Adds experience to the player and handles level-up if necessary
    /// </summary>
    /// <param name="amount">Amount of experience to add</param>
    private void AddExperience(int amount)
    {
        Experience += amount;

        // Check for level up
        if (Experience >= MaxExperience) LevelUp();

        OnChange?.Invoke();
    }

    /// <summary>
    /// Handles player level-up logic
    /// </summary>
    private void LevelUp()
    {
        Level++;
        Experience -= MaxExperience;
        // Increase max experience for next level (gets progressively harder)
        MaxExperience = (int)(MaxExperience * 1.15);

        OnChange?.Invoke();
    }

    public void GainXP()
    {
        var isBoss = gameService.CurrentEnemy == gameService.MaxEnemy;
        var gainedXP = CalculateEnemyXp(isBoss);
        AddExperience(gainedXP);
    }
}