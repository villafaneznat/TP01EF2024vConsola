using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

namespace TP01EF2024.Datos.Interfaces
{
    public interface ISportsRepository
    {
        void Agregar(Sport sport);
        void Editar(Sport sport);
        void Eliminar(Sport sport);
        bool EstaRelacionado(Sport sport);
        bool Existe(Sport sport);
        Sport? GetSportPorId(int id);
        List<Sport> GetSports();
        int GetCantidad();
        List<Shoe>? GetShoes(Sport sport);
        List<Sport> GetSportsPaginadosOrdenados(int page, int pageSize, Orden? orden = null);

    }
}
