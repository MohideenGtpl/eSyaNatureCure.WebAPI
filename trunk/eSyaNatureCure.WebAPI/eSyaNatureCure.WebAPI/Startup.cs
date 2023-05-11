using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNatureCure.DL.Repository;
using eSyaNatureCure.IF;
using eSyaNatureCure.WebAPI.Extention;
using eSyaNatureCure.WebAPI.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using DL_eSyaNatureCure = eSyaNatureCure.DL.Entities;
namespace eSyaNatureCure.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            DL_eSyaNatureCure.eSyaEnterprise._connString = Configuration.GetConnectionString("dbConn_eSyaEnterprise");

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpAuthAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ICommonMasterRepository, CommonMasterRepository>();
            services.AddScoped<IPackageMasterRepository, PackageMasterRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IBedMasterRepository, BedMasterRepository>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IDaywiseActivitiesRepository, DaywiseActivitiesRepository>();
            services.AddScoped<IPackagePriceRepository, PackagePriceRepository>();
            services.AddScoped<IRoomAmenitiesRepository, RoomAmenitiesRepository>();
            services.AddScoped<IFrontOfficeRepository, FrontOfficeRepository>();
            services.AddScoped<IGuestCheckInRepository, GuestCheckInRepository>();
            services.AddScoped<IGuestPaymentRepository, GuestPaymentRepository>();
            services.AddScoped<IGuestCheckOutRepository, GuestCheckOutRepository>();
            services.AddScoped<IGuestBookingRepository, GuestBookingRepository>();
            services.AddScoped<IPackageAmenitiesRepository, PackageAmenitiesRepository>();
            services.AddScoped<IPolicyTypeRepository, PolicyTypeRepository>();
            services.AddScoped<IPackageDiscountRepository, PackageDiscountRepository>();
            services.AddScoped<IRoomReservationRepository, RoomReservationRepository>();
            services.AddScoped<IMembershipRegistrationRepository, MembershipRegistrationRepository>();
            services.AddScoped<IServiceRateRepository, ServiceRateRepository>();
            services.AddScoped<ICommonMasterRepository, CommonMasterRepository>();
            services.AddScoped<IMemberShipCardRepository, MemberShipCardRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentClearanceRepository, DepartmentClearanceRepository>();
            services.AddScoped<IFirstConsultationRepository, FirstConsultationRepository>();
            services.AddScoped<IClinicalVitalsRepository, ClinicalVitalsRepository>();
            services.AddScoped<ILaundryRepository, LaundryRepository>();
            services.AddScoped<IPatientInfoRepository, PatientInfoRepository>();
            services.AddScoped<IDonorMasterRepository, DonorMasterRepository>();

            //for cross origin support
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            //For displying response same as model property case avoid camel case
            services
           .AddMvc()
           .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes
                    .MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

            app.UseMvc();
        }
    }
}
