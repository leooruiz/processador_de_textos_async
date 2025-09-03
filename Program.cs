using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("== Processador assíncrono de arquivos de texto ===");
        Console.Write("Informe o caminho de um diretório contendo arquivos .txt: ");
        string? diretorioPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(diretorioPath) || !Directory.Exists(diretorioPath))
        {
            Console.WriteLine("Diretório inválido ou não encontrado.");
            return;
        }

        var arquivosTxt = Directory.GetFiles(diretorioPath, "*.txt");

        if (arquivosTxt.Length == 0)
        {
            Console.WriteLine("Nenhum arquivo .txt encontrado no diretório.");
            return;
        }

        Console.WriteLine($"\nArquivos .txt encontrados: {arquivosTxt.Length}");
        foreach (var arquivo in arquivosTxt)
        {
            Console.WriteLine($"- {Path.GetFileName(arquivo)}");
        }
        Console.WriteLine("\nIniciando processamento...");

        var exportDir = Path.Combine(AppContext.BaseDirectory, "export");
        Directory.CreateDirectory(exportDir);
        var relatorioPath = Path.Combine(exportDir, "relatorio.txt");

        var stopwatch = Stopwatch.StartNew();
        var tasks = new List<Task<string>>();

        foreach (var arquivoPath in arquivosTxt)
        {
            tasks.Add(ProcessarArquivoAsync(arquivoPath));
        }

        var resultados = await Task.WhenAll(tasks);

        await File.WriteAllLinesAsync(relatorioPath, resultados.Where(r => !string.IsNullOrEmpty(r)));

        stopwatch.Stop();

        Console.WriteLine("\nProcessamento concluído com sucesso!");
        Console.WriteLine($"Tempo total: {stopwatch.Elapsed.TotalSeconds:F2} segundos.");
        Console.WriteLine($"Relatório gerado em: {relatorioPath}");
    }

    static async Task<string> ProcessarArquivoAsync(string arquivoPath)
    {
        var nomeArquivo = Path.GetFileName(arquivoPath);
        Console.WriteLine($"Processando: {nomeArquivo} ...");

        try
        {
            var conteudo = await File.ReadAllTextAsync(arquivoPath);
            var numeroLinhas = conteudo.Split('\n').Length;
            var numeroPalavras = conteudo.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

            var resultado = $"{nomeArquivo} - {numeroLinhas} linhas - {numeroPalavras} palavras";
            Console.WriteLine($"Concluído: {resultado}");
            return resultado;
        }
        catch (Exception ex)
        {
            var erroMsg = $"Erro ao processar o arquivo {nomeArquivo}: {ex.Message}";
            Console.WriteLine(erroMsg);
            return erroMsg;
        }
    }
}
