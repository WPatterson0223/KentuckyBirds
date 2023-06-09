﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KentuckyBirds.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KentuckyBirds.Controllers
{
    public class StatsController : Controller
    {
        private readonly IBirdRepository repo;

        public StatsController(IBirdRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index(string userSearch = "")
        {
            var birds = repo.GetAllBirds();
            if (userSearch != "" && userSearch != null)
            {
                birds = repo.GetAllBirds().Where(x => x.Name.ToLower().Contains(userSearch.ToLower())).ToList();

            }
            else
            {
                birds = repo.GetAllBirds()
;            }

            //var birds = repo.GetAllBirds();
            return View(birds);
        }
        public IActionResult ViewBird(int id)
        {
            var bird = repo.GetBird(id);
            return View(bird);
        }
        public IActionResult UpdateBird(int id)
        {
            Stats bird = repo.GetBird(id);
            if (bird == null)
            {
                return View("BirdNotFound");
            }
            return View(bird);
        }
        public IActionResult UpdateBirdToDatabase(Stats bird)
        {
            repo.UpdateBird(bird);

            return RedirectToAction("ViewBird", new { ID = bird.ID });
        }
        public IActionResult InsertBird()
        {
            var bird = new Stats();
            return View(bird);
        }
        public IActionResult InsertBirdToDatabase(Stats birdToInsert)
        {
            repo.InsertBird(birdToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBird(Stats bird)
        {
            repo.DeleteBird(bird);
            return RedirectToAction("Index");
        }
        public IActionResult InsertChecklistFromStats(Stats birdToInsert)
        {
            repo.InsertChecklistFromStats(birdToInsert);
            return RedirectToAction("Index");
        }
    }
}

