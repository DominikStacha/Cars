using System;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Migrations
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult CreateErrorResponse(this ControllerBase controller, string title,
            Exception exception)
        {
            return controller.BadRequest(new ErrorResponseModel
            {
                Title = title,
                Text = exception.Message,
                StackTrace = exception.StackTrace
            });
        }
    }
}