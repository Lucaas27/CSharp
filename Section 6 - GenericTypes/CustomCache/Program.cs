IDataDownloader dataDownloader = new SlowDataDownloader(new Cache<string, string>());

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

public class SlowDataDownloader : IDataDownloader
{
    private readonly ICache<string, string> _cache;
    public SlowDataDownloader(ICache<string, string> cache)
    {
        _cache = cache;
    }
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly

        return _cache.Fetch(resourceId, id =>
        {
            Thread.Sleep(1000);
            return $"Some data for {resourceId}";
        });

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