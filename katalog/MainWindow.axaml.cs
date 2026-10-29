using Avalonia.Controls;

namespace katalog;

public partial class MainWindow : Window
{
    public static MainWindow? Instance { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        ShowListScreen();
    }

    public void ShowListScreen()
    {
        Content = new ListScreen();
    }

    public void SetScreen(Control screen)
    {
        Content = screen;
    }
}