# Maptor Spatial Library - Sample WPF Application
 
<img width="884" height="592" alt="image" src="https://github.com/user-attachments/assets/94218afd-f706-4cc8-b819-73f260d2b147" />

A demonstration of building a fully-functional GIS application with minimal code using the Maptor spatial library.

## Features

- 🗺️ **Interactive Map Display** with multiple layer support
- 📏 **Measurement Tools** for distance and area
- ✏️ **Drawing Tools** (points, lines, polygons)
- 🔍 **GoTo Location** navigation
- 👁️ **Layer Management** (visibility control, ordering)
- 🔄 **Coordinate System Transformations**
- 🖱️ **Mouse Coordinate Tracking**

## Getting Started

### Prerequisites
- .NET 8 or later
- Visual Studio 2019 or newer

### Installation
1. Clone the repository:

```bash
   git clone https://github.com/hosseinnarimanirad/Maptor.git
```
2. Open the solution file
3. Restore NuGet packages
4. Build and run the application

## Quick Guide to make your own map app
1. Create a WPF project (.NET 8 or higher)
2. install NuGet package ```dotnet add package IRI.Jab.Controls --version 2.1.0```
3. Create a ViewModel inherting from  MapApplicationPresenter
4. Write the followin code on window loaded:
   ```
       private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var presenter = new ViewModel.AppViewModel();

        await this.map.Register(presenter);

        presenter.Initialize(this);

        this.DataContext = presenter;

        presenter.ZoomToExtent(BoundingBoxes.IranWebMercatorBoundingBox, false, isNewExtent: true);

        presenter.SelectedMapProvider = TileMapProviderFactory.GoogleRoadMap;
    }
   ```
5. 
