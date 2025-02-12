using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        //injection: bisogna chiamare il DB
        private readonly ApplicationDBContext _context;

        //crea il costruttore
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        Task<List<Stock>> IStockRepository.GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}
