using GenericRepository.Business.Abstract;
using GenericRepository.Business.Concrete;
using GenericRepository.DataAccess;
using GenericRepository.DataAccess.Repositories;
using GenericRepository.Entities.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace GenericRepository.Api
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
            //services.addswaggerdocument();
            services.AddControllers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBranchServices, BranchServices>();
            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddDbContext<GenericDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<GenericDBContext>();
            //services.AddControllers();
            //services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<GenericDbContext>();
            //services.AddControllers();
            // services.AddTransient //her talebi farký algýlar yeni sonuç oluþtururu
            //services.AddSingleton    //request ne olursa olsun ayný sonuç oluþtur
            services.AddMvc().AddRazorPagesOptions(opt => opt.Conventions.AddPageRoute("/Login", ""));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,//Token deðerini kimlerin-hangi uygulamalarýn kullanýcýðýný belirler
                ValidateIssuer = true,//oluþturulan token deðerini kim daðýtmýþtýr
                ValidateLifetime = true,//Oluþturulan token deðerinin yaþam süresi
                ValidateIssuerSigningKey = true, //Üretilen token deðerinin uygulamamýza ait olup olmadýðý ile alakalý security key'i
                ValidIssuer = Configuration["Token:Issuer"], //
                ValidAudience = Configuration["Token:Audince"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Securitykey"])),
                ClockSkew = TimeSpan.Zero //Token süresinin uzatýlmasýný saðlar
            });
            services.AddRazorPages();

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //    app.UseHttpsRedirection();
            //    app.UseStaticFiles(new StaticFileOptions
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //        Path.Combine(env.ContentRootPath, "Pages")),
            //        RequestPath = "/Pages"
            //    });
            //    app.UseStaticFiles();
            //    app.UseRouting();
            //    app.UseOpenApi();
            //    app.UseSwaggerUi3();
            //    app.UseAuthorization();
            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllers();
            //        endpoints.MapRazorPages();
            //    });
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(env.ContentRootPath, "Pages")),
            //    RequestPath = "/Pages"
            //});
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
