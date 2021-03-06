using System;
using System.Collections.Generic;

class Nturmadiario
{
  List<Turmadiario> turmas = new List<Turmadiario>();

  private Nturmadiario(){}
  static Nturmadiario obj = new Nturmadiario();
  public static Nturmadiario Singleton { get => obj;}

  public void Inserir(Turmadiario turma)
  {
    int max = 0;
    foreach(Turmadiario t in turmas)
      if(t.GetId() > max) max = t.GetId();

    turma.SetId(max + 1);
    turmas.Add(turma);

    Disciplina disciplina = turma.GetDisciplina();
    disciplina.TurmaInserir(turma);
  }

  public void Salvar()
  {
    Arquivo<List<Turmadiario>> a = new Arquivo<List<Turmadiario>>();
    a.Salvar("./turmadiario.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<List<Turmadiario>> a = new Arquivo<List<Turmadiario>>();
    turmas = a.Abrir("./turmadiario.xml");
    AtualizarProfessor();
    AtualizarAmbiente();
    AtualizarDisciplina();
    AtualizarAluno();
  }

  public void AtualizarProfessor()
  {
    for(int i = 0; i<turmas.Count; i++)
    {
      Turmadiario t = turmas[i];

      Professor pro = Nprofessor.Singleton.Listar(t.ProfessorId);
      if(pro != null){
        t.SetProfessor(pro);
        pro.TurmaInserir(t);
      }
    }
  }

  public void AtualizarAmbiente()
  {
    for(int i = 0; i<turmas.Count; i++)
    {
      Turmadiario t = turmas[i];

      Ambiente amb = Nambiente.Singleton.Listar(t.AmbienteId);
      if(amb != null){
        t.SetAmbiente(amb);
        amb.TurmaInserir(t);
      }
    }
   }

  public void AtualizarDisciplina()
  {
    for(int i = 0; i<turmas.Count; i++)
    {
      Turmadiario t = turmas[i];

      Disciplina disc = Ndisciplina.Singleton.Listar(t.DisciplinaId);
      if(disc != null){
        t.SetDisciplina(disc);
        disc.TurmaInserir(t);
      }
    }
  }

  public void AtualizarAluno()
  {
    for(int i = 0; i<turmas.Count; i++)
    {
      Turmadiario t = turmas[i];
      List<int> alunosId = turmas[i].AlunoIdListar();
      for(int j = 0; j<alunosId.Count; j++)
      {
        int id = alunosId[j];
        Aluno aln = Naluno.Singleton.Listar(id);
        if(aln != null){
          t.AlunoInserir(aln);
          aln.TurmaInserir(t);
        }
      }
    }
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