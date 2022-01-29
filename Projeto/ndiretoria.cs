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
    Campus cam = d.GetCampus();
    cam.DiretoriaInserir(d);
  }

  
  public Diretoria[] Listar()
  {
    Diretoria[] d = new Diretoria[ndir];
    Array.Copy(diretorias,d,ndir);
    return d;
  }

  public int Indice(Diretoria d)
  {
    for(int i=0; i<ndir; i++)
      if(diretorias[i] == d) return i;
    return -1;
  }

  public void Excluir(Diretoria d)
  {
    int n = Indice(d);
    if(n == -1) return;
    for(int i = n; i<ndir-1; i++)
      diretorias[i] = diretorias[i+1];
    ndir--;

    Campus cam = d.GetCampus();
    if(d != null){
      cam.DiretoriaExcluir(d);
    }
  }

  public void Atualizar(Diretoria d_velha,string descricao_nova)
  {
  d_velha.SetDescricao(descricao_nova);

  if(d_velha.GetCampus() != null)
    d_velha.GetCampus().DiretoriaAtualizar(d_velha); // adiciona o novo curso ao campus
  }
  
  
  



}