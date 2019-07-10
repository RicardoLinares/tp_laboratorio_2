using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        /// <summary>
        /// Contructor de Pasquete, el estado inicial sera Ingresado.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
        /// <summary>
        /// Propiedad de direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// propiedad de estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Propiedad de trackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        /// <summary>
        /// Cliclo de vida del paquete 4 segundos Ingresado 4 segundos en viaje y al entregarse se lo registra en 
        /// la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.estado = EEstado.EnViaje;
            this.InformarDelegado(this, new EventArgs());
            Thread.Sleep(4000);
            this.estado = EEstado.Entregado;
            this.InformarDelegado(this, new EventArgs());
            PaqueteDAO.Insertar(this);
        }
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarDelegado;
        /// <summary>
        /// sobrecarga del ==.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>TRUE, Tracking id iguales, FALSE distintos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool respuesta = false;
            if(p1.trackingID == p2.trackingID)
            {
                respuesta = true;
            }
            return respuesta;
        }
        /// <summary>
        /// sobrecarga del !=.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>False, Tracking id iguales, True distintos</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Enumardo de los Estados.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        /// <summary>
        /// Metodo de la interfaz IMostrar.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>la informacion del paquete dado</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }
        /// <summary>
        /// sobrecarga de ToString
        /// </summary>
        /// <returns>Informacion del paquete</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} para {1} ", this.trackingID, this.direccionEntrega);
            return builder.ToString();
        }
    }
}
