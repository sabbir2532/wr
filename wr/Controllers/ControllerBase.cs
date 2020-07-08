using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using URF.Core.Abstractions;
using wr.entity;
using wr.entity.viewModels;
using wr.utility.StaticData;
using wr.Utility;
using wr.Utility;

namespace Inventory.Controllers
{
    //[SessionExpireFilter]
    public class ControllerBase : Controller
    {
        protected IHostingEnvironment Environment;
        protected IUnitOfWork UnitOfWork;
        protected static IConfiguration Configuration;
        protected vmSession _session;
        protected readonly IDataProtectionProvider _protectionProvider;
        protected IDataProtector _dataProtector;
        private ControllerBaseParamModel controllerBaseParamModel;

        protected ControllerBase(ControllerBaseParamModel controllerBaseParamModel)
        {
            Environment = controllerBaseParamModel.HostingEnvironment;
            UnitOfWork = controllerBaseParamModel.UnitOfWork;
            _session = controllerBaseParamModel.HttpContextAccessor.HttpContext.Session.GetComplexData<vmSession>("session");
            if (Configuration == null)
            {

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.ContentRootPath)
                    .AddJsonFile(ControllerStaticData.APPLICATION_JSON, true, true);
                Configuration = builder.Build();
            }
        }


    }
}