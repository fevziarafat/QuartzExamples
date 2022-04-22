using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Quartz;
using Quartz.Core;
using Quartz.Impl;
using Quartz.Impl.Matchers;

using QuartzExamples.Jobs;
using QuartzExamples.Services;

using System.Collections.Specialized;

namespace QuartzExamples
{
    public class Startup
    {
        private IScheduler _quartzScheduler;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _quartzScheduler = ConfigureQuartz();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddTransient<SimpleJob>();
            services.AddSingleton(provider => _quartzScheduler);
        }

        private void OnShutdown()
        {
            if (!_quartzScheduler.IsShutdown)
            {
                _quartzScheduler.Shutdown();
            }
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
            _quartzScheduler.JobFactory = new AspnetCoreJobFactory(app.ApplicationServices);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        public IScheduler ConfigureQuartz()
        {
            NameValueCollection props = new NameValueCollection
            {
                {"quartz.serializer.type","binary" },
            };

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();
            scheduler.ListenerManager.AddTriggerListener(new TriggerListener());
              //  scheduler.ListenerManager.AddTriggerListener(new TriggerListener(), GroupMatcher<TriggerKey>.GroupEquals("quartz"));

            scheduler.ListenerManager.AddJobListener(new JobListener());
            scheduler.ListenerManager.AddSchedulerListener(new SchedulerListener());
            return scheduler;
        }
    }
}