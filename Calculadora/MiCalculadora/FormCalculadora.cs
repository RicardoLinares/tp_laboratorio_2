using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora de Ricardo Ezequiel Linares Galvan Araujo del curso 2.A";
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void btnConvertirABinario_click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            this.lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Cerrara el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Limpia todos los campos de texto de el formulario
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.cmbOperador.Text = String.Empty;
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la operacion con los numeros y el operador en el formulario
        /// </summary>
        /// <param name="numero1">texto de txtNumero1</param>
        /// <param name="numero2">texto de txtNumero2</param>
        /// <param name="operador">texto de cmbOperador</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero objNumero1 = new Numero(numero1);
            Numero objNumero2 = new Numero(numero2);
            return Calculadora.Operar(objNumero1, objNumero2, operador);
        }
    }
}
