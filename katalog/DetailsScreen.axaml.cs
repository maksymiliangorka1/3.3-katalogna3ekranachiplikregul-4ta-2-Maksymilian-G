using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class DetailsScreen : UserControl
{
    public DetailsScreen()
    {
        InitializeComponent();
    }

    public DetailsScreen(CatalogItem item) : this()
    {
        DisplayItem(item);
    }

    private void DisplayItem(CatalogItem item)
    {
        TitleText.Text = item.Title;
        YearText.Text = item.Year;
        RatingText.Text = $"{item.Rating}/10";
    }

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.ShowListScreen();
    }
}
