using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Questao02
{
    static void Main()
    {
        string caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string caminhoMatrizDistancias = Path.Combine(caminhoDesktop, "matriz.txt");
        string[]? arrayDistancias = Arquivo.CarregarArquivo(caminhoMatrizDistancias);
        string caminhoPercurso = Path.Combine(caminhoDesktop, "caminho.txt");
        string[]? percursoInformado = Arquivo.CarregarArquivo(caminhoPercurso);
        int distancia = 0;

        if (arrayDistancias == null || percursoInformado == null)
        {
            Console.WriteLine("Matriz e/ou caminho não encontrados! Crie o arquivo matriz.txt e caminho.txt no desktop.");
            return;
        }

        int[][] distancias = new int[arrayDistancias.Length][];
        int[] percurso = percursoInformado[0].Split(',').ToInt();
        int contador = 0;

        foreach (string line in arrayDistancias)
        {
            distancias[contador] = line.Split(',').ToInt();
            contador++;
        }
        for (int i = 1; i < percurso.Length; i++)
        {
            distancia += distancias[percurso[i - 1] - 1][percurso[i] - 1];
        }
        Console.WriteLine($"A distância total percorrida foi de {distancia} km.");
    }
}
public static class Arquivo
{
    public static string[]? CarregarArquivo(string caminho)
    {
        try
        {
            return File.ReadAllLines(caminho);
        }
        catch
        {
            return null;
        }
    }
}


public static class Utils
{
    public static int[] ToInt(this string[] strings)
    {
        int[] val = new int[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            int.TryParse(strings[i], out val[i]);
        }
        return val;
    }
}
