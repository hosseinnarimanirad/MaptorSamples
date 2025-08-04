using IRI.Jab.Common.TileServices;
using IRI.Sta.Common.Primitives;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstMapApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var presenter = new ViewModel.AppViewModel();

        await this.map.Register(presenter);

        presenter.Initialize(this);

        this.DataContext = presenter;

        presenter.ZoomToExtent(BoundingBoxes.IranWebMercatorBoundingBox, false, isNewExtent: true);

        presenter.SelectedMapProvider = TileMapProviderFactory.GoogleRoadMap;
    }
}