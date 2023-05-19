using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityGenerics.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGenericInterface<ProductViewModel> _productService;
        private readonly IGenericInterface<ShelfViewModel> _shelfService;
        private readonly IGenericInterface<CategoryViewModel> _categoryService;
        public ProductsController(IGenericInterface<ProductViewModel> productService
            , IGenericInterface<ShelfViewModel> shelfService,
            IGenericInterface<CategoryViewModel> categoryService)
        {
            _productService = productService;
            _shelfService = shelfService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetEntities();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Shelves = new SelectList(_shelfService.GetEntities().Shelves, "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.GetEntities().Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            model.Product.InsertDateTime = DateTime.Now;
            _productService.CreateEntity(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Shelves = new SelectList(_shelfService.GetEntities().Shelves, "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.GetEntities().Categories, "Id", "Name");
            var product = _productService.GetEntityById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            model.Product.UpdateDateTime = DateTime.Now;
            _productService.UpdateEntity(model);
            return RedirectToAction("Index");
        }
    }
}
