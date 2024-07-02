using Microsoft.EntityFrameworkCore;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

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
            var brandExist = _context.Brands.FirstOrDefault(b => b.BrandId == shoe.BrandId); // Verificar si la marca asociadoal zapatp ya existe en la base de datos
            
            if (brandExist != null) 
            {
                _context.Attach(brandExist);
                shoe.Brand = brandExist;
            }  // Si la marca ya existe, adjuntarlo al contexto en lugar de agregarlo nuevamente

            var sportExist = _context.Sports.FirstOrDefault(s => s.SportId == shoe.SportId);
            
            if (sportExist != null)
            {
                _context.Attach(sportExist);
                shoe.Sport = sportExist;
            }

            var genreExist = _context.Genres.FirstOrDefault(g => g.GenreId == shoe.GenreId);

            if (genreExist != null)
            {
                _context.Attach(genreExist);
                shoe.Genre = genreExist;
            }

            var colourExist = _context.Colours.FirstOrDefault(c => c.ColourId == shoe.ColourId);

            if (colourExist != null)
            {
                _context.Attach(colourExist);
                shoe.Colour = colourExist;
            }

            _context.Shoes.Add(shoe);
        }

        public void Editar(Shoe shoe)
        {
            var brandExist = _context.Brands.FirstOrDefault(b => b.BrandId == shoe.BrandId); 

            if (brandExist != null)
            {
                _context.Attach(brandExist);
                shoe.Brand = brandExist;
            } 

            var sportExist = _context.Sports.FirstOrDefault(s => s.SportId == shoe.SportId);

            if (sportExist != null)
            {
                _context.Attach(sportExist);
                shoe.Sport = sportExist;
            }

            var genreExist = _context.Genres.FirstOrDefault(g => g.GenreId == shoe.GenreId);

            if (genreExist != null)
            {
                _context.Attach(genreExist);
                shoe.Genre = genreExist;
            }

            var colourExist = _context.Colours.FirstOrDefault(c => c.ColourId == shoe.ColourId);

            if (colourExist != null)
            {
                _context.Attach(colourExist);
                shoe.Colour = colourExist;
            }

            _context.Shoes.Update(shoe);
        }

        public void Eliminar(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
        }

        public bool EstaRelacionado(Shoe shoe)
        {
            return _context.ShoesSizes.Any(ss => ss.ShoeId == shoe.ShoeId);
        }

        public bool Existe(Shoe shoe)
        {
            if (shoe.ShoeId == 0)
            {
                return _context.Shoes.Any(s => s.BrandId == shoe.BrandId 
                                            && s.SportId == shoe.SportId 
                                            && s.GenreId == shoe.GenreId
                                            && s.ColourId == shoe.ColourId
                                            && s.Model == shoe.Model
                                            && s.Description == shoe.Description
                                            && s.Price == shoe.Price);
            }
            return _context.Shoes.Any(s => s.BrandId == shoe.BrandId 
                                        && s.SportId == shoe.SportId 
                                        && s.GenreId == shoe.GenreId
                                        && s.ColourId == shoe.ColourId
                                        && s.Model == shoe.Model
                                        && s.Description == shoe.Description
                                        && s.Price == shoe.Price
                                        && s.ShoeId == shoe.ShoeId);
        }

        public Shoe? GetShoePorId(int id)
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Genre).
                Include(s => s.Sport).
                Include(s => s.Colour).
                SingleOrDefault(s => s.ShoeId == id);
        }

        public List<Shoe> GetShoes()
        {
            return _context.Shoes.
                Include(s => s.Brand).
                Include(s => s.Sport).
                Include(s => s.Genre).
                Include(s => s.Colour).
                OrderBy(s => s.ShoeId).
                AsNoTracking().ToList();
        }

        public int GetCantidad()
        {
            return _context.Shoes.Count();
        }

        public List<Shoe> GetListaPaginadaOrdenadaFiltrada(
            bool paginar,
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
                .Include(s => s.Colour)
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
            if (colour != null)
            {
                query = query
                    .Where(s => s.ColourId == colour.ColourId);
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
            if (paginar)
            {
                List<Shoe> listaPaginada = query.AsNoTracking()
                .Skip(page * pageSize)//Saltea estos registros
                .Take(pageSize)//Muestra estos
                .ToList();
                return listaPaginada;
            }
            else
            {
                return query.ToList();
            }
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
            if (colour != null)
            {
                query = query
                    .Where(s => s.ColourId == colour.ColourId);
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

        

        public void AgregarShoeSize(ShoeSize nuevaRelacion)
        {
            _context.Set<ShoeSize>().Add(nuevaRelacion);
        }

        public void ActualizarShoeSize(ShoeSize shoeSize)
        {
            _context.Set<ShoeSize>().Update(shoeSize);
        }

        public void EliminarShoeSize(ShoeSize? ss)
        {
            _context.ShoesSizes.Remove(ss);
        }

        public List<Size> GetSizesForShoe(int shoeId)
        {
            return _context.ShoesSizes
                .Include(ss => ss.Size)
                .Where(ss => ss.ShoeId == shoeId)
                .Select(ss => ss.Size)
                .ToList();

        }

        public ShoeSize? ExisteShoeSize(Shoe shoe, Size size)
        {
            return _context.ShoesSizes.FirstOrDefault(ss => ss.ShoeId == shoe.ShoeId && ss.SizeId == size.SizeId);
        }
    }
}
