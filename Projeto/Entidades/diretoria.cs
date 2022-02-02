using System;
using System.Collections.Generic;

class Diretoria
{
  private int id;
  private string descricao;
  private Campus campus;
  private Instituto instituto;
  private List<Aluno> alunos = new List<Aluno>();

  public Diretoria(int id, string descricao, Campus campus)
  {
    this.id = id;
    this.descricao = descricao;
    this.campus = campus;
    this.instituto = campus.GetInstituto();
  }

  public int GetId()
  {
    return id;
  }

  public string GetDescricao()
  {
    return descricao;
  }

  public Campus GetCampus()
  {
    return campus;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetDescricao(string descricao)
  {
    this.descricao = descricao;
  }

  public void SetCampus(Campus campus)
  {
    this.campus = campus;
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

    return "IdDiretoria: "+id+" - Diretoria: "+descricao+" - Instituto: "+instituto.GetDescricao()+" - Campus: "+campus.GetDescricao();
  }
}