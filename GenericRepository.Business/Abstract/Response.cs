using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GenericRepository.Business.Abstract
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }

        //daha doğrusu her işlem için ayrı bir response (created,updated,..)
        //friendlymessqge yaz
        public Response<T> Ok(int totalCount, T data, string friendlyMessage = "Successfully")
        {
            //generic doğru
            return new Response<T>() { Data = data, Code = HttpStatusCode.OK, Message = "Success", FriendlyMessage = friendlyMessage, TotalCount = totalCount };
        }
        public Response<T> Error(int totalCount, T data, string message = "Error")
        {
            //generic doğru
            return new Response<T>() { Data = data, Code = HttpStatusCode.OK, Message = "Error", FriendlyMessage = message, RecordsTotal = totalCount, RecordsFiltered = totalCount };
        }
        public Response<T> Created(T data, string friendlyMessage = "Successfully")
        {
            return new Response<T>() { Data = data, Code = HttpStatusCode.Created, Message = "Created", FriendlyMessage = friendlyMessage };
        }

        public Response<T> NoContent(string friendlyMessage = "No Content")
        {
            //içerik boş
            return new Response<T>() { Code = HttpStatusCode.NoContent, Message = "No Content", FriendlyMessage = friendlyMessage };
        }

        public Response<T> NotFound(string friendlyMessage = "Not Found")
        {
            //bu sayfa yok
            return new Response<T>() { Code = HttpStatusCode.NotFound, Message = "Not Found", FriendlyMessage = friendlyMessage };
        }

        public Response<T> InternalServerError(string friendlyMessage = "Internal Server Error")
        {
            //birşey çalışmadı (create,delete olmadı gibi)
            //generic false
            return new Response<T>() { Code = HttpStatusCode.InternalServerError, Message = "Internal Server Error", FriendlyMessage = friendlyMessage };
        }

        public Response<T> ServiceUnavailable(string friendlyMessage = "Service Unavailable")
        {
            return new Response<T>() { Code = HttpStatusCode.ServiceUnavailable, Message = "Service Unavailable", FriendlyMessage = friendlyMessage };
        }

        public Response<T> Unauthorized(string friendlyMessage = "Unauthorized")
        {
            //token 
            return new Response<T>() { Code = HttpStatusCode.Unauthorized, Message = "Unauthorized", FriendlyMessage = friendlyMessage };
        }

        public Response<T> ModelStateValidation(List<string> errors, string friendlyMessage = "Bad Request")
        {
            //url not found   yanlış url 
            return new Response<T>() { Code = HttpStatusCode.BadRequest, Message = "Bad Request", FriendlyMessage = friendlyMessage, Errors = errors };
        }
        public Response<T> Conflict(string friendlyMessage = "Conflict")
        {
            //create unique name (external id)  (product ürün no == external id) tekrarlamamak için
            return new Response<T>() { Code = HttpStatusCode.Conflict, Message = "Conflict", FriendlyMessage = friendlyMessage };
        }
    }
}
