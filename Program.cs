Console.WriteLine("=== Estacionamento ===");

Console.Write("Tamanho do veículo (P/G): ");
char tamanho = char.ToLower(Console.ReadKey().KeyChar);
Console.Write("\nTempo de permanência (min): ");
decimal minutos = decimal.Parse(Console.ReadLine() ?? "0");

Console.Write("Serviço de valet (S/N): ");
char valet = char.ToLower(Console.ReadKey().KeyChar);
Console.Write("\nServiço de lavagem (S/N): ");
char lavagem = char.ToLower(Console.ReadKey().KeyChar);
Console.WriteLine();

if (minutos > 720)
{
    Console.WriteLine("\n[ERRO] Tempo de permanência não pode exceder 12 horas.");
    return;
}

decimal horas = Math.Round(minutos / 60, MidpointRounding.AwayFromZero);
decimal estacionamento = 0, valorValet = 0, valorLavagem = 0;

// Cálculo do estacionamento
if (tamanho == 'g')
{
    estacionamento = horas >= 5 ? 80 :
                     horas <= 1 ? 20 :
                     20 + (horas - 1) * 20;
}
else if (tamanho == 'p')
{
    estacionamento = horas >= 5 ? 50 :
                     horas <= 1 ? 20 :
                     20 + (horas - 1) * 10;
}
else
{
    Console.WriteLine("\n[ERRO] Tamanho inválido! Use 'P' para pequeno ou 'G' para grande.");
    return;
}

// Serviços extras
if (valet == 's') valorValet = estacionamento * 0.20m;
if (lavagem == 's') valorLavagem = (tamanho == 'g') ? 100 : 50;

// Total
decimal total = estacionamento + valorValet + valorLavagem;

// Saída final
Console.WriteLine("\n=== Resumo ===");
Console.WriteLine($"Estacionamento: R$ {estacionamento:F2}");
Console.WriteLine($"Valet.........: R$ {valorValet:F2}");
Console.WriteLine($"Lavagem.......: R$ {valorLavagem:F2}");
Console.WriteLine("---------------------------");
Console.WriteLine($"TOTAL.........: R$ {total:F2}");


