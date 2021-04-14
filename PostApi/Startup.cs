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

namespace PostApi
{
    public class Startup
    {
        public readonly IConfiguration _config;
        [Obsolete]
        public readonly IHostingEnvironment _env;

        [Obsolete]
        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<PostContext>(opt => opt.UseInMemoryDatabase("PostList"));

            services.AddScoped<PostsRepository>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .Create());

            services.AddControllers();

        }

        [Obsolete]
        public void Configure(IApplicationBuilder app)
        {

            app.UseHttpsRedirection();

            app.UseWebSockets()
                .UseGraphQL("/graphql")
                .UseGraphiQL("/graphql")
                .UsePlayground("/graphql");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
