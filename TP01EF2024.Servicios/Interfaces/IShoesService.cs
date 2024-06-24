using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

namespace TP01EF2024.Servicios.Interfaces
{
    public interface IShoesService
    {
        void Guardar(Shoe shoe);
        void Eliminar(Shoe shoe);
        bool Existe(Shoe shoe);
        List<Shoe> GetShoes();
        int GetCantidad();
        Shoe GetShoePorId(int id);
        bool EstaRelacionado(Shoe shoe);
        List<Shoe> GetListaPaginadaOrdenadaFiltrada(
            bool paginar,
            int page,
            int pageSize,
            Orden? orden = null,
            Brand? brand = null,
            Sport? sport = null,
            Genre? genre = null,
            Colour? colour = null,
            decimal? maximo = null,
            decimal? minimo = null);
        int GetCantidadFiltrada(Brand? brand = null,
            Sport? sport = null,
            Genre? genre = null,
            Colour? colour = null,
            decimal? maximo = null,
            decimal? minimo = null);

    }
}
