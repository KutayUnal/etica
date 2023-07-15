using E_ticaret_Uygulaması.Identity;
using E_ticaret_Uygulaması.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret_Uygulaması.Controllers
{
    public class AccountController : Controller
    {
       // private UserManager<ApplicationUser> UserManager;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
           var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore=new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager= new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid) 
            {
                //kayıt işlemleri
                var user =new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UsurName;
                var result = userManager.Create(user,model.Password);


                if (result.Succeeded)
                {
                    //kayıt işlemi gerçekleşti kullanıcı oluştu role atayabılırız
                    if (RoleManager.RoleExists("user"))//rolu varmı kontrolu
                    {
                        userManager.AddToRole(user.Id, "user");//rol ataması
                    }
                    return RedirectToAction("Login", "Account");//rol ataması olmazsa login sayfasına gönderdım
                }
                else 
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                    //ModelState hataların oldugu yere yeni bi hata ekledim
                    //hata ismiregisteruser
                }
            }
            return View(model);
        }

        //Get:Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri

              var user= userManager.Find(model.UsurName, model.Password);


                if(user != null)
                {
                    //boş gelmediyse , var olan kullanıcıyı sisteme dahil edicez
                    //ApplicationCookie oluşturulup sisteme bırakılıcak

                    var authManeger=HttpContext.GetOwinContext().Authentication;

                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");

                    //oluşturulan user bi cooki üzerine atıyoruz
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    //kullanıcı kukinin kalıcı olup olmadıgını belırlıyıcek
                     authManeger.SignIn(authProperties, identityclaims);
                   
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");

                }
              
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı Bulunamadı..");

                }


            }
            return View(model);
        }

        public ActionResult Logout()
        {

            var authManager=HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            //oluşturdugumuz cokiyi sistemden silme

            return RedirectToAction("Index","Home");
        }
    }
}