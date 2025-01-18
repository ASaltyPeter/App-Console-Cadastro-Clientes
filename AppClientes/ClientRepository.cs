using Registering;

namespace Repository{

    public class ClientRepository
    {

        public List<Client> Clients = [];

        public static void PrintClient(Client client) 
        {   
            Console.WriteLine("..................................................");
            Console.WriteLine("ID................: " + client.Id);
            Console.WriteLine("Nome..............: " + client.Name);
            Console.WriteLine("Disconto..........: " + client.Discount.ToString());
            Console.WriteLine("Data de Nascimento: " + client.BirthDate);
            Console.WriteLine("Data de Registro..: " + client.RegistrationDateAndTime);
            Console.WriteLine("..................................................");
        }

        public void ListClients()
        {        
            Console.Clear();
            Console.WriteLine("Clientes Cadastrados:");

            foreach (var client in Clients)
            {
                PrintClient(client);
            }

            Console.ReadKey();

        }

        public void AddClient()
        {
            Console.Clear();
            Console.WriteLine("Iniciando o Registro de um Novo Cliente...");

            Console.WriteLine("Digite o Nome do Cliente:");
            var Name = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("Digite a Data de Nascimento (dd/MM/yyyy):");
            var BirthDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Digite o Desconto (%):");
            var Discount = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            var client = new Client();
            client.Id = Clients.Count + 1;
            client.Name = Name;
            client.BirthDate = BirthDate;
            client.Discount = Discount;
            client.RegistrationDateAndTime = DateTime.Now;
            
            Clients.Add(client);

            Console.WriteLine("Cliente cadastrado com sucesso!");
            PrintClient(client);
            
            Console.WriteLine("Pressione uma tecla pra voltar ao menu anterior.");
            Console.ReadKey();
            
        }
        
        public void UpdateClient()
        {
            Console.Clear();
            Console.WriteLine("Atualizando dados de um Cliente...");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Digite o ID do Cliente:");
            var ClientId = int.Parse(Console.ReadLine());

            var Client = Clients.FirstOrDefault(c => c.Id == ClientId);

            if (Client == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.WriteLine("Pressione uma tecla para voltar ao menu anterior.");
                Console.ReadKey();
                return;
            }
            
            PrintClient(Client);

            Console.WriteLine("Digite o novo Nome para registro no Cadastro do Cliente:");
            Client.Name = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("Digite a nova Data de Nascimento (dd/MM/yyyy):");
            Client.BirthDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("Digite o novo Desconto (%):");
            Client.Discount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Cliente atualizado com sucesso!");
            PrintClient(Client);
            
            Console.WriteLine("Pressione uma tecla pra voltar ao menu anterior.");
            Console.ReadKey();
        }

        public void DeleteClient()
        {
            Console.Clear();
            Console.WriteLine("Deletando o registro de um cliente...");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Digite o ID do Cliente:");
            var ClientId = int.Parse(Console.ReadLine());

            var Client = Clients.FirstOrDefault(c => c.Id == ClientId);

            if (Client == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.WriteLine("Pressione uma tecla para voltar ao menu anterior.");
                Console.ReadKey();
                return;
            }
            
            PrintClient(Client);

            Clients.Remove(Client);

            Console.WriteLine("Cliente deletado com sucesso!");
            
            Console.WriteLine("Pressione uma tecla pra voltar ao menu anterior.");
            Console.ReadKey();
        }

        public void SaveData()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(Clients);
            File.WriteAllText("clients.txt", json);
        }
        
        public void LoadData()
        {
            if (File.Exists("clients.txt"))
            {
                var json = File.ReadAllText("clients.txt");
                Clients = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(json);
            }
        }
    }
}