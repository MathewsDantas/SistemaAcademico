using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;


public class Arquivo<T>
{
  public void Salvar(string arquivo,T obj)
  {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter d = new StreamWriter(arquivo,false,Encoding.Default);
    xml.Serialize(d,obj);
    d.Close();
  }

  public T Abrir(string arquivo)
  {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader d = new StreamReader(arquivo,Encoding.Default);
    T obj = (T) xml.Deserialize(d);
    d.Close();
    return obj;
  }
}