# 🗺️ Maptor Spatial Library - Sample WPF Application

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-MIT-green)](https://github.com/hosseinnarimanirad/MaptorSamples/blob/main/LICENSE)

A demonstration of building map-enabled applications with minimal code using the Maptor spatial library.

![Maptor Sample Application Screenshot](https://github.com/user-attachments/assets/3dd6db8d-7442-4dbd-97ed-68039ea07f6e)

## ✨ Features

- 🗺️ **Interactive Map Display** with multiple layer support
- 📏 **Measurement Tools** for distance and area
- ✏️ **Drawing Tools** (points, lines, polygons)
- 🔍 **GoTo Location** navigation
- 👁️ **Layer Management** (visibility control, ordering)
- 🔄 **Coordinate System Transformations**
- 🖱️ **Mouse Coordinate Tracking**

## 🚀 Getting Started

### 📋 Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2019 or newer

### ⚙️ Installation
1. Clone the repository:
```bash
git clone https://github.com/hosseinnarimanirad/Maptor.git
```
2. Open the solution file
3. Restore NuGet packages
4. Build and run the application

## 🛠️ Building Your Own Map Application
1. Project Setup

Create a new WPF project targeting .NET 8 or higher.

2. Install Required Packages
```bash
dotnet add package IRI.Maptor.Bas.SqlSpatialLoader
dotnet add package IRI.Maptor.Jab.Controls
```
3. Configure SQL Server Types
   - Right-click all files under:
     - ```SqlServerTypes/x64```
     - ```SqlServerTypes/x86```
   - Set "Copy to Output Directory" to 'Copy if newer'
   - Reference Microsoft.SqlServer.Types from the ```Deploy/MicrosoftSqlServerTypes/v14``` folder

4. Add Map Control to Your XAML
```xaml
<Window ...
        xmlns:maptor="clr-namespace:IRI.Maptor.Jab.Controls.View;assembly=IRI.Maptor.Jab.Controls">    
    <Grid>
        <maptor:MapViewer x:Name="map" BorderBrush="Black" BorderThickness="1"/>
    </Grid>
</Window>
```

5. Initialize the Map (Code-Behind)
```csharp
private async void Window_Loaded(object sender, RoutedEventArgs e)
{
    // Initial Configs
    System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    SqlServerTypes.Utilities.LoadNativeAssembliesv14(Environment.CurrentDirectory);

    // Initialize map presenter (viewmodel)
    var presenter = new MapApplicationPresenter();
    await this.map.Register(presenter);
    presenter.Initialize(this);

    // Configure initial view
    presenter.SelectedMapProvider = TileMapProviderFactory.GoogleRoadMap;
    presenter.ZoomToExtent(BoundingBoxes.WebMercator_Africa, false, isNewExtent: true);
}
 ```
6. Add Map Tools (Optional)
```xaml
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
```

## 📜 License
This project is licensed under the MIT License.

