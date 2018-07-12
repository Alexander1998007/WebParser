using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        string word = String.Empty;

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
            word = dvm.Name;
            var result = string.Empty;

            // Add the document
            Document document = new Document { Word = word };
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();

            if (dvm.DocumentFile != null)
            {
                using (var reader = new StreamReader(dvm.DocumentFile.OpenReadStream()))
                {
                    result = reader.ReadToEnd();
                }

                foreach (string row in result.Split('.'))
                {
                    if (row.IndexOf(word.ToString()) != -1)
                    {
                        // Add the lines of the document
                        DocumentString documentString = new DocumentString();
                        documentString.DocumentId = _db.Documents.Where(w => w.Word == word).FirstOrDefault().Id;
                        documentString.Count = WordCounter(row);
                        documentString.Text = ReverseString(row);
                        _db.DocumentStrings.Add(documentString);
                        await _db.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // Сounts the number of words given in the sentence
        public int WordCounter(string row)
        {
            return Regex.Matches(row, @"\b" + word + @"\b").Count;
        }

        // Turning line
        public string ReverseString(string row)
        {
            char[] arr = row.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
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
