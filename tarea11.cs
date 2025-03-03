using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Diccionario inicial inglés-español y español-inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño/a"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        while (true)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la frase: ");
                    string frase = Console.ReadLine();
                    string fraseTraducida = TraducirFrase(frase, diccionario);
                    Console.WriteLine("Su frase traducida es: " + fraseTraducida);
                    EsperarTecla();
                    break;

                case "2":
                    AgregarPalabra(diccionario);
                    EsperarTecla();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opción inválida!");
                    EsperarTecla();
                    break;
            }
        }
    }

    static string TraducirFrase(string frase, Dictionary<string, string> diccionario)
    {
        StringBuilder fraseTraducida = new StringBuilder();
        string[] palabras = frase.Split(' ');

        foreach (string palabra in palabras)
        {
            string palabraLimpiada = palabra.ToLower().Trim(new char[] { '.', ',', '!', '?' });
            if (diccionario.ContainsKey(palabraLimpiada))
            {
                fraseTraducida.Append(diccionario[palabraLimpiada] + " ");
            }
            else
            {
                // Verificar si la palabra está en español y traducir al inglés
                string traduccionIngles = ObtenerTraduccionIngles(palabraLimpiada, diccionario);
                if (!string.IsNullOrEmpty(traduccionIngles))
                {
                    fraseTraducida.Append(traduccionIngles + " ");
                }
                else
                {
                    fraseTraducida.Append(palabra + " "); // Si no se encuentra, se deja la palabra original
                }
            }
        }

        return fraseTraducida.ToString().Trim();
    }

    static string ObtenerTraduccionIngles(string palabra, Dictionary<string, string> diccionario)
    {
        foreach (var par in diccionario)
        {
            if (par.Value.Equals(palabra, StringComparison.OrdinalIgnoreCase))
            {
                return par.Key; // Retorna la clave (palabra en inglés)
            }
        }
        return null; // No se encontró traducción
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese palabra en inglés: ");
        string palabraEnIngles = Console.ReadLine().ToLower();
        Console.Write("Ingrese traducción en español: ");
        string palabraEnEspanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(palabraEnIngles))
        {
            diccionario.Add(palabraEnIngles, palabraEnEspanol);
            Console.WriteLine("Palabra agregada exitosamente!");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario!");
        }
    }

    static void EsperarTecla()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
