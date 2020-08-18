using LogStore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LogStore.Api.Base
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected new IActionResult Response(IResultResponse resultResponse)
        {
            return Ok(resultResponse);
        }

        protected new IActionResult Response<T>(IResultResponse<T> resultResponse)
        {
            return Ok(resultResponse);
        }
    }
}