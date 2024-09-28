using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducaoMel.Views
{
    public class MenuManagement
    {
        private MelView _melView;
        private FloresView _floresView;
        private ColmeiaView _colmeiaView;
        private ProducaoView _producaoView;

        public MenuManagement()
        {
            _melView = new MelView();
            _floresView = new FloresView();
            _colmeiaView = new ColmeiaView();
            _producaoView = new ProducaoView();
        }

        public void ShowMenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("Bem-vindo ao Jardim do Mel\n");
                Console.WriteLine("Escolha uma das opções para gerenciar sua produção:\n");
                Console.WriteLine("|1 - Mel: Controle e registre as características do mel produzido.");
                Console.WriteLine("|2 - Flores: Gerencie as flores que dão origem ao néctar.");
                Console.WriteLine("|3 - Colmeia: Acompanhe a saúde e o desenvolvimento das colmeias.");
                Console.WriteLine("|4 - Produção: Registre as colheitas e a qualidade do mel.");
                Console.WriteLine("|0 - Sair: Encerrar o sistema.");
                Console.Write("\nDigite sua opção: ");
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 1:
                        _melView.ExecutarMenuMel();
                        break;
                    case 2:
                        _floresView.ExecutarMenuFlores();
                        break;
                    case 3:
                        _colmeiaView.ExecutarMenuColmeia();
                        break;
                    case 4:
                        _producaoView.ExecutarMenuProducao();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (option != 0);
        }

    }
}
