using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Native.API.Filters;
using Native.Application.Commands.CreateSneaker;
using Native.Application.Commands.CreateUser;
using Native.Application.Commands.DeleteSneaker;
using Native.Application.Commands.LoginUser;
using Native.Application.Commands.UpdateSneaker;
using Native.Application.Queries.GetAllSearchSneakers;
using Native.Application.Queries.GetAllSneakers;
using Native.Application.Queries.GetSneakerById;
using Native.Application.Queries.GetUser;
using Native.Application.Validators;
using Native.Application.ViewModels;
using Native.Core.Repositories;
using Native.Core.Services;
using Native.Infrastructure.Auth;
using Native.Infrastructure.Persistence;
using Native.Infrastructure.Persistence.Repositories;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Native.API;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("NativeCs");
        services.AddDbContext<NativeDbContext>(options => options.UseSqlServer(connectionString));

        //add Repositories
        services.AddScoped<ISneakerRepository, SneakerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        //add Services
        services.AddScoped<IAuthService, AuthService>();

        //add Controllers
        services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
        
        //add Validator
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

        //add Commands Handlers
        services.AddScoped<IRequestHandler<CreateSneakerCommand, int>, CreateSneakerCommandHandler>();
        services.AddScoped<IRequestHandler<CreateUserCommand, int>, CreateUserCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteSneakerCommand, Unit>, DeleteSneakerCommandHandler>();
        services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserViewModel>, LoginUserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateSneakerCommand, Unit>, UpdateSneakerCommandHandler>();

        //add Queries Handlers
        services.AddScoped<IRequestHandler<GetAllSneakersQuery, List<SneakerDetailsViewModel>>, GetAllSneakersQueryHandler>();        
        services.AddScoped<IRequestHandler<GetAllSearchSneakersQuery, List<SneakerDetailsViewModel>>, GetAllSearchSneakersQueryHandler>();
        services.AddScoped<IRequestHandler<GetSneakerByIdQuery, SneakerDetailsViewModel>, GetSneakerByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetUserQuery, UserViewModel>, GetUserQueryHandler>();

        //add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Native.API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header with Bearer."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
             {
                {
                    new OpenApiSecurityScheme 
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    System.Array.Empty<string>()
                }
             });
        });

        services
          .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,

                  ValidIssuer = Configuration["Jwt:Issuer"],
                  ValidAudience = Configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
              };
          });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Native.API v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}