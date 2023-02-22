using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnimalNameFilter
{
    public class Querys
    {
        List<Animal> animales = new List<Animal>();
        public Querys() {
            animales.Add(new Animal() { Name = "Hormiga", Color = "Rojo" });
            animales.Add(new Animal() { Name = "Lobo", Color = "Gris" });
            animales.Add(new Animal() { Name = "Elefante", Color = "Gris" });
            animales.Add(new Animal() { Name = "Pantegra", Color = "Negro" });
            animales.Add(new Animal() { Name = "Gato", Color = "Negro" });
            animales.Add(new Animal() { Name = "Iguana", Color = "Verde" });
            animales.Add(new Animal() { Name = "Sapo", Color = "Verde" });
            animales.Add(new Animal() { Name = "Camaleon", Color = "Verde" });
            animales.Add(new Animal() { Name = "Gallina", Color = "Blanco" });
        }

        public IEnumerable<Animal> AllCollection()
        {
            return animales;
        }

        public IEnumerable<Animal> AnimalColorGreenAndVowel()
        {
            return animales.Where(p => p.Color.Contains("Verde") && (p.Name.StartsWith("A")|| p.Name.StartsWith("E")|| p.Name.StartsWith("I")|| p.Name.StartsWith("O")|| p.Name.StartsWith("U")));
        }

        public IEnumerable<Animal> AnimalOrderByName()
        {
            return animales.OrderBy(p => p.Name);
        }
    }
}
