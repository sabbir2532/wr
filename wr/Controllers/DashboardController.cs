using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;
using wr.entity;
using wr.entity.viewModels;
using wr.service.dbo;
using wr.utility;
using wr.utility.StaticData;
using wr.Utility;
using Microsoft.AspNetCore.Http.Features;

namespace Inventory.Controllers
{
    public class DashboardController : Controller
    {
        private object httpContext;

        public IActionResult Index()
        {

           
            return View();
        }
    }
}