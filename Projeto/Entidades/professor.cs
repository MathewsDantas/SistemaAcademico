using System;
using System.Collections.Generic;

public class Professor
{
  private int id;
  private string nome;
  private long matricula;
  private int diretoriaId;
  private Diretoria diretoria;
  private List<Turmadiario> turmas = new List<Turmadiario>();

  public int Id {get => id; set => id = value;}
  public int DiretoriaId {get => diretoriaId; set => diretoriaId = value;}
  public string Nome {get => nome; set => nome = value;}
  public long Matricula {get => matricula; set => matricula = value;}
  public Professor(){}
  
  public Professor(string nome, long matricula, Diretoria diretoria)
  {
    this.nome = nome;
    this.matricula = matricula;
    this.diretoria = diretoria;
    this.diretoriaId = diretoria.GetId();
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetNome(string nome)
  {
    this.nome = nome;
  }

  public void SetMatricula(long matricula)
  {
    this.matricula = matricula;
  }

  public void SetDiretoria(Diretoria diretoria)
  {
    this.diretoria = diretoria;
    this.diretoriaId = diretoria.GetId();  
  }

  public int GetId()
  {
    return id;
  }

  public string GetNome()
  {
    return nome;
  }

  public long GetMatricula()
  {
    return matricula;
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
      return "IdProfessor: "+id+"- Professor: "+nome+"- Matricula: "+matricula;
  }
}
