using HeroesAPI.Data;
using HeroesAPI.Models.Entities;

namespace HeroesAPI.Repositories.Interfaces
{
    public interface ISuperpoderRepository
    {
        Superpoderes GetById(int superpoderId);
        List<Superpoderes> GetAll();
    }
}
