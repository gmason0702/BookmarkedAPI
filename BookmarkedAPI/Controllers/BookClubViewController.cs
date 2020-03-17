using Bookmarked.Data;
using Bookmarked.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookmarkedAPI.Controllers
{
    public class BookClubViewController : Controller
    {
        // GET: BookClubView
        public ActionResult Index()
        {
            IEnumerable<BookClubListItem> bookClubs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var responseTask = client.GetAsync("BookClub");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookClubListItem>>();
                    readTask.Wait();

                    bookClubs = readTask.Result;
                }
                else
                {
                    bookClubs = Enumerable.Empty<BookClubListItem>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(bookClubs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookClubListItem bookClub)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/BookClub");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var postTask = client.PostAsJsonAsync<BookClubListItem>("bookClub", bookClub);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Servor Error.");
            return View(bookClub);
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