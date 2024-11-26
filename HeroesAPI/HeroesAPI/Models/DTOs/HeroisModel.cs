namespace HeroesAPI.Models.Entities
{
    public class HeroisModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimeto { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public IEnumerable<int> SuperpoderesId { get; set; }
    }
}
