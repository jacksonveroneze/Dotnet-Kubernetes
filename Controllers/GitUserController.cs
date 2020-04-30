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
            try
            {
                string valorJSON = _cacheRepository.GetString(user);

                if (!string.IsNullOrEmpty(valorJSON))
                {
                    _logger.LogInformation($"Response use cache.");

                    return Ok(valorJSON);
                }

                IGitHubApiService gitHubApiService = RestService.For<IGitHubApiService>("https://api.github.com/");

                UserResponse userResponse = await gitHubApiService.GetUser(user);

                valorJSON = JsonSerializer.Serialize(userResponse);

                _cacheRepository.SetString(user, valorJSON, 10);

                _logger.LogInformation($"Response use network.");

                return Ok(valorJSON);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}