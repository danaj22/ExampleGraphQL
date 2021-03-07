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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddSingleton<PatientRepository>();
            services.AddSingleton<GraphQLSchema>();
            services.AddSingleton<GraphQLQuery>();
            services.AddSingleton<PatientType>();
            services.AddSingleton<PatientGenderType>();
            services.AddGraphQL().AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseGraphQL<GraphQLSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            Data.InitialData.Initialize();
        }
    }
}
