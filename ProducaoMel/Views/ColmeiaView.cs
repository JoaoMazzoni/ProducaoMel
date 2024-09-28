using Models;
using ProducaoMel.Controller;
using System.Globalization;

namespace ProducaoMel.Views
{
    public class ColmeiaView
    {
        private ColmeiaController _colmeiaController;

        public ColmeiaView()
        {
            _colmeiaController = new ColmeiaController();
        }

        public void MenuColmeia()
        {
            Console.WriteLine("===== GERENCIAMENTO DE COLMEIAS =====\n");
            Console.WriteLine("1 - Adicionar Colmeia");
            Console.WriteLine("2 - Atualizar Colmeia");
            Console.WriteLine("3 - Deletar Colmeia");
            Console.WriteLine("4 - Listar Colmeias");
            Console.WriteLine("5 - Visualizar Colmeia por ID");
            Console.WriteLine("6 - Voltar");
            Console.Write("\nEscolha uma opção: ");
        }

        public void AdicionarColmeia()
        {
            Console.Clear();
            Console.WriteLine("=== ADICIONAR NOVA COLMEIA ===\n");

            Console.Write("Digite a localização da colmeia: ");
            string localizacao = Console.ReadLine();

            Console.Write("Digite a data de instalação da colmeia (dd/MM/yyyy): ");
            DateTime dataInstalacao;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInstalacao))
            {
                Console.Write("Formato inválido. Tente novamente (dd/MM/yyyy): ");
            }

            Console.Write("Digite o número de abelhas da colmeia: ");
            int numeroAbelhas = int.Parse(Console.ReadLine());

            Console.Write("Digite o estado de saúde da colmeia: ");
            string estadoSaude = Console.ReadLine();

            Console.Write("Digite a espécie de abelhas da colmeia: ");
            string especieAbelhas = Console.ReadLine();

            Colmeia colmeia = new Colmeia
            {
                Localizacao = localizacao,
                DataInstalacao = dataInstalacao,
                NumeroAbelhas = numeroAbelhas,
                EstadoSaude = estadoSaude,
                EspecieAbelhas = especieAbelhas
            };

            _colmeiaController.AddColmeia(colmeia);
            Console.Clear();
        }

        public void AtualizarColmeia()
        {
            Console.Clear();
            Console.WriteLine("=== ATUALIZAR COLMEIA ===\n");

            Console.Write("Digite o ID da colmeia que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            var colmeiaExiste = ImprimirColmeiaById(id);
            if (!colmeiaExiste)
            {
                return;
            }
            else
            {
                Console.WriteLine();

                Console.Write("Digite a localização da colmeia: ");
                string localizacao = Console.ReadLine();

                Console.Write("Digite a data de instalação da colmeia (dd/MM/yyyy): ");
                DateTime dataInstalacao;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInstalacao))
                {
                    Console.Write("Formato inválido. Tente novamente (dd/MM/yyyy): ");
                }

                Console.Write("Digite o número de abelhas da colmeia: ");
                int numeroAbelhas = int.Parse(Console.ReadLine());

                Console.Write("Digite o estado de saúde da colmeia: ");
                string estadoSaude = Console.ReadLine();

                Console.Write("Digite a espécie de abelhas da colmeia: ");
                string especieAbelhas = Console.ReadLine();

                Colmeia colmeia = new Colmeia
                {
                    ID = id,
                    Localizacao = localizacao,
                    DataInstalacao = dataInstalacao,
                    NumeroAbelhas = numeroAbelhas,
                    EstadoSaude = estadoSaude,
                    EspecieAbelhas = especieAbelhas
                };

                _colmeiaController.UpdateColmeia(colmeia);
            }
            Console.Clear();
        }

        public void DeletarColmeia()
        {
            Console.Clear();
            Console.WriteLine("=== DELETAR COLMEIA ===\n");

            Console.Write("Digite o ID da colmeia que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            _colmeiaController.DeleteColmeia(id);
            Console.Clear();
        }

        public void ListarColmeias()
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR TODAS AS COLMEIAS ===\n");

            List<Colmeia> colmeias = _colmeiaController.GetAllColmeias();
            foreach (var colmeia in colmeias)
            {
                Console.WriteLine($"ID: {colmeia.ID}");
                Console.WriteLine($"Localização: {colmeia.Localizacao}");
                Console.WriteLine($"Data de Instalação: {colmeia.DataInstalacao.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Número de abelhas: {colmeia.NumeroAbelhas}");
                Console.WriteLine($"Estado de saúde: {colmeia.EstadoSaude}");
                Console.WriteLine($"Espécie de abelhas: {colmeia.EspecieAbelhas}");
                Console.WriteLine("-------------------------------------------------");
            }

            Console.WriteLine();
            Console.Write("Pressione qualquer tecla para continuar: ");
            Console.ReadLine();
        }

        public void VisualizarColmeia()
        {
            Console.Clear();
            Console.WriteLine("=== VISUALIZAR COLMEIA ===\n");

            Console.Write("Digite o ID da colmeia que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Colmeia colmeia = _colmeiaController.GetColmeiaById(id);

            if (colmeia.ID != 0)
            {
                Console.WriteLine($"ID: {colmeia.ID}");
                Console.WriteLine($"Localização: {colmeia.Localizacao}");
                Console.WriteLine($"Data de Instalação: {colmeia.DataInstalacao.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Número de abelhas: {colmeia.NumeroAbelhas}");
                Console.WriteLine($"Estado de saúde: {colmeia.EstadoSaude}");
                Console.WriteLine($"Espécie de abelhas: {colmeia.EspecieAbelhas}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nNenhuma colmeia encontrada!");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public bool ImprimirColmeiaById(int id)
        {
            Colmeia colmeia = _colmeiaController.GetColmeiaById(id);

            if (colmeia.ID == 0)
            {
                Console.WriteLine("Colmeia não encontrada.");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
                return false;
            }

            Console.WriteLine("\n--- COLMEIA ATUAL ---\n");
            Console.WriteLine($"ID: {colmeia.ID}");
            Console.WriteLine($"Localização: {colmeia.Localizacao}");
            Console.WriteLine($"Data de Instalação: {colmeia.DataInstalacao.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Número de abelhas: {colmeia.NumeroAbelhas}");
            Console.WriteLine($"Estado de saúde: {colmeia.EstadoSaude}");
            Console.WriteLine($"Espécie de abelhas: {colmeia.EspecieAbelhas}");
            return true;
        }

        public void ExecutarMenuColmeia()
        {
            int opcao;
            do
            {
                Console.Clear();
                MenuColmeia();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        AdicionarColmeia();
                        break;
                    case 2:
                        AtualizarColmeia();
                        break;
                    case 3:
                        DeletarColmeia();
                        break;
                    case 4:
                        ListarColmeias();
                        break;
                    case 5:
                        VisualizarColmeia();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }


            } while (opcao != 6);
        }
    }
}
