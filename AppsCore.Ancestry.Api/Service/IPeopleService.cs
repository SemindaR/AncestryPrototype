using System.Collections.Generic;
using AppsCore.Ancestry.Api.Model;

namespace AppsCore.Ancestry.Api.Service
{
    public interface IPeopleService
    {
        List<PeopleSearchResponse> SearchPeople(PeopleSearchRequest request);
    }
}
