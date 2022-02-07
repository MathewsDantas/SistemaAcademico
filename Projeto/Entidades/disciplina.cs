using System;
using System.Collections.Generic;

class Disciplina
{
  private int id;
  private string descricao;
  private string periodo;//vespertino
  private Curso curso;
  private List<Turmadiario> turmas = new List<Turmadiario>();

  public Disciplina(string descricao, string periodo, Curso curso)
  {
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

  public void TurmaInserir(Turmadiario turma)
  {
      turmas.Add(turma);
  }

  public List<Turmadiario> TurmaListar()
  {
    return turmas;
  }

  public Turmadiario TurmaListar(int id)
  {
    for(int j=0; j < turmas.Count; j++)
      if(turmas[j].GetId() == id) return turmas[j];
    return null;
  }

  public void TurmaAtualizar(Turmadiario turma)
  {
    Turmadiario turma_atual = TurmaListar(turma.GetId());
    if(turma_atual == null) return;
    
    turma_atual.SetSemestre(turma.GetSemestre());
    turma_atual.SetProfessor(turma.GetProfessor());
    turma_atual.SetDisciplina(turma.GetDisciplina());
    turma_atual.SetHora_inicio(turma.GetHora_inicio());
    turma_atual.SetHora_fim(turma.GetHora_fim());
  }

  public void TurmaExcluir(Turmadiario turma)
  {
    if(turma != null) turmas.Remove(turma);
  }

  public override string ToString()
  {
     
    return "IdDisciplina: "+id+" - Disciplina: "+descricao+" - Periodo: "+periodo+" - Curso: "+curso.GetDescricao();
  }

}
