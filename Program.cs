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
        using var csvDistancias = new CsvReader(readerDistancias, config);
        using var readerCaminho = new StreamReader(caminhoPercurso);
        using var csvCaminho = new CsvReader(readerCaminho, config);
        int contadorDistancias = 0;
        int contadorCaminho = 0;
        int dimensaoMatriz = 0;
        int dimensaoCaminho = 0;
        int distancia = 0;
        int i = 0;
        csvDistancias.Read();
        csvCaminho.Read();

        while (contadorDistancias != 1)
        {
            try
            {
                csvDistancias.GetField<int>(dimensaoMatriz);
                dimensaoMatriz++;
            }
            catch
            {
                contadorDistancias++;
            }
        }

        int[,] distancias = new int[dimensaoMatriz, dimensaoMatriz];

        do
        {
            for (int j = 0; j < dimensaoMatriz; j++)
            {
                distancias[i, j] = csvDistancias.GetField<int>(j);
            }
            i++;
        }while(csvDistancias.Read());

        while (contadorCaminho != 1)
        {
            try
            {
                csvCaminho.GetField<int>(dimensaoCaminho);
                dimensaoCaminho++;
            }
            catch
            {
                contadorCaminho++;
            }
        }

        int[] percurso = new int[dimensaoCaminho];

        do
        {
            for (int j = 0; j < dimensaoCaminho; j++)
            {
                percurso[j] = csvCaminho.GetField<int>(j);
            }
            i++;
        } while (csvCaminho.Read());

        for (int j = 1; j < percurso.Length; j++)
        {
            distancia += distancias[percurso[j - 1] - 1, percurso[j] - 1];
        }
        Console.WriteLine($"A distância total percorrida foi de {distancia} km.");
    }
}
