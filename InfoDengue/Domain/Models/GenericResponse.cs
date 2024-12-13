using System.Dynamic;
using System.Net;

namespace InfoDisease.Domain.Models
{
    public class GenericResponse<T> where T : class
    {
        public HttpStatusCode HttpCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public ExpandoObject? Error { get; set; }
    }
}
