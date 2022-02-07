using System;
using System.Collections.Generic;

class Aluno
{
  private int id;
  private string nome;
  private long matricula;
  private Diretoria diretoria;
  private List<Nota> notas = new List<Nota>();
  private List<Turmadiario> turmas = new List<Turmadiario>();

  public Aluno(string nome,long matricula,Diretoria diretoria)
  {
    this.nome = nome;
    this.matricula = matricula;
    this.diretoria = diretoria;
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

  public void NotaInserir(Nota nota)
  {
      notas.Add(nota);
  }

  public List<Nota> NotaListar()
  {
    return notas;
  }

  public Nota NotaListar(int id)
  {
    for(int j=0; j < notas.Count; j++)
      if(notas[j].GetId() == id) return notas[j];
    return null;
  }

  public void NotaAtualizar(Nota nota)
  {
    Nota nota_atual = NotaListar(nota.GetId());
    if(nota_atual == null) return;
    nota_atual.SetNota1(nota.GetNota1());
    nota_atual.SetNota2(nota.GetNota2());
  }

  public void NotaExcluir(Nota nota)
  {
    if(nota != null) notas.Remove(nota);
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
      return "IdAluno: "+id+"- Aluno: "+nome+"- Matricula: "+matricula;
  }
}