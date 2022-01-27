using System;

class Ndiretoria
{
  private int ndir;
  private Diretoria[] diretorias = new Diretoria[5];

  public void Inserir(Diretoria d)
  {
    if(diretorias.Length == ndir)
    {
      Array.Resize(ref diretorias, 2*diretorias.Length);
    }
    diretorias[ndir] = d;
    ndir++;
  }
  public Diretoria[] Listar()
  {
    Diretoria[] d = new Diretoria[ndir];
    Array.Copy(diretorias,d,ndir);
    return d;
  }
  
  
  



}