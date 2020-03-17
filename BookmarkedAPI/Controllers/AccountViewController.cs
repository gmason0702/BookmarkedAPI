using Bookmarked.Data;
using BookmarkedAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookmarkedAPI.Controllers
{
    public class AccountViewController : Controller
    {
        // GET: AccountView
        //public ActionResult Index()
        //{
        //    return View();
        //}
     
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterBindingModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var postTask = client.PostAsJsonAsync<RegisterBindingModel>("Account/Register", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("login" );
                }
            }
            ModelState.AddModelError(string.Empty, "Servor Error.");
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(ClientLoginBindingModel model, string returnUrl)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.UserName),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/");
                var response = client.PostAsync("Token", content).Result;
                var token = response.Content.ReadAsStringAsync().Result;
                Response.Cookies.Add(CreateCookie(token));

                return RedirectToAction("Index", "BookView");
            }
        }
        public ActionResult LogOff()
        {
            if (Request.Cookies["UserToken"] != null)
            {
                Response.Cookies["UserToken"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Login", "BookView");
        }

        private HttpCookie CreateCookie(string token)
        {
            HttpCookie loginCookies = new HttpCookie("UserToken");
            loginCookies.Value = token;
            return loginCookies;
        }

        private string DeserializeToken()
        {
            var cookieValue = Request.Cookies["UserToken"];
            if (cookieValue != null)
            {
                var t = JsonConvert.DeserializeObject<Token>(cookieValue.Value);
                return t.Access_Token;

            }
            return null;
        }
    }


}