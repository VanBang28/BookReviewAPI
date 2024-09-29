using CloudinaryDotNet;
using BooksReview.API.Helpers;
using BooksReview.BL.Interfaces;
using BooksReview.BL.Services;
using BooksReview.Common.Models;
using BooksReview.Commons;
using BooksReview.DL.Database;
using BooksReview.DL.Helpers;
using BooksReview.DL.Interfaces;
using BooksReview.DL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Principal;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileDL, FileDL>();
builder.Services.AddScoped<IRegionDL, RegionDL>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookDL, BookDL>();
builder.Services.AddScoped<IBookListDL, BookListDL>();
builder.Services.AddScoped<IBookListItemDL, BookListItemDL>();
builder.Services.AddScoped<IReviewDL, ReviewDL>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserDL, UserDL>();
builder.Services.AddScoped<IUserTokenService, UserTokenService>();
builder.Services.AddScoped<IUserTokenDL, UserTokenDL>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// tạo các public api
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowAnonymousPolicy", policy =>
        policy.RequireAssertion(context => true));
});

// Cấu hình redis
//var redis = ConnectionMultiplexer.Connect("localhost");
//builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Bỏ bắn lỗi mặc định Atrribute
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Config respone để không chuyển hết về chữ thường
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSingleton(new Cloudinary(new Account(
    "dqywrcgrr",
    "511812445438653",
    "LaDWdP21mxTWyhZ2d5c08LkVYsk"
)));

// Get connectionString
DatabaseContext.connectionString = builder.Configuration.GetConnectionString("MySqlLocal");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.UseCors("corspolicy");
app.MapControllers();

app.Run();
