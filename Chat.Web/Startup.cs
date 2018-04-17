using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Chat.Web.Startup))]

namespace Chat.Web
{
    /// <summary>
    /// Класс конфигурации
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
