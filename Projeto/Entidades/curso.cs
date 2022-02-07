using System;
using System.Collections.Generic;


class Curso
{
  private int id;
  private string descricao;
  private Instituto instituto;
  private Campus campus;
  private List<Disciplina> disciplinas = new List<Disciplina>();

  public Curso(string descricao,Instituto instituto,Campus campus)
  {
    this.descricao = descricao;
    this.instituto = instituto;
    this.campus = campus;
  }

  public void SetId(int id)
  {
    this.id = id;
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

  public void DisciplinaInserir(Disciplina d)
  {
      disciplinas.Add(d);
  }

  public List<Disciplina> DisciplinaListar()
  {
    return disciplinas;
  }

  public Disciplina DisciplinaListar(int id)
  {
    for(int i=0; i < disciplinas.Count; i++)
      if(disciplinas[i].GetId() == id) return disciplinas[i];
    return null;
  }

  public void DisciplinaAtualizar(Disciplina d)
  {
    Disciplina d_atual = DisciplinaListar(d.GetId());
    if(d_atual == null) return;
    d_atual.SetDescricao(d.GetDescricao());
    d_atual.SetPeriodo(d.GetPeriodo());
  }

  public void DisciplinaExcluir(Disciplina d)
  {
    if(d != null) disciplinas.Remove(d);
  }


  public override string ToString()
  {
     
    return "IdCurso: "+id+" - Curso: "+descricao+" - Instituto: "+instituto.GetDescricao()+" - Campus: "+campus.GetDescricao();
  }

}