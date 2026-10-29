namespace katalog;

public class CatalogItem
{
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Title} ({Year}) - Ocena: {Rating}/10";
    }
}
