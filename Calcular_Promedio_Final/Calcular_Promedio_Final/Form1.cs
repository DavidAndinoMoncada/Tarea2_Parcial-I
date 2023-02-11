using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcular_Promedio_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void CalcularPromedioAsyncronobutton_Click(object sender, EventArgs e)
        {
            if (PrimerParcialtextBox.Text == "")
            {
                errorProvider1.SetError(PrimerParcialtextBox, "Ingrese un Valor");
                errorProvider1.Clear();
                return;

            }
            if (SegundoParcialtextBox.Text == "")
            {
                errorProvider1.SetError(SegundoParcialtextBox, "Ingrese un Valor");
                return;
            }
            if (TercerParcialtextBox.Text == "")
            {
                errorProvider1.SetError(TercerParcialtextBox, "Ingrese un Valor");
                return;
            }
            if (CuartoParcialtextBox.Text == "")
            {
                errorProvider1.SetError(CuartoParcialtextBox, "Ingrese un Valor");
                return;
            }

            errorProvider1.Clear();

            decimal Parcial1 = Convert.ToDecimal(PrimerParcialtextBox.Text);
            decimal Parcial2 = Convert.ToDecimal(SegundoParcialtextBox.Text);
            decimal Parcial3 = Convert.ToDecimal(TercerParcialtextBox.Text);
            decimal Parcial4 = Convert.ToDecimal(CuartoParcialtextBox.Text);

            decimal Promedio = await CalcularPromedioAsync(Parcial1, Parcial2, Parcial3, Parcial4);

            MessageBox.Show("Tiene un Promedio de: " + Promedio, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private async Task<decimal> CalcularPromedioAsync(decimal num1, decimal num2, decimal num3, decimal num4)
        {
            decimal promedio = await Task.Run(() =>
            {
                return (num1 + num2 + num3 + num4) / 4;
            });

            return promedio;
        }
    }
}
