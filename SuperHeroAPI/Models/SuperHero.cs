namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirestName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
       
        public string Place { get; set; } = string.Empty;
    }
}
