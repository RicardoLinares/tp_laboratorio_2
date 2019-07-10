using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("El id " + p.TrackingID + " ya esta en la lista de envios");
                }
            }
            c.paquetes.Add(p);
            Thread NuevoCiclo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(NuevoCiclo);
            NuevoCiclo.Start();
            return c;
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            Correo lista = (Correo)elemento;
            string resultado = "";
            foreach (Paquete p in lista.paquetes)
            {
                resultado += String.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return resultado;
        }
        public void FinEntregas()
        {
            int cantidad = this.mockPaquetes.Count;
            for(int i = 0; i<cantidad; i++)
            {
                if(this.mockPaquetes[i].ThreadState == ThreadState.Running)
                {
                    this.mockPaquetes[i].Abort();
                }
            }
        }
    }
}
