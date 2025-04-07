using Moq;
using FamilyTreeApi.Models;
using FamilyTreeApi.Data;
using FamilyTreeApi.Services;
using FamilyTreeApi.Exceptions;

namespace FamilyTreeApi.Tests.Services
{
    public class PeopleServiceTests
    {
        [Fact]
        public void GetPeopleByTreeId_ReturnsPeople()
        {
            var mockRepo = new Mock<IPersonRepository>();
            var mockId  = Guid.NewGuid();
                
            mockRepo.Setup(r => r.GetByTreeId("tree1")).Returns(new List<Person>
            {
                new Person { Id = mockId, GivenName = "John", Surname = "Doe", TreeId = "tree1" }
            });

            var service = new PeopleService(mockRepo.Object);
            var result = service.GetPeopleByTreeId("tree1");
            var firstElement = result.First();

            Assert.Single(result);
            Assert.Equal(mockId, firstElement.Value);
            Assert.Contains("John", firstElement.Label);
           
        }

        [Fact]
        public void GetPeopleByTreeId_ThrowsNotFound_WhenEmpty()
        {
            var mockRepo = new Mock<IPersonRepository>();
             mockRepo.Setup(r => r.GetByTreeId("tree2")).Returns(new List<Person>());

            var service = new PeopleService(mockRepo.Object);

            Assert.Throws<NotFoundException>(() => service.GetPeopleByTreeId("tree2"));
        }
    }
}