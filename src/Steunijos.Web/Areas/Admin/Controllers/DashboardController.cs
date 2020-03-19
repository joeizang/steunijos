using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Steunijos.Web.Data;
using Steunijos.Web.Models;
using System.Linq;

namespace Steunijos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly SteunijosContext _db;
        private readonly UserManager<ApplicationUser> _users;
        private readonly RoleManager<ApplicationRole> _roles;


        public DashboardController(SteunijosContext db,
            UserManager<ApplicationUser> users,
            RoleManager<ApplicationRole> roles)
        {
            _db = db;
            _users = users;
            _roles = roles;
        }

        public async Task<ActionResult> Index()
        {
            var result = await GetRegisteredUsers();
            return View();
        }

        private async Task<List<ApplicationUser>> GetRegisteredUsers()
        {
            var users = await _users.Users.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return users;
        }
    }
}