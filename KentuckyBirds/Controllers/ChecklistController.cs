using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KentuckyBirds.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KentuckyBirds.Controllers
{
    public class ChecklistController : Controller
    {
        // GET: /<controller>/
        private readonly IBirdRepository repo;

        public ChecklistController(IBirdRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index(string userSearch = "")
        {
            var birds = repo.GetAllBirdsChecklist();
            if (userSearch != "" && userSearch != null)
            {
                birds = repo.GetAllBirdsChecklist().Where(x => x.Name.Contains(userSearch)).ToList();

            }
            else
            {
                birds = repo.GetAllBirdsChecklist()
;
            }

            //var birds = repo.GetAllBirds();
            return View(birds);
        }
        public IActionResult ViewBird(int id)
        {
            var bird = repo.GetBirdChecklist(id);
            return View(bird);
        }
        public IActionResult UpdateBird(int id)
        {
            Checklist bird = repo.GetBirdChecklist(id);
            if (bird == null)
            {
                return View("BirdNotFound");
            }
            return View(bird);
        }
        public IActionResult UpdateBirdToDatabase(Checklist bird)
        {
            repo.UpdateBird(bird);

            return RedirectToAction("ViewBird", new { ID = bird.ID });
        }
        public IActionResult InsertBird()
        {
            var bird = new Checklist();
            return View(bird);
        }
        public IActionResult InsertBirdToDatabase(Checklist birdToInsert)
        {
            repo.InsertBird(birdToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBird(Checklist bird)
        {
            repo.DeleteBird(bird);
            return RedirectToAction("Index");
        }
    }
}

