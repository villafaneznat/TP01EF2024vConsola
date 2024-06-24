using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Datos.Migrations;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

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
            return _context.Shoes.Any(s => s.ColourId == colour.ColourId);

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

        public List<Colour> GetColoursPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            IQueryable<Colour> query = _context.Colours.AsNoTracking();

            //ORDEN
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(c => c.ColourName);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(c => c.ColourName);
                        break;
                    default:
                        break;
                }
            }

            //PAGINADO
            List<Colour> listaPaginada = query.AsNoTracking()
                .Skip(page * pageSize) //Saltea estos registros
                .Take(pageSize) //Muestra estos
                .ToList();
            return listaPaginada;

        }

        public List<Shoe>? GetShoes(Colour colour)
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Sport).
                Include(s => s.Genre).
                Include(s => s.Colour).
                Where(s => s.ColourId == colour.ColourId).ToList();
        }
    }
}
