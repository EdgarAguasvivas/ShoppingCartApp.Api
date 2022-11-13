using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Business.Services.Abstract
{
    public interface IApiKeyService
    {
        Task<bool> IsAuthorized(string apiKey);
    }
}
