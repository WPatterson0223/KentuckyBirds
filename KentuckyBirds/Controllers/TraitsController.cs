using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KentuckyBirds.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KentuckyBirds.Controllers
{
    public class TraitsController : Controller
    {
        private readonly IBirdRepository repo;

        public TraitsController(IBirdRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index(string userSearch = "", string BrightColor = "", string AccentColor = "", string BackColor = "", string BellyColor = "", string HeadColor = "", string ChestColor = "", string TailColor = "", string BeakColor = "", string SpottedStriped = "", string BeakSize = "", string HeadShape = "")
        {
            var birds = repo.GetAllBirdsTraits();
            if (!String.IsNullOrEmpty(userSearch))
            {
                birds = birds.Where(x => x.Name.ToLower().Contains(userSearch.ToLower())).ToList();
                return View(birds);
            }
            if (!String.IsNullOrEmpty(BrightColor) || !String.IsNullOrEmpty(AccentColor) || !String.IsNullOrEmpty(BackColor) || !String.IsNullOrEmpty(BellyColor) || !String.IsNullOrEmpty(HeadColor) || !String.IsNullOrEmpty(ChestColor) || !String.IsNullOrEmpty(TailColor) || !String.IsNullOrEmpty(BeakColor) || !String.IsNullOrEmpty(SpottedStriped) || !String.IsNullOrEmpty(BeakSize) || !String.IsNullOrEmpty(HeadShape))
            {
                if (!String.IsNullOrEmpty(BrightColor))
                {
                    birds = birds.Where(x => x.BrightColor.ToLower().Contains(BrightColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(AccentColor))
                {
                    birds = birds.Where(x => x.AccentColor.ToLower().Contains(AccentColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(BellyColor))
                {
                    birds = birds.Where(x => x.BellyColor.ToLower().Contains(BellyColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(BackColor))
                {
                    birds = birds.Where(x => x.BackColor.ToLower().Contains(BackColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(HeadColor))
                {
                    birds = birds.Where(x => x.HeadColor.ToLower().Contains(HeadColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(ChestColor))
                {
                    birds = birds.Where(x => x.ChestColor.ToLower().Contains(ChestColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(TailColor))
                {
                    birds = birds.Where(x => x.TailColor.ToLower().Contains(TailColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(BeakColor))
                {
                    birds = birds.Where(x => x.BeakColor.ToLower().Contains(BeakColor.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(SpottedStriped))
                {
                    birds = birds.Where(x => x.SpottedStriped.ToLower().Contains(SpottedStriped.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(BeakSize))
                {
                    birds = birds.Where(x => x.BeakSize.ToLower().Contains(BeakSize.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(HeadShape))
                {
                    birds = birds.Where(x => x.HeadShape.ToLower().Contains(HeadShape.ToLower())).ToList();
                }
            }
            else
            {
                
                birds = repo.GetAllBirdsTraits();
            }

            
            return View(birds);
        }
        public IActionResult ViewBird(int id)
        {
            var bird = repo.GetBirdTraits(id);
            return View(bird);
        }
        public IActionResult UpdateBird(int id)
        {
            Traits bird = repo.GetBirdTraits(id);
            if (bird == null)
            {
                return View("BirdNotFound");
            }
            return View(bird);
        }
        public IActionResult UpdateBirdToDatabase(Traits bird)
        {
            repo.UpdateBird(bird);

            return RedirectToAction("ViewBird", new { ID = bird.ID });
        }
        public IActionResult InsertBird()
        {
            var bird = new Traits();
            return View(bird);
        }
        public IActionResult InsertBirdToDatabase(Traits birdToInsert)
        {
            repo.InsertBird(birdToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBird(Traits bird)
        {
            repo.DeleteBird(bird);
            return RedirectToAction("Index");
        }
        public IActionResult InsertChecklistFromTraits(Traits birdToInsert)
        {
            repo.InsertChecklistFromTraits(birdToInsert);
            return RedirectToAction("Index");
        }
    }
}

