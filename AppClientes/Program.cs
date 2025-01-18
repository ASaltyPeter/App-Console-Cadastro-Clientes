namespace AppClientes;

class Program
{
    static Repository.ClientRepository _ClientRepository = new();
    static void Main(string[] args)
    {
        _ClientRepository.LoadData();
        Console.Clear();
        ApplicationMenu();
      
    }

    static void ApplicationMenu(){
          
        

        Console.WriteLine("Menu:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1. Cadastrar novo cliente");
        Console.WriteLine("2. Listar clientes");
        Console.WriteLine("3. Excluir cliente");
        Console.WriteLine("4. Atualizar cliente");
        Console.WriteLine("0. Sair");
        Console.WriteLine("--------------------------------");
        Console.Write("Escolha uma opção: ");
        int option = int.Parse(Console.ReadLine());
        
        switch (option)
        {
            case 1:
                _ClientRepository.AddClient();
                ApplicationMenu();
                break;
            case 2:
                _ClientRepository.ListClients();
                ApplicationMenu();
                break;
            case 3:
                _ClientRepository.DeleteClient();
                ApplicationMenu();
                break;
            case 4:
                _ClientRepository.UpdateClient();
                ApplicationMenu();
                break;
            case 0:
                _ClientRepository.SaveData();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida!");
                ApplicationMenu();
                break;
        }

    }
}
