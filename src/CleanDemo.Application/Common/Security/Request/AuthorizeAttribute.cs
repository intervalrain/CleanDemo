namespace CleanDemo.Application.Common.Security.Request;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AuthorizeAttribute : Attribute
{
    public string? Permissions { get; set; }
    public string? Role { get; set; }
    public string? Policies { get; set; }
}

