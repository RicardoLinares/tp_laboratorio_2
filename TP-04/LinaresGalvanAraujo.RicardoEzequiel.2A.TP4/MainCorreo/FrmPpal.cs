using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.lstEstadoEntregado.ContextMenuStrip = this.cmsListas;
        }
        /// <summary>
        /// Actualiza los listBox de los estado de los paquetes ingresados.
        /// </summary>
        private void ActualizarEstado()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach(Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Agrega un nuevo paquete con el TrackingID del MaskedTexbox Y la direccionDeEntrega en el TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformarDelegado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                this.correo += paquete;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
               
            }
            this.ActualizarEstado();


        }
        /// <summary>
        /// Forma mas segura de llamar a ActualizarEstado desde otro thread...(Base lo que investige..)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }
        /// <summary>
        /// LLama al metodo FinEntregas() de Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Muestra la informacion de todos los paquetes en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Imprime en el richTextBox toda la informacion de los paquetes en la lista.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="correo"></param>
        private void MostrarInformacion<T>(IMostrar<T> correo)
        {
            if(correo != null)
            {
                this.rtbMostrar.Text = "";
                this.rtbMostrar.Text += correo.MostrarDatos(correo) + "\n";
                this.rtbMostrar.Text.Guardar("Salida.txt");
            }
        }
        /// <summary>
        /// Imprime en el richTextBox la informacion del paquete selecionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);

        }
    }
}
