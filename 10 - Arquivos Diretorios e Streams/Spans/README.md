# Span\<T> e ReadOnlySpan\<T>

- Span<T> é um ref struct que representa uma região contígua de memória.
- É uma janela direta para uma porção da memória existente (array, string, buffer ...)
- Trabalha com partes de grandes blocos de dados **sem precisar copiá-los**.
- Não aloca memória Heap reduzindo a pressão sobre o Garbage Collector.
- É um tipo seguro e isso impede erros comuns de acessos à memória.
- Reside na stack, uma área de memória super rápida e de curta duração.
- ReadOnlySpan\<T> é a versão somente leitura de Span\<T>.  

### Principais recursos do Span\<T>

**.AsSpan() -** Método de extensão que permite obter uma Span\<T> ou ReadOnlySpan\<T> a partir de diversas coleções e tipos de dados existentes. (Array, int, string, etc.)
  
**.Slice(int start) -** Permite obter uma nova "visão" (um novo Span) que começa em um índice especificado e se estende até o final do Span original.
  
**.Slice(int start, int length) -** Cria uma nova "visão" (Span\<T> ou ReadOnlySpan\<T>) que cobre uma porção exata dos dados originais, começando em start e com o length especificado, sem alocar memória nova.

**.IndexOf(T value) -** Encontra a primeira ocorrência de um valor ou de uma sequência de valores dentro do Span.
  
Referência: [Acelere seu código com Span e ReadOnlySpan](https://www.youtube.com/watch?v=YdWyquvIbZA) (Youtube)
