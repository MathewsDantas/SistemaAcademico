using System;
using System.Collections.Generic;

class Nnota
{
  private List<Nota> notas = new List<Nota>();

  public void Inserir(Nota nota)
  {
    int max = 0;
    foreach(Nota n in notas)
      if(n.GetId() > max ) max = n.GetId();
    
    nota.SetId(max + 1);
    notas.Add(nota);

    Aluno aluno = nota.GetAluno();
    aluno.NotaInserir(nota);
  }

  public List<Nota> Listar()
  {
    return notas;
  }

  public Nota Listar(int id)
  {
    for(int i = 0; i < notas.Count; i++)
      if(id == notas[i].GetId()) return notas[i];
    return null;
  }

  public void Atualizar(Nota nota)
  {
    Nota nota_atual = Listar(nota.GetId());

    nota_atual.SetNota1(nota.GetNota1());
    nota_atual.SetNota2(nota.GetNota2());

    Aluno aluno = nota.GetAluno();
    aluno.NotaAtualizar(nota);
  }

  public void Excluir(Nota nota)
  {
    if(nota != null) notas.Remove(nota);

    Aluno aluno = nota.GetAluno();
    aluno.NotaExcluir(nota);
  }
}