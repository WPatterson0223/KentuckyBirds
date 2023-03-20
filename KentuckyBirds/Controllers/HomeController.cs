using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KentuckyBirds.Models;

namespace KentuckyBirds.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBirdRepository repo;

    public HomeController(ILogger<HomeController> logger, IBirdRepository repo)
    {
        _logger = logger;
        this.repo = repo;
    }

    public IActionResult Index(string userSearch = "")
    {
        var birds = repo.GetAllBirds();
        if (userSearch != "" && userSearch != null)
        {
            birds = repo.GetAllBirds().Where(x => x.Name.Contains(userSearch)).ToList();

        }
        else
        {
            birds = repo.GetAllBirds()
;
        }

        //var birds = repo.GetAllBirds();
        return View(birds);
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
