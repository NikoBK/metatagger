using System;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using metatagger.ViewModels;
using TagLib;

namespace metatagger.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void LoadAudioFile_Click(object? sender, RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select audio file",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Audio files")
                {
                    Patterns = new[] { "*.mp3", "*.flac", "*.ogg", "*.m4a", "*.wav" }
                }
            }
        });

        if (files.Count == 0) {
            Console.WriteLine("Error reading!");
            return;
        }
        else {
            Console.WriteLine("Success!");
        }

        var path = files[0].TryGetLocalPath();
        if (string.IsNullOrEmpty(path))
            return;

        var vm = (MainWindowViewModel)DataContext!;

        vm.FilePath = path;

        var audioFile = TagLib.File.Create(path);

        vm.Title = audioFile.Tag.Title ?? "";
        vm.Author = audioFile.Tag.FirstPerformer ?? "";
        vm.Description = audioFile.Tag.Comment ?? "";

        vm.IsFileLoaded = true;
        Console.WriteLine($"fileloaded set to: {vm.IsFileLoaded}");
    }
}
