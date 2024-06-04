using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    public partial class frmSelecaoPartida : Form
    {

        public int Id {get; set;}
        public string Senha { get; set; }
        public frmSelecaoPartida()
        {
            InitializeComponent();
            CarregarPartidas();
        }

        private void CarregarPartidas()
        {
            List<Partida> partidas = Partida.ListarPartidas();

            dgvPartidas.DataSource = partidas;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregarPartidas();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(txtId.Text);
            Senha = txtSenha.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var partida = dgvPartidas.SelectedRows[0];

            if(partida != null)
            {
                Partida carregar = (Partida)partida.DataBoundItem;
                txtId.Text = Convert.ToString(carregar.Id);
            }
        }
    }
}
