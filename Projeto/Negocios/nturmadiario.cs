using System;
using System.Collections.Generic;

class Nturmadiario
{
  List<Turmadiario> turmas = new List<Turmadiario>();

  public void Inserir(Turmadiario turma)
  {
    int max = 0;
    foreach(Turmadiario t in turmas)
      if(t.GetId() > max) max = t.GetId();

    turma.SetId(max + 1);
    turmas.Add(turma);
    Professor professor = turma.GetProfessor();
    professor.TurmaInserir(turma);

    Disciplina disciplina = turma.GetDisciplina();
    disciplina.TurmaInserir(turma);
  }

  public List<Turmadiario> Listar()
  {
    return turmas;
  }

  public Turmadiario Listar(int id)
  {
    for(int i = 0; i < turmas.Count; i++)
      if(id == turmas[i].GetId()) return turmas[i];
    return null;
  }

  public void Atualizar(Turmadiario turma)
  {
    Turmadiario turma_atual = Listar(turma.GetId());

    turma_atual.SetSemestre(turma.GetSemestre());
    turma_atual.SetProfessor(turma.GetProfessor());
    turma_atual.SetDisciplina(turma.GetDisciplina());
    turma_atual.SetHora_inicio(turma.GetHora_inicio());
    turma_atual.SetHora_fim(turma.GetHora_fim());
    
    Professor professor = turma.GetProfessor();
    professor.TurmaAtualizar(turma);

    Disciplina disciplina = turma.GetDisciplina();
    disciplina.TurmaAtualizar(turma);

    List<Aluno> alunos = turma.AlunoListar();
    foreach(Aluno a in alunos)
      a.TurmaAtualizar(turma);
  }

  public void Excluir(Turmadiario turma)
  {
    if(turma != null) turmas.Remove(turma);

    Professor professor = turma.GetProfessor();
    professor.TurmaExcluir(turma);

    Disciplina disciplina = turma.GetDisciplina();
    disciplina.TurmaExcluir(turma);

    List<Aluno> alunos = turma.AlunoListar();
    foreach(Aluno a in alunos)
      a.TurmaExcluir(turma);
  }
}