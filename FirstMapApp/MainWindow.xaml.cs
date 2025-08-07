using System.Windows;
using IRI.Maptor.Sta.Common.Primitives;
using IRI.Maptor.Jab.Common.TileServices;
using IRI.Maptor.Jab.Controls.Presenter;

namespace FirstMapApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

private async void Window_Loaded(object sender, RoutedEventArgs e)
{
    // load prerequisites 
    try
    {
        SqlServerTypes.Utilities.LoadNativeAssembliesv14(Environment.CurrentDirectory);
    }
    catch
    {
        MessageBox.Show("error!");
    }

    // config
    var presenter = new MapApplicationPresenter();

    await this.map.Register(presenter);

    presenter.Initialize(this);

    // set initial map and extent
    presenter.SelectedMapProvider = TileMapProviderFactory.GoogleRoadMap;

    presenter.ZoomToExtent(BoundingBoxes.WebMercator_Africa, false, isNewExtent: true);
}
}