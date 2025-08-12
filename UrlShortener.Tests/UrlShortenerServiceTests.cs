using Xunit;
using UrlShortener.Services;

namespace UrlShortener.Tests;

public class UrlShortenerServiceTests
{
    [Fact]
    public void Should_Shrink_And_Expand_Url()
    {
        var service = new UrlShortenerService();
        var longUrl = "https://google.com";

        var shortCode = service.ShortenUrl(longUrl);
        var resolved = service.GetOriginalUrl(shortCode);
        
        Assert.Equal(longUrl, resolved);
    }
    
    [Fact]
    public void Should_Return_Same_Code_For_Same_Url()
    {
        var service = new UrlShortenerService();
        var longUrl = "https://google.com";
        
        var code1 = service.ShortenUrl(longUrl);
        var code2 = service.ShortenUrl(longUrl);
        
        Assert.Equal(code1, code2);
    }
    
    public void Should_Return_Null_For_Unknown_ShortCode()
    {
        var service = new UrlShortenerService();
        var result = service.GetOriginalUrl("xxxxxx");
        
        Assert.Null(result);
    }
    
}