using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Service;

namespace SaadiaInventorySystem
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
            services.AddControllers();
            services.AddMvc();
            services.AddTransient(typeof(LoginService));
            services.AddTransient(typeof(UserService));
            services.AddTransient(typeof(RoleService));
            services.AddTransient(typeof(CustomerService));
            services.AddTransient(typeof(InventoryService));
            services.AddTransient(typeof(OldPartService));
            services.AddTransient(typeof(QuotationService));
            services.AddTransient(typeof(InvoiceService));

            services.AddScoped(typeof(AppDbContext));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "api/{controller=Login}/{action=Get}");
                });
            });
        }
        
    }
}
