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
            Console.WriteLine("1 - Adicionar Produção");
            Console.WriteLine("2 - Atualizar Produção");
            Console.WriteLine("3 - Deletar Produção");
            Console.WriteLine("4 - Listar Produção");
            Console.WriteLine("5 - Visualizar Produção por ID");
            Console.WriteLine("6 - Voltar");
        }

        
        public void AdicionarProducao()
        {
            Console.WriteLine("Digite a data de colheita: ");
            DateTime dataColheita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID da colmeia: ");
            int colmeiaID = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do mel: ");
            int melID = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade colhida: ");
            double quantidadeColhida = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a qualidade final: ");
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

        }

        public void AtualizarProducao()
        {
            Console.WriteLine("Digite o ID da produção que deseja atualizar: ");
            int lote = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de colheita: ");
            DateTime dataColheita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID da colmeia: ");
            int colmeiaID = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do mel: ");
            int melID = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade colhida: ");
            double quantidadeColhida = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a qualidade final: ");
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

        public void DeletarProducao()
        {
            Console.WriteLine("Digite o ID da produção que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            _producaoController.DeleteProducao(id);
        }

        public void ListarProducao()
        {
            var producoes = _producaoController.GetAllProducao();
            foreach (var producao in producoes)
            {
                Console.WriteLine("ID: " + producao.Lote);
                Console.WriteLine("Data de Colheita: " + producao.DataColheita);
                Console.WriteLine("ID da Colmeia: " + producao.ColmeiaID);
                Console.WriteLine("ID do Mel: " + producao.MelID);
                Console.WriteLine("Quantidade Colhida: " + producao.QuantidadeColhida);
                Console.WriteLine("Qualidade Final: " + producao.QualidadeFinal);
                Console.WriteLine("---------------------------------------------------");
            }
        }

        public void VisualizarProducaoPorID()
        {
            Console.WriteLine("Digite o ID da produção que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            Producao producao = _producaoController.GetProducaoByLote(id);
            if (producao != null)
            {
                Console.WriteLine("ID: " + producao.Lote);
                Console.WriteLine("Data de Colheita: " + producao.DataColheita);
                Console.WriteLine("ID da Colmeia: " + producao.ColmeiaID);
                Console.WriteLine("ID do Mel: " + producao.MelID);
                Console.WriteLine("Quantidade Colhida: " + producao.QuantidadeColhida);
                Console.WriteLine("Qualidade Final: " + producao.QualidadeFinal);
            }
            else
            {
                Console.WriteLine("Produção não encontrada!");
            }
        }

        public void ExecutarMenuProducao()
        {
            int opcao = 0;
            do
            {
                MenuProducao();
                opcao = int.Parse(Console.ReadLine());
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
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 6);
        }
    }
}
