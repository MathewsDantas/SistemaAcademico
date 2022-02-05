using System;

class Horario
{
  private int id;
  private string diasemana;
  private string horario;
  private Ambiente ambiente;
  private Turmadiario turma;


  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetDiasemana(string diasemana)
  {
    this.diasemana = diasemana;
  }

  public void SetHorario(string horario)
  {
    this.horario = horario;
  }

  public void SetAmbiente(Ambiente ambiente)
  {
    this.ambiente = ambiente;
  }

  public void SetTurma(Turmadiario turma)
  {
    this.turma = turma;
  }

  public int GetId()
  {
    return id;
  }

  public string GetHorario()
  {
    return horario;
  }

  public string GetDiasemana()
  {
    return diasemana;
  }

  public Ambiente GetAmbiente()
  {
    return ambiente;
  }

  public Turmadiario GetTurma()
  {
    return turma;
  }

  public override string ToString()
  {
    return "IdHorario: "+id+"- Dia da semana: "+diasemana+"- Horario: "+horario;
  }
}