using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos.Repositorios
{
    public class SportsRepository : ISportsRepository
    {
        private readonly TP01DbContext _context;

        public SportsRepository(TP01DbContext context)
        {
            _context = context;
        }

        public void Agregar(Sport sport)
        {
            _context.Sports.Add(sport);
        }

        public void Editar(Sport sport)
        {
            _context.Sports.Update(sport);
        }

        public void Eliminar(Sport sport)
        {
            _context.Sports.Remove(sport);
        }

        public bool EstaRelacionado(Sport sport)
        {
            return _context.Shoes.Any(s => s.SportId == sport.SportId);
        }

        public bool Existe(Sport sport)
        {
            if (sport.SportId == 0)
            {
                return _context.Sports.Any(s => s.SportName == sport.SportName);
            }
            return _context.Sports.Any(s => s.SportName == sport.SportName && s.SportId != sport.SportId);
        }

        public int GetCantidad()
        {
            return _context.Sports.Count();
        }

        public Sport? GetSportPorId(int id)
        {
            return _context.Sports.SingleOrDefault(s => s.SportId == id);
        }

        public List<Sport> GetSports()
        {
            return _context.Sports.OrderBy(s => s.SportId).ToList();
        }
    }
}
