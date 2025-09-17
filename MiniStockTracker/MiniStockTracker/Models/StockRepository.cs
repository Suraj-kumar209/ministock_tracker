using MiniStockTracker.Models;

public static class StockRepository
{
    private static List<Stock> _stocks = new();
    public static List<Stock> GetAll() => _stocks;
    public static void Add(string symbol, int quantity, decimal price)
    {
        var existing = _stocks.FirstOrDefault(s => s.Symbol == symbol.ToUpper());
        if (existing != null)
        {
            existing.TotalInvested += quantity * price;
            existing.Quantity += quantity;
        }
        else
        {
            _stocks.Add(new Stock
            {
                Symbol = symbol.ToUpper(),
                Quantity = quantity,
                TotalInvested = quantity * price
            });
        }
    }
    public static void UpdateQuantity(string symbol, int newQuantity)
    {
        var stock = _stocks.FirstOrDefault(s => s.Symbol == symbol.ToUpper());
        if (stock != null)
        {
            stock.Quantity = newQuantity;
        }
    }
    public static decimal GetTotalPortfolioValue()
    {
        return _stocks.Sum(s => s.CurrentMarketValue);
    }
}