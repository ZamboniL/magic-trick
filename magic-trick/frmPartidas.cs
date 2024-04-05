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
    public partial class frmPartidas : Form
    {
        public frmPartidas()
        {
            InitializeComponent();
            dgvPartidas.DataSource = Partida.ListarPartidas();
            dgvPartidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPartidas.AllowUserToAddRows = false;
            dgvPartidas.AllowUserToDeleteRows = false;
            dgvPartidas.AllowUserToResizeColumns = false;
            dgvPartidas.AllowUserToResizeRows = false;
            dgvPartidas.RowHeadersVisible = false;
        }

        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Partida p = (Partida)dgvPartidas.SelectedRows[0].DataBoundItem;

            txtNome.Text = p.Nome;
        }
    }
}
