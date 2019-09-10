using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiddlewareExample.Entities;
using MiddlewareExample.Filters;
using MiddlewareExample.Middleware;
using MiddlewareExample.Validator;

namespace MiddlewareExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IValidator<Book>, BookValidator>();
            services.AddMvc(options => 
                    {
                        options.Filters.Add<BookFilter>();
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation();

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = (context) =>
            //    {
            //        var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();

            //        var result = new
            //        {
            //            Code = "100",
            //            Message = "Validation Errors",
            //            Errors = errors
            //        };

            //        return new BadRequestObjectResult(result);
            //    };
            //});
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMyMiddleWare();
            app.UseMvc();
        }
    }
}
