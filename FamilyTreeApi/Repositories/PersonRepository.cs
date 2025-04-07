using System.Text.Json.Serialization;
using FamilyTreeApi.Models;

namespace FamilyTreeApi.Data;

using System.Text.Json;

public class PersonRepository : IPersonRepository
{
    private readonly List<Person> _people;

    public PersonRepository(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "people.json");
        var json = File.ReadAllText(path);

        _people = JsonSerializer.Deserialize<List<Person>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        }) ?? new List<Person>();
    }

    public IEnumerable<Person> GetAll()
    {
        return _people;
    }

    public Person? GetById(Guid id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Person> GetByTreeId(string treeId)
    {
        return _people.Where(p => p.TreeId == treeId);
    }
}
