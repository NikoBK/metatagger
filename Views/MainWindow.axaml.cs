using System;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using metatagger.ViewModels;
using TagLib;

using System.IO;
using Avalonia.Media.Imaging;

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
            return;
        }

        var path = files[0].TryGetLocalPath();
        if (string.IsNullOrEmpty(path)) {
            return;
        }

        var vm = (MainWindowViewModel)DataContext!;

        vm.FilePath = path;

        var audioFile = TagLib.File.Create(path);

        vm.Title = audioFile.Tag.Title ?? "";
        vm.Author = audioFile.Tag.FirstPerformer ?? "";
        vm.Description = audioFile.Tag.Comment ?? "";

        if (audioFile.Tag.Pictures.Length > 0)
        {
            var picData = audioFile.Tag.Pictures[0].Data.Data;

            using var ms = new MemoryStream(picData);
            vm.CoverImage = new Bitmap(ms);
        }
        else
        {
            vm.CoverImage = null;
        }

        vm.IsFileLoaded = true;
    }

    private async void BrowseCover_Click(object? sender, RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select cover image",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Images")
                {
                    Patterns = new[] { "*.jpg", "*.png", "*.jpeg", "*.PNG" }
                }
            }
        });

        if (files.Count == 0) {
            return;
        }

        var path = files[0].TryGetLocalPath();
        if (string.IsNullOrEmpty(path)) {
            return;
        }

        var vm = (MainWindowViewModel)DataContext!;
        vm.CoverPath = path;

        var audioFile = TagLib.File.Create(path);




    }
}
