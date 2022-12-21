using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;

class Questao03
{
    static void Main()
    {
        string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string caminhoMatrizDistancias = Path.Combine(caminhoDesktop, "matriz.txt");
        string caminhoPercurso = Path.Combine(caminhoDesktop, "caminho.txt");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture){HasHeaderRecord = false};
        using var readerDistancias = new StreamReader(caminhoMatrizDistancias) ;
        using var csvDistancias = new CsvParser(readerDistancias, config);
        using var readerCaminho = new StreamReader(caminhoPercurso);
        using var csvCaminho = new CsvParser(readerCaminho, config);
        int dimensaoMatriz = csvDistancias.Record.GetLength(0);
        int dimensaoCaminho = csvCaminho.Record.GetLength(0);
        int distancia = 0;
        int i = 0;

        csvDistancias.Read();
        csvCaminho.Read();
        
        try
        {
            int[,] distancias = new int[dimensaoMatriz, dimensaoMatriz];
        }
        catch
        {
            Console.WriteLine("O arquivo matriz.txt está vazio!");
            return;
        }

        try
        {
            int[] percurso = new int[dimensaoCaminho];
        }
        catch
        {
            Console.WriteLine("O arquivo caminho.txt está vazio!");
            return;
        }

        do
        {
            for (int j = 0; j < dimensaoMatriz; j++)
            {
                distancias[i, j] = csvDistancias.Record[j];
            }
            i++;
        }while(csvDistancias.Read());

        do
        {
            for (int j = 0; j < dimensaoCaminho; j++)
            {
                percurso[j] = csvCaminho.Record[j];
            }
        } while (csvCaminho.Read());

        for (int j = 1; j < percurso.Length; j++)
        {
            distancia += distancias[percurso[j - 1] - 1, percurso[j] - 1];
        }
        Console.WriteLine($"A distância total percorrida foi de {distancia} km.");
    }
}
