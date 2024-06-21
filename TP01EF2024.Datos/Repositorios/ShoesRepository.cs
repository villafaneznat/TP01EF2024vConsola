using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos.Repositorios
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly TP01DbContext _context;
        public ShoesRepository(TP01DbContext context)
        {
            _context = context;
        }

        public void Agregar(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
        }

        public void Editar(Shoe shoe)
        {
            _context.Shoes.Update(shoe);
        }

        public void Eliminar(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
        }

        public bool EstaRelacionado(Shoe shoe)
        {
            return _context.ShoesColours.Any(sc => sc.ShoeId == shoe.ShoeId);
        }

        public bool Existe(Shoe shoe)
        {
            if (shoe.ShoeId == 0)
            {
                return _context.Shoes.Any(s => s.BrandId == shoe.BrandId 
                                            && s.SportId == shoe.SportId 
                                            && s.GenreId == shoe.GenreId);
            }
            return _context.Shoes.Any(s => s.BrandId == shoe.BrandId 
                                        && s.SportId == shoe.SportId 
                                        && s.GenreId == shoe.GenreId 
                                        && s.ShoeId == shoe.ShoeId);
        }

        public Shoe? GetShoePorId(int id)
        {
            return _context.Shoes.SingleOrDefault(s => s.ShoeId == id);
        }

        public List<Shoe> GetShoes()
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Sport).
                Include(s => s.Genre).
                OrderBy(s => s.ShoeId).
                AsNoTracking().ToList();
        }

        public int GetCantidad()
        {
            return _context.Shoes.Count();
        }

    }
}
