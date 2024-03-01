using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Utitmate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public WeatherForecastController(IRepositoryManager repository)
        {
            
            _repositoryManager = repository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<string>> Get()
        {
            
            return new string[] { "value1", "value2" };
        }
    }
}