namespace TheMysteriousTower.Helpers;

using System;
using System.Globalization;

public static class NumberUtility
{
    /// <summary>
    /// Formats a number with suffixes like K, M, B, T for thousands, millions, billions, trillions.
    /// </summary>
    /// <param name="value">The number to format</param>
    /// <param name="decimalPlaces">Maximum decimal places to show (default: 1)</param>
    /// <returns>Formatted string with appropriate suffix</returns>
    public static string FormatNumber(double value, int decimalPlaces = 1)
    {
        // Use invariant culture to ensure consistent formatting with period as decimal separator
        var culture = CultureInfo.InvariantCulture;
        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };

        if (value == 0)
            return "0";

        // Handle negative numbers
        var isNegative = value < 0;
        value = Math.Abs(value);

        // Determine the suffix index based on the magnitude
        var suffixIndex = 0;
        while (value >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            value /= 1000;
            suffixIndex++;
        }

        // Format with specified decimal places
        string formattedValue;

        if (decimalPlaces > 0)
        {
            // Format with decimal places
            formattedValue = value.ToString($"F{decimalPlaces}", culture);

            // Remove trailing zeros and decimal point if it's a whole number
            formattedValue = formattedValue.TrimEnd('0').TrimEnd('.');
        }
        else
        {
            // Format as integer
            formattedValue = Math.Round(value, 0).ToString(culture);
        }

        // Add the suffix and handle negative sign
        return (isNegative ? "-" : "") + formattedValue + suffixes[suffixIndex];
    }
}