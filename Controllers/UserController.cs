using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tenorchem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;

namespace tenorchem.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;    
        }

        [AllowAnonymous]
        public IActionResult Login(){
            var name = HttpContext.User.Identity.Name;

            // if jumped from other page(user does not logged in)
            var s = Request.Query["ReturnUrl"];
            if (s.Count != 0) {
                ViewData.Add("displayMessage","loginWarn");
            }
            else ViewData.Add("displayMessage","false");
            s = Request.Query["Pass"];
            if (s.Count !=0 ){
                ViewData["displayMessage"]="passWrongWarn";
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(int id, string passWord){
            // Select User from database.
            var user = await _context.Users.SingleOrDefaultAsync(m => (m.id == id));
            // if user exist, create authenticate in cookie.
            if (user.passWord == passWord)
            {
                if (user.isAdmin){
                    var claims = new List<Claim>
                    {
                        new Claim("Admin", "true"),
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Sid, user.id.ToString()),
                        new Claim("username",user.userName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Admin");
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.Authentication.SignInAsync("Cookies", claimsPrinciple,
                        new AuthenticationProperties
                        {
                            IsPersistent = true
                        }
                    );
                    return Redirect("/Home/index");
                }
                else{
                    var claims = new List<Claim>
                    {
                        new Claim("Normal", "true"),
                        new Claim(ClaimTypes.Name, "normal"),
                        new Claim(ClaimTypes.Sid, user.id.ToString()),
                        new Claim("username",user.userName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Normal");
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.Authentication.SignInAsync("Cookies", claimsPrinciple,
                        new AuthenticationProperties
                        {
                            IsPersistent = true
                        }
                    );
                    return Redirect("/Home/index");
                }

            }
            return Redirect("/User/Login?Pass=0");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout(){

            await HttpContext.Authentication.SignOutAsync("Cookies");
           return Redirect("/User/Login");
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userName,passWord,isAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userName,passWord,isAdmin")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
