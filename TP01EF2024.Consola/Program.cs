

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
                Console.WriteLine("21. Mostrar los Zapatos POR MARCA");
                Console.WriteLine("22. Mostrar los Zapatos POR DEPORTE");
                Console.WriteLine("23. Mostrar los Zapatos POR GENERO");
                Console.WriteLine("24. Mostrar los Zapatos POR MARCA entre 2 precios");
                Console.WriteLine();

//TP de EF Core Nro 2
//Nota: Todos los listados deben estar paginados.
//1.Mostrar las zapatillas por Marca.
//2.Mostrar las zapatillas por Marca entre 2 precios cualesquiera.
//3.Mostrar las zapatillas por Genero.
//4.Mostrar las zapatillas por Deporte.
//5.Considerar las combinaciones que pudieren haber, esto es, mostrar las zapatillas por
//Genero y Deporte.

                Console.WriteLine("PRESIONE X PARA SALIR");
                Console.Write("Por favor, seleccione una opción: ");
                string? input = Console.ReadLine();

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
                        MostrarZapatosPorMarca();
                        ConsoleExtensions.Enter();
                        break;
                    case "24":
                        Console.Clear();
                        var precioD = ConsoleExtensions.ReadDecimal("Buscar Zapatos por precio desde:");
                        var precioH = ConsoleExtensions.ReadDecimal("Hasta:");
                        MostrarZapatosPorMarca(precioD, precioH);
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
                    tabla.AddRow(s.ShoeId, s.Brand.BrandName, s.Sport.SportName, s.Genre.GenreName,s.Model,s.Description,s.Price);
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

        private static void MostrarZapatosPorMarca(decimal? precioDesde = null, decimal? precioHasta = null)
        {
            MostrarMarcas();
            var servicioMarcas = servicioProvider?.GetService<IBrandsService>();      

            //var lista= (servicioMarcas?.GetBrands().Select(b => b.BrandId.ToString()));

            var brandId = ConsoleExtensions.ReadInt("Ingrese el ID de la marca para ver los zapatos disponibles:");
            
            Brand? brand = servicioMarcas?.GetBrandPorId(brandId);

            if (brand != null)
            {
                List<Shoe>? shoes;

                if (precioDesde != null && precioHasta != null)
                {
                    shoes = servicioMarcas?.GetShoesForPrice(brand, precioDesde, precioHasta);
                }
                else
                {
                    shoes = servicioMarcas?.GetShoes(brand);

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
                    Console.WriteLine($"No existen zapatos de la marca {brand.BrandId} con precio entre ${precioDesde} y ${precioHasta}");
                }


            }
            else
            {
                Console.WriteLine("La marca que ha seleccionado no existe.");
            }

        }

        private static void MostrarZapatosPorDeporte()
        {
            MostrarDeportes();
            var servicioDeportes = servicioProvider?.GetService<ISportsService>();

            var sportId = ConsoleExtensions.ReadInt("Ingrese el ID del deporte para ver los zapatos disponibles:");

            Sport? sport = servicioDeportes?.GetSportPorId(sportId);

            if (sport != null)
            {

                List<Shoe>? shoes = servicioDeportes?.GetShoes(sport);

                Console.WriteLine("Listado de Zapatos");

                var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");
                if (shoes != null)
                {
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


            }
            else
            {
                Console.WriteLine("El deporte que ha seleccionado no existe.");
            }

        }

        private static void MostrarZapatosPorGenero()
        {
            MostrarGeneros();
            var servicioGeneros = servicioProvider?.GetService<IGenresService>();

            var genreId = ConsoleExtensions.ReadInt("Ingrese el ID del genero para ver los zapatos disponibles:");

            Genre? genre = servicioGeneros?.GetGenrePorId(genreId);

            if (genre != null)
            {

                List<Shoe>? shoes = servicioGeneros?.GetShoes(genre);

                Console.WriteLine("Listado de Zapatos");

                var tabla = new ConsoleTable("ID", "MARCA", "DEPORTE", "GENERO", "MODELO", "DESCRIPCION", "PRECIO");
                if (shoes != null)
                {
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


            }
            else
            {
                Console.WriteLine("El genero que ha seleccionado no existe.");
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
    }
}
