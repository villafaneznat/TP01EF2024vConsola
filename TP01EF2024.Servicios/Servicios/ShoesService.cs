using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Datos.Interfaces;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;
using TP01EF2024.Servicios.Interfaces;

namespace TP01EF2024.Servicios.Servicios
{
    public class ShoesService : IShoesService
    {
        private readonly IShoesRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public ShoesService(IShoesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Eliminar(Shoe shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Eliminar(shoe);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public bool EstaRelacionado(Shoe shoe)
        {
            try
            {
                return _repository.EstaRelacionado(shoe);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Shoe shoe)
        {
            try
            {
                return _repository.Existe(shoe);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Shoe GetShoePorId(int id)
        {
            try
            {
                return _repository.GetShoePorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shoe> GetShoes()
        {
            try
            {
                return _repository.GetShoes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }

        public void Guardar(Shoe shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (shoe.ShoeId == 0)
                {
                    _repository.Agregar(shoe);
                }
                else
                {
                    _repository.Editar(shoe);
                }

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public List<Shoe> GetListaPaginadaOrdenadaFiltrada(int page, int pageSize, Orden? orden = null, Brand? brand = null, Sport? sport = null, Genre? genre = null, Colour? colour = null, decimal? maximo = null, decimal? minimo = null)
        {
            return _repository.GetListaPaginadaOrdenadaFiltrada(page,pageSize,orden,brand,sport,genre,colour,maximo,minimo);
        }

        public int GetCantidadFiltrada(Brand? brand = null, Sport? sport = null, Genre? genre = null, Colour? colour = null, decimal? maximo = null, decimal? minimo = null)
        {
            return _repository.GetCantidadFiltrada(brand, sport, genre, colour, maximo, minimo);
        }
    }
}
