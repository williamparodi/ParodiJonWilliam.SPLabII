using TpUtiles;
using System.Text;
using System.Collections.Generic;

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

        /// <summary>
        /// Si la cantidad de tinta en el fibron es mayor descuenta la cantidad ingresada por parametro, si no lanza dos eventos un sin tinta y 
        /// otro que va a mostrar el fibron y cuanta tinta falataba, ademas tambien lanza una excepcion "SinTinta" . 
        /// </summary>
        /// <param name="cantidadTinta"></param>
        /// <exception cref="SinTintaException"></exception>
        public void Resaltar(int cantidadTinta)
        {
            int cantidadFaltante;
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
                    throw new SinTintaException("Te quedaste sin tinta");
                }
                
            }
        }

        /// <summary>
        /// Se sobreecarga el metodo To string para mostrar los datos del fibron.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fibron :");
            sb.AppendLine($"Color : {this.Color}");
            sb.AppendLine($"Cantidad tinta : {this.CantidadTinta}");
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con el fibron y la tinta que faltaba.
        /// </summary>
        /// <param name="fibron"></param>
        /// <param name="cantidadDeTintaFaltante"></param>
        /// <returns></returns>
        public string MuestraFibronSintinta(object fibron, int cantidadDeTintaFaltante)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(fibron.ToString());
            sb.AppendLine($"Cantidad de tinta faltante : {cantidadDeTintaFaltante}");
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con la cantidad de tinta que se necesita y la que contiene el fibron 
        /// </summary>
        /// <param name="cantidadFibron"></param>
        /// <param name="cantidadAUsar"></param>
        /// <returns></returns>
        public string MuestraCantidadDeTinta(int cantidadFibron, int cantidadAUsar)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tinta en el Fibron : {cantidadFibron}");
            sb.AppendLine($"Tinta a Usar : {cantidadAUsar}");
            return sb.ToString();
        }

        /// <summary>
        /// Se Cargan unos tres fibrones con datos en una lista
        /// </summary>
        /// <param name="cartuchera"></param>
        public void HarcodeaFibrones(Cartuchera<Util> cartuchera)
        {
            Fibron fibron1 = new Fibron(5, EColor.Rojo);
            Fibron fibron2 = new Fibron(10, EColor.Azul);
            Fibron fibron3 = new Fibron(6, EColor.Amarillo);
            if(cartuchera is not null)
            {
                cartuchera.ListaUtiles.Add(fibron1);
                cartuchera.ListaUtiles.Add(fibron2);
                cartuchera.ListaUtiles.Add(fibron3);
            }
        }
    }
}
