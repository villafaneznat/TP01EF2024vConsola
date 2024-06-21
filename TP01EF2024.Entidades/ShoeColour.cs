using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01EF2024.Entidades
{
    public class ShoeColour
    {
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; } = null!;
        public int ColourId { get; set; }
        public Colour Colour { get; set; } = null!;

    }
}
