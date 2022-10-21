using System.Collections.Generic;
using System.IO;

namespace CandidateTesting.RaelSantos.iTaas.Utils
{
    public static class FileUtils
    {
        public static void EscreverArquivo(string filePath, string dado)
        {
            using var file = File.AppendText(filePath);
            file.Write(dado);
            file.Close();
        }

        public static void EscreverArquivo(string filePath, List<string> dados)
        {
            using var file = File.AppendText(filePath);

            foreach (var item in dados)
                file.WriteLine(item);

            file.Close();
        }

        public static string[] LerArquivo(string filePath)
        {
            var _array = new List<string>();
            using var file = new StreamReader(filePath);
            string? line;

            while ((line = file.ReadLine()) != null)
                _array.Add(line);

            file.Close();

            return _array.ToArray();
        }

        public static void CriarDiretorio(string filePath)
        {
            var exists = File.Exists(filePath);

            if (!exists)
                Directory.CreateDirectory(filePath);
        }
    }
}
