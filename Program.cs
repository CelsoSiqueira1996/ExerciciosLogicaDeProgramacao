using System;
class Questao01
{
    static void Main()
    {
        Console.Write("Informe a quantidade de cidades: ");
        int.TryParse(Console.ReadLine(), out int numCidades);
        int[,] distancias = new int[numCidades, numCidades];
        int distancia = 0;

        for (int i = 0; i < numCidades; i++)
        {
            for (int j = i + 1; j < numCidades; j++)
            {
                Console.Write($"Informe a distância entre as cidades {i + 1} e {j + 1}: ");
                int.TryParse(Console.ReadLine(), out distancias[i, j]);
                distancias[j, i] = distancias[i, j];
            }
        }

        Console.WriteLine("\nInforme o percurso a ser executado: ");
        string percursoInformado = Console.ReadLine();
        int[] percurso = percursoInformado.Split(',').ToInt();

        for (int i = 1; i < percurso.Length; i++)
        {
            distancia += distancias[percurso[i - 1] - 1, percurso[i] - 1];
        }
        Console.WriteLine($"\nA distância total percorrida foi de {distancia} km.");
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
