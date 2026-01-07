using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }
        public IActionResult CreditEditExpense(int? id)
        {
            if(id!=null)
            {
                //editiing =>load an expenses by id
                var expenseInDb=_context.Expenses.SingleOrDefault(expense=> expense.Id==id)
            return View(expenseInDb);
                    }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => Expenses().Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return DedirectToAction("Expenses");
        }

        private IActionResult DedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult CreditEditExpenseForm(Expense model)
        {
            if (!model.Id == 0)
            {
                //create
                _context.Expenses.Add(model);
            }
            else
            {
                _Context.Expenses,Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Expenses");
                _context.Expenses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
