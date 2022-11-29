using TpUtiles;
using System.Text;

namespace Entidades
{
    public class Fibron : Util
    {
        public delegate void DelegadoSinTinta(string mensaje);
        public delegate void DelegadoGuardaError(string mensaje);
        private int cantidadTinta;
        private EColor color;
        public event DelegadoSinTinta EventoSinTinta;
        public event DelegadoGuardaError EventoError;
        private int cantidadFaltante;
        public Fibron() : base()
        {
            this.cantidadTinta = 0;
            this.color = EColor.SinColor;
        }

        public Fibron(int cantidadTinta, EColor color)
        {
            this.cantidadTinta = cantidadTinta;
            this.color = color;
        }

        public int CantidadTinta
        {
            get { return this.cantidadTinta; }
            set { this.cantidadTinta = value; }
        }

        public EColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public void Resaltar(int cantidadTinta)
        {
            if (this.CantidadTinta > cantidadTinta)
            {
                this.cantidadTinta -= cantidadTinta;
            }
            else
            {
                if (EventoSinTinta is not null && EventoError is not null)
                {
                    cantidadFaltante = cantidadTinta - this.CantidadTinta;
                    EventoSinTinta.Invoke("Evento sin tinta");
                    EventoError.Invoke(MuestraFibronSintinta(this,cantidadFaltante));
                }
                throw new SinTintaException("Te quedaste sin tinta");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fibron :");
            sb.AppendLine($"Color : {this.Color}");
            sb.AppendLine($"Cantidad tinta : {this.CantidadTinta}");
            return sb.ToString();
        }

        public string MuestraFibronSintinta(object fibron, int cantidadDeTintaFaltante)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(fibron.ToString());
            sb.AppendLine($"Cantidad de tinta faltante : {cantidadDeTintaFaltante}");
            return sb.ToString();
        }
    }
}
