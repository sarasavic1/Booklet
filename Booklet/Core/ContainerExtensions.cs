using Booklet.Application;
using Booklet.Application.Commands;
using Booklet.Application.Queries;
using Booklet.Implementation.Commands;
using Booklet.Implementation.Queries;
using Booklet.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklet.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateAuthorCommand, EfCreateAuthorCommand>();
            services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthorCommand>();


            services.AddTransient<ICreatePublisherCommand, EfCreatePublisherCommand>();
            services.AddTransient<IDeletePublisherCommand, EfDeletePublisherCommand>();

            services.AddTransient<ICreateGenreCommand, EfCreateGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();

            services.AddTransient<ICreateFormatCommand, EfCreateFormatCommand>();
            services.AddTransient<IDeleteFormatCommand, EfDeleteFormatCommand>();

            services.AddTransient<ICreateBookCommand, EfCreateBookCommand>();
            services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();
            services.AddTransient<IUpdateBookCommand, EfUpdateBookCommand>();
            services.AddTransient<IGetOneBookQuery, EfGetOneBookQuery>();
            services.AddTransient<IGetBooksQuery, EfGetBooksQuery>();

            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IGetOneOrderQuery, EfGetOneOrderQuery>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();

            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            services.AddTransient<ICreateWishlistCommand, EfCreateWishlistCommand>();
            services.AddTransient<IDeleteWishlistCommand, EfDeleteWishlistCommand>();

            services.AddTransient<ICreateCartCommand, EfCreateCartCommand>();
            services.AddTransient<IDeleteCartCommand, EfDeleteCartCommand>();
            services.AddTransient<IGetCartsQuery, EfGetCartsQuery>();

            services.AddTransient<IGetAuditLogsQuery, EfGetAuditLogsQuery>();

            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCaseCommand>();

            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<CreateAuthorValidator>();

            services.AddTransient<CreatePublisherValidator>();

            services.AddTransient<CreateGenreValidator>();

            services.AddTransient<CreateFormatValidator>();

            services.AddTransient<CreateBookValidator>();
            services.AddTransient<UpdateBookValidator>();

            services.AddTransient<CreateOrderValidator>();

            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UpdateUserValidator>();

            services.AddTransient<CreateWishlistValidator>();

            services.AddTransient<CreateCartValidator>();
            services.AddTransient<CreateUserUseCaseValidator>();
        
    }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);
                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
