using System;
using System.Collections.Generic;
using System.Globalization;

namespace DIO.Bank
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("	<<<< Obrigado por utilizar nossos serviços. >>>>");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("	Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("	Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			listContas[indiceConta].Depositar(valorDeposito);

			Console.WriteLine("\n	<<<< Depósito realizado com sucesso!! >>>>");
		}

		private static void Sacar()
		{
			Console.Write("	Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("	Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			listContas[indiceConta].Sacar(valorSaque);

		}

		private static void Transferir()
		{
			Console.Write("	Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("	Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("	Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

			Console.WriteLine("\n	<<<< Transferência realizada com sucesso!! >>>>");
		}

		private static void InserirConta()
		{
			Console.WriteLine("	<<<< Inserir nova conta >>>>\n");

			Console.Write("	Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("	Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("	Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			Console.Write("	Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			Console.WriteLine("\n	<<<< Cliente cadastrado com sucesso >>>>");

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}

		private static void ListarContas()
		{
			Console.WriteLine("	<<<< Listar contas >>>>");

			if (listContas.Count == 0)
			{
				Console.WriteLine("  Você ainda não cadastou nenhuma conta...\n" + "  digite a opção << 2 >> e cadastre uma nova.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("================================================");
			Console.WriteLine("	DIO BANK AO SEU DISPOR!!!");
			Console.WriteLine("================================================");

			Console.WriteLine("	1- Listar contas");
			Console.WriteLine("	2- Inserir nova conta");
			Console.WriteLine("	3- Transferir");
			Console.WriteLine("	4- Sacar");
			Console.WriteLine("	5- Depositar");
			Console.WriteLine("	C- Limpar Tela");
			Console.WriteLine("	X- Sair");
			Console.Write("	Informe a opção desejada: ");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

	}
}
