using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos.Interfaces
{
    public interface IShoesRepository
    {
        void Agregar(Shoe shoe);
        void Editar(Shoe shoe);
        void Eliminar(Shoe shoe);
        bool EstaRelacionado(Shoe shoe);
        bool Existe(Shoe shoe);
        Shoe? GetShoePorId(int id);
        List<Shoe> GetShoes();
        int GetCantidad();

    }
}
