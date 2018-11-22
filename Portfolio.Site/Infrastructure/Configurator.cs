using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Site.ContentSearch.Repositories;
using Sitecore.DependencyInjection;


namespace Portfolio.Site.Infrastructure
{
    public class Configurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllersInCurrentAssembly();
            serviceCollection.AddSingleton<IProjectsRepository, ProjectsRepository>();
            serviceCollection.AddSingleton<ISitecoreContext, SitecoreContext>();
        }
    }
}