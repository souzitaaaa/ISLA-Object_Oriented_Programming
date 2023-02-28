using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net.Security;
using System.Net.Sockets;

namespace Aula01
{
    class Program
    {
        static int i = 0;
        public struct colaborador
        {
            public int codigo;
            public string nome;
            public int idade;
            public double vencimento;
        }
        public static string menu()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("MENU DE OPÇÕES");
            Console.WriteLine("a) Inserir colaborador");
            Console.WriteLine("b) Listar colaboradores");
            Console.WriteLine("c) Colaborador com maior vencimento");
            Console.WriteLine("d) Média de vencimentos");
            Console.WriteLine("e) Sair");
            Console.WriteLine("");
            string option = Console.ReadLine();
            return option;
        }
        public static void InsertCollab(colaborador[] sColab, int nColab)
        {
            bool repeat = true;
            while (repeat)
            {
                if (i < nColab)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"{i + 1}º Colaborador");
                    Console.WriteLine("Insira o código: ");
                    sColab[i].codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o nome: ");
                    sColab[i].nome = Console.ReadLine();
                    Console.WriteLine("Insira a idade: ");
                    sColab[i].idade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o vencimento: ");
                    sColab[i].vencimento = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------");
                    i++;
                }
                else
                {
                    Console.WriteLine("Chegou ao máximo de colaboradores!");
                    break;
                }
                Console.WriteLine("Continuar a adicionar colaboradores? sim ou não: ");
                string input = Console.ReadLine();
                repeat = input.Equals("sim", StringComparison.OrdinalIgnoreCase);
            }
        }
        public static void ListCollab(colaborador[] sColab, int nColab)
        {
            int pos = -1;
            if (sColab[0].codigo == 0)
            {
                Console.WriteLine("Ainda não foi inserido nenhum Colaborador");
                return;
            }
            while (pos++ < i - 1)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Código: {sColab[pos].codigo}");
                Console.WriteLine($"Nome: {sColab[pos].nome}");
                Console.WriteLine($"Idade: {sColab[pos].idade}");
                Console.WriteLine($"Vencimento: {sColab[pos].vencimento}");
            }
        }
        public static void BiggerVenc(colaborador[] sColab, int nColab)
        {
            int pos = 0;
            int bigger = 0;

            bigger = 0;
            pos = 0;
            while (pos++ < i - 1) 
            {
                if (sColab[pos].vencimento > sColab[bigger].vencimento)
                    bigger = pos;
            }
            Console.WriteLine($"O colaborador com maior vencimento é o {sColab[bigger].nome}, com {sColab[bigger].vencimento}$");
        }
        public static void AverageVenc(colaborador[] sColab, int nColab)
        {
            int pos = -1;
            double average = 0;
            double som = 0;
            while (pos++ < i - 1)
            {
                som += sColab[pos].vencimento;
            }
            average = som / pos;
            Console.WriteLine($"A média do vencimento é {average}$");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicação para gestão de colaboradores");
            Console.WriteLine("Quantos colaboradores existem?:");
            int nColab = Convert.ToInt32(Console.ReadLine());

            colaborador[] sColab = new colaborador[nColab];

            string option = "";

            Console.Clear();
            while (true)
            {
                option = menu();
                switch (option)
                {
                    case "a":
                        InsertCollab(sColab, nColab);
                        break;
                    case "b":
                        ListCollab(sColab, nColab);
                        break;
                    case "c":
                        BiggerVenc(sColab, nColab);
                        break;
                    case "d":
                        AverageVenc(sColab, nColab);
                        break;
                    case "e":
                        return;
                }
            }

        }
    }
}