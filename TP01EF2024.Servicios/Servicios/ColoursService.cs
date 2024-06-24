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
    public class ColoursService : IColoursService
    {
        private readonly IColoursRepository _repository;

        private readonly IUnitOfWork _unitOfWork;
        public ColoursService(IColoursRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Eliminar(Colour colour)
        {
            try
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    _repository.Eliminar(colour);
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    _unitOfWork.RollBack();
                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Colour colour)
        {
            try
            {
                return _repository.EstaRelacionado(colour);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Colour colour)
        {
            try
            {
                return _repository.Existe(colour);
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

        public Colour GetColourPorId(int id)
        {
            try
            {
                return _repository.GetColourPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Colour> GetColours()
        {
            try
            {
                return _repository.GetColours();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Colour> GetColoursPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            return _repository.GetColoursPaginadosOrdenados(page, pageSize, orden);
        }

        public List<Shoe>? GetShoes(Colour colour)
        {
            return _repository.GetShoes(colour);
        }

        public void Guardar(Colour colour)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (colour.ColourId == 0)
                {
                    _repository.Agregar(colour);
                }
                else
                {
                    _repository.Editar(colour);
                }

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }
    }
    
}
