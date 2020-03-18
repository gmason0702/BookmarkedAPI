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
    public class BookDetailsViewController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<BookDetail> bookDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var responseTask = client.GetAsync("Book");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookDetail>>();
                    readTask.Wait();

                    bookDetail = readTask.Result;
                }
                else
                {
                    bookDetail = Enumerable.Empty<BookDetail>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(bookDetail);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookDetail book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/Book");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var postTask = client.PostAsJsonAsync<BookDetail>("book", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Servor Error.");
            return View(book);
        }



        public ActionResult Details(int id)
        {
            BookDetail book = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                string token = DeserializeToken();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var responseTask = client.PostAsJsonAsync("Book?Id=" + id.ToString(), id);
                //var responseTask = client.GetAsync("Book");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookDetail>();
                    readTask.Wait();

                    book = readTask.Result;

                }
            }
            return View(book);
        }
        //public ActionResult Details(BookDetail bookDetail)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44371/api/");
        //        string token = DeserializeToken();
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //        var putTask = client.PutAsJsonAsync<BookDetail>("book", bookDetail);
        //        putTask.Wait();

        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index", "BookView");
        //        }
        //    }
        //    return View(bookDetail);
        //}
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