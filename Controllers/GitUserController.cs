using System;
using System.Text.Json;
using System.Threading.Tasks;
using DotnetRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;

namespace DotnetRedis.Controllers
{
    [ApiController]
    [Route("github-user")]
    public class GitUserController : ControllerBase
    {
        private readonly ILogger<GitUserController> _logger;
        private readonly ICacheRepository _cacheRepository;

        public GitUserController(ILogger<GitUserController> logger, ICacheRepository cacheRepository)
        {
            _logger = logger;
            _cacheRepository = cacheRepository;
        }

        [HttpGet("{user}")]
        public async Task<IActionResult> Get(string user)
        {
            _logger.LogInformation($"Response use cache.");

            try
            {
                string valorJSON = _cacheRepository.GetString(user);

                if (valorJSON is null)
                {
                    IGitHubApiService gitHubApiService = RestService.For<IGitHubApiService>("https://api.github.com/");

                    UserResponse userResponse = await gitHubApiService.GetUser(user);

                    valorJSON = JsonSerializer.Serialize(userResponse);

                    _cacheRepository.SetString(user, valorJSON, 10);
                }

                return Ok(valorJSON);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
