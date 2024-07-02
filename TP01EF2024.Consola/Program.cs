using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using TP01EF2024.Entidades;
using TP01EF2024.Entidades.Enums;
using TP01EF2024.InversionOfControl;
using TP01EF2024.Servicios.Interfaces;
using TP01EF2024.Shared;

namespace TP01EF2024.Consola
{
    internal class Program
    {
        private static IServiceProvider? servicioProvider;
        static int pageSize = 5;
        static void Main(string[] args)
        {
            servicioProvider = DI.ConfigurarServicios();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("MENÚ PRINCIPAL:");
                Console.WriteLine();
                //------------------- MARCAS -------------------
                Console.WriteLine("1. Ver todas las Marcas");
                Console.WriteLine("2. Agregar una Marca");
                Console.WriteLine("3. Editar una Marca");
                Console.WriteLine("4. Eliminar una Marca");
                Console.WriteLine();
                //------------------- COLORES -------------------
                Console.WriteLine("5. Ver todos los Colores");
                Console.WriteLine("6. Agregar un Color");
                Console.WriteLine("7. Editar un Color");
                Console.WriteLine("8. Eliminar un Color");
                Console.WriteLine();
                //------------------- DEPORTES -------------------
                Console.WriteLine("9. Ver todos los Deportes");
                Console.WriteLine("10. Agregar un Deporte");
                Console.WriteLine("11. Editar un Deporte");
                Console.WriteLine("12. Eliminar un Deporte");
                Console.WriteLine();
                //------------------- GENEROS -------------------
                Console.WriteLine("13. Ver todos los Generos");
                Console.WriteLine("14. Agregar un Genero");
                Console.WriteLine("15. Editar un Genero");
                Console.WriteLine("16. Eliminar un Genero");
                Console.WriteLine();
                //------------------- ZAPATOS -------------------
                Console.WriteLine("17. Ver todos los Zapatos");
                Console.WriteLine("18. Agregar un Zapato");
                Console.WriteLine("19. Editar un Zapato");
                Console.WriteLine("20. Eliminar un Zapato");
                Console.WriteLine();
                //------------------- TALLES -------------------
                Console.WriteLine("21. Ver todos los Talles");
                Console.WriteLine("22. Agregar un Talle");
                Console.WriteLine("23. Editar un Talle");
                Console.WriteLine("24. Eliminar un Talle");
                Console.WriteLine();
                //------------------- ENTIDADES PAGINADAS -------------------
                Console.WriteLine("25. Ver todas las Marcas paginadas");
                Console.WriteLine("26. Ver todos los Deportes paginados");
                Console.WriteLine("27. Ver todos los Generos paginados");
                Console.WriteLine("28. Ver todos los Colores paginados");
                Console.WriteLine("29. Ver todos los Zapatos paginados");
                Console.WriteLine("30. Ver todos los Talles paginados");
                Console.WriteLine();
                //------------------- FILTROS DE ZAPATOS POR ENTIDAD -------------------
                Console.WriteLine("31. Ver los Zapatos POR MARCA");
                Console.WriteLine("32. Ver los Zapatos POR DEPORTE");
                Console.WriteLine("33. Ver los Zapatos POR GENERO");
                Console.WriteLine("34. Ver los Zapatos POR COLOR");
                Console.WriteLine();
                //------------------- FILTROS DE ZAPATOS POR ENTIDAD ENTRE PRECIOS -------------------
                Console.WriteLine("35. Ver los Zapatos POR MARCA entre 2 precios (paginado)");
                Console.WriteLine("36. Ver los Zapatos POR DEPORTE entre 2 precios (paginado)");
                Console.WriteLine("37. Ver los Zapatos POR GENERO entre 2 precios (pagindo)");
                Console.WriteLine("38. Ver los Zapatos POR COLOR entre 2 precios (pagindo)");
                Console.WriteLine();
                //------------------- FILTROS DE ZAPATOS POR MÁS DE UNA ENTIDAD  -------------------
                Console.WriteLine("39. Ver los Zapatos POR GENERO y DEPORTE");
                Console.WriteLine();
                //------------------- RELACION: SHOES-SIZES -------------------
                Console.WriteLine("40. Ver todos los Zapatos disponibles en un determinado Talle");
                Console.WriteLine("41. Ver los talles disponibles de un Zapato");
                Console.WriteLine("42. Asignar Talles");
                Console.WriteLine("43. Dar de baja el talle de un zapato");
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
                        MostrarTalles(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "22":
                        Console.Clear();
                        AgregarTalle(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "23":
                        Console.Clear();
                        EditarTalle(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "24":
                        Console.Clear();
                        EliminarTalle(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "25":
                        Console.Clear();
                        MostrarMarcasPaginadas();
                        ConsoleExtensions.Enter();
                        break;
                    case "26":
                        Console.Clear();
                        MostrarDeportesPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "27":
                        Console.Clear();
                        MostrarGenerosPaginados(); ;
                        ConsoleExtensions.Enter();                      
                        break;
                    case "28":
                        Console.Clear();
                        MostrarColoresPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "29":
                        Console.Clear();
                        MostrarZapatosPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "30":
                        Console.Clear();
                        MostrarTallesPaginados(); ;
                        ConsoleExtensions.Enter();
                        break;
                    case "31":
                        Console.Clear();
                        MostrarZapatosPorMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "32":
                        Console.Clear();
                        MostrarZapatosPorDeporte();
                        ConsoleExtensions.Enter();
                        break;
                    case "33":
                        Console.Clear();
                        MostrarZapatosPorGenero();
                        ConsoleExtensions.Enter();
                        break;
                    case "34":
                        Console.Clear();
                        MostrarZapatosPorColor();
                        ConsoleExtensions.Enter();
                        break;
                    case "35":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMin = (decimal)Validar<decimal>(precioMin);
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        precioMax = (decimal)Validar<decimal>(precioMax);
                        MostrarZapatosPorMarca(precioMin, precioMax);
                        Console.WriteLine("Lista Finalizada");
                        ConsoleExtensions.Enter();
                        break;
                    case "36":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMin = (decimal)Validar<decimal>(precioMin);
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        precioMax = (decimal)Validar<decimal>(precioMax);
                        MostrarZapatosPorDeporte(precioMin, precioMax);
                        Console.WriteLine("Lista Finalizada");
                        ConsoleExtensions.Enter();
                        break;
                    case "37":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMin = (decimal)Validar<decimal>(precioMin);
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        precioMax = (decimal)Validar<decimal>(precioMax);
                        MostrarZapatosPorGenero(precioMin, precioMax);
                        Console.WriteLine("Lista Finalizada");
                        ConsoleExtensions.Enter();
                        break;
                    case "38":
                        Console.Clear();
                        precioMin = ConsoleExtensions.ReadDecimal("Ingrese el precio Minimo:");
                        precioMin = (decimal)Validar<decimal>(precioMin);
                        precioMax = ConsoleExtensions.ReadDecimal("Ingrese el precio Maximo:");
                        precioMax = (decimal)Validar<decimal>(precioMax);
                        MostrarZapatosPorColor(precioMin, precioMax);
                        Console.WriteLine("Lista Finalizada");
                        ConsoleExtensions.Enter();
                        break;
                    case "39":
                        Console.Clear();
                        MostrarZapatosPorVariasEntidades(Entidad.Genero, Entidad.Deporte);
                        ConsoleExtensions.Enter();
                        break;
                    case "40":
                        Console.Clear();
                        MostrarZapatosPorTalle();
                        //MOSTRAR ZAPATOS POR TALLE (elijo un talle y me traigo los zapatos en ese talle)
                        ConsoleExtensions.Enter();
                        break;
                    case "41":
                        Console.Clear();
                        MostrarTallesPorZapato();
                        ConsoleExtensions.Enter();
                        break;
                    case "42":
                        Console.Clear();
                        AsignarTalles();
                        ConsoleExtensions.Enter();
                        break;
                    case "43":
                        Console.Clear();
                        BajaDeTalle();
                        ConsoleExtensions.Enter();
                        break;

                    case "x":
                        exit = true;
                        break;
                }
            }
        }


        //----------------- SHOES
        private static void MostrarZapatos()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();
            var shoes = servicio?.GetShoes();
            Console.WriteLine("LISTADO DE ZAPATOS");
            if (shoes != null)
            {
                TablaDeZapatos(shoes); //LA TABLA SE VE MAL PORQUE LAS DESCRIPCIONES SON UN POCO LARGAS (agrandar consola).
            }

            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");

        }

        private static void AgregarZapato()
        {
            var servicio = servicioProvider?.GetService<IShoesService>();

            Console.WriteLine("AGREGAR UN ZAPATO...");

            var model = ConsoleExtensions.ReadString("Ingrese el modelo del zapato: ");
            model = (string)Validar<string>(model);

            var description = ConsoleExtensions.ReadString("Ingrese la descripcion del zapato: ");

            var precio = ConsoleExtensions.ReadDecimal("Ingrese el precio del zapato: ");
            precio = (decimal)Validar<decimal>(precio);

            MostrarMarcas();
            var marcaId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca del zapato: ");
            marcaId = (int)Validar<int>(marcaId, Entidad.Marca);

            MostrarDeportes();
            var deporteId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte del zapato: ");
            deporteId = (int)Validar<int>(deporteId, Entidad.Deporte);

            MostrarGeneros();
            var generoId = ConsoleExtensions.ReadInt("Ingrese el ID del genero del zapato: ");
            generoId = (int)Validar<int>(generoId, Entidad.Genero);

            MostrarColores();
            var colorId = ConsoleExtensions.ReadInt("Ingrese el ID del color del zapato: ");
            colorId = (int)Validar<int>(colorId, Entidad.Color);

            var shoe = new Shoe
            {
                BrandId = marcaId,
                SportId = deporteId,
                GenreId = generoId,
                ColourId = colorId,
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
                model = (string)Validar<string>(model);

                var description = ConsoleExtensions.ReadString("Ingrese la descripcion del zapato: ");

                var precio = ConsoleExtensions.ReadDecimal("Ingrese el precio del zapato: ");
                precio = (decimal)Validar<decimal>(precio);

                MostrarMarcas();
                var marcaId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca del zapato: ");
                marcaId = (int)Validar<int>(marcaId, Entidad.Marca);

                MostrarDeportes();
                var deporteId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte del zapato: ");
                deporteId = (int)Validar<int>(deporteId, Entidad.Deporte);

                MostrarGeneros();
                var generoId = ConsoleExtensions.ReadInt("Ingrese el ID del genero del zapato: ");
                generoId = (int)Validar<int>(generoId, Entidad.Genero);

                MostrarColores();
                var colorId = ConsoleExtensions.ReadInt("Ingrese el ID del color del zapato: ");
                colorId = (int)Validar<int>(colorId, Entidad.Color);

                shoe.Model = model;
                shoe.Description = description;
                shoe.Price = precio;
                shoe.BrandId = marcaId;
                shoe.SportId = deporteId;
                shoe.GenreId = generoId;
                shoe.ColourId = colorId;
                if (!servicio.Existe(shoe))
                {
                    servicio?.Guardar(shoe);
                    Console.WriteLine("Zapato editado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El zapato que desea ingresar ya existe.");
                }

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
                var shoesPaginados = servicio?.GetListaPaginadaOrdenadaFiltrada(true, page, pageSize);

                if (shoesPaginados != null)
                {
                    TablaDeZapatos(shoesPaginados);
                }

                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }


        //----------------- FILTROS

        private static void MostrarZapatosPorMarca(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarMarcas();
            var servicioMarcas = servicioProvider?.GetService<IBrandsService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();
            var brandId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca para ver los zapatos disponibles: ");
            brandId = (int)Validar<int>(brandId, Entidad.Marca);

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
                        shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(true, page, pageSize, null, brand, null, null, null, precioMaximo, precioMinimo);
                        if (shoes != null && shoes.Count() != 0)
                        {
                            Console.WriteLine("LISTADO DE ZAPATOS");
                            Console.WriteLine($"Página: {page + 1}");
                            TablaDeZapatos(shoes);
                            Console.WriteLine($"Cantidad: {CantidadRegistros}");
                            ConsoleExtensions.Enter();

                        }
                        else
                        {
                            Console.WriteLine($"No existen zapatos de la marca {brand.BrandName} con precio entre ${precioMinimo} y ${precioMaximo}");
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

        private static void MostrarZapatosPorDeporte(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarDeportes();
            var servicioDeportes = servicioProvider?.GetService<ISportsService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            var sportId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte para ver los zapatos disponibles:");
            sportId = (int)Validar<int>(sportId, Entidad.Deporte);

            Sport? sport = servicioDeportes?.GetSportPorId(sportId);

            var CantidadRegistros = servicioShoes.GetCantidadFiltrada(null, sport, null, null, precioMaximo, precioMinimo);
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);


            if (sport != null)
            {
                List<Shoe>? shoes;

                if (precioMinimo != null && precioMaximo != null)
                {

                    for (int page = 0; page < CantidadDePaginas; page++)
                    {
                        Console.Clear();                  
                        shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(true, page, pageSize, null, null, sport, null, null, precioMaximo, precioMinimo);
                        if (shoes != null && shoes.Count() != 0)
                        {
                            Console.WriteLine("LISTADO DE ZAPATOS");
                            Console.WriteLine($"Página: {page + 1}");
                            TablaDeZapatos(shoes);
                            Console.WriteLine($"Cantidad: {CantidadRegistros}");
                            ConsoleExtensions.Enter();

                        }
                        else
                        {
                            Console.WriteLine($"No existen zapatos del deporte {sport.SportName} con precio entre ${precioMinimo} y ${precioMaximo}");
                        }

                    }
                }
                else
                {
                    shoes = servicioDeportes?.GetShoes(sport);
                    TablaDeZapatos(shoes);
                    Console.WriteLine($"Cantidad: {servicioShoes?.GetCantidad()}");
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
            genreId = (int)Validar<int>(genreId, Entidad.Genero);

            Genre? genre = servicioGeneros?.GetGenrePorId(genreId);

            var CantidadRegistros = servicioShoes.GetCantidadFiltrada(null, null, genre, null, precioMaximo, precioMinimo);
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);


            if (genre != null)
            {
                List<Shoe>? shoes = null;

                if (precioMinimo != null && precioMaximo != null)
                {

                    for (int page = 0; page < CantidadDePaginas; page++)
                    {
                        Console.Clear();
                        
                        shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(true, page, pageSize, null, null, null, genre, null, precioMaximo, precioMinimo);
                        if (shoes != null && shoes.Count() != 0)
                        {
                            Console.WriteLine("LISTADO DE ZAPATOS");
                            Console.WriteLine($"Página: {page + 1}");
                            TablaDeZapatos(shoes);
                            Console.WriteLine($"Cantidad: {CantidadRegistros}");
                            ConsoleExtensions.Enter();

                        }
                        else
                        {
                            Console.WriteLine($"No existen zapatos del genero {genre.GenreId} con precio entre ${precioMinimo} y ${precioMaximo}");
                        }

                    }

                }
                else
                {
                    shoes = servicioGeneros?.GetShoes(genre);

                }

            }
            else
            {
                Console.WriteLine("El genero que ha seleccionado no existe.");
            }


        }

        private static void MostrarZapatosPorColor(decimal? precioMinimo = null, decimal? precioMaximo = null)
        {
            MostrarColores();
            var servicioColores = servicioProvider?.GetService<IColoursService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            var colourId = ConsoleExtensions.ReadInt("Ingrese el ID del color para ver los zapatos disponibles: ");
            colourId = (int)Validar<int>(colourId, Entidad.Color);

            Colour? colour = servicioColores?.GetColourPorId(colourId);

            var CantidadRegistros = servicioShoes.GetCantidadFiltrada(null, null, null, colour, precioMaximo, precioMinimo);
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);


            if (colour != null)
            {
                List<Shoe>? shoes = null;

                if (precioMinimo != null && precioMaximo != null)
                {

                    for (int page = 0; page < CantidadDePaginas; page++)
                    {
                        Console.Clear();
                        shoes = servicioShoes?.GetListaPaginadaOrdenadaFiltrada(true, page, pageSize, null, null, null, null, colour, precioMaximo, precioMinimo);
                        if (shoes != null && shoes.Count() != 0)
                        {
                            Console.WriteLine("LISTADO DE ZAPATOS");
                            Console.WriteLine($"Página: {page + 1}");
                            TablaDeZapatos(shoes);
                            Console.WriteLine($"Cantidad: {CantidadRegistros}");
                            ConsoleExtensions.Enter();

                        }
                        else
                        {
                            Console.WriteLine($"No existen zapatos del color {colour.ColourName} con precio entre ${precioMinimo} y ${precioMaximo}");
                        }

                    }

                }
                else
                {
                    shoes = servicioColores?.GetShoes(colour);
                }
            }
            else
            {
                Console.WriteLine("El color que ha seleccionado no existe.");
            }


        }

        private static void MostrarZapatosPorVariasEntidades(Entidad? genero=null,Entidad? deporte=null,Entidad? marca=null, Entidad? color=null)
        {
            var servicioGenero = servicioProvider?.GetService<IGenresService>();
            var servicioDeporte = servicioProvider?.GetService<ISportsService>();
            var servicioMarca = servicioProvider?.GetService<IBrandsService>();
            var servicioColor = servicioProvider?.GetService<IColoursService>();
            var servicioShoe = servicioProvider?.GetService<IShoesService>();
            int generoId, deporteId, marcaId, colorId;
            Genre? genre = null;
            Brand? brand = null;
            Sport? sport = null;
            Colour? colour = null;

            if (genero != null)
            {
                MostrarGeneros();
                generoId = ConsoleExtensions.ReadInt("Ingrese el ID del genero para ver los zapatos disponibles:");
                generoId = (int)Validar<int>(generoId, Entidad.Genero);
                genre = servicioGenero?.GetGenrePorId(generoId);
            }
            if (deporte != null)
            {
                MostrarDeportes();
                deporteId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte para ver los zapatos disponibles:");
                deporteId = (int)Validar<int>(deporteId, Entidad.Deporte);

                sport = servicioDeporte?.GetSportPorId(deporteId);
            }
            if (marca != null)
            {
                MostrarMarcas();
                marcaId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca para ver los zapatos disponibles:");
                marcaId = (int)Validar<int>(marcaId, Entidad.Marca);

                brand = servicioMarca?.GetBrandPorId(marcaId);
            }
            if (color != null)
            {
                MostrarColores();
                colorId = ConsoleExtensions.ReadInt("Ingrese el ID del color para ver los zapatos disponibles:");
                colorId = (int)Validar<int>(colorId, Entidad.Color);

                colour = servicioColor?.GetColourPorId(colorId);
            }
            if (genre != null || sport != null || brand != null || color != null)
            {
                List<Shoe>? shoes = servicioShoe?.GetListaPaginadaOrdenadaFiltrada(false, 0, pageSize, 0, brand, sport, genre, colour, null, null);
                if (shoes.Count() != 0)
                {
                    Console.WriteLine("Listado de Zapatos");

                    TablaDeZapatos(shoes);

                }
                else
                {
                    Console.WriteLine($"No existen zapatos con el filtro aplicado.");
                }

            }
            else
            {
                Console.WriteLine("El registro que ha seleccionado para filtrar no existe");
            }
        }


        //----------------- SHOE-SIZE
        private static void AsignarTalles()
        {
            var servicioTalles = servicioProvider?.GetService<ISizesService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            if (servicioTalles == null || servicioShoes == null)
            {
                Console.WriteLine("Servicios no disponibles.");
                return;
            }

            MostrarZapatos();
            var shoeId = ConsoleExtensions.ReadInt("Ingrese el ID del zapato al que se le asignará un talle: ");
            Shoe shoe = servicioShoes.GetShoePorId(shoeId);
            if (shoe != null)
            {
                MostrarTalles();
                var sizeId = ConsoleExtensions.ReadInt("Ingrese el ID del talle que desea asignar al zapato:  ");
                Size size = servicioTalles.GetSizePorId(sizeId);

                if (size != null)
                {
                    Console.WriteLine($"Está por agregar el talle {size.SizeNumber} a los zapatos de id {shoe.ShoeId} y modelo {shoe.Model}");
                    var stock = ConsoleExtensions.ReadInt("Ingrese la cantidad de stock a dar de alta para este ingreso: ");
                    servicioShoes.AsignarTalle(shoe, size, stock);

                    Console.WriteLine("Se ingresó lo siguiente:");
                    Console.WriteLine($"ZAPATOS: ");
                    Console.WriteLine($"Marca: {shoe.Brand.BrandName}");
                    Console.WriteLine($"Deporte: {shoe.Sport.SportName}");
                    Console.WriteLine($"Genero: {shoe.Genre.GenreName}");
                    Console.WriteLine($"Color: {shoe.Colour.ColourName}");
                    Console.WriteLine($"Modelo: {shoe.Model}");
                    Console.WriteLine($"Descripción {shoe.Description}");
                    Console.WriteLine($"Precio {shoe.Price}");
                    Console.WriteLine($"TALLE: {size.SizeNumber}");
                    Console.WriteLine($"Cantidad de stock: {stock}");

                    Console.WriteLine("Registro agregado satisfactoriamente...");
                }
                else
                {
                    Console.WriteLine("El ID del talle que ha seleccionado, no existe");

                }
            }
            else
            {
                Console.WriteLine("El ID del zapato que ha seleccionado, no existe");
            }
            
        }

        private static void BajaDeTalle()
        {
            var servicioTalles = servicioProvider?.GetService<ISizesService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            if (servicioTalles == null || servicioShoes == null)
            {
                Console.WriteLine("Servicios no disponibles.");
                return;
            }

            MostrarZapatos();

            var shoeId = ConsoleExtensions.ReadInt("Ingrese el ID del zapato al que se le dará de baja un talle: ");
            Shoe shoe = servicioShoes.GetShoePorId(shoeId);
            if (shoe != null)
            {
                Console.WriteLine("ZAPATO SELECCIONADO: ");

                var tablaShoe = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "COLOR", "MODELO", "DESCRIPCION", "PRECIO");
                tablaShoe.AddRow(
                        shoe.ShoeId,
                        shoe.Brand.BrandName,
                        shoe.Sport.SportName,
                        shoe.Genre.GenreName,
                        shoe.Colour.ColourName,
                        shoe.Model,
                        shoe.Description,
                        shoe.Price);
                tablaShoe.Options.EnableCount = false;
                tablaShoe.Write();

                List<Size>? sizes = servicioShoes?.GetSizesForShoe(shoe.ShoeId);
                if (sizes != null && sizes.Count() > 0)
                {
                    Console.WriteLine("TALLES DISPONIBLES");

                    var tablaSizes = new ConsoleTable("ID", "TALLE", "STOCK");
                    foreach (var s in sizes)
                    {
                        int stock = servicioShoes.GetStockShoeSize(shoe, s);

                        tablaSizes.AddRow(s.SizeId, s.SizeNumber, stock);
                    }
                    tablaSizes.Options.EnableCount = false;
                    tablaSizes.Write();
                    var sizeId = ConsoleExtensions.ReadInt("Ingrese el ID del talle a dar de baja: ");
                    if (sizes.Any(s => s.SizeId == sizeId))
                    {
                        Size size = servicioTalles.GetSizePorId(sizeId);
                        servicioShoes.EliminarShoeSize(shoe, size);
                        Console.WriteLine("El talle se ha borrado de este zapato correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El talle que desea elimar no pertenece a este zapato");
                    }
                }
                else
                {
                    Console.WriteLine("No hay talles disponibles para este zapato.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("El ID del zapato que ha seleccionado, no existe");
            }
        }

        private static void MostrarTallesPorZapato()
        {
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            MostrarZapatos();

            var shoeId = ConsoleExtensions.ReadInt("Ingrese el ID del zapato para poder ver los talles en los que se encuentra disponible: ");

            Shoe? shoe = servicioShoes?.GetShoePorId(shoeId);

            if (shoe != null)
            {
                Console.WriteLine("ZAPATO SELECCIONADO: ");

                var tablaShoe = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "COLOR", "MODELO", "DESCRIPCION", "PRECIO");
                tablaShoe.AddRow(
                        shoe.ShoeId,
                        shoe.Brand.BrandName,
                        shoe.Sport.SportName,
                        shoe.Genre.GenreName,
                        shoe.Colour.ColourName,
                        shoe.Model,
                        shoe.Description,
                        shoe.Price);
                tablaShoe.Options.EnableCount = false;
                tablaShoe.Write();

                List<Size>? sizes = servicioShoes?.GetSizesForShoe(shoe.ShoeId);
                if (sizes != null && sizes.Count() > 0)
                {
                    Console.WriteLine("TALLES DISPONIBLES");

                    var tablaSizes = new ConsoleTable("ID", "TALLE", "STOCK");
                    foreach (var s in sizes)
                    {
                        int stock = servicioShoes.GetStockShoeSize(shoe, s);

                        tablaSizes.AddRow(s.SizeId, s.SizeNumber, stock);
                    }
                    tablaSizes.Options.EnableCount = false;
                    tablaSizes.Write();

                }
                else
                {
                    Console.WriteLine("No hay talles disponibles para este zapato.");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("El ID que ha ingresado no corresponde a ningun zapato.");
            }
        }

        private static void MostrarZapatosPorTalle()
        {
            var servicioSizes = servicioProvider?.GetService<ISizesService>();
            var servicioShoes = servicioProvider?.GetService<IShoesService>();

            MostrarTalles();

            var sizeId = ConsoleExtensions.ReadInt("Ingrese el ID del talle para poder ver los zapatos disponibles: ");

            Size? size = servicioSizes?.GetSizePorId(sizeId);

            if (size != null)
            {
                Console.WriteLine($"TALLE SELECCIONADO: {size.SizeNumber}");

                List<Shoe>? shoes = servicioSizes?.GetShoesForSize(size.SizeId);

                if (shoes != null && shoes.Count() > 0)
                {
                    Console.WriteLine("ZAPATOS DISPONIBLES:");
                    var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "COLOR", "MODELO", "DESCRIPCION", "PRECIO", "STOCK");
                    foreach (var s in shoes)
                    {
                        int stock = servicioShoes.GetStockShoeSize(s, size);

                        tabla.AddRow(s.ShoeId,
                            s.Brand.BrandName,
                            s.Sport.SportName,
                            s.Genre.GenreName,
                            s.Colour.ColourName,
                            s.Model,
                            s.Description,
                            s.Price,
                            stock);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();
                }
                else
                {
                    Console.WriteLine("No hay zapatos disponibles en el talle seleccionado.");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("El ID que ha ingresado no corresponde a ningun talle.");
            }
        }


        //----------------- SIZES
        private static void MostrarTalles()
        {
            var servicio = servicioProvider?.GetService<ISizesService>();
            var sizes = servicio?.GetSizes();
            Console.WriteLine("LISTADO DE TALLES");

            var tabla = new ConsoleTable("ID", "TALLE");

            if (sizes != null)
            {
                foreach (var s in sizes)
                {
                    tabla.AddRow(s.SizeId, s.SizeNumber);
                }
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");

        }

        private static void AgregarTalle()
        {
            var servicio = servicioProvider?.GetService<ISizesService>();

            Console.WriteLine("AGREGAR UN TALLE...");

            var sizeNumber = ConsoleExtensions.ReadDecimal("Ingrese el número del talle: ");

            var size = new Size
            {
                SizeNumber = sizeNumber
            };

            if (servicio != null)
            {
                if (!servicio.Existe(size))
                {
                    servicio.Guardar(size);
                    Console.WriteLine("Talle agregado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El talle que desea ingresar ya existe.");
                }
            }
            else
            {
                Console.WriteLine("Servicio no disponible");
            }

            Thread.Sleep(2000);

        }

        private static void EditarTalle()
        {
            var servicio = servicioProvider?.GetService<ISizesService>();

            Console.WriteLine("EDITAR UN TALLE...");
            MostrarTalles();

            var id = ConsoleExtensions.ReadInt("Ingrese el ID del talle que desea editar: ");
            var size = servicio?.GetSizePorId(id);

            if (size != null)
            {
                Console.WriteLine($"TALLE ANTERIOR: {size.SizeNumber}");
                var nuevoNumber = ConsoleExtensions.ReadDecimal("Ingrese el nuevo talle: ");
                if (!servicio.GetSizes().Any(s => s.SizeNumber == nuevoNumber))
                {
                    size.SizeNumber = nuevoNumber;
                    servicio?.Guardar(size);
                    Console.WriteLine("Talle editado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El nombre que ingresó ya existe, intentelo nuevamente");

                }

            }
            else
            {
                Console.WriteLine("El talle que desea editar no existe.");
            }
            Thread.Sleep(2000);
        }

        private static void EliminarTalle()
        {
            Console.WriteLine("ELIMINAR UN TALLE...");
            MostrarTalles();
            var id = ConsoleExtensions.ReadInt("Ingrese el ID del talle que desea eliminar: ");
            try
            {
                var servicio = servicioProvider?.GetService<ISizesService>();
                var size = servicio?.GetSizePorId(id);

                if (size != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(size))
                        {
                            servicio.Eliminar(size);
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

        private static void MostrarTallesPaginados()
        {
            var servicio = servicioProvider?.GetService<ISizesService>();
            var sizes = servicio?.GetSizes();

            var CantidadRegistros = servicio?.GetCantidad() ?? 0;
            var CantidadDePaginas = CalcularCantidadPaginas(CantidadRegistros, pageSize);

            for (int page = 0; page < CantidadDePaginas; page++)
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE TALLER:");
                Console.WriteLine($"Página: {page + 1}");
                var sizesPaginados = servicio?.GetSizesPaginadosOrdenados(page, pageSize);


                var tabla = new ConsoleTable("ID", "TALLE");

                if (sizesPaginados != null)
                {
                    foreach (var s in sizesPaginados)
                    {
                        tabla.AddRow(s.SizeId, s.SizeNumber);
                    }
                }

                tabla.Options.EnableCount = false;
                tabla.Write();
                Console.WriteLine($"Cantidad: {servicio?.GetCantidad()}");
                ConsoleExtensions.Enter();
            }
        }


        //----------------- GENRES
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
                if (!servicio.GetGenres().Any(s => s.GenreName == nuevoName))
                {
                    genre.GenreName = nuevoName;
                    servicio?.Guardar(genre);
                    Console.WriteLine("Genero editado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El nombre que ingresó ya existe, intentelo nuevamente");

                }

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



        //----------------- SPORTS
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
                if (!servicio.GetSports().Any(s => s.SportName == nuevoName))
                {
                    sport.SportName = nuevoName;

                    servicio?.Guardar(sport);
                    Console.WriteLine("Deporte editado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El nombre que ingresó ya existe, intentelo nuevamente");

                }
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


        //----------------- COLOURS
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

                if (!servicio.GetColours().Any(s => s.ColourName == nuevoName))
                {
                    colour.ColourName = nuevoName;
                    servicio?.Guardar(colour);
                    Console.WriteLine("Color editado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El nombre que ingresó ya existe, intentelo nuevamente");

                }
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


        //----------------- BRANDS
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
                if (!servicio.GetBrands().Any(s => s.BrandName == nuevoName))
                {
                    brand.BrandName = nuevoName;
                    servicio?.Guardar(brand);
                    Console.WriteLine("Marca editada satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("El nombre que ingresó ya existe, intentelo nuevamente");
                }
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


        //----------------- METODOS DE VALIDACIÓN
        public static object Validar<T>(T obj, Entidad? tipo = null)
        {
            bool seguir = false;

            if (obj is string model)
            {
                do
                {
                    if (model.Length > 150)
                    {
                        Console.WriteLine("El modelo debe tener menos de 150 caracteres.");
                        Console.Write("Ingrese nuevamente: ");
                        seguir = true;

                    }
                    else
                    {
                        seguir = false;
                    }

                } while (seguir);
                return model;
            }
            else if (obj is decimal precio)
            {
                do
                {
                    if (precio < 0)
                    {
                        Console.WriteLine("El precio debe ser mayor a 0.");
                        Console.Write("Ingrese nuevamente: ");
                        seguir = true;
                    }
                    else
                    {
                        seguir = false;
                    }

                } while (seguir);
                return precio;
            }
            else if (obj is int id)
            {
                do
                {
                    seguir = !ValidarId(id, tipo);

                    if (seguir)
                    {
                        Console.WriteLine($"El ID ingresado no existe.");
                        Console.Write("Ingrese nuevamente: ");
                        id = int.Parse(Console.ReadLine());
                    }

                } while (seguir);

                return id;
            }
            else
            {
                return null;
            }
        }

        private static bool ValidarId(int id, Entidad? tipo)
        {
            switch (tipo)
            {
                case Entidad.Marca:
                    var servicioBrands = servicioProvider.GetService<IBrandsService>();
                    return servicioBrands.GetBrands().Any(b => b.BrandId == id);

                case Entidad.Deporte:
                    var servicioSports = servicioProvider.GetService<ISportsService>();
                    return servicioSports.GetSports().Any(s => s.SportId == id);

                case Entidad.Genero:
                    var servicioGenres = servicioProvider.GetService<IGenresService>();
                    return servicioGenres.GetGenres().Any(g => g.GenreId == id);

                case Entidad.Color:
                    var servicioColours = servicioProvider.GetService<IColoursService>();
                    return servicioColours.GetColours().Any(c => c.ColourId == id);

                default:
                    return false;
            }
        }


        //---------------- PAGINADO
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

        private static void TablaDeZapatos(List<Shoe>? shoes)
        {
            var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "COLOR", "MODELO", "DESCRIPCION", "PRECIO");

            foreach (var s in shoes)
            {
                tabla.AddRow(s.ShoeId,
                    s.Brand.BrandName,
                    s.Sport.SportName,
                    s.Genre.GenreName,
                    s.Colour.ColourName,
                    s.Model,
                    s.Description.Length <= 28 ? s.Description : s.Description.Substring(0, 28) + "...",
                    //s.Description,
                    s.Price);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }


        //ACLARACIÓN: HAY MUCHO CÓDIGO QUE TODAVIA PUEDE SIMPLIFICARSE EN MÉTODOS.
    }

}
