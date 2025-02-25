using System;
using System.IO;
using System.Security.Cryptography;

namespace GetChecksumMD5
{
    class Program
    {
        static void Main(string[] args)
        {
            string version = "1.0.0";

            string rootPath = Directory.GetCurrentDirectory();

            string checkMD5(string filename)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg == "-v" || arg == "-ver" || arg == "-version")
                {
                    Console.WriteLine("Version");
                    Console.WriteLine($"v{version}");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Drag and drop your file onto this EXE to get checksum");
                Console.ReadKey();
                Environment.Exit(0);
            }
            string path = args[0];
            Console.WriteLine($"Calculating file: \"{path}\"");
            Console.WriteLine("This may take a while depending on the file size.");
            Console.WriteLine();
            Console.WriteLine($"{checkMD5(path)}");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}