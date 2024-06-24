using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                                            && s.GenreId == shoe.GenreId
                                            && s.Model == shoe.Model);
            }
            return _context.Shoes.Any(s => s.BrandId == shoe.BrandId 
                                        && s.SportId == shoe.SportId 
                                        && s.GenreId == shoe.GenreId
                                        && s.Model == shoe.Model
                                        && s.ShoeId == shoe.ShoeId);
        }

        public Shoe? GetShoePorId(int id)
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Genre).
                Include(s => s.Sport).
                SingleOrDefault(s => s.ShoeId == id);
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

        public List<Shoe> GetListaPaginadaOrdenadaFiltrada(
            int page, 
            int pageSize, 
            Orden? orden = null, 
            Brand? brand = null,
            Sport? sport = null, 
            Genre? genre = null, 
            Colour? colour = null,
            decimal? maximo = null, 
            decimal? minimo = null)
        {
            IQueryable<Shoe> query = _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .AsNoTracking();

            // FILTROS
            if (brand != null)
            {
                query = query
                    .Where(s => s.BrandId == brand.BrandId);
            }
            if (sport != null)
            {
                query = query
                    .Where(s => s.SportId == sport.SportId);
            }
            if (genre != null)
            {
                query = query
                    .Where(s => s.GenreId == genre.GenreId);
            }

            //ORDEN
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(s => s.Model);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(s => s.Model);
                        break;
                    case Orden.MenorPrecio:
                        query = query.OrderBy(s => s.Price);
                        break;
                    case Orden.MayorPrecio:
                        query = query.OrderByDescending(s => s.Price);
                        break;
                    default:
                        break;
                }
            }

            //PRECIO
            if (maximo != null && minimo != null)
            {
                query = query
                    .Where(s => s.Price <= maximo)
                    .Where(s => s.Price >= minimo);
            }

            //PAGINADO
            List<Shoe> listaPaginada = query.AsNoTracking()
                .Skip(page * pageSize)//Saltea estos registros
                .Take(pageSize)//Muestra estos
                .ToList();

            return listaPaginada;
        }

        public int GetCantidadFiltrada(Brand? brand = null,
            Sport? sport = null,
            Genre? genre = null,
            Colour? colour = null,
            decimal? maximo = null,
            decimal? minimo = null)
        {
            IQueryable<Shoe> query = _context.Shoes.AsNoTracking();
            // FILTROS
            if (brand != null)
            {
                query = query
                    .Where(s => s.BrandId == brand.BrandId);
            }
            if (sport != null)
            {
                query = query
                    .Where(s => s.SportId == sport.SportId);
            }
            if (genre != null)
            {
                query = query
                    .Where(s => s.GenreId == genre.GenreId);
            }
            //PRECIO
            if (maximo != null && minimo != null)
            {
                query = query
                    .Where(s => s.Price <= maximo)
                    .Where(s => s.Price >= minimo);
            }

            return query.Count();
        }
    }
}
