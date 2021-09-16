using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1" :
                        ListarContas();
                        break;
                    case "2" :
                        InserirConta();
                        break;
                    case "3" :
                        Transferir();
                        break;
                    case "4" :
                        Sacar();
                        break;
                    case "5" :
                        Depositar();
                        break;
                    case "C" :
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nosso serviços :) ");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da sua Conta: ");
            int indiceMinhaConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta a RECEBER a transferencia: ");
            int indiceContaRecebe = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceMinhaConta].Transferir(valorTransferencia: valorTransferencia, contaDestino: listContas[indiceContaRecebe]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado nessa: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
 
        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas: ");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} . ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.WriteLine("Digite 1 para pessoa fisica e 2 para pessoa juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o deposito inicial para criação da conta: ");
            double entradaDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito disponibilizado inicialmente: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta
            (tipoConta: (TipoConta)entradaTipoConta, saldo: entradaDeposito, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Banco Bank");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir Nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
