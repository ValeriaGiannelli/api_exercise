using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace api.Models
{
	public class Stock
	{
		public int Id { get; set; }

		public string Symbol { get; set; } = string.Empty; //simbolo

        public string CompanyName { get; set; } = string.Empty; //nome dell'azienda

        [Column(TypeName = "decimal(18,2)")]
		public decimal Purchase {  get; set; } //costo

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; } //porzione di utile della società

        public string Industry { get; set; } = string.Empty; //nome dell'industria

        public long MarketCap{ get; set; }; //valore totale azioni

        public List<Comment> Comments { get; set; } = new List<Comment>; //commenti linkati con classe comment

    }
}
