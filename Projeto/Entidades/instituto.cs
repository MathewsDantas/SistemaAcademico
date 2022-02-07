using System;


class Instituto
{
  private int id;
  private string descricao;
  private Campus[] campus = new Campus[1];
  private int ncam;
  private Curso[] cursos = new Curso[1];
  private int ncur;

  public Instituto(string descricao)
  {
    this.descricao = descricao;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetDescricao(string descricao)
  {
    this.descricao = descricao;
  }

  public int GetId()
  {
    return id;
  }

  public string GetDescricao()
  {
    return descricao;
  }

  public void CampusInserir(Campus c)
  {
    if(ncam == campus.Length)
    {
      Array.Resize(ref campus,2*campus.Length);
    }
    campus[ncam] = c;
    ncam++;
  }

  public void CampusAtualizar(Campus c)
  {
    Campus c_atual = CampusListar(c.GetId());
    if(c_atual == null) return;
    c_atual.SetDescricao(c.GetDescricao());
  }

  public int CampusIndice(Campus c)
  {
    for(int i=0; i<ncam; i++)
      if(campus[i] == c) return i;
    return -1;
  }
  public void CampusExcluir(Campus c)
  {
    int n = CampusIndice(c);
    if(n == -1) return;
    for(int i=n; i < ncam - 1; i++)
      campus[i] = campus[i+1];
    ncam--;
  }

  public Campus[] CampusListar()
  {
    Campus[] c = new Campus[ncam];
    Array.Copy(campus,c,ncam);
    return c;
  }

  public Campus CampusListar(int id)
  {
    for(int i = 0; i<ncam; i++)
      if(campus[i].GetId() == id) return campus[i];
    
    return null;
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

  public void CursoAtualizar(Curso c)
  {
    Curso c_atual = CursoListar(c);
    if(c_atual == null) return;
    c_atual.SetDescricao(c.GetDescricao());
  }

  public Curso CursoListar(Curso c)
  {
    // poderia usar CompareTo aqui
    for(int i = 0; i<ncur; i++)
      if(cursos[i].GetCampus().GetDescricao() == c.GetCampus().GetDescricao() && cursos[i].GetId() == c.GetId()) 
      return cursos[i];
    
    return null;
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

  public override string ToString()
  {
    return "IdInstituto: " + id + " - Descricao:" + descricao;
  }
}