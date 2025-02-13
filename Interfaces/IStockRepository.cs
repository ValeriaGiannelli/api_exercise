using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id); //il ? è dato perché il find può essere NULL
        Task<Stock> CreateAsync(Stock stockModel);        
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto); //l'update ha bisogno dell'Id e ritorna l'oggetto aggiornato
        Task<Stock?> DeleteAsync(int id);
    }
}
