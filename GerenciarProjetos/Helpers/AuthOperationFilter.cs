using GerenciarProjetos.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GerenciarProjetos.Helpers
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext ctx)
        {
            if (ctx.ApiDescription.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                bool requerAutorizacao = ctx.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                    ctx.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

                if (requerAutorizacao)
                {
                    operation.Security.Add(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
                }
            }
        }
    }
}
