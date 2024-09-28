using Models;
using ProducaoMel.Controller;

namespace ProducaoMel.Views
{
    public class ProducaoView
    {
        private ProducaoController _producaoController;

        public ProducaoView()
        {
            _producaoController = new ProducaoController();
        }

        public void MenuProducao()
        {
            Console.Clear();
            Console.WriteLine("===== GESTÃO DE PRODUÇÃO =====\n");
            Console.WriteLine("|1 - Adicionar Produção");
            Console.WriteLine("|2 - Atualizar Produção");
            Console.WriteLine("|3 - Deletar Produção");
            Console.WriteLine("|4 - Listar Produção");
            Console.WriteLine("|5 - Visualizar Produção por ID");
            Console.WriteLine("|6 - Voltar");
            Console.Write("\nEscolha uma opção: ");
        }

        public void AdicionarProducao()
        {
            Console.Clear();
            Console.WriteLine(" ==== CADASTRAR PRODUÇÃO DE MEL ====\n");

            Console.Write("Digite a data de colheita (dd/MM/yyyy): ");
            DateTime dataColheita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Digite o ID da colmeia: ");
            int colmeiaID = int.Parse(Console.ReadLine());

            Console.Write("Digite o ID do mel: ");
            int melID = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade colhida: ");
            double quantidadeColhida = double.Parse(Console.ReadLine());

            Console.Write("Digite a qualidade final: ");
            string qualidadeFinal = Console.ReadLine();

            Producao producao = new Producao
            {
                DataColheita = dataColheita,
                ColmeiaID = colmeiaID,
                MelID = melID,
                QuantidadeColhida = quantidadeColhida,
                QualidadeFinal = qualidadeFinal
            };

            _producaoController.AddProducao(producao);

            Console.Clear();
        }

        public void AtualizarProducao()
        {
            Console.Clear();
            Console.WriteLine(" ==== ATUALIZAR PRODUÇÃO DE MEL ====\n");

            Console.Write("Digite o ID da produção que deseja atualizar: ");
            int lote = int.Parse(Console.ReadLine());

            Console.WriteLine();
            var producaoExiste = ImpressaoProducaoPorID(lote);

            if (!producaoExiste)
            {
                return;
            }
            else
            {

                Console.WriteLine();

                Console.Write("Digite a data de colheita (dd/MM/yyyy): ");
                DateTime dataColheita = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Digite o ID da colmeia: ");
                int colmeiaID = int.Parse(Console.ReadLine());

                Console.Write("Digite o ID do mel: ");
                int melID = int.Parse(Console.ReadLine());

                Console.Write("Digite a quantidade colhida: ");
                double quantidadeColhida = double.Parse(Console.ReadLine());

                Console.Write("Digite a qualidade final: ");
                string qualidadeFinal = Console.ReadLine();

                Producao producao = new Producao
                {
                    Lote = lote,
                    DataColheita = dataColheita,
                    ColmeiaID = colmeiaID,
                    MelID = melID,
                    QuantidadeColhida = quantidadeColhida,
                    QualidadeFinal = qualidadeFinal
                };

                _producaoController.UpdateProducao(producao);
            }

            Console.Clear();
        }

        public void DeletarProducao()
        {
            Console.Clear();
            Console.WriteLine(" ==== DELETAR PRODUÇÃO DE MEL ====\n");
            Console.Write("Digite o ID da produção que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            _producaoController.DeleteProducao(id);

            Console.Clear();

        }

        public void ListarProducao()
        {
            Console.Clear();
            Console.WriteLine(" ==== LISTAR PRODUÇÕES DE MEL ====\n");
            var producoes = _producaoController.GetAllProducao();

            if (producoes.Count == 0)
            {
                Console.WriteLine("Nenhuma produção encontrada.\n");
                return;
            }

            foreach (var producao in producoes)
            {
                Console.WriteLine($"ID: {producao.Lote}");
                Console.WriteLine($"Data de Colheita: {producao.DataColheita:dd/MM/yyyy}");
                Console.WriteLine($"ID da Colmeia: {producao.ColmeiaID}");
                Console.WriteLine($"ID do Mel: {producao.MelID}");
                Console.WriteLine($"Quantidade Colhida: {producao.QuantidadeColhida}");
                Console.WriteLine($"Qualidade Final: {producao.QualidadeFinal}");
                Console.WriteLine("---------------------------------------------------");
            }

            Console.WriteLine();
            Console.Write("\nPressione qualquer tecla para continuar: ");
            Console.ReadLine();
        }

        public void VisualizarProducaoPorID()
        {
            Console.Clear();
            Console.WriteLine(" ==== VISUALIZAR PRODUÇÕES DE MEL ====\n");
            Console.Write("Digite o ID da produção que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Producao producao = _producaoController.GetProducaoByLote(id);

            if (producao.Lote != 0)
            {
                Console.WriteLine($"ID: {producao.Lote}");
                Console.WriteLine($"Data de Colheita: {producao.DataColheita:dd/MM/yyyy}");
                Console.WriteLine($"ID da Colmeia: {producao.ColmeiaID}");
                Console.WriteLine($"ID do Mel: {producao.MelID}");
                Console.WriteLine($"Quantidade Colhida: {producao.QuantidadeColhida}");
                Console.WriteLine($"Qualidade Final: {producao.QualidadeFinal}\n");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nNenhuma produção encontrada!\n");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public bool ImpressaoProducaoPorID(int id)
        {
            Producao producao = _producaoController.GetProducaoByLote(id);

            if (producao.Lote == 0)
            {
                Console.WriteLine("\nProdução não encontrada.");
                Console.Write("\nPressione qualquer tecla para continuar: ");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            Console.WriteLine("\n--- PRODUÇÃO ATUAL ---\n");
            Console.WriteLine($"ID: {producao.Lote}");
            Console.WriteLine($"Data de Colheita: {producao.DataColheita:dd/MM/yyyy}");
            Console.WriteLine($"ID da Colmeia: {producao.ColmeiaID}");
            Console.WriteLine($"ID do Mel: {producao.MelID}");
            Console.WriteLine($"Quantidade Colhida: {producao.QuantidadeColhida}");
            Console.WriteLine($"Qualidade Final: {producao.QualidadeFinal}\n");
            return true;
        }

        public void ExecutarMenuProducao()
        {
            int opcao = 0;
            do
            {
                MenuProducao();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        AdicionarProducao();
                        break;
                    case 2:
                        AtualizarProducao();
                        break;
                    case 3:
                        DeletarProducao();
                        break;
                    case 4:
                        ListarProducao();
                        break;
                    case 5:
                        VisualizarProducaoPorID();
                        break;
                    case 6:
                        Console.WriteLine("Voltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.\n");
                        break;
                }
            } while (opcao != 6);
        }
    }
}
