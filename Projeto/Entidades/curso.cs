using System;

class Curso
{
  private int id;
  private string descricao;
  private Instituto instituto;
  private Campus campus;

  public Curso(int id,string descricao,Instituto instituto,Campus campus)
  {
    this.id = id;
    this.descricao = descricao;
    this.instituto = instituto;
    this.campus = campus;
  }

  public void SetDescricao(string descricao)
  {
    this.descricao = descricao;
  }

  public string GetDescricao()
  {
    return descricao;
  }
  
  public int GetId()
  {
    return id;
  }

  public Instituto GetInstituto()
  {
    return instituto;
  }

  public Campus GetCampus()
  {
    return campus;
  }

  public override string ToString()
  {
     
    return "IdCurso: "+id+" - Curso: "+descricao+" - Instituto: "+instituto.GetDescricao()+" - Campus: "+campus.GetDescricao();
  }

}