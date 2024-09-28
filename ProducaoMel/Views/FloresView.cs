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
            Console.WriteLine("===== Gerenciamento de Flores =====\n");
            Console.WriteLine("1 - Adicionar Flores");
            Console.WriteLine("2 - Atualizar Flores");
            Console.WriteLine("3 - Deletar Flores");
            Console.WriteLine("4 - Listar Flores");
            Console.WriteLine("5 - Visualizar Flor por ID");
            Console.WriteLine("6 - Voltar");
            Console.Write("\nEscolha uma opção: ");
        }

        public void AdicionarFlores()
        {
            Console.Clear();
            Console.WriteLine("=== ADICIONAR NOVA FLOR ===\n");

            Console.Write("Digite o nome da flor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o tipo da flor: ");
            string tipo = Console.ReadLine();

            Console.Write("Digite o período de floração da flor: ");
            string periodoFloracao = Console.ReadLine();

            Console.Write("Digite a origem da flor: ");
            string origem = Console.ReadLine();

            Console.WriteLine("\nA flor atrai abelhas?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            Console.Write("Escolha uma opção: ");
            string atracaoAbelhasToBool = Console.ReadLine();
            bool atracaoAbelhas = atracaoAbelhasToBool == "1";

            Flores flores = new Flores
            {
                Nome = nome,
                Tipo = tipo,
                PeriodoFloracao = periodoFloracao,
                Origem = origem,
                AtracaoAbelhas = atracaoAbelhas
            };

            _floresController.AddFlores(flores);
            Console.Clear();
            Console.WriteLine("Flor adicionada com sucesso!\n");
        }

        public void AtualizarFlores()
        {
            Console.Clear();
            Console.WriteLine("=== ATUALIZAR FLOR ===\n");

            Console.Write("Digite o ID da flor que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            ImprimirFlorById(id);
            Console.WriteLine();

            Console.Write("Digite o nome da flor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o tipo da flor: ");
            string tipo = Console.ReadLine();

            Console.Write("Digite o período de floração da flor: ");
            string periodoFloracao = Console.ReadLine();

            Console.Write("Digite a origem da flor: ");
            string origem = Console.ReadLine();

            Console.WriteLine("\nA flor atrai abelhas?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            Console.Write("Escolha uma opção: ");
            string atracaoAbelhasToBool = Console.ReadLine();
            bool atracaoAbelhas = atracaoAbelhasToBool == "1";

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
            Console.Clear();
            Console.WriteLine("Flor atualizada com sucesso!\n");
        }

        public void DeletarFlores()
        {
            Console.Clear();
            Console.WriteLine("=== DELETAR FLOR ===\n");

            Console.Write("Digite o ID da flor que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            _floresController.DeleteFlores(id);
            Console.Clear();
            Console.WriteLine("Flor deletada com sucesso!\n");
        }

        public void ListarFlores()
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR TODAS AS FLORES ===\n");

            var flores = _floresController.GetAllFlores();
            foreach (var flor in flores)
            {
                Console.WriteLine($"ID: {flor.ID}");
                Console.WriteLine($"Nome: {flor.Nome}");
                Console.WriteLine($"Tipo: {flor.Tipo}");
                Console.WriteLine($"Período de floração: {flor.PeriodoFloracao}");
                Console.WriteLine($"Origem: {flor.Origem}");
                Console.WriteLine($"Atrai abelhas: {(flor.AtracaoAbelhas ? "Sim" : "Não")}");
                Console.WriteLine(new string('-', 30));
            }

            Console.WriteLine();
        }

        public void VisualizarFlor()
        {
            Console.Clear();
            Console.WriteLine("=== VISUALIZAR FLOR ===\n");

            Console.Write("Digite o ID da flor que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());

            Flores flores = _floresController.GetFloresById(id);

            Console.WriteLine($"ID: {flores.ID}");
            Console.WriteLine($"Nome: {flores.Nome}");
            Console.WriteLine($"Tipo: {flores.Tipo}");
            Console.WriteLine($"Período de floração: {flores.PeriodoFloracao}");
            Console.WriteLine($"Origem: {flores.Origem}");
            Console.WriteLine($"Atrai abelhas: {(flores.AtracaoAbelhas ? "Sim" : "Não")}");
            Console.WriteLine();
        }

        public void ImprimirFlorById(int id)
        {
            Flores flores = _floresController.GetFloresById(id);

            if (flores.ID == 0)
            {
                Console.WriteLine("Flor não encontrada.");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
                ExecutarMenuFlores();
            }

            Console.WriteLine("\n--- FLOR ATUAL ---\n");
            Console.WriteLine($"ID: {flores.ID}");
            Console.WriteLine($"Nome: {flores.Nome}");
            Console.WriteLine($"Tipo: {flores.Tipo}");
            Console.WriteLine($"Período de floração: {flores.PeriodoFloracao}");
            Console.WriteLine($"Origem: {flores.Origem}");
            Console.WriteLine($"Atrai abelhas: {(flores.AtracaoAbelhas ? "Sim" : "Não")}");
            Console.WriteLine();

        }

        public void ExecutarMenuFlores()
        {
            int opcao;
            do
            {
                Console.Clear();
                MenuFlores();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

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
                }

                if (opcao != 6)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcao != 6);
        }
    }
}
