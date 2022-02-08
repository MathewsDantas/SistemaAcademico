using System;
using System.Collections.Generic;

class Turmadiario
{
  private int id;
  private string semestre;// 2021.2
  private int hora_inicio;
  private int hora_fim;
  private Professor professor;
  private Disciplina disciplina;
  private Ambiente ambiente;
  private List<Aluno> alunos = new List<Aluno>();

  public Turmadiario(string semestre,int hora_inicio,int hora_fim,Disciplina disciplina)
  {
    this.semestre = semestre;
    this.hora_inicio = hora_inicio;
    this.hora_fim = hora_fim;
    this.disciplina = disciplina;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetSemestre(string semestre)
  {
    this.semestre = semestre;
  }

  public void SetProfessor(Professor professor)
  {
    this.professor = professor;
  }

  public void SetDisciplina(Disciplina disciplina)
  {
    this.disciplina = disciplina;
  }

  public void SetAluno(Aluno aluno)
  {
    this.alunos.Add(aluno);
  }

  public void SetHora_inicio(int hora_inicio)
  {
    this.hora_inicio = hora_inicio;
  }

  public void SetHora_fim(int hora_fim)
  {
    this.hora_fim = hora_fim;
  }

  public void SetAmbiente(Ambiente ambiente)
  {
    this.ambiente = ambiente;
  }

  public int GetId()
  {
    return id;
  }

  public string GetSemestre()
  {
    return semestre;
  }

  public Professor GetProfessor()
  {
    return professor;
  }

  public Disciplina GetDisciplina()
  {
    return disciplina;
  }

  public int GetHora_inicio()
  {
    return hora_inicio;
  }

  public int GetHora_fim()
  {
    return hora_fim;
  }

  public Ambiente GetAmbiente()
  {
    return ambiente;
  }

  public void AlunoInserir(Aluno a)
  {
      alunos.Add(a);
  }

  public List<Aluno> AlunoListar()
  {
    return alunos;
  }

  public Aluno AlunoListar(int id)
  {
    for(int j=0; j < alunos.Count; j++)
      if(alunos[j].GetId() == id) return alunos[j];
    return null;
  }

  public void AlunoAtualizar(Aluno a)
  {
    Aluno a_atual = AlunoListar(a.GetId());
    if(a_atual == null) return;
    a_atual.SetNome(a.GetNome());
    a_atual.SetMatricula(a.GetMatricula());
  }

  public void AlunoExcluir(Aluno a)
  {
    if(a != null) alunos.Remove(a);
  }

  public override string ToString()
  {
    return "IdTurma:"+id+" - Disciplina:"+disciplina.GetDescricao()+" - Semestre:"+semestre+" - Inicio:"+hora_inicio+" - Fim:"+hora_fim;
  }
}