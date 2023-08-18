using System.Reflection;

Random rng = new(new Random(new Random(new Random(new Random(new Random(new Random(new Random().Next()).Next()).Next()).Next()).Next()).Next()).Next());
string pid = (rng.NextDouble() * rng.Next()).ToString();
Console.Title = $"[{Assembly.GetExecutingAssembly().GetName().Name} v{Assembly.GetExecutingAssembly().GetName().Version!.ToString().Replace(".",string.Empty).TrimEnd('0')}] Pid:{pid}";

while (true)
{
    
}