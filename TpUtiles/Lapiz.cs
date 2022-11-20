using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TpUtiles
{
    public class Lapiz : Util,ISerializa,IDeserealiza
    {
        private EColor color;
        private ETipoLapiz tipoDeLapiz;

        public Lapiz() : base()
        {
            this.color = EColor.Negro;
            this.tipoDeLapiz = ETipoLapiz.Normal;
        }

        public Lapiz(double precio,string marca,EColor color,ETipoLapiz tipoDelapiz) :base(precio,marca)
        {
            this.color = color;
            this.tipoDeLapiz = tipoDelapiz;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Precio :{this.precio},Marca : {this.marca},Color : {this.color},Tipo de Lapiz: {this.tipoDeLapiz}");
            return sb.ToString();
        }

        public string SerializaLapizJson(Lapiz lapiz)
        {
            string lapizTexto = "";

            if(lapiz is not null)
            {
                lapizTexto = JsonSerializer.Serialize(lapiz);
            }
            return lapizTexto;
        }

        public Lapiz DeseralizaJsonLapiz(string str)
        {
            Lapiz lapiz = new Lapiz();
            if(string.IsNullOrEmpty(str))
            {
                lapiz = JsonSerializer.Deserialize<Lapiz>(str);
            }
            
            return lapiz;
        }

        public void SerializaLapizXml(string nombreArchivo, Lapiz lapiz)
        {
            if(string.IsNullOrEmpty(nombreArchivo) && lapiz is not null)
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo, true))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                    serializer.Serialize(writer, lapiz);
                }   
            }
            else
            {
                throw new ExceptionArchivo("Error al serializar xml");
            }
           
        }

        public Lapiz DeserealizaLapizXml(string nombreDelArchivo)
        {
            Lapiz lapiz = new Lapiz();

            if(string.IsNullOrEmpty(nombreDelArchivo))
            {
                using(StreamReader streamReader = new StreamReader(nombreDelArchivo, true))
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




    }
}
