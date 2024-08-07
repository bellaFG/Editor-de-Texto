using System;
using System.IO;
using System.Text;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair.");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("----------------------------------------");
            StringBuilder text = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == null)
                    break;

                text.AppendLine(line);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                    break;
            }

            Save(text.ToString());
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("1 - Escolha um caminho para salvar o arquivo");
            Console.WriteLine("0 - Não desejo salvar este arquivo");

            short options;

            if (!short.TryParse(Console.ReadLine(), out options) || (options != 0 && options != 1))
            {
                Console.WriteLine("Opção inválida. Por favor, selecione 1 para salvar ou 0 para não salvar.");
                Console.ReadLine();
                return;
            }

            if (options == 0)
            {
                Console.WriteLine("Arquivo não será salvo.");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o caminho completo para salvar o arquivo:");
            string path = Console.ReadLine();
            using (var file = new StreamWriter(path))

            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
