using Microsoft.JSInterop;

namespace TheMysteriousTower.Helpers;

/// <summary>
/// Utility class for sound operations
/// </summary>
public static class SoundUtility
{
    private static IJSRuntime? _jsRuntime;

    public static void Initialize(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Plays the critical hit sound effect
    /// </summary>
    public static async Task PlayCritSound()
    {
        if (_jsRuntime == null)
        {
            Console.WriteLine("JSRuntime not initialized");
            return;
        }

        Console.WriteLine("Attempting to play critical hit sound...");
        await _jsRuntime.InvokeVoidAsync("soundPlayer.play", "/sounds/critical-hit.wav");
        Console.WriteLine("Critical hit sound triggered");
    }
}
