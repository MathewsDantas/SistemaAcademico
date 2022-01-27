using System;

class Diretoria
{
  private int id;
  private string descricao;
  private Campus campus;
  private Instituto instituto;

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

public override string ToString()
{

  return "IdDiretoria: "+id+" - Diretoria: "+descricao+" - Instituto: "+instituto.GetDescricao()+" - Campus: "+campus.GetDescricao();
}
}