using System.Globalization;

namespace CashFlow.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        //cria uma lista com as languages suportadas pelo .NET
        var supportedLangueges = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureDefualt = new CultureInfo("en");

        //verifica se no header da request enviou a linguagem do user e se a language enviada é suportada pelo .NET
        if (!string.IsNullOrWhiteSpace(requestCulture)
            && supportedLangueges.Exists(l => l.Name.Equals(requestCulture)))
        {
            cultureDefualt = new CultureInfo(requestCulture); //sobreescreve caso seja valido
        }

        CultureInfo.CurrentCulture = cultureDefualt;
        CultureInfo.CurrentUICulture = cultureDefualt;

        await _next(context);
    }
}
