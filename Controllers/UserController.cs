using cty.Interfaces;
using cty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cty.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserModels _adminSvc;

        [HttpGet]
        [ActionName("listCustomer")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetCustomer()
        {
            var list = await _adminSvc.GetAllUserModel();
            return list;
        }
    }
}
