using System;
using System.IO;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class AddScreen : UserControl
{
    public AddScreen()
    {
        InitializeComponent();
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        if (!ValidateInput(out string title, out int year, out int rating))
        {
            return;
        }

        SaveItem(title, year, rating);
        MainWindow.Instance?.ShowListScreen();
    }

    private bool ValidateInput(out string title, out int year, out int rating)
    {
        title = (TitleBox.Text ?? "").Trim();
        year = 0;
        rating = 0;

        if (string.IsNullOrWhiteSpace(title) || title.Contains(';'))
        {
            ValidationText.Text = "Podaj poprawny tytuł (bez średników).";
            return false;
        }

        if (!int.TryParse(YearBox.Text, out year) || year < 1800 || year > 2100)
        {
            ValidationText.Text = "Podaj poprawny rok (1800-2100).";
            return false;
        }

        if (!int.TryParse(RatingBox.Text, out rating) || rating < 1 || rating > 10)
        {
            ValidationText.Text = "Podaj poprawną ocenę w skali 1-10.";
            return false;
        }

        ValidationText.Text = string.Empty;
        return true;
    }

    private void SaveItem(string title, int year, int rating)
    {
        string filePath = GetDataFilePath();
        string directory = Path.GetDirectoryName(filePath) ?? "";
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string line = $"{title};{year};{rating}{Environment.NewLine}";
        File.AppendAllText(filePath, line, Encoding.UTF8);
    }

    private static string GetDataFilePath()
    {
        if (File.Exists("dane/pozycje.txt"))
        {
            return "dane/pozycje.txt";
        }

        if (File.Exists(Path.Combine("katalog", "dane", "pozycje.txt")))
        {
            return Path.Combine("katalog", "dane", "pozycje.txt");
        }

        return "dane/pozycje.txt";
    }

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.ShowListScreen();
    }
}
