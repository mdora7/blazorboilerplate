using BlazorBoilerplate.Shared.Interfaces;
using BlazorBoilerplate.Shared.Models;
using BlazorBoilerplate.Theme.Material.Demo.Shared.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;

namespace BlazorBoilerplate.Theme.Material.Demo
{
    public class Module : BaseModule
    {
        public override string Description => "BlazorBoilerplate demo";

        public override int Order => 2;

        private void Init(IServiceCollection services)
        {
            services.AddSingleton<IDynamicComponent, NavMenu>();
            services.AddSingleton<IDynamicComponent, Footer>();
            services.AddSingleton<IDynamicComponent, DrawerFooter>();
            services.AddSingleton<IDynamicComponent, TopRightBarSection>();

            #region Local browser storage
            services.AddBlazoredLocalStorage(conf=>
            {
                conf.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                conf.JsonSerializerOptions.WriteIndented = false;
            });
            #endregion
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            Init(services);
        }

        public override void ConfigureWebAssemblyServices(IServiceCollection services)
        {
            Init(services);
        }
    }
}
