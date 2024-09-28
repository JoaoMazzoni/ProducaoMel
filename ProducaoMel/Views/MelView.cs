using Models;
using ProducaoMel.Controller;

namespace ProducaoMel.Views
{
    public class MelView
    {
        private MelController _melController;

        public MelView()
        {
            _melController = new MelController();
        }

        public void MenuMel()
        {
            Console.WriteLine("1 - Adicionar Mel");
            Console.WriteLine("2 - Atualizar Mel");
            Console.WriteLine("3 - Deletar Mel");
            Console.WriteLine("4 - Listar Mel");
            Console.WriteLine("5 - Visualizar Mel por ID");
            Console.WriteLine("6 - Voltar");
        }

        public void AdicionarMel()
        {
            Console.WriteLine("Digite o nome do mel: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a cor do mel: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a consistência do mel: ");
            string consistencia = Console.ReadLine();
            Console.WriteLine("Digite o sabor do mel: ");
            string sabor = Console.ReadLine();
            Console.WriteLine("Digite o aroma do mel: ");
            string aroma = Console.ReadLine();
            Console.WriteLine("Digite a composição do mel: ");
            string composicao = Console.ReadLine();
            Console.WriteLine("Digite o ID da flor: ");
            int florID = int.Parse(Console.ReadLine());

            Mel mel = new Mel
            {
                Nome = nome,
                Cor = cor,
                Consistencia = consistencia,
                Sabor = sabor,
                Aroma = aroma,
                Composicao = composicao,
                FlorID = florID
            };

            _melController.AddMel(mel);

        }

        public void AtualizarMel()
        {
            Console.WriteLine("Digite o ID do mel que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do mel: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a cor do mel: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a consistência do mel: ");
            string consistencia = Console.ReadLine();
            Console.WriteLine("Digite o sabor do mel: ");
            string sabor = Console.ReadLine();
            Console.WriteLine("Digite o aroma do mel: ");
            string aroma = Console.ReadLine();
            Console.WriteLine("Digite a composição do mel: ");
            string composicao = Console.ReadLine();
            Console.WriteLine("Digite o ID da flor: ");
            int florID = int.Parse(Console.ReadLine());

            Mel mel = new Mel
            {
                ID = id,
                Nome = nome,
                Cor = cor,
                Consistencia = consistencia,
                Sabor = sabor,
                Aroma = aroma,
                Composicao = composicao,
                FlorID = florID
            };

            _melController.UpdateMel(mel);
        }

        public void DeletarMel()
        {
            Console.WriteLine("Digite o ID do mel que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            _melController.DeleteMel(id);
        }

        public void ListarMel()
        {
            var mels = _melController.GetAllMel();

            foreach (var mel in mels)
            {
                Console.WriteLine("ID: " + mel.ID);
                Console.WriteLine("Nome: " + mel.Nome);
                Console.WriteLine("Cor: " + mel.Cor);
                Console.WriteLine("Consistência: " + mel.Consistencia);
                Console.WriteLine("Sabor: " + mel.Sabor);
                Console.WriteLine("Aroma: " + mel.Aroma);
                Console.WriteLine("Composição: " + mel.Composicao);
                Console.WriteLine("ID da flor: " + mel.FlorID);
                Console.WriteLine("------------------------------------------------");
            }
        }

        public void VisualizarMelPorID()
        {
            Console.WriteLine("Digite o ID do mel que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Mel mel = _melController.GetMelByID(id);

            if (mel != null)
            {
                Console.WriteLine("ID: " + mel.ID);
                Console.WriteLine("Nome: " + mel.Nome);
                Console.WriteLine("Cor: " + mel.Cor);
                Console.WriteLine("Consistência: " + mel.Consistencia);
                Console.WriteLine("Sabor: " + mel.Sabor);
                Console.WriteLine("Aroma: " + mel.Aroma);
                Console.WriteLine("Composição: " + mel.Composicao);
                Console.WriteLine("ID da flor: " + mel.FlorID);
            }
            else
            {
                Console.WriteLine("Mel não encontrado!");
            }
        }

        public void ExecutarMenuMel()
        {
            int opcao = 0;
            do
            {
                MenuMel();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        AdicionarMel();
                        break;
                    case 2:
                        AtualizarMel();
                        break;
                    case 3:
                        DeletarMel();
                        break;
                    case 4:
                        ListarMel();
                        break;
                    case 5:
                        VisualizarMelPorID();
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
