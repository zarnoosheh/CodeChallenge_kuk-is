using Core.Dtos;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Helpers;

public class BaseController: Controller
{
    protected ActionResult<Result<T>> ApiResult<T>(Result<T> result)
    {
        if (result.IsSuccessful)
            return Ok(result);

        if (result.Errors.Contains(ErrorCodes.NotFound))
            return NotFound(result);

        return BadRequest(result);
    }

    protected ActionResult<Result> ApiResult(Result result)
    {
        if (result.IsSuccessful)
            return Ok(result);

        if (result.Errors.Contains(ErrorCodes.NotFound))
            return NotFound(result);

        return BadRequest(result);
    }
}