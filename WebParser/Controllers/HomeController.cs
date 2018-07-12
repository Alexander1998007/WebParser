using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebParser.Models;
using WebParser.ViewModels;

namespace WebParser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ParserContext _db;
        string line = null;

        public HomeController(ParserContext context)
        {
            this._db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DocumentViewModel dvm)
        {
            Document document = new Document { Word = dvm.Name };
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();

            var result = string.Empty;

            if (dvm.DocumentFile != null)
            {
                using (var reader = new StreamReader(dvm.DocumentFile.OpenReadStream()))
                {
                    result = reader.ReadToEnd();
                }

                foreach (string row in result.Split('.'))
                {
                    if (row.IndexOf(dvm.Name.ToString()) != -1)
                    {
                    DocumentString documentString = new DocumentString();
                    documentString.DocumentId = _db.Documents.Where(w => w.Word == dvm.Name).FirstOrDefault().Id;
                    documentString.Text = row;
                    _db.DocumentStrings.Add(documentString);
                    await _db.SaveChangesAsync();
                    }                  
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
