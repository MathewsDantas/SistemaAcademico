using System;
using System.Collections.Generic;

class Nambiente
{
  private List<Ambiente> ambientes = new List<Ambiente>();

  public void Inserir(Ambiente ambiente)
  {
    int max = 0;
    foreach(Ambiente a in ambientes)
      if(a.GetId() > max ) max = a.GetId();
    
    ambiente.SetId(max + 1);
        
    ambientes.Add(ambiente);
    Diretoria dir = ambiente.GetDiretoria();
    dir.AmbienteInserir(ambiente);
  }

  public List<Ambiente> Listar()
  {
    return ambientes;
  }

  public Ambiente Listar(int id)
  {
    for(int i = 0; i < ambientes.Count; i++)
      if(ambientes[i].GetId() == id) return ambientes[i];
    return null;
  }

  public void Atualizar(Ambiente ambiente)
  {
    Ambiente ambiente_atual = Listar(ambiente.GetId());
    if(ambiente_atual == null) return;

    ambiente_atual.SetEspaco(ambiente.GetEspaco());
    ambiente_atual.SetDiretoria(ambiente.GetDiretoria());

    Diretoria dir = ambiente.GetDiretoria();
    dir.AmbienteAtualizar(ambiente);
  }

  public void Excluir(Ambiente ambiente)
  {
    if(ambiente != null) ambientes.Remove(ambiente);

    Diretoria dir = ambiente.GetDiretoria();
    dir.AmbienteExcluir(ambiente);
  }
}