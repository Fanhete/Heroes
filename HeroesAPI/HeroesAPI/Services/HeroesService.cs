using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using HeroesAPI.Services.Interfaces;

namespace HeroesAPI.Services
{
    public class HeroesService : IHeroesService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IHeroisSuperpoderesRepository _heroisSuperpoderesRepository;
        private readonly ISuperpoderRepository _superpoderRepository;

        public HeroesService
        (
            IHeroRepository heroRepository,
            IHeroisSuperpoderesRepository heroisSuperpoderesRepository,
            ISuperpoderRepository superpoderRepository
        )
        {
            _heroRepository = heroRepository;
            _heroisSuperpoderesRepository = heroisSuperpoderesRepository;
            _superpoderRepository = superpoderRepository;
        }

        public async Task<Herois> AddAsync(HeroisModel hero)
        {
            var existingHero = await _heroRepository.GetbyNameAsync(hero.Nome).ConfigureAwait(false);

            if (existingHero != null)
            {
                if (existingHero.Nome.ToLower() == hero.Nome.ToLower())
                    throw new ArgumentException("Heroi ja cadastrado com este nome!");
            }

            Herois newHero = new Herois
            {
                Nome = hero.Nome,
                NomeHeroi = hero.NomeHeroi,
                DataNascimeto = hero.DataNascimeto,
                Altura = hero.Altura,
                Peso = hero.Peso
            };

            var addedHero = await _heroRepository.AddAsync(newHero);

            if (hero.SuperpoderesId != null && hero.SuperpoderesId.Any())
            {
                foreach (var superpoderId in hero.SuperpoderesId)
                {
                    var superpoder = _superpoderRepository.GetById(superpoderId);
                    if (superpoder == null)
                    {
                        throw new ArgumentException($"Superpoder com ID {superpoderId} não encontrado.");
                    }

                    var heroiSuperpoder = new HeroisSuperpoderes
                    {
                        HeroiId = addedHero.Id,
                        SuperpoderId = superpoder.Id
                    };

                    await _heroisSuperpoderesRepository.AddAsync(heroiSuperpoder).ConfigureAwait(false);
                }
            }

            return addedHero;
        }

        public async Task<Herois> UpdateAsync(HeroisModel hero)
        {
            var actualHero = await _heroRepository.GetbyIdAsync(hero.Id).ConfigureAwait(false);
            if (actualHero == null)
                throw new ArgumentNullException("Herói não encontrado!");

            var existingHeroByName = await _heroRepository.GetbyNameAsync(hero.Nome).ConfigureAwait(false);
            if (existingHeroByName != null && existingHeroByName.Id != hero.Id)
                throw new ArgumentException("Já existe herói com esse nome cadastrado!");

            actualHero.Nome = hero.Nome;
            actualHero.NomeHeroi = hero.NomeHeroi;
            actualHero.DataNascimeto = hero.DataNascimeto;
            actualHero.Altura = hero.Altura;
            actualHero.Peso = hero.Peso;

            await _heroRepository.UpdateAsync(actualHero).ConfigureAwait(false);

            if (hero.SuperpoderesId != null)
            {
                var existingAssociations = await _heroisSuperpoderesRepository
                    .GetByHeroiIdAsync(hero.Id)
                    .ConfigureAwait(false);

                var associationsToRemove = existingAssociations
                    .Where(e => !hero.SuperpoderesId.Contains(e.SuperpoderId))
                    .ToList();

                foreach (var association in associationsToRemove)
                {
                    await _heroisSuperpoderesRepository.DeleteAsync(association).ConfigureAwait(false);
                }

                var newSuperpoderes = hero.SuperpoderesId
                    .Where(id => !existingAssociations.Any(e => e.SuperpoderId == id))
                    .ToList();

                foreach (var superpoderesId in newSuperpoderes)
                {
                    var superpoder = _superpoderRepository.GetById(superpoderesId);
                    if (superpoder == null)
                        throw new ArgumentException($"Superpoder com ID {superpoderesId} não encontrado.");

                    var newAssociation = new HeroisSuperpoderes
                    {
                        HeroiId = hero.Id,
                        SuperpoderId = superpoderesId
                    };

                    await _heroisSuperpoderesRepository.AddAsync(newAssociation).ConfigureAwait(false);
                }
            }

            return actualHero;
        }

        public async Task DeleteAsync(int id)
        {
            var hero = await _heroRepository.GetbyIdAsync(id).ConfigureAwait(false);

            if (hero == null)
                throw new ArgumentNullException("Herói não encontrado!");

            var heroSuperpowers = await _heroisSuperpoderesRepository.GetByHeroiIdAsync(id).ConfigureAwait(false);

            if (heroSuperpowers.Any())
            {
                foreach (var association in heroSuperpowers)
                {
                    await _heroisSuperpoderesRepository.DeleteAsync(association).ConfigureAwait(false);
                }
            }

            await _heroRepository.DeleteAsync(hero).ConfigureAwait(false);
        }

        public async Task<Herois> GetbyIdAsync(int id)
        {
            return await _heroRepository.GetbyIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<Herois>> GetAllAsync()
        {
            var hero = await _heroRepository.GetAllAsync().ConfigureAwait(false);

            if (hero == null)
                throw new ArgumentNullException("Sem Herois Cadastrados!");

            return hero;
        }
    }
}
