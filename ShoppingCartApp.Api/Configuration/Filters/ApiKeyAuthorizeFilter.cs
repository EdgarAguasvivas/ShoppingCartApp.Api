using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingCartApp.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingCartApp.Api.Configuration.Filters
{
    public class ApiKeyAuthorizeFilter
    {
        public static string ApiKeyHeaderName = "ApiKey";

        private readonly IApiKeyService apiKeyService;

        public ApiKeyAuthorizeFilter(IApiKeyService apiKeyService)
        {
            this.apiKeyService = apiKeyService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var hasApiKeyHeader = request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyValue);

            if (hasApiKeyHeader)
            {
                if (apiKeyValue.Count != 0 && !string.IsNullOrWhiteSpace(apiKeyValue))
                {
                    
                        if (await apiKeyService.IsAuthorized(apiKeyValue))
                        {     
                            var apiKeyClaim = new Claim("apikey", apiKeyValue);
                            var principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { apiKeyClaim}, "ApiKey"));
                            context.HttpContext.User = principal;
                            return;
                        }   
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
