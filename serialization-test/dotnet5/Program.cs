using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace dotnet5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var people = await DeserializeAsyncTest("sample.json");

            Console.WriteLine($"{Environment.NewLine}--{Environment.NewLine}");

            SerializeTest(people);

            Console.WriteLine($"{Environment.NewLine}--{Environment.NewLine}");

            await NewtonsoftDeserializeAsyncTest("sample.json");

            Console.WriteLine($"{Environment.NewLine}--{Environment.NewLine}");

            NewtonsoftSerializeTest(people);

            Console.ReadLine();

        }

        static async Task<Person[]> DeserializeAsyncTest(string filePath)
        {
            Console.WriteLine("Iniciando teste de deserialização");

            // Lendo arquivo
            var texto = await File.ReadAllTextAsync(filePath);
            var json = new MemoryStream();
            var writer = new StreamWriter(json);
            writer.Write(texto);
            writer.Flush();
            json.Position = 0;

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatchTotal = new Stopwatch();
            stopWatchTotal.Start();

            var objeto = await System.Text.Json.JsonSerializer.DeserializeAsync<Person[]>(json);

            stopWatchTotal.Stop();

            // Tempo decorrido.
            TimeSpan ts = stopWatchTotal.Elapsed;

            // Formatando o tempo para exibir no console.
            Console.WriteLine($"Tempo de execução: {ts.Milliseconds}ms");

            Console.WriteLine("Teste finalizado");

            return objeto;
        }

        static async Task<Person[]> NewtonsoftDeserializeAsyncTest(string filePath)
        {
            Console.WriteLine("Newtonsoft - Iniciando teste de deserialização");

            // Lendo arquivo
            var json = await File.ReadAllTextAsync(filePath);

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatchTotal = new Stopwatch();
            stopWatchTotal.Start();

            var objeto = Newtonsoft.Json.JsonConvert.DeserializeObject<Person[]>(json);

            stopWatchTotal.Stop();

            // Tempo decorrido.
            TimeSpan ts = stopWatchTotal.Elapsed;

            // Formatando o tempo para exibir no console.
            Console.WriteLine($"Newtonsoft - Tempo de execução: {ts.Milliseconds}ms");

            Console.WriteLine("Teste finalizado");

            return objeto;
        }

        static void SerializeTest(Person[] people)
        {
            Console.WriteLine("Iniciando teste de serialização");

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatchTotal = new Stopwatch();
            stopWatchTotal.Start();

            var json = System.Text.Json.JsonSerializer.Serialize(people);

            stopWatchTotal.Stop();

            // Tempo decorrido.
            TimeSpan ts = stopWatchTotal.Elapsed;

            // Formatando o tempo para exibir no console.
            Console.WriteLine($"Tempo de execução: {ts.Milliseconds}ms");

            Console.WriteLine("Teste finalizado");
        }

        static void NewtonsoftSerializeTest(Person[] people)
        {
            Console.WriteLine("Newtonsoft - Iniciando teste de serialização");

            // Monitorar tempo de escrita e leitura de arquivo
            Stopwatch stopWatchTotal = new Stopwatch();
            stopWatchTotal.Start();

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(people);

            stopWatchTotal.Stop();

            // Tempo decorrido.
            TimeSpan ts = stopWatchTotal.Elapsed;

            // Formatando o tempo para exibir no console.
            Console.WriteLine($"Tempo de execução: {ts.Milliseconds}ms");

            Console.WriteLine("Teste finalizado");
        }
    }

    public class Person
    {
        public string _id { get; set; }
        public int index { get; set; }
        public string guid { get; set; }
        public bool isActive { get; set; }
        public string balance { get; set; }
        public string picture { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string registered { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string[] tags { get; set; }
        public Friend[] friends { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }

    public class Friend
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
