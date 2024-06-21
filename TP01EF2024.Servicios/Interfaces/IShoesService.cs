using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

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

    }
}
