using AnimalNameFilter;

Querys querys = new Querys();
PrintValues(querys.AllCollection());
PrintValues(querys.AnimalColorGreenAndVowel());
PrintValues(querys.AnimalOrderByName());

// filters all green animals whose name starts with a vowel
void PrintValues(IEnumerable<Animal> ListAnimal)
{
    Console.WriteLine("{0,-60} {1,15}\n", "Name", "Color");

    foreach (var item in ListAnimal)
    {
        Console.WriteLine("{0,-60} {1,15}\n", item.Name, item.Color);
    }
}