using System;

class Aluno
{
  private int id;
  private string nome;
  private int matricula;
  private Diretoria diretoria;

  public Aluno(string nome,int matricula,Diretoria diretoria)
  {
    this.nome = nome;
    this.matricula = matricula;
    this.diretoria = diretoria;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetNome(string nome)
  {
    this.nome = nome;
  }

  public void SetMatricula(int matricula)
  {
    this.matricula = matricula;
  }

  public void SetDiretoria(Diretoria diretoria)
  {
    this.diretoria = diretoria;
  }

  public int GetId()
  {
    return id;
  }

  public string GetNome()
  {
    return nome;
  }

  public int GetMatricula()
  {
    return matricula;
  }

  public Diretoria GetDiretoria()
  {
    return diretoria;
  }

  public override string ToString()
  {
      return "IdAluno: "+id+"- Aluno: "+nome+"- Matricula: "+matricula;
  }
}