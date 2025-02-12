using System;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        //definisco la variabile _context
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        /// <summary>
        /// Metodo per prendere tutti gli Stock del Db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //per ogni elemento della lista chiama il metodo stock su di esso
            var stocks = await _stockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        /// <summary>
        /// Metodo per prendere uno Stock in base all'ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        /// <summary>
        /// Metodo per creare un nuovo Stock
        /// </summary>
        /// <param name="stockDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();

            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }


        /// <summary>
        /// Metodo per modificare lo stock
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            //prendo lo stock con l'id
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            //vedo se lo stock esiste
            if(stockModel == null)
            {
                return NotFound();
            }

            //se esiste modifica i valori
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            //salvare
            await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }

        /// <summary>
        /// Metodo per cancellare l'elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }

            //Remove non ha l'Async
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
