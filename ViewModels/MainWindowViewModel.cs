using Avalonia.Media.Imaging;

namespace metatagger.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    // META DISPLAY DATA
    public string? _title;
    public string? Title {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string? _author;
    public string? Author {
        get => _author;
        set => SetProperty(ref _author, value);
    }

    public string? _album;
    public string? Album {
        get => _album;
        set => SetProperty(ref _album, value);
    }

    public string? _description;
    public string? Description {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string? _filePath;
    public string? FilePath {
        get => _filePath;
        set => SetProperty(ref _filePath, value);
    }

    private Bitmap? _coverImage;
    public Bitmap? CoverImage
    {
        get => _coverImage;
        set => SetProperty(ref _coverImage, value);
    }

    // FILE DATA
    public string? _coverPath;
    public string? CoverPath {
        get => _coverPath;
        set => SetProperty(ref _coverPath, value);
    }

    private string? _folderPath;
    public string? FolderPath
    {
        get => _folderPath;
        set => SetProperty(ref _folderPath, value);
    }

    // EDITOR PROPERTIES
    private bool _isFileLoaded;
    public bool IsFileLoaded {
        get => _isFileLoaded;
        set => SetProperty(ref _isFileLoaded, value);
    }

    public bool IsFolderLoaded = false;
}
