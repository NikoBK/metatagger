using Avalonia.Media.Imaging;

namespace metatagger.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string? _filePath;
    public string? FilePath {
        get => _filePath;
        set => SetProperty(ref _filePath, value);
    }

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

    public string? _description;
    public string? Description {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string? _coverPath;
    public string? CoverPath {
        get => _coverPath;
        set => SetProperty(ref _coverPath, value);
    }

    private Bitmap? _coverImage;
    public Bitmap? CoverImage
    {
        get => _coverImage;
        set => SetProperty(ref _coverImage, value);
    }

    private bool _isFileLoaded;
    public bool IsFileLoaded {
        get => _isFileLoaded;
        set => SetProperty(ref _isFileLoaded, value);
    }

    private bool _isFolderLoaded;
    public bool IsFolderLoaded {
        get => _isFolderLoaded;
        set => SetProperty(ref _isFolderLoaded, value);
    }
}
