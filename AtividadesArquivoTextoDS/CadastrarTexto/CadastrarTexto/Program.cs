﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CadastrarTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaração de váriavies -- Exercício 1 
            string msgDig = "";
            int menu;
            bool sair = false;

            //Declaração de váriaveis -- Exercício 2
            int idade = 0;
            string nome = "nome", email = "email@email.com";

            //MENU
            Console.Clear();
            Console.WriteLine("==== MENU ===\n[ 1 ] Gravar mensagem\n[ 2 ] Ler um TXT\n[ 0 ] Sair");
            Console.Write("Digite a opção desejada: "); menu = int.Parse(Console.ReadLine());

            //Opções do MENU
            do
            {
                switch (menu)
                {
                    case 0:
                        sair = true;
                        break;

                    case 1:
                        Console.Clear();
                        Console.Write("Digite a mensagem: "); msgDig = Console.ReadLine(); //Recebe as informações na var 'msgDig'
                        StreamWriter mensagem = new StreamWriter(@"C:\Users\Usuario\Desktop\AtividadesArquivoTextoDS\CadastrarTexto\CadastrarTexto\arquivosTexto\arquivo.txt", true); //Declara o objeto writer 'mensagem'
                        mensagem.WriteLine(msgDig); //Passa o texto da var msgDig para o objeto writer mensagem
                        mensagem.Close();
                        break;

                    case 2:
                        StreamReader lerMsg = new StreamReader(@"C:\Users\Usuario\Desktop\AtividadesArquivoTextoDS\CadastrarTexto\CadastrarTexto\arquivosTexto\arquivo.txt");
                        while (!lerMsg.EndOfStream)
                        {
                            string linha = lerMsg.ReadLine();
                            Console.WriteLine(linha);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite as informações pedidas: ");
                        Console.Write("\nNome: "); nome = Console.ReadLine();
                        Console.Write("\nEmail: "); email = Console.ReadLine();
                        Console.Write("\nIdade: "); idade = int.Parse(Console.ReadLine());

                        FileStream stream1 = new FileStream(@"C:\Users\Usuario\Desktop\AtividadesArquivoTextoDS\CadastrarTexto\CadastrarTexto\arquivosTexto\arquivo.bin", FileMode.Create);
                        BinaryWriter writer = new BinaryWriter(stream1);
                        writer.Write(nome);
                        writer.Write(email);
                        writer.Write(idade);
                        writer.Flush();
                        writer.Close();
                        break;

                    case 4:
                        FileStream stream2 = new FileStream(@"C:\Users\Usuario\Desktop\AtividadesArquivoTextoDS\CadastrarTexto\CadastrarTexto\arquivosTexto\arquivo.bin", FileMode.Open);
                        BinaryReader reader = new BinaryReader(stream2);

                        string nome1 = reader.ReadString();
                        string email1 = reader.ReadString();
                        int idade1 = reader.ReadInt32();

                        reader.Close();

                        Console.Write($"Informações do arquivo bin:\nNome: {nome1}\nEmail: {email1}\nIdade: {idade1}");

                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (sair != false);
            Console.ReadKey();

        }
    }
}