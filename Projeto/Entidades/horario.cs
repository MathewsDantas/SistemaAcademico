using System;

class Horario
{
  private int id;
  private string diasemana;
  private string horario;
  private Ambiente ambiente;


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

  public override string ToString()
  {
    return "IdHorario: "+id+"- Dia da semana: "+diasemana+"- Horario: "+horario;
  }
}