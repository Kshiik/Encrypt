using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (Aes aes = Aes.Create())
            //{
            //    byte[] key =
            //    {
            //        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            //        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            //    };
            //    aes.Key = key;

            //    byte[] iv = aes.IV;
            //}
            

            string textEncrypt = "text texttext texttexttext texttexttexttext"; //что нужно зашифровать
            //string textDecrypt; //зашифрованая строка
            //int numb = 0;
            ////textEncrypt = Console.ReadLine();
            ////string[] blocks = textEncrypt.Split();
            //foreach (var item in textEncrypt)
            //{
            //    if (numb == 16)
            //    {
            //        Console.WriteLine();
            //        numb = 0;
            //    }
            //    Console.WriteLine(item);
            //    numb++;
            //}

            Aes aes = Aes.Create();
            Console.WriteLine($"{aes.GetType()}");
            Console.WriteLine($"Размер ключа: {aes.KeySize}");
            Console.WriteLine($"Размер блока: {aes.BlockSize}");
            Console.WriteLine($"Режим работы: {aes.Mode}");
            Console.WriteLine("Размеры ключей, поддерживаемые симметричным алгоритмом:");
            foreach (var keySize in aes.LegalKeySizes)
            {
                Console.WriteLine($"{keySize.MinSize} - {keySize.MaxSize} бит (с шагом {keySize.SkipSize})");
            }
            Console.WriteLine("Размеры блоков, поддерживаемые симметричным алгоритмом:");
            foreach (var blockSize in aes.LegalBlockSizes)
            {
                Console.WriteLine($"{blockSize.MinSize} - {blockSize.MaxSize} бит");
            }

            Console.ReadKey();
        }
    }
}
