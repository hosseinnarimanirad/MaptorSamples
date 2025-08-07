# 🗺️ Maptor Spatial Library - Sample WPF Application
 
<img width="888" height="526" alt="image" src="https://github.com/user-attachments/assets/3dd6db8d-7442-4dbd-97ed-68039ea07f6e" />


A demonstration of building a map-enabled application with minimal code using the Maptor spatial library.

## ✨ Features

- 🗺️ **Interactive Map Display** with multiple layer support
- 📏 **Measurement Tools** for distance and area
- ✏️ **Drawing Tools** (points, lines, polygons)
- 🔍 **GoTo Location** navigation
- 👁️ **Layer Management** (visibility control, ordering)
- 🔄 **Coordinate System Transformations**
- 🖱️ **Mouse Coordinate Tracking**

## 🚀 Getting Started

### Prerequisites
- .NET 8 or later
- Visual Studio 2019 or newer

### ⚙️ Installation
1. Clone the repository:

```bash
   git clone https://github.com/hosseinnarimanirad/Maptor.git
```
2. Open the solution file
3. Restore NuGet packages
4. Build and run the application

## 💻 Quick Guide to make your own map app
1. Create a WPF project (.NET 8 or higher)
2. Install following NuGet packages
```bash
   dotnet add package IRI.Maptor.Bas.SqlSpatialLoader
   dotnet add package IRI.Maptor.Jab.Controls
   ```
3. Rightclick all files under SqlServerTypes/x64 and SqlServerTypes/x86 folders and set the copy to output directory to 'Copy if newer'
4. Make sure to reference the 'Microsoft.SqlServer.Types' at Deploy/MicrosoftSqlServerTypes/v14 folder on this repositoy
6. Add namespace in the XAML
   ```xmlns:maptor="clr-namespace:IRI.Maptor.Jab.Controls.View;assembly=IRI.Maptor.Jab.Controls"```
   
7. Add map component on the XAML
   ```
    <maptor:MapViewer Grid.Row="1" Grid.Column="1" x:Name="map" BorderBrush="Black" BorderThickness="1"/>
   ```
8. Write the following code on window loaded:
 ```
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
 ```

9. Add functinalities using predefined commands in the MapApplicationPresenter
    ```xaml
    <StackPanel Grid.Column="1">
        <Border BorderBrush="Black" BorderThickness="1" Margin="2">
            <StackPanel Orientation="Horizontal" >
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding ClearText}" Command="{Binding ClearAllCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding FullExtentText}" Command="{Binding FullExtentCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding AddShapefileText}" Command="{Binding AddShapefileCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding MeasureLengthText}" Command="{Binding MeasureLengthCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding MeasureAreaText}" Command="{Binding MeasureAreaCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding DrawPointText}" Command="{Binding DrawPointCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding DrawPolylineText}" Command="{Binding DrawPolylineCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding DrawPolygonText}" Command="{Binding DrawPolygonCommand}"/>
                <Button Margin="4" Style="{StaticResource flatButtonPrimary}" Content="{Binding GoToText}" Command="{Binding GoToCommand}"/>
            </StackPanel>
        </Border> 
    </StackPanel>
    ```
