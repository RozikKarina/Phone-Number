using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        // Remove all non-numeric characters
        string cleaned = Regex.Replace(phoneNumber, "[^0-9]", "");

        // Handle country code (NANP starts with '1' for 11-digit numbers)
        if (cleaned.Length == 11 && cleaned.StartsWith("1"))
        {
            cleaned = cleaned.Substring(1);
        }

        // Validate length
        if (cleaned.Length != 10)
        {
            throw new ArgumentException("Phone number must be 10 digits long after cleaning.");
        }

        // Validate area code and exchange code
        if (cleaned[0] < '2' || cleaned[3] < '2')
        {
            throw new ArgumentException("Invalid area or exchange code.");
        }

        return cleaned;
    }
}