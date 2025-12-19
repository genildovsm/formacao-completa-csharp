using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string diretorioArquivo = Path.Combine(Environment.CurrentDirectory, "samples");
        string nomeArquivo = "lorem.txt";
        string caminhoArquivo = Path.Combine(diretorioArquivo, nomeArquivo);

        while (true)
        {
            Console.WriteLine("\nDiretório do arquivo: " + diretorioArquivo + "\n");

            Console.WriteLine("Selecione uma opção: \n------\n" +
                            "[1] Criar arquivo\n" +
                            "[2] Gravar em arquivo\n" +
                            "[3] Ler arquivo\n" +
                            "[4] Procurar texto em arquivo\n" +
                            "[0] Sair\n"
            );

            int op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 0:
                    return;

                case 1:
                    CriarArquivo(caminhoArquivo);
                    break;

                case 2:
                    await GravarEmArquivo(caminhoArquivo);
                    break;

                case 3:
                    await LerArquivo(caminhoArquivo);
                    break;

                case 4:
                    await ProcurarTexto(caminhoArquivo);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        static void CriarArquivo(string arquivo)
        {
            try
            {
                string nome = new FileInfo(arquivo).Name;

                using (FileStream fs = new(arquivo, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Console.WriteLine($"Arquivo \"{nome}\" criado com sucesso.");
                }
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro na criação do arquivo.");
            }
        }

        static async Task GravarEmArquivo(string arquivo)
        {
            string nomeArquivo = new FileInfo(arquivo).Name;
            Console.WriteLine("Informe o texto a ser gravado: ");
            string? texto = Console.ReadLine();

            try
            {
                using (FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, true))
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8, 65536))
                {
                    await writer.WriteLineAsync(texto);
                    Console.WriteLine($"Texto gravado no arquivo \"{nomeArquivo}\"");
                }
            }
            catch
            {
                Console.WriteLine($"Ocorreu um erro ao gravar em \"{nomeArquivo}\"");
            }
        }

        static async Task LerArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine($"Arquivo \"{new FileInfo(arquivo).Name}\" não encontrado");
                return;
            }

            string nomeArquivo = new FileInfo(arquivo).Name;

            try
            {
                using (StreamReader reader = new StreamReader(arquivo))
                {
                    string? linha;

                    while ((linha = await reader.ReadLineAsync()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo \"{nomeArquivo}\"");
            }
        }

        static async Task ProcurarTexto(string arquivo)
        {
            Console.Write("Informe o texto a ser localizado: ");
            string textoProcurado = Console.ReadLine() ?? "";

            if (!File.Exists(arquivo))
            {
                Console.WriteLine($"Arquivo \"{new FileInfo(arquivo).Name}\" não encontrado");
                return;
            }

            string nomeArquivo = new FileInfo(arquivo).Name;

            try
            {
                bool encontrado = false;

                using (StreamReader reader = new StreamReader(arquivo, Encoding.UTF8))
                {
                    string? linha;
                    int nrLinha = 0;

                    while ((linha = await reader.ReadLineAsync()) != null)
                    {
                        nrLinha++;

                        if (linha.Length > 0 && linha.Contains(textoProcurado))
                        {
                            Console.WriteLine($"Linha [{nrLinha}]: {linha}");
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine($"Texto não foi localizado no arquivo \"{nomeArquivo}\"");
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Ocorreu um erro ao realizar busca no arquivo \"{nomeArquivo}\"");
            }
        }
    }
}
