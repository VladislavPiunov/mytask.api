using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mytask.API.Model;

namespace Mytask.API.Controllers;

[ApiController]
[Route("api")]
public class StageController : ControllerBase
{
    private readonly IBoardRepository _boardRepository;
    private readonly IStageRepository _stageRepository;

    public StageController(
        IBoardRepository boardRepository,
        IStageRepository stageRepository)
    {
        _boardRepository = boardRepository;
        _stageRepository = stageRepository;
    }

    [Route("stage/{boardId}")]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Stage>>> GetStagesAsync(string boardId)
    {
        var boardStages = _boardRepository.GetBoardByIdAsync(boardId).Result.Stages;

        return await _stageRepository.GetStagesAsync(boardStages);
    }

    [Route("stage")]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Stage>> CreateStageAsync([FromBody] Stage stage)
        => await _stageRepository.CreateStageAsync(stage);

    [Route("stage")]
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Stage>> UpdateStageAsync([FromBody] Stage stage)
        => await _stageRepository.UpdateStageAsync(stage);

    [Route("stage/{id}")]
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<bool>> DeleteStageAsync(string id)
        => await _stageRepository.DeleteStageAsync(id);
    
}   