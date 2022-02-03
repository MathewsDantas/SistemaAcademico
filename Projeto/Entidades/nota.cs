using System;

class Nota
{
  private int id;
  private float nota1;
  private float nota2;
  private float notaf;
  private float media;
  private Aluno aluno;


  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetNota1(float nota1)
  {
    this.nota1 = nota1;
  }

  public void SetNota2(float nota2)
  {
    this.nota2 = nota2;
  }

  public void SetAluno(Aluno aluno)
  {
    this.aluno = aluno;
  }

  public int GetId()
  {
    return id;
  }

  public float GetNota1()
  {
    return nota1;
  }

  public float GetNota2()
  {
    return nota2;
  }

  public Aluno GetAluno()
  {
    return aluno;
  }

  public void CalcularMedia(float nota1,float nota2)
  {
    this.media = (nota1*2 + nota2*3)/2;
  }

  public override string ToString()
  {
    return "IdNota: "+id+"- Nota1: "+nota1+"- Nota2: "+nota2;
  }
}