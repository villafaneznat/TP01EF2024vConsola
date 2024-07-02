﻿namespace TP01EF2024.Entidades
{
    public class Colour
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; } = null!;
        public bool Active { get; set; } = true;
        public ICollection<Shoe> Shoes{ get; set; } = new List<Shoe>();
    }
}
