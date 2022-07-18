using Autofac;
using Autofac.Extensions.DependencyInjection;
using EnterSellSave.Common.AutoFacManager;
using EnterSellSave.Common.BaseOptions;
using EnterSellSave.SqlData;
using EnterSellSave.SqlData.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 注入Jwt的服务

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
        byte[] secBytes = Encoding.UTF8.GetBytes(jwtOptions.SecKey);
        var symmetricSecurityKey = new SymmetricSecurityKey(secBytes);
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symmetricSecurityKey
        };
    });

#endregion

#region 让swagger 上可以 增加 Autorization

builder.Services.AddSwaggerGen(c =>
{
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);
});

#endregion

#region 注入SQLServer 服务

builder.Services.AddDbContext<MirDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("default");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new ArgumentException("配置信息错误,请联系管理员核查~~~");
    }

    opt.UseSqlServer(connectionString);
    
});

#endregion

#region  注入 Identity 的服务

builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<User>(opt =>
{
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});

IdentityBuilder identityBuilder = new IdentityBuilder(typeof(User), typeof(Role), builder.Services);
identityBuilder.AddEntityFrameworkStores<MirDbContext>().
    AddDefaultTokenProviders().
    AddRoleManager<RoleManager<Role>>().
    AddUserManager<UserManager<User>>();

#endregion

#region 注入Serilog服务

Log.Logger = new LoggerConfiguration().
    MinimumLevel.Information().
    WriteTo.File($"{AppContext.BaseDirectory}00_Logs\\log.log", rollingInterval: RollingInterval.Day)
             .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
          loggingBuilder.AddSerilog(dispose: true));

#endregion

#region AutoFac 反射注入

// 替换内置的ServiceProviderFactory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// 自动注入服务
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    AutofacExtend.UseCustomConfigureContainer(containerBuilder);
});

#endregion

#region 配置文件流大小

// 限制托管服务器大小1G
builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = (long)1024 * 1024 * 1024;
    x.ValueCountLimit = int.MaxValue;
});

builder.Services.Configure<KestrelServerOptions>(x =>
{
    x.Limits.MaxRequestBodySize = (long)1024 * 1024 * 1024;
});

#endregion

//builder.Services.AddAutoMapper(opt=>opt.AddProfile());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 启动身份验证中间件
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
