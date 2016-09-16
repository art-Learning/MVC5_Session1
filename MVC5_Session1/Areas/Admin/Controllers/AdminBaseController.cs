using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Session1.Areas.Admin.Controllers
{
    [Authorize(Roles = ROLE_ADMIN)]
    public abstract class AdminBaseController : Controller
    {
        private const string ROLE_ADMIN = "admin";
        private const string ROLE_USER = "user";
    }
}