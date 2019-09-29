using LogCorner.Hackaton.TennisPlayer.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LogCorner.Hackaton.TennisPlayer.Presentation.Controllers
{
    [Route("api/tennis-player")]
    [ApiController]
    public class TennisPlayerController : ControllerBase
    {
        private readonly IGetPlayersUsesCase _listPlayersUsesCase;

        public TennisPlayerController(IGetPlayersUsesCase listPlayersUsesCase)
        {
            _listPlayersUsesCase = listPlayersUsesCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _listPlayersUsesCase.Handle();
            return Ok(result);
        }
    }
}