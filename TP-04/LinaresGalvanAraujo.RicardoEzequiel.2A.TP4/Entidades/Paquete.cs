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
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
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
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool respuesta = false;
            if(p1.trackingID == p2.trackingID)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} para {1} ", this.trackingID, this.direccionEntrega);
            return builder.ToString();
        }
    }
}
