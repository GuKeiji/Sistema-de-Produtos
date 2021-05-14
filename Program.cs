using System;

namespace AtividadeDeSexta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fazer array backup
            // ou somar capacidadeArray com a capacidade anterior
            // Eu mudei as posições da array para capacidadeArray: no for, na setagem, e recebimento de métodos
            int capacidadeArray = 10;
            int validarAumentoLista = 0;
            int i2 = 0;
            bool check = true;
            int selecionar;
            string[] nome = new string[capacidadeArray];
            double[] Preco = new double[capacidadeArray];
            bool[] Promocao = new bool[capacidadeArray];
            string[] validarPromocao = new string[capacidadeArray];
            string[] mostrarPromocao = new string[capacidadeArray];
            while (check == true)
            {
                MostrarMenu();
                Array.Resize(ref nome, capacidadeArray);
                Array.Resize(ref Preco, capacidadeArray);
                Array.Resize(ref Promocao, capacidadeArray);
                Array.Resize(ref validarPromocao, capacidadeArray);
                Array.Resize(ref mostrarPromocao, capacidadeArray);
                // Console.WriteLine(i2);
                selecionar = int.Parse(Console.ReadLine());
                if (selecionar == 1)
                {
                    i2 = CadastrarProduto(nome, Preco, Promocao, validarPromocao, mostrarPromocao, i2, capacidadeArray);
                }
                else if (selecionar == 2)
                {
                    ListarProduto(nome, Preco, Promocao, i2, mostrarPromocao);
                }
                else if (selecionar == 3)
                {
                    Console.WriteLine("Qual capacidade da lista deseja colocar?");
                    validarAumentoLista = int.Parse(Console.ReadLine());
                    if (validarAumentoLista > capacidadeArray)
                    {
                        capacidadeArray = validarAumentoLista;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida, a nova capacidade deve ser maior que a anterior");
                    }
                }
                else
                {
                    check = false;
                }

            }
        }
        static int CadastrarProduto(string[] nome, double[] Preco, bool[] Promocao, string[] validarPromocao, string[] mostrarPromocao, int i2, int capacidadeArray)
        {
            string resposta = "";
            Console.WriteLine($"Você pode cadastrar até {capacidadeArray} itens");
            for (var i = i2; i < capacidadeArray; i++)
            {
                Console.WriteLine($"Digite o nome do {i + 1}º produto:");
                nome[i] = Console.ReadLine();
                Console.WriteLine($"Digite o preço do {i + 1}º produto:");
                Preco[i] = float.Parse(Console.ReadLine());
                Console.WriteLine($"Digite se o {i + 1}º produto está em promoção: (S/N)");
                validarPromocao[i] = Console.ReadLine().ToLower();
                if (validarPromocao[i] == "s")
                {
                    Promocao[i] = true;
                }
                else
                {
                    Promocao[i] = false;
                }
                if (Promocao[i] == true)
                {
                    mostrarPromocao[i] = "Está em promoção";
                }
                else
                {
                    mostrarPromocao[i] = "Não está em promoção";
                }
                Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
                resposta = Console.ReadLine().ToLower();
                i2++;
                // Console.WriteLine(nome[i]);
                // Console.WriteLine(Preco[i]);
                // Console.WriteLine(Promocao[i]);
                if (resposta == "n")
                {
                    break;
                }
                else if (i2 == capacidadeArray)
                {
                    Console.WriteLine($"Você já cadastrou {capacidadeArray} itens, para cadastrar mais, favor aumentar capacidade no menu");
                }
            }
            return i2;
        }
        static void MostrarMenu()
        {
            Console.WriteLine($@"
+----------------------------------------------------------------------------------------------+
|   1-CADASTRAR PRODUTO        2-LISTAR PRODUTO           3-AUMENTAR LISTA           0-SAIR    |        
+----------------------------------------------------------------------------------------------+

Escolha uma das opções:
                ");
        }
        static void ListarProduto(string[] nome, double[] Preco, bool[] Promocao, int i2, string[] mostrarPromocao)
        {
            for (var i = 0; i < i2; i++)
            {

                Console.WriteLine($@"
----------------------------
|   {i + 1}º Produto          |        
|--------------------------|    
|      {nome[i]}           |
|      R${Preco[i]}         |
|      {mostrarPromocao[i]}        |
----------------------------
                            ");
            }
        }
    }
}
