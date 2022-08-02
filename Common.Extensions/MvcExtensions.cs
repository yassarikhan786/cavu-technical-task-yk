using Microsoft.AspNetCore.Mvc;

namespace Common.Extensions
{
    public static class MvcExtensions
    {
        public static int? StatusCode<T>(this ActionResult<T> actionResult)
        {
            int? statusCode = -1;
            var actualResult = actionResult.Result;
            if (actualResult is OkObjectResult okResult)
            {
                statusCode = okResult.StatusCode;
            }

            if (actualResult is NotFoundResult notFoundResult)
            {
                statusCode = notFoundResult.StatusCode;
            }
            return statusCode;
        }
    }
}
