using Assisment.Infrastructure.AuthHandeler;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Student;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : TypeFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyFilter))
    {
    }
}
