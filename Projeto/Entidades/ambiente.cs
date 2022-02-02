using System;

class Ambiente
{
  private int id;
  private string espaco;
  private Diretoria diretoria;

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

  public override string ToString()
  {
      return "IdEspaco: "+id+"- Espaco: "+espaco+"- Diretoria: "+diretoria.GetDescricao();
  }
}