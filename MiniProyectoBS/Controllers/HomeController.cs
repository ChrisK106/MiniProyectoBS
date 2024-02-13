using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using MiniProyecto.Models;

namespace MiniProyecto.Controllers
{
    public class HomeController : Controller
    { 
        private readonly string BaseUrl = "https://jsonplaceholder.typicode.com/";

        public async Task<ActionResult> Index()
        {
            List<Album> AlbumInfo = new List<Album>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("albums");

                if (Res.IsSuccessStatusCode)
                {
                    var AlbumResponse = Res.Content.ReadAsStringAsync().Result;

                    AlbumInfo = JsonConvert.DeserializeObject<List<Album>>(AlbumResponse);
                }

                return View(AlbumInfo);
            }
        }

        public async Task<ActionResult> PhotoTable(int id)
        {
            List<Photo> PhotoInfo = new List<Photo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("photos?albumId=" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var PhotoResponse = Res.Content.ReadAsStringAsync().Result;

                    PhotoInfo = JsonConvert.DeserializeObject<List<Photo>>(PhotoResponse);
                }

                return PartialView("_PhotoTable", PhotoInfo);
            }
        }

        public async Task<ActionResult> CommentList(int id)
        {
            List<Comment> CommentInfo = new List<Comment>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("comments?postId=" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var CommentResponse = Res.Content.ReadAsStringAsync().Result;

                    CommentInfo = JsonConvert.DeserializeObject<List<Comment>>(CommentResponse);
                }

                return PartialView("_CommentList", CommentInfo);
            }
        }
    }
}