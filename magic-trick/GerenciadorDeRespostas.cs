using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    internal static class GerenciadorDeRespostas
    {
        // Passado uma string e um componente de lista, ele adiciona o conteúdo da string na lista
        public static void AdicionarStringALista(ListBox lst, string str)
        {
            lst.Items.Clear();

            if (str.Length == 0)
            {
                return;
            }

            string[] list = SepararStringDeResposta(str);

            for (int i = 0; i < list.Length; i++)
            {
                lst.Items.Add(list[i]);
            }
        }

        public static string[] SepararStringDeResposta(string str)
        {
            str = str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            return str.Split('\n');
        }

        public static bool PossuiErro(string str)
        {
            return str.StartsWith("ERRO:");
        }

        public static void MostrarErro(string message)
        {
            string errorMessage = message.Split(':')[1];

            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
