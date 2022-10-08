using k190146_Q4.Models;
using k190146_Q4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;


namespace k190146_Q4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private List<string> categories;
        string app_folder_path = "";

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> options)
        {
            
            _logger = logger;
            _appSettings = options;
            app_folder_path = _appSettings.Value.folderPath;
            if (app_folder_path.Last() != '\\') {
                app_folder_path += "\\";
            }
            

        }
        [HttpGet("/api/{name}")]
        public List<Stock> getData(string name) {

            string n = name.Replace("&amp;", "&");
            string folderPath = app_folder_path;
            Console.WriteLine(folderPath);
            string filename = DirUtils.getLatestFile(folderPath+ n);
            Console.WriteLine(filename);
            string finalPath = folderPath + n + filename;

            XmlUtils utils = new XmlUtils();
            List<Stock> stocks = utils.parseXml(finalPath);



            return stocks;
        }

        public IActionResult refreshValue(string categoryName)
        {
            


            return View("Index");
        }

        public IActionResult Index()
        {
            string path = app_folder_path;
            categories = DirUtils.getCategories(path);
            
            ViewData["categories"] = categories;
            ViewData["Title"] = "new title";




            return View();
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
}