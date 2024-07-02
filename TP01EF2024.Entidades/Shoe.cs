namespace TP01EF2024.Entidades
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = null!;
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public int ColourId { get; set; }
        public Colour Colour { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<ShoeSize> ShoesSizes { get; set; } = new List<ShoeSize>();

    }
}
