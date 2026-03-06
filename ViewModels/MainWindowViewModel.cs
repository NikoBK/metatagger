namespace metatagger.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string? FilePath { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? CoverPath { get; set; }
}
