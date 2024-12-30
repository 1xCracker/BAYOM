
using BAYOM.BL.Abstract;
using BAYOM.BL.Concrete.Token;
using BAYOM.BL.Mapping;
using BAYOM.BL.Services;
using BAYOM.DAL.Abstract;
using BAYOM.DAL.Concrete;
using BAYOM.DAL.Repository;
using BAYOM.EL.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ISignUp),typeof(SignUp));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IServices<>), typeof(Service<>));
builder.Services.AddScoped(typeof(ICategorySercive),typeof(CategoryService));


builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<ModelContext>();
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.MapFallbackToFile("/index.html");



app.Run();
