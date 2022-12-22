using WebAPI.Persistence;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding the db context so its usable
builder.Services.AddDbContext<KinderGardenContext>();

//Adding the service classes so i can use them in the controller, automatically add in the constructors
builder.Services.AddScoped<IChildService, ChildDbService>();
builder.Services.AddScoped<IToyService, ToyDbService>();


var app = builder.Build();

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