namespace TP01EF2024.Entidades
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
