namespace TodoApp.DataAccess
{
    public abstract class StringsRepository : IStringsRepository
    {
        public List<Todo> Read<Todo>(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return TextToStrings<Todo>(fileContents);
            }
            return new List<Todo>();
        }
        public void Write<T>(string filePath, List<T> data)
        {
            File.WriteAllText(filePath, StringsToText(data));
        }

        public void Delete(string filePath)
        {
            File.Delete(filePath);
        }
        protected abstract List<Data> TextToStrings<Data>(string fileContents);
        protected abstract string StringsToText<Data>(List<Data> strings);
    }
}
