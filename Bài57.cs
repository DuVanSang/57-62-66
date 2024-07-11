using System;
using System.Text.Json;

class Bài57
{
    // Hàm tính toán và trả về kết quả dưới dạng JSON string
    public static string TinhToanHinhTron(double r)
    {
        double dien_tich = Math.PI * Math.Pow(r, 2);
        double chu_vi = 2 * Math.PI * r;
        double duong_kinh = 2 * r;

        var ketQua = new
        {
            dien_tich = dien_tich,
            chu_vi = chu_vi,
            duong_kinh = duong_kinh
        };

        return JsonSerializer.Serialize(ketQua);
    }

    static void Main(string[] args)
    {
        double r;
        while (true)
        {
            Console.Write("Nhập vào bán kính r: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out r) && r > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Giá trị nhập vào không hợp lệ. Vui lòng nhập lại.");
            }
        }

        string ketQuaJson = TinhToanHinhTron(r);
        Console.WriteLine("Kết quả: " + ketQuaJson);
    }
}