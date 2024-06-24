using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

namespace TP01EF2024.Datos.Interfaces
{
    public interface IColoursRepository
    {
        void Agregar(Colour colour);
        void Editar(Colour colour);
        void Eliminar(Colour colour);
        bool EstaRelacionado(Colour colour);
        bool Existe(Colour colour);
        Colour? GetColourPorId(int id);
        List<Colour> GetColours();
        int GetCantidad();
        List<Shoe>? GetShoes(Colour colour);
        List<Colour> GetColoursPaginadosOrdenados(int page, int pageSize, Orden? orden = null);


    }
}
