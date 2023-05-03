using App.DataAccess.Repositories.Abstractions;
using App.DataAccess.Repositories.Implementations;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("App.DataAccess"));
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, AppDbContext>();

builder.Services.AddTransient<IReadOnlyRepository, ReadOnlyRepository>();
builder.Services.AddTransient<IWriteOnlyRepository, WriteOnlyRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        const int statusCode = StatusCodes.Status500InternalServerError;
        var message = "Something went wrong";

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "text/plain";

        await context.Response.WriteAsync($"Status Code: {statusCode}; {message}");
    });
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
