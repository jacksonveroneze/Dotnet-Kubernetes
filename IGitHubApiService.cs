using System.Threading.Tasks;
using DotnetRedis.Models;
using Newtonsoft.Json;
using Refit;

namespace DotnetRedis
{
    public interface IGitHubApiService
    {
        [Get("/users/{user}")]
        [Headers("User-Agent: Awesome Octocat App")]
        Task<UserResponse> GetUser(string user);
    }
}