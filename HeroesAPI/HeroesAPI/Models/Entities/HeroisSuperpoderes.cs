namespace HeroesAPI.Models.Entities
{
    public class HeroisSuperpoderes
    {
        public int Id { get; set; }
        public int HeroiId { get; set; }
        public Herois Heroi { get; set; }
        public int SuperpoderId { get; set; }
        public Superpoderes Superpoder { get; set; }
    }
}
