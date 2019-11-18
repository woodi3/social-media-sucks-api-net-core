using System;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Controllers
{
    public class BaseController : Controller
    {
        protected ResultResponse<T> GetErrorResponse<T>(Exception ex, string message)
        {
            return new ResultResponse<T>
            {
                Exception = ex,
                Message = message,
                Success = false
            };
        }
    }
}
