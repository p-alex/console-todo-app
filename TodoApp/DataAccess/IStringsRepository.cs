public interface IStringsRepository
{
    List<Data> Read<Data>(string filePath);
    void Write<Data>(string filePath, List<Data> strings);
    void Delete(string filePath);
}
