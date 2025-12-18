string workDirectory = Environment.CurrentDirectory + "/" + "workDirectory";
string pathFile01 = workDirectory + "/" + "file01.txt";

if (!Directory.Exists(workDirectory))
{
    Console.WriteLine("Criando diretório de trabalho");
    Directory.CreateDirectory(workDirectory);
}

if (!File.Exists(pathFile01))
{
    Console.WriteLine("\nCriando o arquivo de trabalho");
    FileStream arquivo = File.Create(pathFile01);

    // necessário porque é retornado um FileStream após a criação
    // e o arquivo criado continua aberto, não sendo possível
    // usar o método WriteAllTextAsync() para escrita
    arquivo.Close();
    arquivo.Dispose();

    string loremIpsumText = await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory,"loremIpsum.txt"));

    await File.WriteAllTextAsync(pathFile01, loremIpsumText);
}

var info_file01 = new FileInfo(pathFile01);

Console.WriteLine(
    "\n" +
    "Metadados do arquivo: \n---------------------\n" +
    "Name: " + info_file01.Name + "\n" +
    "FullPath: " + info_file01.FullName + "\n" +
    "ReadOnly: " + info_file01.IsReadOnly + "\n" +
    "DirectoryFullName: " + info_file01.Directory?.FullName + "\n" +
    "FileSize: " + info_file01.Length + " bytes\n" +
    "LastWrite: " + info_file01.LastWriteTime + "\n" +
    "LastAccess: " + info_file01.LastAccessTime
);




Console.WriteLine("\nConcluído");
