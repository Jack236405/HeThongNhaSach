using HeThongNhaSach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongNhaSach.Controllers
{
    public class HomeController : Controller 
    {


        private readonly ILogger<HomeController> _logger;
        private readonly HeThongNhaSachContext _context;
    

        public HomeController(ILogger<HomeController> logger, HeThongNhaSachContext context)
        {
            _logger = logger;
            _context = context;
         
        }


        public static string NSetConnectionString = "Server=DESKTOP-3URUEMD;Database=#HeThongNhaSach;Trusted_Connection=True;MultipleActiveResultSets=true";

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Nhanvien model)
        {
            ViewData["Matkhauvuanhap"] = model.Matkhau;
            if (model.Matkhau == null || model.Matkhau.Contains(" "))
                return View();

       //     string matKhauMaHoa = model.Matkhau; //SHA1.ComputeHash(model.MatKhau);

            string matKhauMaHoa = SHA1.ComputeHash(model.Matkhau);
            var taiKhoan = _context.Nhanvien.Where(r => r.Manv == model.Manv && r.Matkhau == matKhauMaHoa).Include(p => p.MacvNavigation).SingleOrDefault();

            if (taiKhoan == null)
            {
                ViewData["Wrongpassword"] = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }
            else
            {
                NSetConnectionString = $"Server=DESKTOP-3URUEMD;Database=#HeThongNhaSach;User Id={taiKhoan.MacvNavigation.Taikhoan.Trim()};password={taiKhoan.MacvNavigation.Matkhau.Trim()};Trusted_Connection=False;MultipleActiveResultSets=true";

                if (!CheckConnection(NSetConnectionString))
                {
                    return RedirectToAction("Privacy", "Home");                                   
                }
                HttpContext.Session.SetString("manv", taiKhoan.MacvNavigation.Taikhoan.Trim());
                return RedirectToAction("Index", "Home");
            }
        }

        public bool CheckConnection(string conString)
        {           
            bool isValid = false;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                isValid = true;
            }
            catch (SqlException ex)
            {
                isValid = false;              
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return isValid;
        }
    }
}
