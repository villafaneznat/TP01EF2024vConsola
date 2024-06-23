

using Azure;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Numerics;
using TP01EF2024.Entidades;
using TP01EF2024.InversionOfControl;
using TP01EF2024.Servicios.Interfaces;
using TP01EF2024.Shared;

namespace TP01EF2024.Consola
{
    internal class Program
    {
        private static IServiceProvider? servicioProvider;
        static int pageSize = 1;
        static void Main(string[] args)
        {
            servicioProvider = DI.ConfigurarServicios();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("MENÚ PRINCIPAL:");
                Console.WriteLine();
                Console.WriteLine("1. Ver todas las Marcas");
                Console.WriteLine("2. Agregar una Marca");
                Console.WriteLine("3. Editar una Marca");
                Console.WriteLine("4. Eliminar una Marca");
                Console.WriteLine();
                Console.WriteLine("5. Ver todos los Colores");
                Console.WriteLine("6. Agregar un Color");
                Console.WriteLine("7. Editar un Color");
                Console.WriteLine("8. Eliminar un Color");
                Console.WriteLine();
                Console.WriteLine("9. Ver todos los Deportes");
                Console.WriteLine("10. Agregar un Deporte");
                Console.WriteLine("11. Editar un Deporte");
                Console.WriteLine("12. Eliminar un Deporte");
                Console.WriteLine();
                Console.WriteLine("13. Ver todos los Generos");
                Console.WriteLine("14. Agregar un Genero");
                Console.WriteLine("15. Editar un Genero");
                Console.WriteLine("16. Eliminar un Genero");
                Console.WriteLine();
                Console.WriteLine("17. Ver todos los Zapatos");
                Console.WriteLine("18. Agregar un Zapato");
                Console.WriteLine("19. Editar un Zapato");
                Console.WriteLine("20. Eliminar un Zapato");
                Console.WriteLine();
                Console.WriteLine("21. Ver los Zapatos POR MARCA");
                Console.WriteLine("22. Ver los Zapatos POR DEPORTE");
                Console.WriteLine("23. Ver los Zapatos POR GENERO");
                Console.WriteLine("24. Ver los Zapatos POR MARCA entre 2 precios");
                Console.WriteLine("25. Ver los Zapatos POR DEPORTE entre 2 precios");
                Console.WriteLine("26. Ver los Zapatos POR GENERO entre 2 precios");
                Console.WriteLine("27. Ver los Zapatos POR GENERO y DEPORTE");
                Console.WriteLine("");
                Console.WriteLine("28. Ver todas las Marcas paginadas");
                Console.WriteLine("29. Ver todos los Deportes paginados");
                Console.WriteLine("30. Ver todos los Generos paginados");
                Console.WriteLine("31. Ver todos los Colores paginados");
                Console.WriteLine("32. Ver todos los Zapatos paginados");

                Console.WriteLine();

                Console.WriteLine("PRESIONE X PARA SALIR");
                Console.Write("Por favor, seleccione una opción: ");
                string? input = Console.ReadLine();

                var precioMin = 0m;
                var precioMax = 0m;

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        MostrarMarcas();
                        ConsoleExtensions.Enter();
                        break;
                    case "2":
                        Console.Clear();
                        AgregarMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "3":
                        Console.Clear();
                        EditarMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "4":
                        Console.Clear();
                        EliminarMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "5":
                        Console.Clear();
                        MostrarColores();
                        ConsoleExtensions.Enter();
                        break;
                    case "6":
                        Console.Clear();
                        AgregarColor();
                        ConsoleExtensions.Enter();
                        break;
                    case "7":
                        Console.Clear();
                        EditarColor();
                        ConsoleExtensions.Enter();
                        break;
                    case "8":
                        Console.Clear();
                        EliminarColor();
                        ConsoleExtensions.Enter();
                        break;
                    case "9":
                        Console.Clear();
                        MostrarDeportes();
                        ConsoleExtensions.Enter();
                        break;
                    case "10":
                        Console.Clear();
                        AgregarDeporte();
                        ConsoleExtensions.Enter();
                        break;
                    case "11":
                        Console.Clear();
                        EditarDeporte();
                        ConsoleExtensions.Enter();
                        break;
                    case "12":
                        Console.Clear();
                        EliminarDeporte();
                        ConsoleExtensions.Enter();
                        break;
                    case "13":
                        Console.Clear();
                        MostrarGeneros();
                        ConsoleExtensions.Enter();
                        break;
                    case "14":
                        Console.Clear();
                        AgregarGenero();
                        ConsoleExtensions.Enter();
                        break;
                    case "15":
                        Console.Clear();
                        EditarGenero();
                        ConsoleExtensions.Enter();
                        break;
                    case "16":
                        Console.Clear();
                        EliminarGenero();
                        ConsoleExtensions.Enter();
                        break;
                    case "17":
                        Console.Clear();
                        MostrarZapatos();
                        ConsoleExtensions.Enter();
                        break;
                    case "18":
                        Console.Clear();
                        AgregarZapato();
                        ConsoleExtensions.Enter();
                        break;
                    case "19":
                        Console.Clear();
                        EditarZapato();
                        ConsoleExtensions.Enter();
                        break;
                    case "20":
                        Console.Clear();
                        EliminarZapato();
                        ConsoleExtensions.Enter();
                        break;
                    case "21":
                        Console.Clear();
                        MostrarZapatosPorMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "22":
                        Console.Clear();
                        MostrarZapatosPorDeporte();
                        ConsoleExtensions.Enter();
                        break;
                    case "23":
                        Console.Clear();
                        MostrarZapatosPorGenero();
                        ConsoleExtensions.Enter();
                        break;
                    case "24":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        MostrarZapatosPorMarca(precioMin, precioMax);
                        Console.WriteLine("Lista Finalizada");
                        ConsoleExtensions.Enter();
                        break;
                    case "25":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        MostrarZapatosPorDeporte(precioMin, precioMax);
                        ConsoleExtensions.Enter();
                        break;
                    case "26":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        MostrarZapatosPorGenero(precioMin, precioMax);
                        ConsoleExtensions.Enter();
                        break;
                    case "27":
                        Console.Clear();
                        MostrarZapatosPorVariasEntidades("genero","deporte",string.Empty);
                        ConsoleExtensions.Enter();
                        break;
                    case "28":
                        Console.Clear();
                        MostrarMarcasPaginadas();
                        ConsoleExtensions.Enter();
                        break;
                    case "29":
                        Console.Clear();
                        MostrarDeportesPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "30":
                        Console.Clear();
                        MostrarGenerosPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "31":
                        Console.Clear();
                        MostrarColoresPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "32":
                        Console.Clear();
                        MostrarZapatosPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;

                    case "x":
                        exit = true;
                        break;
                }
            }
        }


        //SHOES
        private static void MostrarZapatos()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();
            var shoes = servicio?.GetShoes();

            Console.WriteLine("LISTADO DE ZAPATOS:");

            var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

            if (shoes != null)
            {
                foreach (var s in shoes)
                {
                    tabla.AddRow(s.ShoeId, s.Brand.BrandName, s.Sport.SportName, s.Genre.GenreName, s.Model, s.Description, s.Price);
                }
            }

            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");

        }

        private static void AgregarZapato()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();

            Console.WriteLine("AGREGAR UN ZAPATO...");

            var model = ConsoleExtensions.ReadString("Ingrese el modelo del zapato: ");
            var description = ConsoleExtensions.ReadString("Ingrese la descripcion del zapato: ");
            var precio = ConsoleExtensions.ReadDecimal("Ingrese el precio del zapato: ");
            MostrarMarcas();
            var marca = ConsoleExtensions.ReadInt("Ingrese el ID de la marca del zapato: ");
            MostrarDeportes();
            var deporte = ConsoleExtensions.ReadInt("Ingrese el ID del deporte del zapato: ");
            MostrarGeneros();
            var genero = ConsoleExtensions.ReadInt("Ingrese el ID del genero del zapato: ");

            var shoe = new Shoe
            {
                BrandId = marca,
                SportId = deporte,
                GenreId = genero,
                Model = model,
                Description = description,
                Price = precio
            };

            if (servicio != null)
            {
                if (!servicio.Existe(shoe))
                {
                    servicio.Guardar(shoe);
                    Console.WriteLine("Zapato agregado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El zapato que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);

        }

        private static void EditarZapato()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();

            Console.WriteLine("EDITAR UN ZAPATO..");
            MostrarZapatos();

            var id = ConsoleExtensions.ReadInt("Ingrese el ID del zapato que desea editar: ");
            var shoe = servicio?.GetShoePorId(id);

            if (shoe != null)
            {
                Console.WriteLine($"ZAPATO ANTERIOR: ID: {shoe.ShoeId} | MARCA: {shoe.Brand.BrandName} | DEPORTE: {shoe.Sport.SportName} | GENERO: {shoe.Genre.GenreName} | MODELO:{shoe.Model} | DESCRIPCION: {shoe.Description} | PRECIO:{shoe.Price}");

                var model = ConsoleExtensions.ReadString("Ingrese el modelo del zapato: ");
                var description = ConsoleExtensions.ReadString("Ingrese la descripcion del zapato: ");
                var precio = ConsoleExtensions.ReadDecimal("Ingrese el precio del zapato: ");
                MostrarMarcas();
                var marca = ConsoleExtensions.ReadInt("Ingrese el ID de la marca del zapato: ");
                MostrarDeportes();
                var deporte = ConsoleExtensions.ReadInt("Ingrese el ID del deporte del zapato: ");
                MostrarGeneros();
                var genero = ConsoleExtensions.ReadInt("Ingrese el ID del genero del zapato: ");

                shoe.Model = model;
                shoe.Description = description;
                shoe.Price = precio;
                shoe.BrandId = marca;
                shoe.SportId = deporte;
                shoe.GenreId = genero;

                servicio?.Guardar(shoe);
                Console.WriteLine("Zapato editado satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("El zapato que desea editar no existe.");
            }
            Thread.Sleep(2000);
        }

        private static void EliminarZapato()
        {
            Console.WriteLine("ELIMINAR UN ZAPATO...");
            MostrarZapatos();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del zapato que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<IShoesService>();
                var shoe = servicio?.GetShoePorId(id);

                if (shoe != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(shoe))
                        {
                            servicio.Eliminar(shoe);
                            Console.WriteLine("Registro eliminado satisfactoriamente.");

                        }
                        else
                        {
                            Console.WriteLine("El registro no puede ser eliminado porque se encuentra relacionado.");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("El registro que desea eliminar no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

            Thread.Sleep(5000);
        }

        private static void MostrarZapatosPaginados()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE ZAPATOS:");
                Console.WriteLine($"Página: {page + 1}");
                var shoesPaginados = servicio?.GetListaPaginadaOrdenadaFiltrada(page,pageSize);

                var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

                if (shoesPaginados != null)
                {
                    foreach (var s in shoesPaginados)
                    {
                        tabla.AddRow(s.ShoeId, s.Brand.BrandName, s.Sport.SportName, s.Genre.GenreName, s.Model, s.Description, s.Price);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }


        private static void MostrarZapatosPorMarca(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarMarcas();
            var servicioMarcas = servicioProvider?.GetService<IBrandsService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();
            var brandId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca para ver los zapatos disponibles: ");
            
            Brand? brand = servicioMarcas?.GetBrandPorId(brandId);

            var CantidadRegistros = servicioShoes.GetCantidadFiltrada(brand, null, null, null, precioMaximo, precioMinimo);
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            if (brand != null)
            {
                List<Shoe>? shoes = null;

                if (precioMinimo != null && precioMaximo != null)
                {
                    for (int page = 0; page < CantidadDePaginas; page++)
                    {
                        Console.Clear();
                        Console.WriteLine("LISTADO DE ZAPATOS");
                        Console.WriteLine($"Página: {page + 1}");
                        shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, null, brand, null, null, null, precioMaximo, precioMinimo);
                        if (shoes != null)
                        {
                            TablaDeZapatos(shoes);
                            Console.WriteLine($"Cantidad: {CantidadRegistros}");
                            ConsoleExtensions.Enter();

                        }
                        else
                        {
                            Console.WriteLine($"No existen zapatos de la marca {brand.BrandId} con precio entre ${precioMinimo} y ${precioMaximo}");
                        }
                    }
                }
                else
                {
                    shoes = servicioMarcas?.GetShoes(brand);
                    TablaDeZapatos(shoes);
                    Console.WriteLine($"Cantidad: {servicioShoes?.GetCantidad()}");

                }

            }
            else
            {
                Console.WriteLine("La marca que ha seleccionado no existe.");
            }

        }

        private static void TablaDeZapatos(List<Shoe>? shoes)
        {
            var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

            foreach (var s in shoes)
            {
                tabla.AddRow(s.ShoeId,
                    s.Brand.BrandName,
                    s.Sport.SportName,
                    s.Genre.GenreName,
                    s.Model, s.Description,
                    s.Price);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }

        private static void MostrarZapatosPorDeporte(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarDeportes();
            var servicioDeportes = servicioProvider?.GetService<ISportsService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            var sportId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte para ver los zapatos disponibles:");

            Sport? sport = servicioDeportes?.GetSportPorId(sportId);

            if (sport != null)
            {
                List<Shoe>? shoes;

                if (precioMinimo != null && precioMaximo != null)
                {

                    shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(0, 0, 0, null, sport, null, null, precioMaximo, precioMinimo);
                }
                else
                {
                    shoes = servicioDeportes?.GetShoes(sport);

                }

                if (shoes.Count() != 0)
                {
                    Console.WriteLine("Listado de Zapatos");

                    var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

                    foreach (var s in shoes)
                    {
                        tabla.AddRow(s.ShoeId,
                            s.Brand.BrandName,
                            s.Sport.SportName,
                            s.Genre.GenreName,
                            s.Model, s.Description,
                            s.Price);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();

                }
                else
                {
                    Console.WriteLine($"No existen zapatos del deporte {sport.SportName} con precio entre ${precioMinimo} y ${precioMaximo}");
                }


            }
            else
            {
                Console.WriteLine("El deporte que ha seleccionado no existe.");
            }


        }

        private static void MostrarZapatosPorGenero(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarGeneros();
            var servicioGeneros = servicioProvider?.GetService<IGenresService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            var genreId = ConsoleExtensions.ReadInt("Ingrese el ID del genero para ver los zapatos disponibles:");

            Genre? genre = servicioGeneros?.GetGenrePorId(genreId);

            if (genre != null)
            {
                List<Shoe>? shoes;

                if (precioMinimo != null && precioMaximo != null)
                {

                    shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(0, 0, 0, null, null, genre, null, precioMaximo, precioMinimo);
                }
                else
                {
                    shoes = servicioGeneros?.GetShoes(genre);

                }

                if (shoes.Count() != 0)
                {
                    Console.WriteLine("Listado de Zapatos");

                    var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

                    foreach (var s in shoes)
                    {
                        tabla.AddRow(s.ShoeId,
                            s.Brand.BrandName,
                            s.Sport.SportName,
                            s.Genre.GenreName,
                            s.Model, s.Description,
                            s.Price);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();

                }
                else
                {
                    Console.WriteLine($"No existen zapatos del genero {genre.GenreName} con precio entre ${precioMinimo} y ${precioMaximo}");
                }


            }
            else
            {
                Console.WriteLine("El genero que ha seleccionado no existe.");
            }


        }

        private static void MostrarZapatosPorVariasEntidades(string genero, string deporte, string marca)
        {
            var servicioGenero = servicioProvider?.GetService<IGenresService>();
            var servicioDeporte = servicioProvider?.GetService<ISportsService>();
            var servicioMarca = servicioProvider?.GetService<IBrandsService>();
            var servicioShoe = servicioProvider?.GetService<IShoesService>();
            int generoId, deporteId, marcaId;
            Genre? genre = null;
            Brand? brand = null;
            Sport? sport = null;

            if (genero != string.Empty)
            {
                MostrarGeneros();
                generoId = ConsoleExtensions.ReadInt("Ingrese el ID del genero para ver los zapatos disponibles:");
                genre = servicioGenero?.GetGenrePorId(generoId);
            }
            if (deporte != string.Empty)
            {
                MostrarDeportes();
                deporteId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte para ver los zapatos disponibles:");
                sport = servicioDeporte?.GetSportPorId(deporteId);
            }
            if (marca != string.Empty)
            {
                MostrarMarcas();
                marcaId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca para ver los zapatos disponibles:");
                brand = servicioMarca?.GetBrandPorId(marcaId);
            }

            if (genre != null || sport != null || brand != null)
            {
                List<Shoe>? shoes = servicioShoe?.GetListaPaginadaOrdenadaFiltrada(0, 0, 0, brand, sport, genre, null, null, null);
                if (shoes.Count() != 0)
                {
                    Console.WriteLine("Listado de Zapatos");

                    var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");

                    foreach (var s in shoes)
                    {
                        tabla.AddRow(s.ShoeId,
                            s.Brand.BrandName,
                            s.Sport.SportName,
                            s.Genre.GenreName,
                            s.Model, s.Description,
                            s.Price);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();

                }
                else
                {
                    Console.WriteLine($"No existen zapatos con el filtro aplicado.");
                }

            }
            else if (genre is null)
            {
                Console.WriteLine("El genero que ha seleccioando no existe");
            }
            else if (sport is null)
            {
                Console.WriteLine("El deporte que ha seleccioando no existe");

            }
            else if (brand is null)
            {
                Console.WriteLine("La marca que ha seleccioando no existe");

            }
        }

        //GENRES
        private static void EliminarGenero()
        {
            Console.WriteLine("ELIMINAR UN GENERO...");
            MostrarGeneros();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del genero que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<IGenresService>();
                var genre = servicio?.GetGenrePorId(id);

                if (genre != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(genre))
                        {
                            servicio.Eliminar(genre);
                            Console.WriteLine("Registro eliminado satisfactoriamente.");

                        }
                        else
                        {
                            Console.WriteLine("El registro no puede ser eliminado porque se encuentra relacionado.");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("El registro que desea eliminar no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

            Thread.Sleep(5000);
        }

        private static void EditarGenero()
        {
            var servicio = servicioProvider?.GetService<IGenresService>();

            Console.WriteLine("EDITAR UN GENERO...");
            MostrarGeneros();

            var id = ConsoleExtensions.ReadInt("Ingrese el ID del genero que desea editar: ");
            var genre = servicio?.GetGenrePorId(id);

            if (genre != null)
            {
                Console.WriteLine($"GENERO ANTERIOR: {genre.GenreName}");
                var nuevoName = ConsoleExtensions.ReadString("Ingrese el nuevo genero: ");
                genre.GenreName = nuevoName;
                servicio?.Guardar(genre);
                Console.WriteLine("Genero editado satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("El genero que desea editar no existe.");
            }
            Thread.Sleep(2000);
        }

        private static void AgregarGenero()
        {
            var servicio = servicioProvider?.GetService<IGenresService>();

            Console.WriteLine("AGREGAR UN GENERO...");

            var genreName = ConsoleExtensions.ReadString("Ingrese el nombre del genero: ");

            var genre = new Genre
            {
                GenreName = genreName
            };

            if (servicio != null)
            {
                if (!servicio.Existe(genre))
                {
                    servicio.Guardar(genre);
                    Console.WriteLine("Genero agregado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El genero que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);

        }

        private static void MostrarGenerosPaginados()
        {
            var servicio = servicioProvider?.GetService<IGenresService>();
            var genres = servicio?.GetGenres();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE GENEROS:");
                Console.WriteLine($"Página: {page + 1}");
                var genresPaginados = servicio?.GetGenresPaginadosOrdenados(page, pageSize);


                var tabla = new ConsoleTable("ID", "GENERO");

                if (genresPaginados != null)
                {
                    foreach (var g in genresPaginados)
                    {
                        tabla.AddRow(g.GenreId, g.GenreName);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }

        private static void MostrarGeneros()
        {
            var servicio = servicioProvider?.GetService<IGenresService>();
            var genres = servicio?.GetGenres();

            Console.WriteLine("LISTADO DE GENEROS:");

            var tabla = new ConsoleTable("ID", "GENERO");

            if (genres != null)
            {
                foreach (var g in genres)
                {
                    tabla.AddRow(g.GenreId, g.GenreName);
                }
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
        }



        //SPORTS
        private static void EliminarDeporte()
        {
            Console.WriteLine("ELIMINAR UN DEPORTE...");
            MostrarDeportes();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del deporte que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<ISportsService>();
                var sport = servicio?.GetSportPorId(id);

                if (sport != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(sport))
                        {
                            servicio.Eliminar(sport);
                            Console.WriteLine("Registro eliminado satisfactoriamente.");

                        }
                        else
                        {
                            Console.WriteLine("El registro no puede ser eliminado porque se encuentra relacionado.");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("El registro que desea eliminar no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

            Thread.Sleep(5000);
        }

        private static void EditarDeporte()
        {
            var servicio = servicioProvider?.GetService<ISportsService>();

            Console.WriteLine("EDITAR UN DEPORTE...");
            MostrarDeportes();

            var id = ConsoleExtensions.ReadInt("Ingrese el ID del deporte que desea editar: ");
            var sport = servicio?.GetSportPorId(id);

            if (sport != null)
            {
                Console.WriteLine($"DEPORTE ANTERIOR: {sport.SportName}");
                var nuevoName = ConsoleExtensions.ReadString("Ingrese el nuevo deporte:");
                sport.SportName = nuevoName;
                servicio?.Guardar(sport);
                Console.WriteLine("Deporte editado satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("El deporte que desea editar no existe.");
            }
            Thread.Sleep(2000);
        }

        private static void AgregarDeporte()
        {
            var servicio = servicioProvider?.GetService<ISportsService>();

            Console.WriteLine("AGREGAR UN DEPORTE...");

            var sportName = ConsoleExtensions.ReadString("Ingrese el nombre del deporte: ");

            var sport = new Sport
            {
                SportName = sportName
            };

            if (servicio != null)
            {
                if (!servicio.Existe(sport))
                {
                    servicio.Guardar(sport);
                    Console.WriteLine("Deporte agregado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El deporte que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);

        }

        private static void MostrarDeportesPaginados()
        {
            var servicio = servicioProvider?.GetService<ISportsService>();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE DEPORTES:");
                Console.WriteLine($"Página: {page + 1}");
                var sportsPaginados = servicio?.GetSportsPaginadosOrdenados(page, pageSize);

                var tabla = new ConsoleTable("ID", "GENERO");

                if (sportsPaginados != null)
                {
                    foreach (var s in sportsPaginados)
                    {
                        tabla.AddRow(s.SportId, s.SportName);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }


        private static void MostrarDeportes()
        {
            var servicio = servicioProvider?.GetService<ISportsService>();
            var sports = servicio?.GetSports();

            Console.WriteLine("LISTADO DE DEPORTES:");

            var tabla = new ConsoleTable("ID", "DEPORTE");

            if (sports != null)
            {
                foreach (var s in sports)
                {
                    tabla.AddRow(s.SportId, s.SportName);
                }
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
        }


        //COLOURS
        private static void EliminarColor()
        {
            Console.WriteLine("ELIMINAR UN COLOR...");
            MostrarColores();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del color que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<IColoursService>();
                var colour = servicio?.GetColourPorId(id);
                if (colour != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(colour))
                        {
                            servicio.Eliminar(colour);
                            Console.WriteLine("Registro eliminado satisfactoriamente.");

                        }
                        else
                        {
                            Console.WriteLine("El registro no puede ser eliminado porque se encuentra relacionado.");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("El registro que desea eliminar no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

            Thread.Sleep(5000);

        }

        private static void EditarColor()
        {
            var servicio = servicioProvider?.GetService<IColoursService>();
            Console.WriteLine("EDITAR UN COLOR...");
            MostrarColores();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del color que desea editar: ");
            var colour = servicio?.GetColourPorId(id);
            if (colour != null)
            {
                Console.WriteLine($"COLOR ANTERIOR: {colour.ColourName}");
                var nuevoName = ConsoleExtensions.ReadString("Ingrese el nuevo color:");
                colour.ColourName = nuevoName;
                servicio?.Guardar(colour);
                Console.WriteLine("Color editado satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("El color que desea editar no existe.");
            }
            Thread.Sleep(2000);

        }

        private static void AgregarColor()
        {
            var servicio = servicioProvider?.GetService<IColoursService>();

            Console.WriteLine("AGREGAR UN COLOR...");

            var colorName = ConsoleExtensions.ReadString("Ingrese el nombre del color: ");

            var color = new Colour
            {
                ColourName = colorName
            };

            if (servicio != null)
            {
                if (!servicio.Existe(color))
                {
                    servicio.Guardar(color);
                    Console.WriteLine("Color agregado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El color que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);
        }

        private static void MostrarColoresPaginados()
        {
            var servicio = servicioProvider?.GetService<IColoursService>();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE COLORES:");
                Console.WriteLine($"Página: {page + 1}");
                var coloursPaginados = servicio?.GetColoursPaginadosOrdenados(page, pageSize);

                var tabla = new ConsoleTable("ID", "COLOR");

                if (coloursPaginados != null)
                {
                    foreach (var c in coloursPaginados)
                    {
                        tabla.AddRow(c.ColourId, c.ColourName);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }

        private static void MostrarColores()
        {
            var servicio = servicioProvider?.GetService<IColoursService>();
            var colours = servicio?.GetColours();

            Console.WriteLine("LISTADO DE COLORES:");

            var tabla = new ConsoleTable("ID", "COLOR");

            if (colours != null)
            {
                foreach (var c in colours)
                {
                    tabla.AddRow(c.ColourId, c.ColourName);
                }
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");

        }


        //BRANDS
        private static void EliminarMarca()
        {
            Console.WriteLine("ELIMINAR UNA MARCA...");
            MostrarMarcas();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID de la marca que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<IBrandsService>();
                var brand = servicio?.GetBrandPorId(id);
                if (brand != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(brand))
                        {
                            servicio.Eliminar(brand);
                            Console.WriteLine("Registro eliminado satisfactoriamente.");

                        }
                        else
                        {
                            Console.WriteLine("No se puede eliminar esta marca porque está relacionada.");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("La marca que desea borrar no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

            Thread.Sleep(5000);
        }

        private static void EditarMarca()
        {
            var servicio = servicioProvider?.GetService<IBrandsService>();
            Console.WriteLine("EDITAR UNA MARCA...");
            MostrarMarcas();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID de la marca que desea editar: ");
            var brand = servicio?.GetBrandPorId(id);
            if (brand != null)
            {
                Console.WriteLine($"MARCA ANTERIOR: {brand.BrandName}");
                var nuevoName = ConsoleExtensions.ReadString("Ingrese la nueva marca:");
                brand.BrandName = nuevoName;
                servicio?.Guardar(brand);
                Console.WriteLine("Marca editada satisfactoriamente.");
            }
            else
            {
                Console.WriteLine("La marca que desea editar no existe.");
            }
            Thread.Sleep(2000);
        }

        private static void AgregarMarca()
        {
            var servicio = servicioProvider?.GetService<IBrandsService>();

            Console.WriteLine("AGREGAR UNA MARCA...");

            var brandName = ConsoleExtensions.ReadString("Ingrese el nombre de la marca: ");

            var brand = new Brand
            {
                BrandName = brandName
            };

            if (servicio != null)
            {
                if (!servicio.Existe(brand))
                {
                    servicio.Guardar(brand);
                    Console.WriteLine("Marca agregada satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("La marca que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);
        }

        private static void MostrarMarcasPaginadas()
        {
            var servicio = servicioProvider?.GetService<IBrandsService>();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE MARCAS:");
                Console.WriteLine($"Página: {page + 1}");
                var brandsPaginados = servicio?.GetBrandsPaginadosOrdenados(page, pageSize);

                var tabla = new ConsoleTable("ID", "MARCA");

                if (brandsPaginados != null)
                {
                    foreach (var b in brandsPaginados)
                    {
                        tabla.AddRow(b.BrandId, b.BrandName);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }

        private static void MostrarMarcas()
        {
            var servicio = servicioProvider?.GetService<IBrandsService>();
            var brands = servicio?.GetBrands();

            Console.WriteLine("LISTADO DE MARCAS:");

            var tabla = new ConsoleTable("ID", "MARCA");

            if (brands != null)
            {
                foreach (var b in brands)
                {
                    tabla.AddRow(b.BrandId, b.BrandName);
                }
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
        }

        //PAGINADO
        private static int CalcularCantidadPaginas(int cantidadRegistros, int cantidadPorPagina)
        {
            if (cantidadRegistros < cantidadPorPagina)
            {
                return 1;
            }
            else if (cantidadRegistros % cantidadPorPagina == 0)
            {
                return cantidadRegistros / cantidadPorPagina;
            }
            else
            {
                return cantidadRegistros / cantidadPorPagina + 1;
            }
        }
    }
}
