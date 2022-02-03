using System;
using System.Collections.Generic;

class Ambiente
{
  private int id;
  private string espaco;
  private Diretoria diretoria;
  private List<Horario> horarios = new List<Horario>();

  public Ambiente(string espaco, Diretoria diretoria)
  {
    this.espaco = espaco;
    this.diretoria = diretoria;
  }

  public void SetId(int id)
  {
    this.id = id;
  }

  public void SetEspaco(string espaco)
  {
    this.espaco = espaco;
  }

  public void SetDiretoria(Diretoria diretoria)
  {
    this.diretoria = diretoria;
  }

  public int GetId()
  {
    return id;
  }

  public string GetEspaco()
  {
    return espaco;
  }

  public Diretoria GetDiretoria()
  {
    return diretoria;
  }

  public void HorarioInserir(Horario horario)
  {
      horarios.Add(horario);
  }

  public List<Horario> HorarioListar()
  {
    return horarios;
  }

  public Horario HorarioListar(int id)
  {
    for(int j=0; j < horarios.Count; j++)
      if(horarios[j].GetId() == id) return horarios[j];
    return null;
  }

  public void HorarioAtualizar(Horario horario)
  {
    Horario horario_atual = HorarioListar(horario.GetId());
    if(horario_atual == null) return;
    horario_atual.SetDiasemana(horario.GetDiasemana());
    horario_atual.SetHorario(horario.GetHorario());
  }

  public void HorarioExcluir(Horario horario)
  {
    if(horario != null) horarios.Remove(horario);
  }

  public override string ToString()
  {
      return "IdEspaco: "+id+"- Espaco: "+espaco+"- Diretoria: "+diretoria.GetDescricao();
  }
}