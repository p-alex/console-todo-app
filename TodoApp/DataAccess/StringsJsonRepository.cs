using System.Text.Json;
namespace TodoApp.DataAccess
{
    public class StringsJsonRepository : StringsRepository
    {
        protected override List<Data> TextToStrings<Data>(string fileContents)
        {
            return JsonSerializer.Deserialize<List<Data>>(fileContents);
        }
        protected override string StringsToText<Data>(List<Data> strings)
        {
            return JsonSerializer.Serialize(strings);
        }
    }
}
