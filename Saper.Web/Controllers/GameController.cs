using Application.UseCases.Commands.AddGame;
using Application.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Saper.Web.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IMediator _mediator;

        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<GameInfoResponse>> AddGame([FromBody] AddGameCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid game data.");
            }

            var gameInfo = await _mediator.Send(command);
            _logger.LogInformation("пиривет рабаотаем");
            return Ok(gameInfo);
        }
    }
}
