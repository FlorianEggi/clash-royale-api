using ClashRoyaleApiBackend.Models;
using ClashRoyaleApiBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleApiBackend.Controllers
{
    [ApiController]
    public class ClashRoyaleAPIController : ControllerBase
    {
        private RoyaleAPIService _apiService;


        public ClashRoyaleAPIController(RoyaleAPIService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("getMembers/{clanTag}")]
        public Task<Players> Get(string clanTag)
        {
            return _apiService.GetMembersOfClan(clanTag);
        }
    }
}
