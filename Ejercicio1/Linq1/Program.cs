var frutas = new string[]
{
    "Mango", "Fresa", "Banano", "Sandia","Mango de Azucar", "Mango Tomy"
};
var MangoList = frutas.Where(p => p.StartsWith("Mango")).ToList();
MangoList.ForEach(p =>Console.WriteLine(p));

