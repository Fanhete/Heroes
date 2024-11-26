using HeroesAPI.Data;
using HeroesAPI.Models.Entities;

namespace HeroesAPI.Repositories.Interfaces
{
    public interface IHeroisSuperpoderesRepository
    {
        Task<HeroisSuperpoderes> AddAsync(HeroisSuperpoderes heroisSuperpoderes);
        Task DeleteAsync(HeroisSuperpoderes heroisSuperpoderes);
        Task<List<HeroisSuperpoderes>> GetByHeroiIdAsync(int heroiId);
    }
}
