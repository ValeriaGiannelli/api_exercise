using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace api.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty; //titolo
		public string Content { get; set; } = string.Empty; //contenuto
        public DateTime CreateOn { get; set; } = DateTime.Now; //data di creazione default ora

        public int? StockId { get; set; } //FK

        //proprietà di navigazione
        public Stock? Stock { get; set; }
	}
}
