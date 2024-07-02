using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;

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
        void AgregarShoeSize(ShoeSize nuevaRelacion);
        void ActualizarShoeSize(ShoeSize shoeSize);
        void EliminarShoeSize(ShoeSize? ss);
        List<Size> GetSizesForShoe(int shoeId);
        ShoeSize? ExisteShoeSize(Shoe shoe, Size size);
    }
}
