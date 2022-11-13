using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ShoppingCartApp.Api.Models
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(string _message)
        {
            Message = _message;
        }
    }

    [DataContract]
    public class ApiResponse<T> : ApiResponse
    {
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public T Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(string _message) : base(_message)
        {
        }

        public ApiResponse(string _message, T _data) : this(_message)
        {
            Data = _data;
        }
    }

    [DataContract]
    public class ApiErrorResponse : ApiResponse<ErrorsDictionary>
    {
        public ApiErrorResponse()
        {
        }

        public ApiErrorResponse(string _message) : base(_message)
        {
        }

        public ApiErrorResponse(string _message, ModelStateDictionary _modelState) : base(_message, new ErrorsDictionary(_modelState))
        {
        }
    }

    [DataContract]
    public class ErrorsDictionary
    {
        [DataMember(Name = "errors")]
        public Dictionary<string, string[]> Errors { get; set; }

        public ErrorsDictionary(ModelStateDictionary _modelState)
        {
            Errors = _modelState.GetErrorsDictionary();
        }
    }
}
