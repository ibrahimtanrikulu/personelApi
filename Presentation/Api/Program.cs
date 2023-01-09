using Application;
using Application.Mapping;
using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Fluent validators
builder.Services.AddApplicationService();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//iOS konteiner interface karşılıgı class cagırmak için
builder.Services.AddPersistenceService();
builder.Services.AddInfrastructureService();

//Apinin güvenliği
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
//(policy=>policy.WithOrigins("http://localhost:4200/", "https://localhost:4200/", "http://localhost:4200/admin/products").AllowAnyHeader().AllowAnyMethod() ));

//autoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Dosya yüklemek için
app.UseStaticFiles();

//Cors politikaları için
app.UseHttpLogging();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
