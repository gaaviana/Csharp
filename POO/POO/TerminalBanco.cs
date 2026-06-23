
namespace POO
{
    public class TerminalBanco
    {
        //chamando istancia operacoes
        Operacoes banco = new Operacoes();
        public void Inicio()
        {
            var emExecucao = true;

            while (emExecucao)
            {
                DisplayMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        banco.Saldo();
                        break;

                    case "2":
                        banco.Deposito();
                        break;

                    case "3":
                        banco.Saque();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Operação invalida, tente novamente!");
                        break;

                }
            }
        }
        public void DisplayMenu()
        {
            Console.WriteLine("==========BANCO==========");
            Console.WriteLine("1 - Saldo");
            Console.WriteLine("2 - Deposito");
            Console.WriteLine("3 - Saque");
            Console.WriteLine("4 - Sair");
            Console.Write("Selecione uma opção: ");
        }
    }
}
