using Microsoft.AspNetCore.Mvc;
using ExpenseMangementApp.DataLayer;
using ExpenseMangementApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;   

namespace ExpenseMangementApp.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DBContextExpMgt _context;

        public  ExpenseController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity>  expenseList  = _context.Expenses.ToList();
            foreach (var obj in expenseList) { 
            
                obj.ExpenseCategory=_context.ExpenseCategorys.FirstOrDefault(
                    u=> u.ExpenseCateoryId == obj.ExpenseCategoryId );
            
            
            }
            return View(expenseList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategorys.
                Select(i => new SelectListItem
                {
                    Text = i.ExpenseCateoryName,
                    Value = i.ExpenseCateoryId.ToString()

                });

            ViewBag.PopulateExpenseCateory = getExpenseCategoryList;

           if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
           return View();
        }


        public IActionResult GetExpenseDetailsForUpdate(int? Id)
        {

            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategorys.
               Select(i => new SelectListItem
               {
                   Text = i.ExpenseCateoryName,
                   Value = i.ExpenseCateoryId.ToString()

               });

            ViewBag.PopulateExpenseCateory = getExpenseCategoryList;

            var _ExpenseDetails = _context.Expenses.Find(Id);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseDetails);
        }

        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
          
        }




        public IActionResult GetExpenseDetailsForDelete(int? Id)
        {

            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategorys.
              Select(i => new SelectListItem
              {
                  Text = i.ExpenseCateoryName,
                  Value = i.ExpenseCateoryId.ToString()

              });

            ViewBag.PopulateExpenseCateory = getExpenseCategoryList;

            var _ExpenseDetails = _context.Expenses.Find(Id);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            return View(_ExpenseDetails);
        }

        [HttpPost]
        public IActionResult Delete(int? ExpenseId)
        {
            var _ExpenseDetails = _context.Expenses.Find(ExpenseId);

            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
