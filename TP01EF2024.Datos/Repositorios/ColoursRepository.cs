using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Datos.Migrations;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos.Repositorios
{
    public class ColoursRepository : IColoursRepository
    {
        private readonly TP01DbContext _context;

        public ColoursRepository(TP01DbContext context)
        {
            _context = context;
        }

        public void Agregar(Colour colour)
        {
            _context.Colours.Add(colour);
        }

        public void Editar(Colour colour)
        {
            _context.Colours.Update(colour);
        }

        public void Eliminar(Colour colour)
        {
            _context.Colours.Remove(colour);
        }

        public bool EstaRelacionado(Colour colour)
        {
            return _context.ShoesColours.Any(cs => cs.ColourId == colour.ColourId);

        }

        public bool Existe(Colour colour)
        {
            if (colour.ColourId == 0)
            {
                return _context.Colours.Any(c => c.ColourName == colour.ColourName);
            }
            return _context.Colours.Any(c => c.ColourName == colour.ColourName && c.ColourId != colour.ColourId);

        }

        public int GetCantidad()
        {
            return _context.Colours.Count();
        }

        public Colour? GetColourPorId(int id)
        {
            return _context.Colours.SingleOrDefault(c => c.ColourId == id);
        }

        public List<Colour> GetColours()
        {
            return _context.Colours.OrderBy(c => c.ColourId).AsNoTracking().ToList();
        }
    }
}
