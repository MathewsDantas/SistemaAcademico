using System;
using System.Collections.Generic;

class Nhorario
{
  private List<Horario> horarios = new List<Horario>();

  public void Inserir(Horario horario)
  {
    int max = 0;
    foreach(Horario h in horarios)
      if(h.GetId() > max ) max = h.GetId();
    
    horario.SetId(max + 1);
    horarios.Add(horario);

    Ambiente ambiente = horario.GetAmbiente();
    ambiente.HorarioInserir(horario);
    Turmadiario turma = horario.GetTurma();
    turma.HorarioInserir(horario);
  }

  public List<Horario> Listar()
  {
    return horarios;
  }

  public Horario Listar(int id)
  {
    for(int i = 0; i < horarios.Count; i++)
      if(id == horarios[i].GetId()) return horarios[i];
    return null;
  }

  public void Atualizar(Horario horario)
  {
    Horario horario_atual = Listar(horario.GetId());

    horario_atual.SetDiasemana(horario.GetDiasemana());
    horario_atual.SetHorario(horario.GetHorario());

    Ambiente ambiente = horario.GetAmbiente();
    ambiente.HorarioAtualizar(horario);

    Turmadiario turma = horario.GetTurma();
    turma.HorarioAtualizar(horario);
  }

  public void Excluir(Horario horario)
  {
    if(horario != null) horarios.Remove(horario);

    Ambiente ambiente = horario.GetAmbiente();
    ambiente.HorarioExcluir(horario);
    Turmadiario turma = horario.GetTurma();
    turma.HorarioExcluir(horario);
  }
}