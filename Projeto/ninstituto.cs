using System;

class Ninstituto
{
  private Instituto[] institutos = new Instituto[5];
  private int ni;

  public void Inserir(Instituto i)
  {
    if(ni == institutos.Length)
    {
      Array.Resize(ref institutos, 2*institutos.Length);
    }
    institutos[ni] = i;
    ni++;
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
    for(int j = n; j<ni; j++)
      institutos[j] = institutos[j+1];
    ni--;

    Campus[] cs = i.CampusListar();
    foreach(Campus c in cs) c.SetInstituto(null);
  }
  
} 