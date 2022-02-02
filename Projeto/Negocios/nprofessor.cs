using System;
using System.Collections.Generic;

class Nprofessor
{
  private List<Professor> professores = new List<Professor>();

  public void Inserir(Professor professor)
  {
    int max = 0;
    foreach(Professor p in professores)
      if(p.GetId() > max ) max = p.GetId();
    
    professor.SetId(max + 1);
        
    professores.Add(professor);
    Diretoria dir = professor.GetDiretoria();
    dir.ProfessorInserir(professor);
  }

  public List<Professor> Listar()
  {
    return professores;
  }

  public Professor Listar(int id)
  {
    for(int i = 0; i < professores.Count; i++)
      if(professores[i].GetId() == id) return professores[i];
    return null;
  }

  public void Atualizar(Professor professor)
  {
    Professor p_atual = Listar(professor.GetId());
    if(p_atual == null) return;

    p_atual.SetNome(professor.GetNome());
    p_atual.SetMatricula(professor.GetMatricula());
    p_atual.SetDiretoria(professor.GetDiretoria());

    Diretoria dir = professor.GetDiretoria();
    dir.ProfessorAtualizar(professor);
  }

  public void Excluir(Professor professor)
  {
    if(professor != null) professores.Remove(professor);

    Diretoria dir = professor.GetDiretoria();
    dir.ProfessorExcluir(professor);
  }
}