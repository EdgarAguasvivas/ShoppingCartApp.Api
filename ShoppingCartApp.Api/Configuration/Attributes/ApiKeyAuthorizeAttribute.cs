using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Api.Configuration.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Api.Configuration.Attributes
{
    public class ApiKeyAuthorizeAttribute : TypeFilterAttribute
    {
        public ApiKeyAuthorizeAttribute() : base(typeof(ApiKeyAuthorizeFilter))
        {
        }
    }
}
