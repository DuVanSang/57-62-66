using System;
using System.IO;

public class bài64
{
    public static bool Write2DArrayToCsv(float[,] array, string fileName)
    {
        try
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j > 0)
                            sw.Write(",");
                        sw.Write(array[i, j]);
                    }
                    sw.WriteLine();
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi ghi file CSV: " + ex.Message);
            return false;
        }
    }

    public static void Main(string[] args)
    {
        string fileName = "output.csv"; // Tên file CSV để ghi

        float[,] array = {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        bool result = Write2DArrayToCsv(array, fileName);

        if (result)
        {
            Console.WriteLine("Ghi file CSV thành công.");
        }
        else
        {
            Console.WriteLine("Ghi file CSV thất bại.");
        }
    }
}
