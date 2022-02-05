using System;
using System.Collections.Generic;

class Turmadiario
{
  private int id;
  private int semestre;
  private string turma; //turma A 20211.1.01404.1V
  private Professor professor;
  private Disciplina disciplina;
  private List<Aluno> alunos = new List<Aluno>();
  private List<Horario> horarios = new List<Horario>();

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetSemestre(int semestre)
  {
    this.semestre = semestre;
  }

  public void SetTurma(string turma)
  {
    this.turma = turma;
  }

  public void SetProfessor(Professor professor)
  {
    this.professor = professor;
  }

  public void SetDisciplina(Disciplina disciplina)
  {
    this.disciplina = disciplina;
  }

  // fazer nota e horario

  public int GetId()
  {
    return id;
  }

  public int GetSemestre()
  {
    return semestre;
  }

  public string GetTurma()
  {
    return turma;
  }

  public Professor GetProfessor()
  {
    return professor;
  }

  public Disciplina GetDisciplina()
  {
    return disciplina;
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

  public void HorarioInserir(Horario horario)
  {
      horarios.Add(horario);
  }

  public List<Horario> HorarioListar()
  {
    return horarios;
  }

  public Horario HorarioListar(int id)
  {
    for(int j=0; j < horarios.Count; j++)
      if(horarios[j].GetId() == id) return horarios[j];
    return null;
  }

  public void HorarioAtualizar(Horario horario)
  {
    Horario horario_atual = HorarioListar(horario.GetId());
    if(horario_atual == null) return;
    horario_atual.SetDiasemana(horario.GetDiasemana());
    horario_atual.SetHorario(horario.GetHorario());
  }

  public void HorarioExcluir(Horario horario)
  {
    if(horario != null) horarios.Remove(horario);
  }

  public override string ToString()
  {
    return "IdTurma: "+id+"- Turma: "+turma+"- Semestre: "+semestre+"°";
  }
}