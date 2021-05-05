using System.Text;
using GraphiQl;
using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using HotChocolate.AspNetCore;
using libongo.Authentication;
using libongo.GraphiQl.Config;
using libongo.Helpers;
using libongo.InMemory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace libongo {
    public class Startup {
        //public ContextServiceLocator _contextServiceLocator
        public Startup (IConfiguration configuration) {
            // _contextServiceLocator1=contextServiceLocator;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddCors ();
            services.AddControllers ().AddNewtonsoftJson (ops => ops.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddHttpContextAccessor ();
            // For Entity Framework
            services.AddDbContext<ApplicationDbContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("ConnStr")));

            // For Identity
            services.AddIdentity<ApplicationUser, IdentityRole> ()
                .AddEntityFrameworkStores<ApplicationDbContext> ()
                .AddDefaultTokenProviders ();

            services.AddSingleton<ContextServiceLocator> ();
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-3C90IMJ;Initial Catalog=NHLStats;Integrated Security=True"));
            services.AddTransient<IRepository, Repository> ();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter> ();
            services.AddSingleton<Query> ();
            services.AddSingleton<Mutation> ();
            new help ().ConfigureServices (services);
            var sp = services.BuildServiceProvider ();
            services.AddSingleton<ISchema> (new GraphiQlSchema (new FuncDependencyResolver (type => sp.GetService (type))));

            /*var key = Encoding.ASCII.GetBytes(Settings.Secret);
             services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
             */

            services.AddAuthentication (options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                // Adding Jwt Bearer
                .AddJwtBearer (options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters () {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration["JWT:Secret"]))
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            //app.UseHttpsRedirection();
            app.UseCors (conf => {
                conf.AllowAnyOrigin ()
                    .AllowAnyHeader ()
                    .AllowAnyMethod ();
            });

            /*
           
            app.UseRouting();
            app.UseGraphiQl("/osvaldo");
            app.UseRouting().UseEndpoints(routing => routing.MapControllers());

            app.UseAuthentication();
            app.UseAuthorization();
          
            //app.UseAuthorization();
            */
            app.UseGraphiQLServer (new GraphiQLOptions {
                GraphiQLPath = "/graphql",
                    GraphQLEndPoint = "/graphql"
            });
            app.UseRouting ();

            app.UseAuthentication ();
            app.UseAuthorization ();
            app.UseEndpoints (routing => routing.MapControllerRoute ("/graphql", pattern: "controller={graphql}"));

        }
    }
}