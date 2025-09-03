# Processador Assíncrono de Arquivos de Texto

## Resumo do Projeto

Este projeto é uma aplicação de console desenvolvida em C# com .NET 9, criada como parte de um desafio de programação. A aplicação tem como objetivo processar múltiplos arquivos de texto (`.txt`) de forma assíncrona e paralela para contar o número de linhas e palavras em cada um. Ao final, gera um relatório consolidado com os resultados.

## Funcionalidades

- **Entrada de Diretório:** Solicita ao usuário que forneça o caminho de um diretório no computador.
- **Busca de Arquivos:** Localiza e lista todos os arquivos com a extensão `.txt` presentes no diretório especificado.
- **Processamento Assíncrono:** Utiliza `async/await` para processar cada arquivo em paralelo, garantindo que a interface do console permaneça responsiva e não "congele" durante a execução.
- **Feedback em Tempo Real:** Exibe mensagens no console indicando o início e a conclusão do processamento de cada arquivo.
- **Geração de Relatório:** Calcula a quantidade total de linhas e palavras para cada arquivo e salva os resultados em um arquivo `relatorio.txt`.
- **Organização de Saída:** O relatório gerado é salvo em uma pasta `./export/`, criada no mesmo diretório onde a aplicação está sendo executada.

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET 9
- **Projeto:** Console App

## Como Executar

### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior.

### Passos

1. **Clone o repositório (ou baixe os arquivos do projeto):**

    ```bash
    git clone <URL_DO_SEU_REPOSITORIO>
    cd <NOME_DA_PASTA_DO_PROJETO>
    ```plaintext

2. **Navegue até a pasta do projeto:**

    ```bash
    cd ProcessadorArquivos
    ```

3. **Execute a aplicação:**

    ```bash
    dotnet run
    ```

4. **Informe o caminho:**
    Quando solicitado, insira o caminho completo do diretório que contém os arquivos `.txt` que você deseja processar.

    Exemplo de saída no console:

    ```bash
    == Processador assíncrono de arquivos de texto ===
    Informe o caminho de um diretório contendo arquivos .txt: /caminho/para/sua/pasta/de/textos

    Arquivos .txt encontrados: 1000
    - arquivo1.txt
    - arquivo10.txt
    ...

    Iniciando processamento...
    Processando: arquivo1.txt ...
    Concluído: arquivo1.txt - 18 linhas - 211 palavras
    Processando: arquivo10.txt ...
    Concluído: arquivo10.txt - 16 linhas - 193 palavras
    ...

    Processamento concluído com sucesso!
    Tempo total: X.XX segundos.
    Relatório gerado em: /caminho/do/projeto/ProcessadorArquivos/bin/Debug/net9.0/export/relatorio.txt
    ```

## Integrantes do Grupo

Leonardo de Oliveira Ruiz - RM98901

- [Nome do Integrante 1]
- [Nome do Integrante 2]
- [Adicionar mais nomes conforme necessário]
