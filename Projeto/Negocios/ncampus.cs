using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Ncampus
{
  private Campus[] campus = new Campus[5];
  private int nc;
  
  private Ncampus(){}
  static Ncampus obj = new Ncampus();
  public static Ncampus Singleton { get => obj;} 
  
  public void Inserir(Campus c)
  {
    if(nc == campus.Length)
    {
      Array.Resize(ref campus,2*campus.Length);
    }

    int max = 0;
    for(int i = 0; i<nc; i++)
      if(campus[i].GetId() > max) max = campus[i].GetId();
    
    c.SetId(max + 1);

    campus[nc] = c;
    nc++;

    Instituto ins = c.GetInstituto();
    if(ins != null) ins.CampusInserir(c);
  }

  public void Salvar()
  {
    Arquivo<Campus[]> d = new Arquivo<Campus[]>();
    d.Salvar("./campus.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<Campus[]> d = new Arquivo<Campus[]>();
    campus = d.Abrir("./campus.xml");
    nc = campus.Length;
    AtualizarInstituto();
  }

  public void AtualizarInstituto()
  {
    for(int i = 0; i<nc; i++)
    {
      Campus c = campus[i];

      Instituto ins = Ninstituto.Singleton.Listar(c.InstitutoId);
      if(ins != null){
        c.SetInstituto(ins);
        ins.CampusInserir(c);
      }
    }
  }
  
  public Campus[] Listar()
  {
    Campus[] c = new Campus[nc];
    Array.Copy(campus,c,nc);
    return c;
  }

  public Campus Listar(string descricao)
  {
    for(int i=0; i<nc; i++)
      if(campus[i].GetDescricao() == descricao) return campus[i];
    
    return null;
  }

  public Campus ListarId(int id)
  {
    for(int i = 0; i<nc; i++)
      if(campus[i].GetId() == id) return campus[i];
    
    return null;
  }

  public void Atualizar(Campus c_velho, string descricao_nova)
  { 
    c_velho.SetDescricao(descricao_nova);
    
    if(c_velho.GetInstituto() != null)
      c_velho.GetInstituto().CampusAtualizar(c_velho); // adiciona o novo campus ao instituto
  }

  public int Indice(Campus c)
  {
    for(int i=0; i<nc; i++)
      if(campus[i] == c) return i;
    return -1;
  }

  public void Excluir(Campus c)
  {
    int n = Indice(c);
    if(n == -1) return;
    for(int i = n; i<nc-1; i++)
      campus[i] = campus[i+1];
    nc--;

    Instituto j = c.GetInstituto();
    if(c != null) j.CampusExcluir(c);

    Curso[] cur = c.CursoListar();
    foreach(Curso x in cur) Ncurso.Singleton.Excluir(x);
    
    Diretoria[] dir = c.DiretoriaListar();
    foreach(Diretoria d in dir) Ndiretoria.Singleton.Excluir(d);
  }
}