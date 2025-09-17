namespace MiniStockTracker.Models
{
    public class Stock
    {
        public string Symbol { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalInvested { get; set; }

        public decimal AverageBuyPrice =>
            Quantity == 0 ? 0 : TotalInvested / Quantity;

        public decimal CurrentMarketValue => Quantity * GetMockMarketPrice(Symbol);

        private decimal GetMockMarketPrice(string symbol)
        {
            return symbol.ToUpper() switch
            {
                "AAPL" => 180,
                "MSFT" => 320,
                "GOOG" => 2700,
                _ => 100
            };
        }
    }
}
