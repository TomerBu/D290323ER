using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options=>options.);
var app = builder.Build();

//app.Use((context, next) =>
//{
//	//code that runs on each request
//	var logger = context.RequestServices.GetService<ILogger<Program>>();

//	logger?.LogInformation("logged the request");
//	logger?.LogInformation($"URL: {context.Request.Path}");
//	logger?.LogInformation($"URL: {context.Request.Method}"); //GET/POST/DELETE

//	//dont forget to call the next function
//	return next(context);
//});


app.Use((context, next) =>
{
	//activly allow our client - all other clients are blocked:
	context.Response.Headers.AccessControlAllowOrigin = "http://localhost:5173";
	return next(context);
});
app.Use(async (context, next) =>
{
	//collect data on the incoming request: method path
	var sb = new StringBuilder();
	sb.Append(context.Request.Method)
	.Append(' ')
	.Append(context.Request.Path);

	//let the controller handle it
	await next();

	//check the status
	sb.Append(' ').Append(context.Response.StatusCode);

	//log:
	Console.WriteLine(sb);
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
