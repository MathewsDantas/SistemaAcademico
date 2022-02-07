using System;
using System.Collections.Generic;

class Ambiente
{
  private int id;
  private string espaco;
  private Diretoria diretoria;
  private List<Turmadiario> turmas = new List<Turmadiario>();

  public Ambiente(string espaco, Diretoria diretoria)
  {
    this.espaco = espaco;
    this.diretoria = diretoria;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetEspaco(string espaco)
  {
    this.espaco = espaco;
  }

  public void SetDiretoria(Diretoria diretoria)
  {
    this.diretoria = diretoria;
  }

  public int GetId()
  {
    return id;
  }

  public string GetEspaco()
  {
    return espaco;
  }

  public Diretoria GetDiretoria()
  {
    return diretoria;
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
      return "IdEspaco: "+id+"- Espaco: "+espaco+"- Diretoria: "+diretoria.GetDescricao();
  }
}