namespace TheMysteriousTower.Helpers;

public static class ImageUtility{

    /// <summary>
    /// Gets a random image path from the specified directory
    /// </summary>
    /// <param name="folderPath">The full path to the folder containing images</param>
    /// <param name="searchPattern">Optional. The search pattern for image files (default: *.png;*.jpg;*.jpeg;*.gif)</param>
    /// <returns>The full path to a random image, or null if no images are found</returns>
    public static string? GetRandomImageFromFolder(string folderPath, string searchPattern = "*.png;*.jpg;*.jpeg;*.gif")
    {
        try
        {
            // Ensure the path starts with wwwroot if not already present
            if (!folderPath.StartsWith("wwwroot", StringComparison.OrdinalIgnoreCase))
            {
                folderPath = Path.Combine("wwwroot", folderPath);
            }

            if (!Directory.Exists(folderPath))
                return null;

            // Split the search pattern and get all matching files
            var patterns = searchPattern.Split(';');
            var imageFiles = patterns
                .SelectMany(pattern => Directory.GetFiles(folderPath, pattern))
                .ToList();

            if (imageFiles.Count == 0)
                return null;

            // Create a random number generator
            Random random = new();

            // Get a random index and return the corresponding file path
            int randomIndex = random.Next(0, imageFiles.Count);
            var fullPath = imageFiles[randomIndex];
            var webPath = fullPath.Replace("wwwroot/", "").Replace("wwwroot\\", "")
                                .Replace("\\", "/");
            return webPath.StartsWith('/') ? webPath : "/" + webPath;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
