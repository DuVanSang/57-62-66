using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

public class bài63
{
    public static bool WriteDictionaryToJson(Dictionary<string, string> dictionary, string fileName)
    {
        try
        {
            string jsonText = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            File.WriteAllText(fileName, jsonText);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi ghi file JSON: " + ex.Message);
            return false;
        }
    }

    public static void Main(string[] args)
    {
        string fileName = "output.json"; // Tên file JSON để ghi

        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" }
        };

        bool result = WriteDictionaryToJson(dict, fileName);

        if (result)
        {
            Console.WriteLine("Ghi file JSON thành công.");
        }
        else
        {
            Console.WriteLine("Ghi file JSON thất bại.");
        }
    }
}

