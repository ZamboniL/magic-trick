using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            lblVersao.Text = $"Versão: {Jogo.Versao}";
            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            frmSelecaoPartida frm = new frmSelecaoPartida();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                AbrirPartida(frm.Id, frm.Senha);
            }
        }
        private void btnCriar_Click(object sender, EventArgs e)
        {
            frmCriacaoPartida frm = new frmCriacaoPartida();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AbrirPartida(frm.Id, frm.Senha);
            }
        }

        private void AbrirPartida(int id, string senha)
        {
            MatchForm frm = new MatchForm(id, senha);
            frm.Show();
        }

    }
}
