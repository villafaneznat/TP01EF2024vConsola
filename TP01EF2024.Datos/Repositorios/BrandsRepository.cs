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
    public class BrandsRepository : IBrandsRepository
    {
        private readonly TP01DbContext _context;
        public BrandsRepository(TP01DbContext context)
        {
            _context = context;
        }

        public void Agregar(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void Editar(Brand brand)
        {
            _context.Brands.Update(brand);
        }

        public void Eliminar(Brand brand)
        {
            _context.Brands.Remove(brand);
        }

        public bool EstaRelacionado(Brand brand)
        {
            return _context.Shoes.Any(s => s.BrandId == brand.BrandId);
        }

        public bool Existe(Brand brand)
        {
            if (brand.BrandId == 0)
            {
                return _context.Brands.Any(b => b.BrandName == brand.BrandName);
            }
            return _context.Brands.Any(b => b.BrandName == brand.BrandName && b.BrandId != brand.BrandId);
        }

        public Brand? GetBrandPorId(int id)
        {
            return _context.Brands.SingleOrDefault(b => b.BrandId == id);
        }

        public List<Brand> GetBrands()
        {
            return _context.Brands.OrderBy(b => b.BrandId).AsNoTracking().ToList();
        }

        public int GetCantidad()
        {
            return _context.Brands.Count();
        }

        public List<Shoe>? GetShoes(Brand brand)
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Sport).
                Include(s => s.Genre).
                Where(s=> s.BrandId == brand.BrandId).ToList();
        }
    }
}
