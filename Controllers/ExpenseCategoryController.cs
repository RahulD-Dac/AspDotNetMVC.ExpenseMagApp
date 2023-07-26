using Microsoft.AspNetCore.Mvc;
using ExpenseMangementApp.DataLayer;
using ExpenseMangementApp.Models;

namespace ExpenseMangementApp.Controllers
{
    public class ExpenseCategoryController : Controller

  
    {
        public readonly DBContextExpMgt _context;

        public ExpenseCategoryController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<ExpenseCategoryEntity> ExpenseCategoryList = _context.ExpenseCategorys.ToList();
            return View(ExpenseCategoryList);
        }

        public IActionResult Create(ExpenseCategoryEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseCategorys.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }


        public IActionResult GetExpCatDetailsForUpdate(int? Id)
        {
            var _ExpenseCatDetails = _context.ExpenseCategorys.Find(Id);

            if (_ExpenseCatDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetails);
        }

        [HttpPost]
        public IActionResult Update(ExpenseCategoryEntity _ExpenseCatDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseCategorys.Update(_ExpenseCatDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }

        //======================/*/*==*/*/==========


        public IActionResult GetExpCatDetailsForDelete(int? Id)
        {
            var _ExpenseCatDetails = _context.ExpenseCategorys.Find(Id);

            if (_ExpenseCatDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseCatDetails);
        }

        [HttpPost]
        public IActionResult Delete(int? ExpenseCateoryId)
        {
            var _ExpenseCatDetails = _context.ExpenseCategorys.Find(ExpenseCateoryId);

            if (_ExpenseCatDetails == null)
            {
                return NotFound();
            }
            _context.ExpenseCategorys.Remove(_ExpenseCatDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
