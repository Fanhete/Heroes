using HeroesAPI.Data;
using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroesAPI.Repositories
{
    public class SuperpoderRepository : ISuperpoderRepository
    {
        private readonly AppDbContext _context;
        private readonly List<Superpoderes> _superpoderes;

        public SuperpoderRepository()
        {
            _superpoderes = new List<Superpoderes>
            {
                new Superpoderes { Id = 1, Superpoder = "Voo", Descricao = "Permite voar pelos ares." },
                new Superpoderes { Id = 2, Superpoder = "Força Sobrehumana", Descricao = "Força muito superior à humana." },
                new Superpoderes { Id = 3, Superpoder = "Visão de Raio-X", Descricao = "Capacidade de ver através de objetos sólidos." },
                new Superpoderes { Id = 4, Superpoder = "Controle Mental", Descricao = "Controle sobre a mente das pessoas." }
            };
        }

        public List<Superpoderes> GetAll()
        {
            return _superpoderes;
        }

        public Superpoderes GetById(int id)
        {
            return _superpoderes.FirstOrDefault(sp => sp.Id == id);
        }
    }
}
