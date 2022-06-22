using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using System.Collections.Generic;

namespace DogGo.Controllers
{
    public class WalksController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly IDogRepository _dogRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalksController(IWalkerRepository walkerRepository,
                                 IWalkRepository walkRepository,
                                 IDogRepository dogRepository)
        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
            _dogRepo = dogRepository;
        }

        // GET: Walks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Walks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalksController/Create
        public ActionResult Create()
        {
            List<Walker> walkers = _walkerRepo.GetAllWalkers();
            List<Dog> dogs = _dogRepo.GetAllDogs();

            WalkFormViewModel vm = new WalkFormViewModel()
            {
                Walkers = walkers,
                Dogs = dogs,
                Walk = new Walk(),
                SelectedDogIds = new List<int>()
            };

            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalkFormViewModel walkFormViewModel)
        {
            try
            {
                foreach (var id in walkFormViewModel.SelectedDogIds)
                {
                    walkFormViewModel.Walk.DogId = id;
                    _walkRepo.AddWalk(walkFormViewModel.Walk);
                }
                return RedirectToAction("Index", "Walkers");
            }
            catch
            {
                walkFormViewModel.Dogs = _dogRepo.GetAllDogs();
                walkFormViewModel.Walkers = _walkerRepo.GetAllWalkers();
                return View(walkFormViewModel);
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

