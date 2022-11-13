using ShoppingCartApp.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Business.Services.Concrete
{
    class ApiKeyService : IApiKeyService
    {
        public Task<bool> IsAuthorized(string apiKey)
        {
            if (apiKey == Security.Security.ApiKey)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}