using FamilyTreeApi.Models;

namespace FamilyTreeApi.Data;

/// <summary>
/// Interface for the base repository 
/// </summary>
public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    Person? GetById(Guid id);
    IEnumerable<Person> GetByTreeId(string treeId);
}