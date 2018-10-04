using AppsCore.Ancestry.Api.Config;
using AppsCore.Ancestry.Api.DataReadClient;
using AppsCore.Ancestry.Api.Model;
using AppsCore.Ancestry.Api.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppsCore.Ancestry.Api
{
    public class Startup
    {
        private readonly IAppConfiguration _appConfiguration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appConfiguration = configuration.GetSection("AppConfiguration").Get<AppConfiguration>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_appConfiguration)
                .AddSingleton<IDataReadClient<AncestralData>, DataReadClient<AncestralData>>()
                .AddSingleton<IPeopleService, PeopleService>();
                
            services.AddMvc().AddJsonOptions(options =>
            {
                // we need this
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
