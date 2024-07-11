using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static double[,] ReadCsvTo2DArray(string fileName)
    {
        try
        {
            List<List<double>> rows = new List<List<double>>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                bool isFirstLine = true;

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] values = line.Split(',');

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue; // Bỏ qua header nếu có
                    }

                    List<double> row = new List<double>();
                    foreach (var value in values)
                    {
                        if (double.TryParse(value, out double num))
                        {
                            row.Add(num);
                        }
                        else
                        {
                            Console.WriteLine($"Giá trị '{value}' không hợp lệ.");
                            return null;
                        }
                    }
                    rows.Add(row);
                }
            }

            int maxCols = rows.Count > 0 ? rows[0].Count : 0;
            double[,] array = new double[rows.Count, maxCols];

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Count; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc file CSV: " + ex.Message);
            return null;
        }
    }

    // Hàm in mảng 2 chiều để kiểm tra kết quả
    public static void Print2DArray(double[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        // Đoạn code ghi file và gọi hàm WriteDictionaryToCsv đã được đưa ở phần trước

        // Gọi hàm đọc file CSV để kiểm tra
        string csvFileName = "input.csv"; // Tên file CSV để đọc
        double[,] array = ReadCsvTo2DArray(csvFileName);

        if (array != null)
        {
            Console.WriteLine("Đọc file CSV thành công. Dữ liệu từ file:");
            Print2DArray(array);
        }
        else
        {
            Console.WriteLine("Đọc file CSV thất bại.");
        }
    }
}

