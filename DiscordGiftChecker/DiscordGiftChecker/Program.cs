using System;
using System.Net;

namespace DiscordGiftGenerator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("<--|   Checker de Gifts Discord   |-->\n<--|  https://github.com/20cmDuro |-->\n");
            if(File.Exists("./gifts.txt")) {
                Console.WriteLine("Verificando os gifts...");
                foreach (string l in System.IO.File.ReadAllLines("./gifts.txt")) {
                    using var client = new HttpClient();
                    string code = l.Replace("https://discord.gift/", "");
                    HttpResponseMessage res = await client.GetAsync($"https://discordapp.com/api/v6/entitlements/gift-codes/{code}");
                    if (res.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"O gift [https://discord.gift/{code}] é válido!");
                    } else if(res.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        Console.WriteLine("Demasiados requests! (...)");
                        Thread.Sleep(60000);
                        Console.WriteLine("Voltando a verificar.");
                    }
                    Thread.Sleep(1500); // Conseguir uns requests extra, se for tudo sem delay terá TimeOut bem mais rápido.
                }
                Console.WriteLine("Gifts verificados com sucesso!");
            } else {
                Console.WriteLine("Não foi possível achar 'gifts.txt'.");
            }
            Console.ReadKey();
        }
    }
}