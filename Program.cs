// DateTime ultimoLogin = DateTime.Now;

// Console.WriteLine($"Último login {ultimoLogin}");
// TimeOnly abertura = new TimeOnly(10, 30);
// TimeOnly fechamento = new TimeOnly(16, 00);

// TimeSpan tempoTrabalhado = fechamento - abertura;
// Console.WriteLine($"tempo de trabalho: {tempoTrabalhado}");


// // Simular um pedido
// TimeOnly horarioAbertura = new TimeOnly(10, 30);
// TimeOnly horarioFechamento = new TimeOnly(22, 00);
// DateTime agora = DateTime.Now;
// TimeOnly pedidoHora = TimeOnly.FromDateTime(agora);
// bool estaAberto = pedidoHora >= horarioAbertura && pedidoHora <= horarioFechamento;
// string estadoRestaurante = estaAberto ? "Aberto" : "Fechado";
// Console.WriteLine($"O restaurante está {estadoRestaurante}");

// DateTimeOffset dataPedido = DateTimeOffset.Now;
// Console.WriteLine($"Horário do pedido (local): {dataPedido}");
// TimeSpan deslocamento = dataPedido.Offset;
// TimeZoneInfo fusoLocal = TimeZoneInfo.Local;

// Console.WriteLine($"Data e hora local: {dataPedido}");
// Console.WriteLine($"Fuso do sistema (UTC e Offset): {deslocamento}");
// Console.WriteLine($"Nome do fuso: {fusoLocal.StandardName}");

// verificador de dia da semana (averiguador de resenha!)

// using System.Globalization;

// Console.Write("Digite uma data (dd/MM/yyyy)");
// string inputData = Console.ReadLine();

// if 
// (!DateOnly.TryParseExact
//     (
//     inputData,
//     "dd/MM/yyyy",
//     CultureInfo.InvariantCulture,
//     DateTimeStyles.None,
//     out DateOnly data
//     )
// )
// {
//    Console.WriteLine("Erro: Formato de data inválido");
//    return; 
// }
// //                                 Especificador de formato
// // dd = digitos; ddd = dia abreviado; dddd =  completa
// string diaDaSemana = data.ToString("dddd", new CultureInfo("pt-BR"));

// Console.WriteLine(diaDaSemana);
// String[] diasDeResenha = {"sexta-feira", "sábado"};
// if (diasDeResenha.Contains(diaDaSemana)) Console.WriteLine("RESENHA!");

using System.Globalization;
using System.Text.Json;

Console.WriteLine("===== VERIFICADOR DE FERIADOS (API) =====");

// Solicita a data ao usuário
Console.Write("Digite uma data (dd/MM/yyyy): ");
string inputData = Console.ReadLine();

// Tenta converter a entrada para DateOnly
if (!DateOnly.TryParseExact(inputData, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly data))
{
    Console.WriteLine("Erro: Formato de data inválido! Use o formato dd/MM/yyyy.");
    return;
}

// Chama a API para buscar feriados
bool isFeriado = await VerificarFeriadoAPI(data);

if (isFeriado)
    Console.WriteLine($"{data:dd/MM/yyyy} é um feriado!");
else
    Console.WriteLine($"{data:dd/MM/yyyy} não é um feriado nacional.");


//Método assíncrono Verificar Feriado que consulta a API BrasilAPI para verificar se
//a data informada é um feriado nacional. Ele faz uma requisição HTTP GET para obter
//a lista de feriados do ano correspondente e verifica se a data está presente nessa lista.
//Se for um feriado, exibe o nome do feriado; caso contrário, informa que não é um feriado nacional.
//O método também trata possíveis erros de conexão com a API.
static async Task<bool> VerificarFeriadoAPI(DateOnly data)
{
    string url = $"https://brasilapi.com.br/api/feriados/v1/{data.Year}";

    using HttpClient client = new HttpClient();
    try
    {
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var feriados = JsonSerializer.Deserialize<Feriado[]>(jsonResponse);

            // Converte a data para string no formato "yyyy-MM-dd"
            string dataFormatada = data.ToString("yyyy-MM-dd");

            // Verifica se a data informada está na lista de feriados
            foreach (var feriado in feriados)
            {
                if (feriado.date == dataFormatada)
                {
                    Console.WriteLine($"📅 {data:dd/MM/yyyy} é um feriado nacional: {feriado.name}!");
                    return true;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
    }

    return false;
}


// Classe para deserializar os feriados da API
class Feriado
{
    public string date { get; set; }  // Formato: "yyyy-MM-dd"
    public string name { get; set; }  // Nome do feriado
}