using HeroesAPI.Models.Entities;

namespace HeroesAPI.Services.Interfaces
{
    public interface IHeroesService
    {

        Task<Herois> AddAsync(HeroisModel heroi);
        Task<Herois> UpdateAsync(HeroisModel heroi);
        Task DeleteAsync(int id);
        Task<Herois> GetbyIdAsync(int id);
        Task<List<Herois>> GetAllAsync();

    }
}
