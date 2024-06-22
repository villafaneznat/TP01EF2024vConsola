using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

namespace TP01EF2024.Servicios.Interfaces
{
    public interface ISportsService
    {
        void Guardar(Sport sport);
        void Eliminar(Sport sport);
        bool EstaRelacionado(Sport sport);
        bool Existe(Sport sport);
        Sport? GetSportPorId(int id);
        List<Sport> GetSports();
        int GetCantidad();
        List<Shoe>? GetShoes(Sport sport);
    }
}
