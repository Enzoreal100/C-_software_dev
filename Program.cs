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
// Console.WriteLine("Digite um número que queira ver a tabuada");
// string userInput = Console.ReadLine();

// // converter diretamente para int --> Convert.ToInt32
// if (int.TryParse(userInput, out int num))
// {
//     Console.WriteLine($"Tabuada do {userInput}");
//     for (int multiplier = 0; multiplier <= 10; multiplier++)
//     {
//         Console.WriteLine($"{num} x {multiplier} = {num*multiplier}");
//     }
// }
// else Console.WriteLine("Digite apenas números");

// programa que calcule a soma dos numeros do array

// int[] nums = {10, 20, 30, 40, 50};
// int soma = 0;
// foreach(int i in nums) soma += i;
// Console.WriteLine($"A soma dos números é {soma}");

// Criar um rograma que só aceita numeros positivos, continua solicitando novo valor

int num;

do
{
    Console.WriteLine("Digite um número positivo");
    num = Convert.ToInt32(Console.ReadLine());

    if (num < 0)
    {
        Console.WriteLine("Número inválido");
    }
} while (num < 0);
Console.WriteLine($"Numero escolhido: {num}");