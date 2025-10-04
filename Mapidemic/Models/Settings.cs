namespace Mapidemic.Models;

public class Settings
{
    public string Unit { get; set; }
    public AppTheme Theme { get; set; }
    public int PostalCode { get; set; }

    public Settings(string unit, AppTheme theme, int postalCode)
    {
        Unit = unit;
        Theme = theme;
        PostalCode = postalCode;
    }
}