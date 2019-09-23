using System;
 using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Monster>("Index") == null)
            {
                HttpContext.Session.SetObjectAsJson("Index", new Monster());
            }
            ViewBag.DachiInfo = HttpContext.Session.GetObjectFromJson<Monster>("Index");

            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Monster myMonster = HttpContext.Session.GetObjectFromJson<Monster>("Index");
            myMonster.Feed();
            HttpContext.Session.SetObjectAsJson("Index",myMonster);
            return RedirectToAction("Index");
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Monster myMonster = HttpContext.Session.GetObjectFromJson<Monster>("Index");
            myMonster.Play();
            HttpContext.Session.SetObjectAsJson("Index",myMonster);
            return RedirectToAction("Indexr");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Monster myMonster = HttpContext.Session.GetObjectFromJson<Monster>("Index");
            myMonster.Work();
            HttpContext.Session.SetObjectAsJson("Index",myMonster);
            return RedirectToAction("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Monster myMonster = HttpContext.Session.GetObjectFromJson<Monster>("Index");
            myMonster.Sleep();
            HttpContext.Session.SetObjectAsJson("Index",myMonster);
            return RedirectToAction("Index");
        }
















        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
    }

// Somewhere in your namespace, outside other classes
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
