using Models;
using ProducaoMel.Controller;

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
            Console.WriteLine("1 - Adicionar Colmeia");
            Console.WriteLine("2 - Atualizar Colmeia");
            Console.WriteLine("3 - Deletar Colmeia");
            Console.WriteLine("4 - Listar Colmeias");
            Console.WriteLine("5 - Visualizar Colmeia por ID");
            Console.WriteLine("6 - Voltar");
        }

        public void AdicionarColmeia()
        {
            Console.WriteLine("Digite a localização da colmeia: ");
            string localizacao = Console.ReadLine();
            Console.WriteLine("Digite a data de instalação da colmeia: ");
            DateTime dataInstalacao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número de abelhas da colmeia: ");
            int numeroAbelhas = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o estado de saúde da colmeia: ");
            string estadoSaude = Console.ReadLine();
            Console.WriteLine("Digite a espécie de abelhas da colmeia: ");
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

        }

        public void AtualizarColmeia()
        {
            Console.WriteLine("Digite o ID da colmeia que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a localização da colmeia: ");
            string localizacao = Console.ReadLine();
            Console.WriteLine("Digite a data de instalação da colmeia: ");
            DateTime dataInstalacao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número de abelhas da colmeia: ");
            int numeroAbelhas = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o estado de saúde da colmeia: ");
            string estadoSaude = Console.ReadLine();
            Console.WriteLine("Digite a espécie de abelhas da colmeia: ");
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

        public void DeletarColmeia()
        {
            Console.WriteLine("Digite o ID da colmeia que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            _colmeiaController.DeleteColmeia(id);
        }

        public void ListarColmeias()
        {
            List<Colmeia> colmeias = _colmeiaController.GetAllColmeias();
            foreach (var colmeia in colmeias)
            {
                Console.WriteLine("ID: " + colmeia.ID);
                Console.WriteLine("Localização: " + colmeia.Localizacao);
                Console.WriteLine("Data de Instalação: " + colmeia.DataInstalacao);
                Console.WriteLine("Número de abelhas: " + colmeia.NumeroAbelhas);
                Console.WriteLine("Estado de saúde: " + colmeia.EstadoSaude);
                Console.WriteLine("Espécie de abelhas: " + colmeia.EspecieAbelhas);
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public void VisualizarColmeia()
        {
            Console.WriteLine("Digite o ID da colmeia que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Colmeia colmeia = _colmeiaController.GetColmeiaById(id);
            Console.WriteLine("ID: " + colmeia.ID);
            Console.WriteLine("Localização: " + colmeia.Localizacao);
            Console.WriteLine("Data de Instalação: " + colmeia.DataInstalacao);
            Console.WriteLine("Número de abelhas: " + colmeia.NumeroAbelhas);
            Console.WriteLine("Estado de saúde: " + colmeia.EstadoSaude);
            Console.WriteLine("Espécie de abelhas: " + colmeia.EspecieAbelhas);
        }

        public void ExecutarMenuColmeia()
        {
            int opcao = 0;
            do
            {
                MenuColmeia();
                opcao = int.Parse(Console.ReadLine());
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
            } while (opcao != 5);
        }
    }
}
