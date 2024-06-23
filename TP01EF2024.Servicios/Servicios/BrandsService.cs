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
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public BrandsService(IBrandsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Eliminar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Eliminar(brand);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public bool EstaRelacionado(Brand brand)
        {
            try
            {
                return _repository.EstaRelacionado(brand);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Brand brand)
        {
            try
            {
                return _repository.Existe(brand);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Brand GetBrandPorId(int id)
        {
            try
            {
                return _repository.GetBrandPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Brand> GetBrands()
        {
            try
            {
                return _repository.GetBrands();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Brand> GetBrandsPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            return _repository.GetBrandsPaginadosOrdenados(page, pageSize, orden);
        }

        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }

        public List<Shoe>? GetShoes(Brand brand)
        {
            return _repository.GetShoes(brand);
        }

        public void Guardar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (brand.BrandId == 0)
                {
                    _repository.Agregar(brand);
                }
                else
                {
                    _repository.Editar(brand);
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
