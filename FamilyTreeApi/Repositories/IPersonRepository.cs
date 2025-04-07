using FamilyTreeApi.Models;

namespace FamilyTreeApi.Data;

public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    Person? GetById(Guid id);
    IEnumerable<Person> GetByTreeId(string treeId);
}