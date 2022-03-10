using System;

public class Campus : IComparable
{
  private int id;
  private string descricao;
  private Instituto instituto;
  private int institutoId;
  private Curso[] cursos = new Curso[1];
  private int ncur;
  private Diretoria[] diretorias = new Diretoria[1];
  private int ndir;

  public int Id {get => id; set => id = value; }
  public string Descricao {get => descricao; set => descricao = value; }
  public int InstitutoId { get => institutoId; set => institutoId = value; }
  public Campus(){}

  public Campus(string descricao,Instituto instituto) 
  {
    this.descricao = descricao;
    this.instituto = instituto;
    this.InstitutoId = instituto.GetId();
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetDescricao(string descricao)
  {
    this.descricao = descricao;
  }

  public void SetInstituto(Instituto instituto)
  {
    this.instituto = instituto;
    this.InstitutoId = instituto.GetId();
  }

  public int GetId()
  {
    return id;
  }

  public string GetDescricao()
  {
    return descricao;
  }

  public Instituto GetInstituto()
  {
    return instituto;
  }

  public void CursoInserir(Curso c)
  {
    if(ncur == cursos.Length)
    {
      Array.Resize(ref cursos,2*cursos.Length);
    }
    cursos[ncur] = c;
    ncur++;
  }

  public Curso[] CursoListar()
  {
    Curso[] c = new Curso[ncur];
    Array.Copy(cursos,c,ncur);
    return c;
  }

  public Curso CursoListar(int id)
  {
    for(int i = 0; i<ncur; i++)
      if(cursos[i].GetId() == id) return cursos[i];
    
    return null;
  }

  public void CursoAtualizar(Curso c)
  {
    Curso c_atual = CursoListar(c.GetId());
    if(c_atual == null) return;
    c_atual.SetDescricao(c.GetDescricao());
  }

  public int CursoIndice(Curso c)
  {
    for(int i=0; i<ncur; i++)
      if(cursos[i] == c) return i;
    return -1;
  }

  public void CursoExcluir(Curso c)
  {
    int n = CursoIndice(c);
    if(n == -1) return;
    for(int i=n; i < ncur - 1; i++)
      cursos[i] = cursos[i+1];
    ncur--;
  }

  public void DiretoriaInserir(Diretoria d)
  {
    if(diretorias.Length == ndir)
    {
      Array.Resize(ref diretorias, 2*diretorias.Length);
    }
    diretorias[ndir] = d;
    ndir++;

  }

  public Diretoria[] DiretoriaListar()
  {
    Diretoria[] d = new Diretoria[ndir];
    Array.Copy(diretorias,d,ndir);
    return d;
  }

  public Diretoria DiretoriaListar(int id)
  {
    for(int i = 0; i<ndir; i++)
      if(diretorias[i].GetId() == id) return diretorias[i];
    return null;
  }
  
  public int DiretoriaIndice(Diretoria d)
  {
    for(int i=0; i<ndir; i++)
      if(diretorias[i] == d) return i;
    return -1;
  }

  public void DiretoriaExcluir(Diretoria d)
  {
    int n = DiretoriaIndice(d);
    if(n == -1) return;
    for(int i=n; i < ndir - 1; i++)
      diretorias[i] = diretorias[i+1];
    ndir--;
  }

  public void DiretoriaAtualizar(Diretoria d)
  {
    Diretoria d_atual = DiretoriaListar(d.GetId());
    if(d_atual == null) return;
    d_atual.SetDescricao(d.GetDescricao());
  }

  public int CompareTo(object obj)
  {
    Campus c = (Campus) obj;
    return this.descricao.CompareTo(c.descricao);
  }
  
  public override string ToString()
  {
    if(instituto == null)
    {
      return "IdCampus: " + id + " - Campus:" + descricao;
    }
    else
    {
      return "IdCampus: " + id + " - Campus:" + descricao + " - Instituto:" + instituto.GetDescricao();
    }
  }
}