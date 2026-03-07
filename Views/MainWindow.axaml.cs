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
        vm.Album = audioFile.Tag.Album ?? "";
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

    private async void LoadAudioFolder_Click(object? sender, RoutedEventArgs e)
    {
        var folders = await StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select audio folder",
            AllowMultiple = false
        });

        if (folders.Count == 0)
            return;

        var folderPath = folders[0].TryGetLocalPath();
        if (string.IsNullOrEmpty(folderPath))
            return;

        var vm = (MainWindowViewModel)DataContext!;

        vm.FolderPath = folderPath;
        vm.IsFolderLoaded = true;
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

        using var stream = System.IO.File.OpenRead(path);
        vm.CoverImage = new Bitmap(stream);
    }

    private void SaveTags_Click(object? sender, RoutedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext!;

        if (vm.IsFolderLoaded)
        {
            string path = vm.FolderPath == null ? "" : vm.FolderPath;

            if (string.IsNullOrEmpty(path)) {
                return;
            }

            var files = Directory.GetFiles(path);

            foreach (var fPath in files)
            {
                try
                {
                    var audioFile = TagLib.File.Create(fPath);

                    if (ValidateField(vm.Title)) {
                        audioFile.Tag.Title= vm.Title;
                    }

                    if (ValidateField(vm.Author) && vm.Author != null) {
                        string? author = vm.Author.Replace(", ", ",");
                        string[] performers = vm.Author.Split(',');

                        if (performers.Length > 0) {
                            audioFile.Tag.Performers = performers;
                        }
                    }

                    if (ValidateField(vm.Album)) {
                        audioFile.Tag.Album = vm.Album;
                    }

                    if (ValidateField(vm.Description)) {
                        audioFile.Tag.Album = vm.Description;
                    }

                    audioFile.Save();
                }
                catch {
                    // skip files that TagLibSharp can't open
                }
            }
        }
        else
        {
            string path = vm.FilePath == null ? "" : vm.FilePath;

            if (string.IsNullOrEmpty(path)) {
                return;
            }

            var audioFile = TagLib.File.Create(path);

            if (ValidateField(vm.Title)) {
                audioFile.Tag.Title= vm.Title;
            }

            if (ValidateField(vm.Author) && vm.Author != null) {
                string? author = vm.Author.Replace(", ", ",");
                string[] performers = vm.Author.Split(',');

                if (performers.Length > 0) {
                    audioFile.Tag.Performers = performers;
                }
            }

            if (ValidateField(vm.Album)) {
                audioFile.Tag.Album = vm.Album;
            }

            if (ValidateField(vm.Description)) {
                audioFile.Tag.Album = vm.Description;
            }

            audioFile.Save();
        }
    }

    // Checks whether or not the given string is null, whitespace or empty space.
    private bool ValidateField(string? context) {
        if (string.IsNullOrEmpty(context)) {
            return false;
        }
        if (string.IsNullOrWhiteSpace(context)) {
            return false;
        }

        return true;
    }
}
