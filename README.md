# 🗺️ Maptor Spatial Library - Sample WPF Application

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-MIT-green)](https://github.com/hosseinnarimanirad/MaptorSamples/blob/main/LICENSE)

A demonstration of building map-enabled applications with minimal code using the Maptor spatial library.

![Maptor Sample Application Screenshot](https://github.com/user-attachments/assets/e4c20caf-89a6-4b95-850e-31f30f8639cc)

## ✨ Features

- 🗺️ **Interactive Map Display** with multiple layer support
- 📏 **Measurement Tools** for distance and area
- ✏️ **Drawing Tools** (points, lines, polygons)
- 🔍 **GoTo Location** navigation
- 🔄 **Coordinate System Transformations**
- 🖱️ **Mouse Coordinate Tracking**

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2019 or newer

### Installation
1. Clone the repository:
```bash
git clone https://github.com/hosseinnarimanirad/Maptor.git
```
2. Open the solution file
3. Restore NuGet packages
4. Build and run the application

## 🛠️ Building Your Own Map Application
### Project Setup
📍 Create a new **WPF project** Visual Studio targeting .NET 8 (or higher).
 
<img width="525" height="308" alt="image" src="https://github.com/user-attachments/assets/d0e28161-e6b6-493d-83c0-02ea612ff88f" />

📍 Install the required Maptor NuGet package
```bash
dotnet add package IRI.Maptor.Jab.Controls 
```

📍 Reference the Maptor’s resource files in App.xaml
```
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.Slider.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.RadioButton.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.TabControl.xaml" />

            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Amber.xaml" />

            <ResourceDictionary Source="pack://application:,,,/IRI.Maptor.Jab.Common;component/Assets/Styles/ButtonStyles.xaml"/>
  
            <ResourceDictionary Source="pack://application:,,,/IRI.Maptor.Jab.Common;component/Assets/Shapes/Others.xaml"/>
            <ResourceDictionary Source="pack://application:,,,/IRI.Maptor.Jab.Common;component/Assets/IRI.Converters.xaml"/>
            <ResourceDictionary Source="pack://application:,,,/IRI.Maptor.Jab.Common;component/Assets/IRI.Fonts.xaml"/>
            <ResourceDictionary Source="pack://application:,,,/IRI.Maptor.Jab.Common;component/Assets/IRI.Colors.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### Prepare the map in XAML

📍 Define the Maptor namespace in your MainWindow.xaml (or the desired window)
```xaml
<Window ...
        xmlns:maptor="clr-namespace:IRI.Maptor.Jab.Controls.View;assembly=IRI.Maptor.Jab.Controls"> 
</Window>
```
📍 Add the MapViewer control along with any other necessary UI elements
```xaml
<maptor:MapViewer Grid.Row="1" x:Name="map" BorderBrush="Black" BorderThickness="1"/>
<maptor:MapInfoView Grid.Row="1" DataContext="{Binding }"/> 
```
### Configure the Map in C#
In the code-behind, configure the map and set up:
- Google Maps as the base layer
- An initial map extent for your view
This is done in the `Window.Loaded` event
```csharp
private async void Window_Loaded(object sender, RoutedEventArgs e)
{
    // initial setup
    System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

    // Initialize map presenter (viewmodel)
    var presenter = new MapApplicationPresenter();
    await this.map.Register(presenter);
    presenter.Initialize(this);

    // Configure initial view
    presenter.SelectedMapProvider = TileMapProviderFactory.GoogleRoadMap;
    presenter.ZoomToExtent(BoundingBoxes.WebMercator_Africa, false, isNewExtent: true);
}
 ```

### Add Core Functionalities

📍**Add shapefiles to map**  
Add a button and set its command to `AddShapefileCommand`

```xaml
<Button Content="Add Shapefile" Command="{Binding AddShapefileCommand}"/>
```

📍**Measure distance and area**  
Add buttons and set their commands to `MeasureLengthCommand` and `MeasureAreaCommand`.

```xaml
<StackPanel Orientation="Horizontal" >     
    <Button Content="Measure Length}" Command="{Binding MeasureLengthCommand}"/>
    <Button Content="Measure Area}" Command="{Binding MeasureAreaCommand}"/>
</StackPanel>
```

📍**Add drawings to map**  
To draw point/line/polygon add buttons and set their commands.
```xaml
<StackPanel Orientation="Horizontal" > 
    <Button Content="Draw Point" Command="{Binding DrawPointCommand}"/>
    <Button Content="Draw Polyline" Command="{Binding DrawPolylineCommand}"/>
    <Button Content="Draw Polygon" Command="{Binding DrawPolygonCommand}"/> 
</StackPanel>
```

📍**Use Go To dialog**  
To user Go To dialog all you need is to add a button and set its command.
```xaml
 <Button Content="Go To" Command="{Binding GoToCommand}"/>
```

📍**Show current mouse position**  
You can show the current mouse position in geographic (wgs84), utm, mercator, and several other spatial reference systems. To do that just add the `CoordinatePanelView` component and bind its `Position` property to the `map`:
```xaml
<maptor:CoordinatePanelView DataContext="{Binding CoordinatePanel}" Position="{Binding CurrentPoint, ElementName=map}"/>
```

## 📜 License
This project is licensed under the MIT License.

