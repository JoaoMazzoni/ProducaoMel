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
            Console.Clear();
            Console.WriteLine("===== GESTÃO DE MEL =====\n");
            Console.WriteLine("|1 - Adicionar Mel");
            Console.WriteLine("|2 - Atualizar Mel");
            Console.WriteLine("|3 - Deletar Mel");
            Console.WriteLine("|4 - Listar Mel");
            Console.WriteLine("|5 - Visualizar Mel por ID");
            Console.WriteLine("|6 - Voltar");
            Console.Write("\nEscolha uma opção: ");
        }

        public void AdicionarMel()
        {
            Console.Clear();
            Console.WriteLine("===== ADICIONAR MEL =====\n");

            Console.Write("Digite o nome do mel: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a cor do mel: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a consistência do mel: ");
            string consistencia = Console.ReadLine();

            Console.Write("Digite o sabor do mel: ");
            string sabor = Console.ReadLine();

            Console.Write("Digite o aroma do mel: ");
            string aroma = Console.ReadLine();

            Console.Write("Digite a composição do mel: ");
            string composicao = Console.ReadLine();

            Console.Write("Digite o ID da flor: ");
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

            Console.Clear();
        }

        public void AtualizarMel()
        {
            Console.Clear();
            Console.WriteLine("===== ATUALIZAR MEL =====\n");

            Console.Write("Digite o ID do mel que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            var melExiste = ImprimirMelById(id);
            if (!melExiste)
            {
                return;
            }
            else
            {
                Console.WriteLine();

                Console.Write("Digite o nome do mel: ");
                string nome = Console.ReadLine();

                Console.Write("Digite a cor do mel: ");
                string cor = Console.ReadLine();

                Console.Write("Digite a consistência do mel: ");
                string consistencia = Console.ReadLine();

                Console.Write("Digite o sabor do mel: ");
                string sabor = Console.ReadLine();

                Console.Write("Digite o aroma do mel: ");
                string aroma = Console.ReadLine();

                Console.Write("Digite a composição do mel: ");
                string composicao = Console.ReadLine();

                Console.Write("Digite o ID da flor: ");
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
            Console.Clear();
        }

        public void DeletarMel()
        {
            Console.Clear();
            Console.WriteLine("===== DELETAR MEL =====\n");

            Console.Write("Digite o ID do mel que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            _melController.DeleteMel(id);

            Console.Clear();
        }

        public void ListarMel()
        {
            Console.Clear();
            Console.WriteLine("===== LISTA DE MEL =====\n");

            var mels = _melController.GetAllMel();

            if (mels.Count == 0)
            {
                Console.WriteLine("Nenhum mel cadastrado no sistema.");
            }
            else
            {
                foreach (var mel in mels)
                {
                    Console.WriteLine($"ID: {mel.ID}");
                    Console.WriteLine($"Nome: {mel.Nome}");
                    Console.WriteLine($"Cor: {mel.Cor}");
                    Console.WriteLine($"Consistência: {mel.Consistencia}");
                    Console.WriteLine($"Sabor: {mel.Sabor}");
                    Console.WriteLine($"Aroma: {mel.Aroma}");
                    Console.WriteLine($"Composição: {mel.Composicao}");
                    Console.WriteLine($"ID da flor: {mel.FlorID}");
                    Console.WriteLine("------------------------------------------------");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public void VisualizarMelPorID()
        {
            Console.Clear();
            Console.WriteLine("===== VISUALIZAR MEL POR ID =====\n");

            Console.Write("Digite o ID do mel que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Mel mel = _melController.GetMelByID(id);

            if (mel.ID != 0)
            {
                Console.WriteLine($"\nID: {mel.ID}");
                Console.WriteLine($"Nome: {mel.Nome}");
                Console.WriteLine($"Cor: {mel.Cor}");
                Console.WriteLine($"Consistência: {mel.Consistencia}");
                Console.WriteLine($"Sabor: {mel.Sabor}");
                Console.WriteLine($"Aroma: {mel.Aroma}");
                Console.WriteLine($"Composição: {mel.Composicao}");
                Console.WriteLine($"ID da flor: {mel.FlorID}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nMel não encontrado!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public bool ImprimirMelById(int id)
        {
            Mel mel = _melController.GetMelByID(id);

            if (mel.ID == 0)
            {
                Console.WriteLine("Mel não encontrada.");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
                return false;
            }


            Console.WriteLine("\n--- MEL ATUAL ---\n");
            Console.WriteLine($"ID: {mel.ID}");
            Console.WriteLine($"Nome: {mel.Nome}");
            Console.WriteLine($"Cor: {mel.Cor}");
            Console.WriteLine($"Consistência: {mel.Consistencia}");
            Console.WriteLine($"Sabor: {mel.Sabor}");
            Console.WriteLine($"Aroma: {mel.Aroma}");
            Console.WriteLine($"Composição: {mel.Composicao}");
            Console.WriteLine($"ID da flor: {mel.FlorID}");
            return true;

        }

        public void ExecutarMenuMel()
        {
            int opcao = 0;
            do
            {
                MenuMel();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
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
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcao != 6);
        }
    }
}
