using MyNextApp.Components.Domain;
using MyNextApp.Components.Repository.Abstract;
using MyNextApp.Components.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNextApp.Web.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IIdeaService _ideaService;

        public IdeaController(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        //
        // GET: /Idea/
        public ActionResult Index()
        {
            var ideas = _ideaService.Get();

            return View(ideas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Idea idea)
        {
            _ideaService.Create(idea);
            return RedirectToAction("Index", "Idea");
        }

        public ActionResult Details(int Id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Idea idea)
        {
            return View();
        }
	}
}