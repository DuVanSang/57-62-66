using System;
using System.Collections.Generic;
using System.IO;

public class bài65
{
    public static bool WriteDictionaryToCsv(Dictionary<string, double> dictionary, string fileName)
    {
        try
        {
            // Lấy danh sách các key và value từ dictionary
            List<string> keys = new List<string>(dictionary.Keys);
            List<double> values = new List<double>(dictionary.Values);

            // Đảm bảo số lượng key và value là như nhau
            if (keys.Count != values.Count)
            {
                Console.WriteLine("Số lượng key và value không khớp.");
                return false;
            }

            // Mở file để ghi dữ liệu
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                // Viết header
                sw.WriteLine("Key,Value");

                // Viết từng dòng dữ liệu
                for (int i = 0; i < keys.Count; i++)
                {
                    sw.WriteLine($"{keys[i]},{values[i]}");
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

        Dictionary<string, double> dict = new Dictionary<string, double>
        {
            { "key1", 1.1 },
            { "key2", 2.2 },
            { "key3", 3.3 }
        };

        bool result = WriteDictionaryToCsv(dict, fileName);

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
