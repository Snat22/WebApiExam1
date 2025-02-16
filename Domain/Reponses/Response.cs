using System.Net;

namespace Domain.Reponses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Description { get; set; } = new List<string>();
    public T? Data { get; set; }
    public Response(HttpStatusCode statusCode, string message, T data)
    {
        StatusCode = (int)statusCode;
        Description.Add(message);
        Data = data;
    }

    public Response(HttpStatusCode statusCode, List<string> messages,T data)
    {
     StatusCode = (int) statusCode;
     Description = messages;
     Data = data;   
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int) statusCode;
        Description.Add(message);
    }

    public Response(HttpStatusCode statusCode, List<string> messages)
    {
        StatusCode  = (int) statusCode;
        Description = messages;
    }
    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}
