using Entidades;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TpUtiles
{
    public class Lapiz : Util, ISerializa, IDeserealiza
    {
        private EColor color;
        private ETipoLapiz tipoDeLapiz;
  
        public Lapiz() : base()
        {
            this.color = EColor.SinColor;
            this.tipoDeLapiz = ETipoLapiz.SinTipo;
        }

        public Lapiz(double precio,string marca) : base(precio,marca)
        {

        }

        public Lapiz(double precio, string marca, EColor color, ETipoLapiz tipoDelapiz) : base(precio, marca)
        {
            this.color = color;
            this.tipoDeLapiz = tipoDelapiz;
         
        }      

        //Propiedades
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETipoLapiz TipoDeLapiz
        {
            get { return this.tipoDeLapiz; }
            set { this.tipoDeLapiz = value; }
        }

    

        //Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Precio :{this.precio}, Marca : {this.marca},Color : {this.Color},Tipo de Lapiz: {this.TipoDeLapiz}");
            return sb.ToString();
        }

        public virtual EColor CargaColor(string color)
        {
            EColor auxColor = new EColor();
            switch (color)
            {
                case "Rojo":
                    auxColor = EColor.Rojo;
                    break;
                case "Azul":
                    auxColor = EColor.Azul;
                    break;
                case "Amarillo":
                    auxColor = EColor.Amarillo;
                    break;
                case "Negro":
                    auxColor = EColor.Negro;
                    break;
                default:
                    break;
            }

            return auxColor;
        }

        public ETipoLapiz CargaTipoLapiz(string tipo)
        {
            ETipoLapiz auxLapiz = new ETipoLapiz();
            switch (tipo)
            {
                case "Normal":
                    auxLapiz = ETipoLapiz.Normal;
                    break;
                case "Grafito":
                    auxLapiz = ETipoLapiz.Grafito;
                    break;
                default:
                    break;
            }

            return auxLapiz;
        }

        public  Lapiz CargaDatosLapiz(string precio, string marca, string color, string tipo)
        {
            double precioAsumar = double.Parse(precio);
           
            Lapiz auxLapiz = new Lapiz();

            auxLapiz.precio = precioAsumar;
            auxLapiz.marca = marca;
            auxLapiz.Color = auxLapiz.CargaColor(color);
            auxLapiz.TipoDeLapiz = auxLapiz.CargaTipoLapiz(tipo);

            return auxLapiz;
        }

        //Serealiza y Deserealiza
        public void SerializaLapizJson(Lapiz lapiz)
        {
            string lapizTexto;

            if (lapiz is not null)
            {
                lapizTexto = JsonSerializer.Serialize(lapiz);
                File.WriteAllText("lapiz.json", lapizTexto);
            }
        }

        public Lapiz DeseralizaJsonLapiz(string str)
        {
            Lapiz lapiz = new Lapiz();
            if (!string.IsNullOrEmpty(str))
            { 
                str = File.ReadAllText(str);
                lapiz = JsonSerializer.Deserialize<Lapiz>(str);
            }

            return lapiz;
        }

        public void SerializaLapizXml(string nombreArchivo,Lapiz lapiz)
        {
            if (string.IsNullOrEmpty(nombreArchivo) && lapiz is not null)
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo, true))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                    serializer.Serialize(writer, lapiz);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                    serializer.Serialize(writer, lapiz);
                }
                   
            }

        }

        public Lapiz DeserealizaLapizXml(string nombreDelArchivo)
        {
            Lapiz lapiz = new Lapiz();

            if (!string.IsNullOrEmpty(nombreDelArchivo))
            {
                using (StreamReader streamReader = new StreamReader(nombreDelArchivo, true))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(Lapiz));
                    lapiz = (Lapiz)deserializer.Deserialize(streamReader);
                }
            }
            else
            {
                throw new ExceptionArchivo("Error al deserealizar xml");
            }

            return lapiz;
        }

        public static bool operator == (Lapiz a, Lapiz b)
        {
            return (a == b);
        }

        public static bool operator !=(Lapiz a, Lapiz b)
        {
            return !(a == b);
        }
     



    }
}
