using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityGenerics.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly IGenericInterface<ShelfViewModel> _shelfService;
        private readonly IGenericInterface<StoreViewModel> _storeService;
        public ShelvesController(IGenericInterface<ShelfViewModel> shelfService
            , IGenericInterface<StoreViewModel> storeService)
        {
            _shelfService = shelfService;
            _storeService = storeService;
        }

        public IActionResult Index()
        {
            var shelves = _shelfService.GetEntities();
            return View(shelves);
        }

        public IActionResult Create()
        {
            ViewBag.Stores = new SelectList(_storeService.GetEntities().Stores, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShelfViewModel model)
        {
            model.Shelf.InsertDateTime = DateTime.Now;
            _shelfService.CreateEntity(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Stores = new SelectList(_storeService.GetEntities().Stores, "Id", "Name");
            var store = _shelfService.GetEntityById(id);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        [HttpPost]
        public IActionResult Edit(ShelfViewModel model)
        {
            model.Shelf.UpdateDateTime = DateTime.Now;
            _shelfService.UpdateEntity(model);
            return RedirectToAction("Index");
        }
    }
}
