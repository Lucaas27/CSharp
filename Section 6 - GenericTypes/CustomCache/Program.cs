IDataDownloader dataDownloader = new DataDownloaderWithCache(new PrintDataDownloader(new SlowDataDownloader()), new Cache<string, string>());

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();



public interface IDataDownloader
{
    string DownloadData(string resourceId);
}


public class PrintDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    public PrintDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }
    public string DownloadData(string resourceId)
    {
        var data = _dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready!");
        return data;
    }
}

public class DataDownloaderWithCache : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly ICache<string, string> _cache;

    public DataDownloaderWithCache(IDataDownloader dataDownloader, ICache<string, string> cache)
    {
        _cache = cache;
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        return _cache.Fetch(resourceId, _dataDownloader.DownloadData);

    }
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class Cache<TKey, TValue> : ICache<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _cache = new();
    public TValue Fetch(TKey identifier, Func<TKey, TValue> fetchFunc)
    {
        if (!_cache.ContainsKey(identifier))
        {
            _cache[identifier] = fetchFunc(identifier);
        }

        return _cache[identifier];
    }
}

public interface ICache<TKey, TValue>
{
    TValue Fetch(TKey identifier, Func<TKey, TValue> fetchFunc);
}