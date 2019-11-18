using System;
namespace SocialMediaSucks2.Models
{
    public class ResultResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Item { get; set; }

        public Exception Exception { get; set; }

        public string Token { get; set; }
    }
}
