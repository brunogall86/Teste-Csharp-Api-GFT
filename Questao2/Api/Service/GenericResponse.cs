using System.Dynamic;
using System.Net;

namespace Questao2.Api.Service
{
    public class GenericResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public ExpandoObject Error { get; set; }        
    }
}