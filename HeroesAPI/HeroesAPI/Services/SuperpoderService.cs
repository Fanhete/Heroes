using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using HeroesAPI.Services.Interfaces;

namespace HeroesAPI.Services
{
    public class SuperpoderService : ISuperpoderService
    {
        private readonly ISuperpoderRepository _superpoderRepository;

        public SuperpoderService
        (
            ISuperpoderRepository superpoderRepository
        )
        {
            _superpoderRepository = superpoderRepository;
        }

        public List<Superpoderes> GetAllSuperpoderes()
        {
            return _superpoderRepository.GetAll();
        }
    }
}
