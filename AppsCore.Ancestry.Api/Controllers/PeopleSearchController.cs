using System;
using AppsCore.Ancestry.Api.Constants;
using AppsCore.Ancestry.Api.Model;
using AppsCore.Ancestry.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppsCore.Ancestry.Api.Controllers
{
    [Route("api/search")]
    public class PeopleSearchController : Controller
    {
        private IPeopleService _peopleService;
        public PeopleSearchController(IPeopleService service)
        {
            _peopleService = service;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "keyword")] string keyWord, [FromQuery(Name = "gender")] string gender)
        {
            if (string.IsNullOrEmpty(keyWord))
            {
                return new BadRequestObjectResult(new ResponseError(ErrorCode.KeywordRequired.ToString(), "Search keyword required"));
            }

            var request = new PeopleSearchRequest
            {
                Gender = (Gender?) (string.IsNullOrEmpty(gender) ? null : Enum.Parse(typeof(Gender), gender,true)),
                Keyword = keyWord
            };

            var result = _peopleService.SearchPeople(request);

            return Ok(result);
        }

        private IActionResult Ok<T>(T data)
        {
            return new OkObjectResult(data);
        }
    }
}
