using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HotChocolate.AspNetCore;
using HotChocolate;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;
using PostApi.GraphQL;
using PostApi.Controllers;
using PostApi.GraphQL.Data;
using Microsoft.AspNetCore.Identity;

namespace PostApi
{
    public class Startup
    {
        public readonly IConfiguration _config;
        public readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<PostContext>(options =>
                options.UseNpgsql(_config["ConnectionString:Postgres_Connection"]));
            
            services.AddScoped<PostsRepository>();

            services.AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseHttpsRedirection();

            /*app.UseGraphQL("/graphql")
                .UseGraphiQL("/graphql")
                .UsePlayground("/graphql");*/

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
