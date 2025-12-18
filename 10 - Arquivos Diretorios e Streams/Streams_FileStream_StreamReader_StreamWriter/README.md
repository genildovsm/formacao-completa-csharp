# FileStream

Fornece um stream para um arquivo, dando suporte a operações de leitura e gravação síncronas e assíncronas. ESta classe deriva da classe **Stream**.
  
>**Nota:** Um stream é uma sequência de (bytes) que pode ser lida ou escrita em partes menores. A classe **Stream** é a classe base para todos os streams.
  
Ela pode ser usada para ler, gravar, abrir e fechar arquivos em um sistema de arquivos, e para tratar com outros manipuladores do sistema operacional relacionados a arquivos, incluindo **pipes**, a entrada padrão e a saída padrão.

### StreamReader

É uma classe auxiliar usada para ler caracteres de um Stream, convertendo bytes em caracteres usando um valor codificado e pode ser usada para ler strings de diferentes Streams como FileStream, MemoryStream, etc.

### StreamWriter

É uma classe auxiliar usada para gravar uma string em um Stream, convertendo caracteres em bytes, e pode ser usada para gravar strings em diferentes Streams, como FileStream, MemoryStream, etc.

>**Fluxo:** *Primeiro deve-se criar um FileStream associado a um arquivo específico, depois usar as classes StreamReader ou StreamWriter para ler ou gravar dados do stream.*

