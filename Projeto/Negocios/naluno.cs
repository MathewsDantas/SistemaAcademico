using System;
using System.Collections.Generic;

class Naluno
{
  private List<Aluno> alunos = new List<Aluno>();

  public void Inserir(Aluno aluno)
  {
    int max = 0;
    foreach(Aluno a in alunos)
      if(a.GetId() > max ) max = a.GetId();
    
    aluno.SetId(max + 1);
        
    alunos.Add(aluno);
    Diretoria dir = aluno.GetDiretoria();
    dir.AlunoInserir(aluno);
  }

  public List<Aluno> Listar()
  {
    return alunos;
  }

  public Aluno Listar(int id)
  {
    for(int i = 0; i < alunos.Count; i++)
      if(alunos[i].GetId() == id) return alunos[i];
    return null;
  }

  public void Atualizar(Aluno aluno)
  {
    Aluno a_atual = Listar(aluno.GetId());
    if(a_atual == null) return;

    a_atual.SetNome(aluno.GetNome());
    a_atual.SetMatricula(aluno.GetMatricula());
    a_atual.SetDiretoria(aluno.GetDiretoria());

    Diretoria dir = aluno.GetDiretoria();
    dir.AlunoAtualizar(aluno);

    List<Turmadiario> turmas = aluno.TurmaListar();
    foreach(Turmadiario t in turmas)
      t.AlunoAtualizar(aluno);
  }

  public void Excluir(Aluno aluno)
  {
    if(aluno != null) alunos.Remove(aluno);

    Diretoria dir = aluno.GetDiretoria();
    dir.AlunoExcluir(aluno);

    List<Turmadiario> turmas = aluno.TurmaListar();
    foreach(Turmadiario t in turmas)
      t.AlunoExcluir(aluno);
  }
}