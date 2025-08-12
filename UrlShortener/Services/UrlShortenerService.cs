using System.Text;

namespace UrlShortener.Services;

public class UrlShortenerService
{
    private readonly Dictionary<string, string> _shortToLong = new();
    private readonly Dictionary<string, string> _longToShort = new();
    private long _currentId = 0;
    private readonly object _lock = new();

    public string ShortenUrl(string longUrl)
    {
        if (_longToShort.TryGetValue(longUrl, out var existingShortCode))
        {
            return existingShortCode;
        }

        string shortCode;

        lock (_lock)
        {
            shortCode = Base62Encode(_currentId++);
        }

        _shortToLong[shortCode] = longUrl;
        _longToShort[longUrl] = shortCode;

        return shortCode;
    }

    public string? GetOriginalUrl(string shortCode)
    {
        return _shortToLong.TryGetValue(shortCode, out var longUrl)
            ? longUrl
            : null;
    }

    private static string Base62Encode(long number)
    {
        const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (number == 0)
            return chars[0].ToString();

        var sb = new StringBuilder();
        while (number > 0)
        {
            int remainder = (int)(number % 62);
            sb.Insert(0, chars[remainder]);
            number /= 62;
        }

        return sb.ToString().PadLeft(6, '0');
    }
}