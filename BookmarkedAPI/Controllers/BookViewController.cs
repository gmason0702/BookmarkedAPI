using Bookmarked.Models;
using BookmarkedAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookmarkedAPI.Controllers
{
    public class BookViewController : Controller
    {
        // GET: BookView
        public ActionResult Index()
        {
            IEnumerable<BookListItem> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                var responseTask = client.GetAsync("Book");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookListItem>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {
                    books = Enumerable.Empty<BookListItem>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(books);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookListItem book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/Book");

                var postTask = client.PostAsJsonAsync<BookListItem>("book", book);
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
  

        public ActionResult Edit(int id)
        {
            BookListItem book= null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");
                var responseTask = client.PostAsJsonAsync("Book?id=" + id.ToString(), id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookListItem>();
                    readTask.Wait();

                    book = readTask.Result;

                }
            }
            return View(book);

        }
        [HttpPost]
        public ActionResult Edit(BookListItem book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/Book");

                var putTask = client.PutAsJsonAsync<BookListItem>("book", book);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        public ActionResult Delete (int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44371/api/");

                var deleteTask = client.DeleteAsync("Book?bookId=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}