using DP.DAL;
using DP.DataServices.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace BP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        UserDataService uds = new UserDataService();
        DPEntities db = new DPEntities();

        public ActionResult Login()
        {
            return View("RegisterAndLogin");
        }

        public ActionResult RegisterAndLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Isdeleted = false;
            user.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    if (!Roles.RoleExists("User"))
                        Roles.CreateRole("User");
                    // uds.Save(user);
                    user.Isdeleted = false;
                    user.CreatedDate = DateTime.Now;
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new { user.Email, user.FirstName, user.LastName, user.Isdeleted, user.CreatedDate });
                    Roles.AddUserToRole(user.UserName, "User");

                    WebSecurity.Login(user.UserName, user.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    return View("Error", e.Message);
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {
            if (WebSecurity.Login(user.UserName, user.Password))
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View("RegisterAndLogin");
            }
        }

        public ActionResult UserDetail()
        {
            var currentUser = db.Users.Find(WebSecurity.CurrentUserId);
            var roles = Roles.GetRolesForUser(currentUser.UserName);
            ViewBag.Role = roles[0];

            return View(currentUser);
        }

        [HttpPost]
        public JsonResult ChangePassword(string oldPassword, string newPasswaord)
        {
            var userName = WebSecurity.CurrentUserName;
            bool result;
            string message = "";
            try
            {
                result = WebSecurity.ChangePassword(userName,
                                                         oldPassword,
                                                         newPasswaord);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            if (result)
            {
                message = "Başarılı";
            }
            else
            {
                message = "Eski şifreyi hatalı girdiniz! Lütfen tekrar deneyin.";
            }

            return Json(message);
        }

    }
}
