using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Ninstituto
{
  private Ninstituto(){}
  static Ninstituto obj = new Ninstituto();
  public static Ninstituto Singleton { get => obj;} // garante uma unica lista de instituto
  
  private Instituto[] institutos = new Instituto[5];
  private int ni;

  public void Inserir(Instituto instituto)
  {
    if(ni == institutos.Length)
    {
      Array.Resize(ref institutos, 2*institutos.Length);
    }
    
    int max = 0;
    for(int i = 0; i<ni; i++)
      if(institutos[i].GetId() > max) max = institutos[i].GetId();
    
    instituto.SetId(max + 1);
    institutos[ni] = instituto;
    ni++;
  }

  public void Salvar()
  {
    Arquivo<Instituto[]> d = new Arquivo<Instituto[]>();
    d.Salvar("./institutos.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<Instituto[]> d = new Arquivo<Instituto[]>();
    institutos = d.Abrir("./institutos.xml");
    ni = institutos.Length;
  }
  
  public Instituto[] Listar()
  {
    Instituto[] i = new Instituto[ni];
    Array.Copy(institutos,i,ni);
    return i;
  }

  public Instituto Listar(int id)
  {
    for(int i = 0; i<ni; i++)
      if(institutos[i].GetId() == id) return institutos[i];
    
    return null;
  }

  public void Atualizar(Instituto i)
  {
    Instituto i_atual = Listar(i.GetId());
    if(i_atual == null) return;
    i_atual.SetDescricao(i.GetDescricao());
  }

  private int Indice(Instituto i)
  {
    for(int j=0; j<ni; j++)
      if(institutos[j] == i) return j;
    return -1;
  }

  public void Excluir(Instituto i)
  {
    int n = Indice(i);
    if(n == -1) return;
    for(int j = n; j < ni -1; j++)
      institutos[j] = institutos[j+1];
    ni--;
    
    Campus[] cs = i.CampusListar();
    foreach(Campus c in cs) Ncampus.Singleton.Excluir(c); // exclui todos os campus pertecentes ao instituto. 
  }
  
} 