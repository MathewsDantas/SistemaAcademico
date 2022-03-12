using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Nprofessor
{
  private List<Professor> professores = new List<Professor>();
  private Nprofessor(){}
  static Nprofessor obj = new Nprofessor();
  public static Nprofessor Singleton { get => obj;}


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
  
  public void Salvar()
  {
    Arquivo<List<Professor>> p = new Arquivo<List<Professor>>();
    p.Salvar("./professor.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<List<Professor>> p = new Arquivo<List<Professor>>();
    professores = p.Abrir("./professor.xml");
    AtualizarDiretoria();
  }
  public void AtualizarDiretoria()
  {
    for(int i = 0; i<professores.Count; i++)
    {
      Professor p = professores[i];

      Diretoria dir = Ndiretoria.Singleton.Listar(p.DiretoriaId);
      if(dir != null){
        p.SetDiretoria(dir);
        dir.ProfessorInserir(p);
      }
    }
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