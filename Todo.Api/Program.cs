using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Validators.Commands;
using Todo.Infra;
using Todo.Infra.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
.AddNewtonsoftJson();

builder.Services.AddDbContext<SqlServerContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddTransient<TodoHandler , TodoHandler>();
builder.Services.AddTransient<CreateNewTaskCommandValidator , CreateNewTaskCommandValidator>();
builder.Services.AddTransient<UpdateTaskCommandValidator , UpdateTaskCommandValidator>();
builder.Services.AddTransient<ChangeToCompletedTaskCommandValidator , ChangeToCompletedTaskCommandValidator>();
builder.Services.AddTransient<ChangeToUncompletTaskCommandValidator , ChangeToUncompletTaskCommandValidator>();

builder.Services.AddAuthentication().AddJwtBearer( JwtBearerDefaults.AuthenticationScheme, x =>
{   x.Authority = "https://securetoken.google.com/todo-d5177";
    x.TokenValidationParameters = new TokenValidationParameters
    {  
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/todo-d5177",
        ValidateAudience = true,
        ValidAudience = "todo-d5177",
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
