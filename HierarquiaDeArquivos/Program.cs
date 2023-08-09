using HierarquiaDeArquivos.Classes;
using System;
using System.IO;
using System.Threading;

namespace HierarquiaDeArquivos
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite a pasta que ira ser vasculhada:");
                string rootPath = Console.ReadLine();

                var reader = new DirectoryReader(rootPath);

                var root = reader.GetRootDirectoryData();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
