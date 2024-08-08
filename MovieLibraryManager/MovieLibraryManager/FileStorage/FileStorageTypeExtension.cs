namespace MovieLibraryManager.FileStorage;

public static class FileStorageTypeExtension
{
    public static string GetFileExtension(this FileStorageType fileType)
    => fileType == FileStorageType.JSON ? "json" : "txt";
}
