using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using URF.Core.Abstractions;
using wr.entity.viewModels;

namespace wr.Utility
{
    public class ControllerBaseParamModel
    {
        public ControllerBaseParamModel(  IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            HostingEnvironment = hostingEnvironment;
            HttpContextAccessor = httpContextAccessor;
            UnitOfWork = unitOfWork;
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }
        public IUnitOfWork UnitOfWork { get; }

    }
}