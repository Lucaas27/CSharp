
namespace MovieLibraryManager.FileStorage;

public class FileMetadata(FileStorageType fileType, string fileName)
{
    public string FileName { get; } = fileName;
    public FileStorageType FileType { get; } = fileType;

    public string FilePath() => $"{FileName}.{FileType.GetFileExtension()}";


}
