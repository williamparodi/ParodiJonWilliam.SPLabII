using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpUtiles;

namespace Entidades
{
    public interface ISerializa
    {
        string SerializaLapizJson(Lapiz lapiz);
        Lapiz DeseralizaJsonLapiz(string str);

        void SerializaLapizXml(string nombreArchivo,Lapiz lapiz);

        Lapiz DeserealizaLapizXml(string nombreDelArchivo);
    }
}
