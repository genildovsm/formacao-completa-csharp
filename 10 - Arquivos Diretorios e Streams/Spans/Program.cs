using System.Diagnostics;

Console.WriteLine("Método tradicional usando Split e Parse\n");

// Dados de uma venda simulando registro de banco de dados ou arquivo
string linhaItem = "42|2025-03-15|3299.00|Playstation 5";

Stopwatch sw = Stopwatch.StartNew();

// Processamento ineficiente (aloca strings a cada operação)
for (int i=0; i<100_000; i++)
{
    string[] fields = linhaItem.Split("|");
    int id = int.Parse(fields[0]);
    DateTime data = DateTime.Parse(fields[1]);
    decimal preco = decimal.Parse(fields[2]);
    string produto = fields[3];
}

sw.Stop();

Console.WriteLine($"Tempo gasto: {sw.ElapsedMilliseconds}ms\n\n--------\n\n" +
                    "Método avançado (usando Span<T>)\n\n" +
                    "Para iniciar o processamento tecle algo ...\n");

sw.Restart();

for (int i=0; i<100_000; i++)
{
    ReadOnlySpan<char> registroSpan = linhaItem.AsSpan();
    int posicaoPipe = registroSpan.IndexOf("|");
    int id = int.Parse(registroSpan.Slice(0, posicaoPipe));

    ReadOnlySpan<char> parteRestante = registroSpan.Slice(posicaoPipe + 1);
    posicaoPipe = parteRestante.IndexOf("|");

    DateTime data = DateTime.Parse(parteRestante.Slice(0, posicaoPipe));

    parteRestante = parteRestante.Slice(posicaoPipe + 1);
    posicaoPipe = parteRestante.IndexOf("|");
    decimal preco = decimal.Parse(parteRestante.Slice(0, posicaoPipe));

    string produto = parteRestante.Slice(posicaoPipe + 1).ToString();
}

sw.Stop();

Console.WriteLine($"\nTempo gasto: {sw.ElapsedMilliseconds}ms\n\n" +
                    "Verificação finalizada.\n"
);

Console.ReadKey();