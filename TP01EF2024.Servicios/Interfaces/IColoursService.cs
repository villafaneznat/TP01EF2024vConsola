﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

namespace TP01EF2024.Servicios.Interfaces
{
    public interface IColoursService
    {
        void Guardar(Colour colour);
        void Eliminar(Colour colour);
        bool Existe(Colour colour);
        List<Colour> GetColours();
        int GetCantidad();
        Colour GetColourPorId(int id);
        bool EstaRelacionado(Colour colour);

    }
}
