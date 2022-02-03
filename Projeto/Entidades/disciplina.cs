using System;

class Disciplina
{
  private int id;
  private string descricao;
  private string periodo;
  private Curso curso;

  public Disciplina(int id, string descricao, string periodo, Curso curso)
  {
    this.id = id;
    this.descricao = descricao;
    this.periodo = periodo;
    this.curso = curso;
  }
  public void SetId(int id)
  {
    this.id = id;
  }
  public void SetDescricao(string descricao)
  {
    this.descricao = descricao;
  }
  public void SetPeriodo(string periodo)
  {
    this.periodo = periodo;
  }  
  public void SetCurso(Curso curso)
  {
    this.curso = curso;
  }

  public int GetId()
  {
    return id;
  }
  public string GetDescricao()
  {
    return descricao;
  }
  public string GetPeriodo()
  {
    return periodo;
  } 
  public Curso GetCurso()
  {
    return curso;
  } 

  public override string ToString()
  {
     
    return "IdDisciplina: "+id+" - Disciplina: "+descricao+" - Periodo: "+periodo+" - Curso: "+curso.GetDescricao();
  }

}
