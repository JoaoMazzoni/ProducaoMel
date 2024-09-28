using Models;
using ProducaoMel.Controller;

namespace ProducaoMel.Views
{
    public class FloresView
    {
        private FloresController _floresController;

        public FloresView()
        {
            _floresController = new FloresController();
        }

        public void MenuFlores()
        {
            Console.WriteLine("1 - Adicionar Flores");
            Console.WriteLine("2 - Atualizar Flores");
            Console.WriteLine("3 - Deletar Flores");
            Console.WriteLine("4 - Listar Flores");
            Console.WriteLine("5 - Visualizar Flor por ID");
            Console.WriteLine("6 - Voltar");
        }

        public void AdicionarFlores()
        {
            Console.WriteLine("Digite o nome da flor: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo da flor: ");
            string tipo = Console.ReadLine();
            Console.WriteLine("Digite o período de floração da flor: ");
            string periodoFloracao = Console.ReadLine();
            Console.WriteLine("Digite a origem da flor: ");
            string origem = Console.ReadLine();
            Console.WriteLine("A flor atrai abelhas: ");
            Console.WriteLine("\n1 - Sim");
            Console.WriteLine("2 - Não");
            Console.WriteLine("Digite a resposta: ");
            string atracaoAbelhasToBool = Console.ReadLine();
            bool atracaoAbelhas = atracaoAbelhasToBool == "1" ? true : false;

            Flores flores = new Flores
            {
                Nome = nome,
                Tipo = tipo,
                PeriodoFloracao = periodoFloracao,
                Origem = origem,
                AtracaoAbelhas = atracaoAbelhas
            };

            _floresController.AddFlores(flores);

        }

        public void AtualizarFlores()
        {
            Console.WriteLine("Digite o ID da flor que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome da flor: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo da flor: ");
            string tipo = Console.ReadLine();
            Console.WriteLine("Digite o período de floração da flor: ");
            string periodoFloracao = Console.ReadLine();
            Console.WriteLine("Digite a origem da flor: ");
            string origem = Console.ReadLine();
            Console.WriteLine("A flor atrai abelhas: ");
            Console.WriteLine("\n1 - Sim");
            Console.WriteLine("2 - Não");
            Console.WriteLine("Digite a resposta: ");
            string atracaoAbelhasToBool = Console.ReadLine();
            bool atracaoAbelhas = atracaoAbelhasToBool == "1" ? true : false;

            Flores flores = new Flores
            {
                ID = id,
                Nome = nome,
                Tipo = tipo,
                PeriodoFloracao = periodoFloracao,
                Origem = origem,
                AtracaoAbelhas = atracaoAbelhas
            };

            _floresController.UpdateFlores(flores);
        }

        public void DeletarFlores()
        {
            Console.WriteLine("Digite o ID da flor que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            _floresController.DeleteFlores(id);
        }

        public void ListarFlores()
        {
            var flores = _floresController.GetAllFlores();

            foreach (var flor in flores)
            {
                Console.WriteLine("ID: " + flor.ID);
                Console.WriteLine("Nome: " + flor.Nome);
                Console.WriteLine("Tipo: " + flor.Tipo);
                Console.WriteLine("Período de floração: " + flor.PeriodoFloracao);
                Console.WriteLine("Origem: " + flor.Origem);
                Console.WriteLine("Atrai abelhas: " + (flor.AtracaoAbelhas ? "Sim" : "Não"));
                Console.WriteLine();
            }
        }

        public void VisualizarFlor()
        {
            Console.WriteLine("Digite o ID da flor que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Flores flores = _floresController.GetFloresById(id);
            Console.WriteLine("ID: " + flores.ID);
            Console.WriteLine("Nome: " + flores.Nome);
            Console.WriteLine("Tipo: " + flores.Tipo);
            Console.WriteLine("Período de floração: " + flores.PeriodoFloracao);
            Console.WriteLine("Origem: " + flores.Origem);
            Console.WriteLine("Atrai abelhas: " + (flores.AtracaoAbelhas ? "Sim" : "Não"));
        }

        public void ExecutarMenuFlores()
        {
            int opcao = 0;
            do
            {
                MenuFlores();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        AdicionarFlores();
                        break;
                    case 2:
                        AtualizarFlores();
                        break;
                    case 3:
                        DeletarFlores();
                        break;
                    case 4:
                        ListarFlores();
                        break;
                    case 5:
                        VisualizarFlor();
                        break;
                    case 6:
                        break;
                }
            } while (opcao != 5);
        }
    }
}
