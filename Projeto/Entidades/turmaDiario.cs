using System;
using System.Collections.Generic;

public class Turmadiario
{
  private int id;
  private string semestre;// 2021.2
  private string hora_inicio;
  private string hora_fim;
  private Professor professor;
  private int professorId;
  private Disciplina disciplina;
  private int disciplinaId;
  private Ambiente ambiente;
  private int ambienteId;
  private List<Aluno> alunos = new List<Aluno>();


  public int Id { get => id; set => id = value;}
  public string Semestre { get => semestre; set => semestre = value;}
  public string Hora_inicio { get => hora_inicio; set => hora_inicio = value;}
  public string Hora_fim { get => hora_fim; set => hora_fim = value;}
  public int ProfessorId { get => professorId; set => professorId = value;}
  public int DisciplinaId { get => disciplinaId; set => disciplinaId = value;}
  public int AmbienteId { get => ambienteId; set => ambienteId = value;}
  public Turmadiario(){}
  
  public Turmadiario(string semestre,string hora_inicio,string hora_fim,Disciplina disciplina)
  {
    this.semestre = semestre;
    this.hora_inicio = hora_inicio;
    this.hora_fim = hora_fim;
    this.disciplina = disciplina;
    this.disciplinaId = disciplina.GetId();
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
    this.professorId = professor.GetId();
  }

  public void SetDisciplina(Disciplina disciplina)
  {
    this.disciplina = disciplina;
    this.disciplinaId = disciplina.GetId();
  }

  public void SetAluno(Aluno aluno)
  {
    this.alunos.Add(aluno);
  }

  public void SetHora_inicio(string hora_inicio)
  {
    this.hora_inicio = hora_inicio;
  }

  public void SetHora_fim(string hora_fim)
  {
    this.hora_fim = hora_fim;
  }

  public void SetAmbiente(Ambiente ambiente)
  {
    this.ambiente = ambiente;
    this.ambienteId = ambiente.GetId();
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

  public string GetHora_inicio()
  {
    return hora_inicio;
  }

  public string GetHora_fim()
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
    return "- IdTurma:"+id+"  Disciplina:"+disciplina.GetDescricao()+"\n Semestre:"+semestre+"\n Inicio:"+hora_inicio+"\n Fim:"+hora_fim+"\n";
  }
}