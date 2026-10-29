using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class ListScreen : UserControl
{
    public ListScreen()
    {
        InitializeComponent();
        LoadItems();
    }

    private void LoadItems()
    {
        var items = ReadItemsFromFile();
        ItemsListBox.ItemsSource = items;
    }

    private List<CatalogItem> ReadItemsFromFile()
    {
        var items = new List<CatalogItem>();
        string filePath = GetDataFilePath();

        if (!File.Exists(filePath))
        {
            StatusText.Text = "Brak pliku danych: " + filePath;
            return items;
        }

        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
        foreach (string line in lines)
        {
            var item = ParseLine(line);
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }

    private CatalogItem? ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        string[] parts = line.Split(';');
        if (parts.Length < 3)
        {
            return null;
        }

        return new CatalogItem
        {
            Title = parts[0].Trim(),
            Year = parts[1].Trim(),
            Rating = parts[2].Trim()
        };
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

    private void OnDetailsClick(object? sender, RoutedEventArgs e)
    {
        var selectedItem = ItemsListBox.SelectedItem as CatalogItem;
        if (selectedItem == null)
        {
            StatusText.Text = "Wybierz pozycję z listy, aby przejść do szczegółów.";
            return;
        }

        OpenDetailsScreen(selectedItem);
    }

    private void OpenDetailsScreen(CatalogItem item)
    {
        // Ekran szczegółów zostanie podłączony w etapie eksperymentu
        StatusText.Text = $"Wybrano: {item.Title}";
    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {
        OpenAddScreen();
    }

    private void OpenAddScreen()
    {
        // Ekran formularza dodawania zostanie podłączony w etapie formularza
        StatusText.Text = "Przejście do formularza dodawania.";
    }
}
