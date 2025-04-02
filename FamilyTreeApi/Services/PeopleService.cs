using FamilyTreeApi.Data;
using FamilyTreeApi.Models;

namespace FamilyTreeApi.Services;

public class PeopleService
{
    private readonly IPersonRepository personRepository;

    public PeopleService(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }
    
    public IEnumerable<PersonDto> GetPeopleByTreeId(string treeId)
    {
        var people = personRepository.GetByTreeId(treeId);
        return people.Select(p => new PersonDto
        {
            Value = p.Id,
            Label = $"{p.GivenName} {p.Surname} {CalculateLifespan(p)}"
        });
    }

    private string CalculateLifespan(Person person)
    {
        if (person.BirthDate.HasValue && person.DeathDate.HasValue)
            return $"({person.BirthDate.Value.Year}-{person.DeathDate.Value.Year})";

        if (!person.BirthDate.HasValue && person.DeathDate.HasValue)
            return $"(-{person.DeathDate.Value.Year})";

        if (person.BirthDate.HasValue)
        {
            var age = DateTime.UtcNow.Year - person.BirthDate.Value.Year;
            return age >= 120 ? $"({person.BirthDate.Value.Year}-)" : "(Living)";
        }

        return "(Living)";
    }

}