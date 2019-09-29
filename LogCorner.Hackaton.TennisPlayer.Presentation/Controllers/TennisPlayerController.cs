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
        private readonly IGetPlayerUsesCase _getPlayersUsesCase;
        private readonly IDeletePlayerUsesCase _deletePlayerUsesCase;

        public TennisPlayerController(IGetPlayersUsesCase listPlayersUsesCase, IGetPlayerUsesCase getPlayersUsesCase, IDeletePlayerUsesCase deletePlayerUsesCase)
        {
            _listPlayersUsesCase = listPlayersUsesCase;
            _getPlayersUsesCase = getPlayersUsesCase;
            _deletePlayerUsesCase = deletePlayerUsesCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _listPlayersUsesCase.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _getPlayersUsesCase.Handle(new PlayerRequest(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deletePlayerUsesCase.Handle(new DeletePlayerCommand(id));

            return Ok();
        }
    }
}