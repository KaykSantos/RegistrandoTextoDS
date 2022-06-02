using System;
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

            //Declaração de váriaveis -- Exercício 2
            int idade = 0;
            string nome = "nome", email = "email@email.com";

            //MENU
            Console.Clear();
            Console.WriteLine("============= MENU ============\n[ 1 ] Gravar mensagem em um TXT\n[ 2 ] Ler um arquivo TXT\n[ 3 ] Gravar em um binário\n[ 4 ] Ler um arquivo binário\n[ 0 ] Sair");
            Console.Write("\nDigite a opção desejada: "); menu = int.Parse(Console.ReadLine());

            //Opções do MENU
            switch (menu)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                    
                case 1:
                    Console.Clear();
                    Console.Write("Digite a mensagem: "); msgDig = Console.ReadLine(); //Recebe as informações na var 'msgDig'
                    StreamWriter mensagem = new StreamWriter(@"C:\Users\Aluno\Desktop\CadastrarTexto\arquivos\arquivo.txt", true); //Declara o objeto writer 'mensagem' -- Caminho onde ficará o arquivo
                    mensagem.WriteLine(msgDig); //Passa o texto da var msgDig para o objeto writer mensagem
                    mensagem.Close();
                    break;

                case 2:
                    //Erro na hora da leitura pode ser problema: no caminho do arquivo, ou se ele existe
                    StreamReader lerMsg = new StreamReader(@"C:\Users\Aluno\Desktop\CadastrarTexto\arquivos\arquivo.txt"); //Caminho de onde está o arquivo para ser lido
                    while (!lerMsg.EndOfStream)
                    {
                        string linha = lerMsg.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Texto do arquivo: \n\n{linha}");
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Digite as informações pedidas: ");
                    Console.Write("\nNome: "); nome = Console.ReadLine();
                    Console.Write("\nEmail: "); email = Console.ReadLine();
                    Console.Write("\nIdade: "); idade = int.Parse(Console.ReadLine());

                    FileStream arqBin = new FileStream(@"C:\Users\Aluno\Desktop\CadastrarTexto\arquivos\arquivo.bin", FileMode.Create); 
                    BinaryWriter writer = new BinaryWriter(arqBin);
                    writer.Write(nome);
                    writer.Write(email);
                    writer.Write(idade);
                    writer.Flush();
                    writer.Close();
                    break;

                case 4:
                    //Erro na hora da leitura pode ser problema: no caminho do arquivo, ou se ele existe
                    FileStream arqBinAb = new FileStream(@"C:\Users\Aluno\Desktop\CadastrarTexto\arquivos\arquivo.bin", FileMode.Open);
                    BinaryReader reader = new BinaryReader(arqBinAb);

                    string nome1 = reader.ReadString();
                    string email1 = reader.ReadString();
                    int idade1 = reader.ReadInt32();

                    reader.Close();
                    Console.Clear();
                    Console.Write($"Informações do arquivo bin:\n\nNome: {nome1}\n\nEmail: {email1}\n\nIdade: {idade1}");

                    break;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
