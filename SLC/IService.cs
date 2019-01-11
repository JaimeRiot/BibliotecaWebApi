using Entidades;
using System;

namespace SLC
{
    public interface IService
    {
        Biblioteca CreateNewBook(Biblioteca nuevoLibro);
    }
}
