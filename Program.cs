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
        using var readerPercurso = new StreamReader(caminhoPercurso);
        using var csvPercurso = new CsvParser(readerPercurso, config);
        int distancia = 0;
        int i = 0;

        csvDistancias.Read();
        csvPercurso.Read();

        int dimensaoMatriz = csvDistancias.Record.GetLength(0);
        int dimensaoPercurso = csvPercurso.Record.GetLength(0);
        int[,] distancias = new int[dimensaoMatriz, dimensaoMatriz];
        int[] percurso = new int[dimensaoPercurso];

        do
        {
            for (int j = 0; j < dimensaoMatriz; j++)
            {
                int.TryParse(csvDistancias.Record[j], out distancias[i, j]);
            }
            i++;
        }while(csvDistancias.Read());

        do
        {
            for (int j = 0; j < dimensaoPercurso; j++)
            {
                int.TryParse(csvPercurso.Record[j], out percurso[j]);
            }
        } while (csvPercurso.Read());

        for (int j = 1; j < percurso.Length; j++)
        {
            distancia += distancias[percurso[j - 1] - 1, percurso[j] - 1];
        }
        Console.WriteLine($"A distância total percorrida foi de {distancia} km.");
    }
}
