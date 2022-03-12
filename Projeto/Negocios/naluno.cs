using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Naluno
{
  private List<Aluno> alunos = new List<Aluno>();

  private Naluno(){}
  static Naluno obj = new Naluno();
  public static Naluno Singleton { get => obj;}

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
  
  public void Salvar()
  {
    Arquivo<List<Aluno>> a = new Arquivo<List<Aluno>>();
    a.Salvar("./aluno.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<List<Aluno>> a = new Arquivo<List<Aluno>>();
    alunos = a.Abrir("./aluno.xml");
    AtualizarDiretoria();

  }
  
  public void AtualizarDiretoria()
  {
    for(int i = 0; i<alunos.Count; i++)
    {
      Aluno a = alunos[i];

      Diretoria dir = Ndiretoria.Singleton.Listar(a.DiretoriaId);
      if(dir != null){
        a.SetDiretoria(dir);
        dir.AlunoInserir(a);
      }
    }
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