using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

namespace TP01EF2024.Servicios.Interfaces
{
    public interface IBrandsService
    {
        void Guardar(Brand brand);
        void Eliminar(Brand brand);
        bool Existe(Brand brand);
        List<Brand> GetBrands();
        int GetCantidad();
        Brand GetBrandPorId(int id);
        bool EstaRelacionado(Brand brand);
        List<Shoe>? GetShoes(Brand brand);
        List<Brand> GetBrandsPaginadosOrdenados(int page, int pageSize, Orden? orden = null);

    }
}
