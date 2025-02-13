using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers //è un extension method
    {
        /// <summary>
        /// Metodo per modificare da Stock a DTO
        /// </summary>
        /// <param name="stockModel"></param>
        /// <returns></returns>
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
                
            };
        }


        /// <summary>
        /// Merodo per modificare un DTo creato in uno Stock
        /// </summary>
        /// <param name="stockDto"></param>
        /// <returns></returns>
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            //deve essere sotto forma di Stock, non può essere un dto
            return new Stock
            {
                Symbol = stockDto.Symbol, 
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}
