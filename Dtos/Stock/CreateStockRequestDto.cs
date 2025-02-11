namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        public string Symbol { get; set; } = string.Empty; //simbolo
        public string CompanyName { get; set; } = string.Empty; //nome dell'azienda
        public decimal Purchase { get; set; } //costo
        public decimal LastDiv { get; set; } //porzione di utile della società
        public string Industry { get; set; } = string.Empty; //nome dell'industria
        public long MarketCap { get; set; } //valore totale azioni
    }
}
