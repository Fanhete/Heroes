namespace HeroesAPI.Models.Entities
{
    public class Superpoderes
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Superpoder { get; set; }

        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
