using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (File.Exists("./teste.txt"))
                File.Delete("./teste.txt");

            await WriteFileAsync();

            Console.WriteLine($"{Environment.NewLine}--{Environment.NewLine}");

            await ReadFileAsync();

            Console.ReadLine();

        }

        static async Task WriteFileAsync()
        {
            Console.WriteLine("Iniciando teste de escrita");

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Escrevendo arquivo
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("./", "teste.txt")))
            {
                for (int i = 1; i < 5_000_001; i++)
                {
                    await outputFile.WriteLineAsync($"linha {i}");
                }
            }

            stopWatch.Stop();

            // Tempo decorridp.
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("Teste finalizado");

            // Formatando o tempo para exibir no console.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);

            Console.WriteLine("Tempo de execução: " + elapsedTime);
        }

        static async Task ReadFileAsync()
        {
            Console.WriteLine("Iniciando teste de leitura");

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Lendo arquivo
            var text = await File.ReadAllTextAsync("./teste.txt");

            stopWatch.Stop();

            // Tempo decorridp.
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("Teste finalizado");

            // Formatando o tempo para exibir no console.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);

            Console.WriteLine("Tempo de execução: " + elapsedTime);
        }
    }
}
