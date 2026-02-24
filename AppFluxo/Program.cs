// Console.WriteLine("Digite um numero inteiro para verificar se o num é par ou impar");
// string userInput = Console.ReadLine();

// if (int.TryParse(userInput, out int num))
// {
//     int module = num % 2;
//     string output = module == 0 ? "É par" : "É impar";
//     Console.Write(output);
// }
// else Console.WriteLine("Digite apenas números");

//  programa que imprima a tabuada de um número
Console.WriteLine("Digite um número que queira ver a tabuada");
string userInput = Console.ReadLine();

// converter diretamente para int --> Convert.ToInt32
if (int.TryParse(userInput, out int num))
{
    Console.WriteLine($"Tabuada do {userInput}");
    for (int multiplier = 0; multiplier <= 10; multiplier++)
    {
        Console.WriteLine($"{num} x {multiplier} = {num*multiplier}");
    }
}
else Console.WriteLine("Digite apenas números");