using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PruebaCosas
{
    class Prueba
    {
        static void Main(string[] args)
        {
            string librosPath = "C:/Users/Maybe/documents/visual studio 2015/Projects/PruebaCosas/PruebaCosas/.net/Libros.txt";
            List<string> todosLibrosString = new List<string>((File.ReadAllLines(librosPath)));
            List<Libro> todosLibros = new List<Libro>();
            todosLibros.AddRange(from string s in todosLibrosString select (new Libro(s.Split(':'))));
            IEnumerable<Libro> listaLibrosQueYoQuiero = todosLibros.Where(libroAcutal => libroAcutal.categoria == "Cultura").OrderByDescending(i => i.precio );
            foreach(Libro libro in listaLibrosQueYoQuiero)
            {
                Console.WriteLine(libro.titulo + "   " + libro.precio);
            }
            todosLibros.Add (new Libro(new string[] { "a", "b", "c", "1", "2", "d", "Cultura", "3" }));
            Console.WriteLine("\nAqui meto un nuevo libro\n");
            foreach (Libro libro in listaLibrosQueYoQuiero)
            {
                Console.WriteLine(libro.titulo + "   " + libro.precio);
            }
            Console.ReadKey();
        }
    }
}

