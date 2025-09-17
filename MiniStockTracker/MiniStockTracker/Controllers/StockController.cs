using Microsoft.AspNetCore.Mvc;
using MiniStockTracker.Models;
public class StockController : Controller
    {
        public IActionResult Index()
        {
            var stocks = StockRepository.GetAll();
            var totalValue = StockRepository.GetTotalPortfolioValue();
            ViewBag.TotalPortfolioValue = totalValue;
            return View(stocks);
        }

        [HttpPost]
        public IActionResult Add(string symbol, int quantity, decimal price)
        {
            StockRepository.Add(symbol, quantity, price);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(string symbol, int quantity)
        {
            StockRepository.UpdateQuantity(symbol, quantity);
            return RedirectToAction("Index");
        }
    }