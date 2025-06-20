using CashFlow.API.Filters;
using CashFlow.API.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configura o filtro para que a API execute-o
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
//configura o banco de dados
//builder.Configuration.GetSection("ConnectionStrings");//Apaguei a class que tinhna o ConnectionStrings, pois n�o � necess�rio usar o appsettings.json para a conex�o com o banco de dados, j� que a conex�o � feita diretamente no CashFlowDbContext.cs
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
