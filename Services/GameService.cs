using TheMysteriousTower.Helpers;

namespace TheMysteriousTower.Services;

public class GameService
{

    public GameService()
    {
    }
    public event Action? OnChange;

    public string BackgroundImage { get; set; } = "/images/backgrounds/bg1.png";
    public byte FloorNumber { get; set; } = 1;

    public void IncrementFloor()
    {
        FloorNumber++;
        SetBackgroundImage();
        OnChange?.Invoke();
    }

    private void SetBackgroundImage()
    {
        BackgroundImage = ImageUtility.GetRandomImageFromFolder("images/backgrounds") ?? "";
        OnChange?.Invoke();
    }

}
