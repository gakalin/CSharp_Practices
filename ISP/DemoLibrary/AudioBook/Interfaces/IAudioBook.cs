namespace DemoLibrary
{
    public interface IAudioBook : ILibraryItem
    {
        int RuntimeInMinutes { get; set;  }
    }
}
