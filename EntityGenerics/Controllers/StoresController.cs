using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EntityGenerics.Controllers
{
    public class StoresController : Controller
    {
        private readonly IGenericInterface<StoreViewModel> _storeService;
        public StoresController(IGenericInterface<StoreViewModel> storeService)
        {
            _storeService = storeService;
        }

        public IActionResult Index()
        {
            var stores = _storeService.GetEntities();
            return View(stores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StoreViewModel model)
        {
            model.Store.InsertDateTime = DateTime.Now;
            _storeService.CreateEntity(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = _storeService.GetEntityById(id);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        [HttpPost]
        public IActionResult Edit(int id, StoreViewModel model)
        {
            model.Store.UpdateDateTime = DateTime.Now;
            _storeService.UpdateEntity(model);
            return RedirectToAction("Index");
        }
    }
}
