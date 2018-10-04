using System;
using System.Collections.Generic;
using System.Text;
using AppsCore.Ancestry.Api.Config;
using AppsCore.Ancestry.Api.Constants;
using AppsCore.Ancestry.Api.DataReadClient;
using AppsCore.Ancestry.Api.Model;
using AppsCore.Ancestry.Api.Service;
using NSubstitute;
using Xunit;

namespace AppsCore.Ancestry.Api.Test
{
    public class PeopleServiceTests
    {
        private readonly IAppConfiguration _configuration;
        private readonly IDataReadClient<AncestralData> _dataReadClient;
        private readonly IPeopleService _peopleService;
        public PeopleServiceTests()
        {
            _configuration = Substitute.For<IAppConfiguration>();
            _dataReadClient = Substitute.For<IDataReadClient<AncestralData>>();
            _peopleService = new PeopleService(_configuration, _dataReadClient);

            _dataReadClient.ReadJsonData(Arg.Any<string>()).Returns(GetAncestralData());
        }

        [Fact]
        public void SearchPeople_FilterByName_Success()
        {
            //Arrange
            var request = new PeopleSearchRequest
            {
                Gender = null,
                Keyword = "sam"
            };

            //Act
            var result = _peopleService.SearchPeople(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2,result.Count);
        }

        [Fact]
        public void SearchPeople_FilterByNameAndGenderMale_Success()
        {
            //Arrange
            var request = new PeopleSearchRequest
            {
                Gender = Gender.Male,
                Keyword = "sam"
            };

            //Act
            var result = _peopleService.SearchPeople(request);

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }


        private List<AncestralData> GetAncestralData()
        {
            return new List<AncestralData>
           {
               new AncestralData
               {
                   People = new List<Person>
                   {
                       new Person
                       {
                           Gender = "M",
                           Name = "Sam",
                           PlaceId = 1
                       },
                       new Person
                       {
                           Gender = "M",
                           Name = "James",
                           PlaceId = 1
                       },
                       new Person
                       {
                           Gender = "F",
                           Name = "Samantha",
                           PlaceId = 1
                       }
                   },
                   Places = new List<Place>
                   {
                       new Place
                       {
                           Id = 1,
                           Name = "Test Place"
                       },
                       new Place
                       {
                           Id = 2,
                           Name = "Test Place 2"
                       }
                   }
               }
           };
        }
    }
}
