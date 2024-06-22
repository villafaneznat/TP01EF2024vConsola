using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos.Interfaces
{
    public interface IBrandsRepository
    {
        void Agregar(Brand brand);
        void Editar(Brand brand);
        void Eliminar(Brand brand);
        bool EstaRelacionado(Brand brand);
        bool Existe(Brand brand);
        Brand? GetBrandPorId(int id);
        List<Brand> GetBrands();
        int GetCantidad();
        List<Shoe>? GetShoes(Brand brand);
    }
}
