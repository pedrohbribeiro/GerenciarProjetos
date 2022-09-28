using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using GerenciarProjetos.Exceptions;

namespace GerenciarProjetos.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool validado = (bool)(context.HttpContext.Items["Validado"] ?? false);
            if (!validado)
            {
                throw new UnauthorizedException("Token não informado ou inválido");
            }
        }
    }
}
