using TheMysteriousTower.Helpers;

namespace TheMysteriousTower.Services;

public class GameService
{
    public event Action? OnChange;

    public string BackgroundImage { get; set; } = "/images/backgrounds/bg1.png";
    public byte FloorNumber { get; set; } = 1;
    public byte CurrentEnemy { get; set; } = 1;
    public byte MaxEnemy { get; set; } = 7;

    public void IncrementFloor()
    {
        FloorNumber++;
        SetBackgroundImage();
        ResetEnemy();
        SetMaxEnemy();
        OnChange?.Invoke();
    }

    private void SetBackgroundImage()
    {
        BackgroundImage = ImageUtility.GetRandomImageFromFolder("images/backgrounds") ?? "";
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

    public void IncrementEnemy()
    {
        CurrentEnemy++;
        OnChange?.Invoke();
    }

    public void ResetEnemy()
    {
        CurrentEnemy = 1;
        OnChange?.Invoke();
    }

}
