using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;


class Ndisciplina
{
  private List<Disciplina> disciplinas = new List<Disciplina>();

  private Ndisciplina(){}
  static Ndisciplina obj = new Ndisciplina();
  public static Ndisciplina Singleton{ get => obj;}

  public void Inserir(Disciplina disciplina)
  {
    int max = 0;
    foreach(Disciplina d in disciplinas)
      if(d.GetId() > max ) max = d.GetId();
    
    disciplina.SetId(max + 1);
        
    disciplinas.Add(disciplina);
    Curso cur = disciplina.GetCurso();
    cur.DisciplinaInserir(disciplina);
  }

  public void Salvar()
  {
    Arquivo<List<Disciplina>> d = new Arquivo<List<Disciplina>>();
    d.Salvar("./disciplina.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<List<Disciplina>> d = new Arquivo<List<Disciplina>>();
    disciplinas = d.Abrir("./disciplina.xml");
    AtualizarCurso();
  }

  public void AtualizarCurso()
  {
    for(int i = 0; i < disciplinas.Count; i++)
    {
      Disciplina d = disciplinas[i];

      Curso cur = Ncurso.Singleton.Listar(d.CursoId);
      if(cur != null){
        d.SetCurso(cur);
        cur.DisciplinaInserir(d);
      }
    }
  }

  public List<Disciplina> Listar()
  {
    return disciplinas;
  }

  public Disciplina Listar(int id)
  {
    for(int i = 0; i < disciplinas.Count; i++)
      if(disciplinas[i].GetId() == id) return disciplinas[i];
    return null;
  }

  public void Atualizar(Disciplina disciplina)
  {
    Disciplina d_atual = Listar(disciplina.GetId());
    if(d_atual == null) return;

    d_atual.SetDescricao(disciplina.GetDescricao());
    d_atual.SetPeriodo(disciplina.GetPeriodo());
    d_atual.SetCurso(disciplina.GetCurso());

    Curso cur = disciplina.GetCurso();
    cur.DisciplinaAtualizar(disciplina);
  }

  public void Excluir(Disciplina disciplina)
  {
    if(disciplina != null) disciplinas.Remove(disciplina);

    Curso cur = disciplina.GetCurso();
    cur.DisciplinaExcluir(disciplina);
  }
}