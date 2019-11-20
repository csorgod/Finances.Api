using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using FluentValidation;

using Finances.Common.Data;
using Finances.Common.Helpers;
using Finances.Common.Interfaces;
using Finances.Core.Application;
using Finances.Core.Application.Interfaces;

using Finances.Core.Application.Authorization.Commands.SignIn;
using Finances.Core.Application.Authorization.Commands.CreateAccount;

using Finances.Core.Application.Incomings.Commands.CreateIncoming;
using Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId;

using Finances.Core.Application.Expenses.Queries.GetExpensesByUserId;

using Finances.Infrastructure.Infrastructure;
using Finances.Infrastructure.Persistence.DatabaseContext;
using FluentValidation.AspNetCore;
using System;

namespace Finances.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.TryAddSingleton<IResponseCompressionProvider, ResponseCompressionProvider>();

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<CryptoHelper, CryptoHelper>();
            services.AddSingleton<IJwtManager, JwtManager>();

            services.AddScoped<IFinancesDbContext, FinancesDbContext>();

            AddValidatorsInjection(services);
            ConfigureAutoMapper(services);
            
            services
                .Configure<AppSettings>(appSettingsSection)
                .AddAutoMapper()
                .AddMediatR()
                .AddCors()
                .AddMvc().ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddFluentValidation()
                .AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            const string applicationAssemblyName = "Finances.Core";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
            .FindValidatorsInAssembly(assembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSecret);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false
                    };
                });
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg => 
            {

            });

            configuration.AssertConfigurationIsValid();
        }

        private void AddValidatorsInjection(IServiceCollection services)
        {
            #region Accounts

            #endregion

            #region Authorization

            services.AddScoped<AbstractValidator<SignUp>, CreateAccountValidator>();
            services.AddScoped<AbstractValidator<SignIn>, SignInValidator>();

            #endregion

            #region Exceptions

            #endregion

            #region Expenses

            services.AddScoped<AbstractValidator<ExpensesByUserId>, GetExpensesByUserIdValidator>();

            #endregion

            #region Favored

            #endregion

            #region Incomings

            services.AddScoped<AbstractValidator<IncomingsByUserId>, GetIncomingsByUserIdValidator>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();
            //else
                app.UseHsts();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
