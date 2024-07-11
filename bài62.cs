using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

public class bài62
{
    public static Dictionary<string, string> ReadJsonFile(string fileName)
    {
        try
        {
            string jsonText = File.ReadAllText(fileName);
            Dictionary<string, string> dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
            return dictionary;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc file JSON: " + ex.Message);
            return null;
        }
    }

    public static void Main(string[] args)
    {
        string fileName = "data.json"; // Tên file JSON để đọc

        Dictionary<string, string> dict = ReadJsonFile(fileName);

        if (dict != null)
        {
            Console.WriteLine("Dữ liệu từ file JSON:");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
