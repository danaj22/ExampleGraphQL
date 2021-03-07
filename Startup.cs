using ExampleGraphQL.GraphQL;
using ExampleGraphQL.GraphQL.Types;
using ExampleGraphQL.Repositories;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL
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
            services.AddMvc();
            services.AddControllers();
            services.AddSingleton<PatientRepository>();
            services.AddSingleton<GraphQLSchema>();
            services.AddSingleton<GraphQLQuery>();
            services.AddSingleton<PatientType>();
            services.AddSingleton<ProductTypeEnumType>();
            services.AddGraphQL().AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseGraphQL<GraphQLSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            Data.InitialData.Initialize();
        }
    }
}
