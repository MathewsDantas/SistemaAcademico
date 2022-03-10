using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Ncurso
{
  private int ncur;
  private Curso[] cursos = new Curso[5];

  private Ncurso(){}
  static Ncurso obj = new Ncurso();
  public static Ncurso Singleton { get => obj;} 
  
  public void Inserir(Curso c)
  {
    if(cursos.Length == ncur)
    {
      Array.Resize(ref cursos, 2*cursos.Length);
    }
    int max = 0;
    for(int i = 0; i<ncur; i++)
      if(cursos[i].GetId() > max) max = cursos[i].GetId();
    
    c.SetId(max + 1);
    cursos[ncur] = c;
    ncur++;

    Instituto ins = c.GetInstituto();
    Campus cam = c.GetCampus();
    ins.CursoInserir(c);
    cam.CursoInserir(c);
  }

  public void Salvar()
  {
    Arquivo<Curso[]> d = new Arquivo<Curso[]>();
    d.Salvar("./curso.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<Curso[]> d = new Arquivo<Curso[]>();
    cursos = d.Abrir("./curso.xml");
    ncur = cursos.Length;
    AtualizarCampus();
  }

  public void AtualizarCampus()
  {
    for(int i = 0; i < ncur; i++)
    {
      Curso c = cursos[i];

      Campus cam = Ncampus.Singleton.ListarId(c.CampusId);
      if(cam != null){
        c.SetCampus(cam);
        cam.CursoInserir(c);
      }
    }
  }


  public Curso[] Listar()
  {
    Curso[] c = new Curso[ncur];
    Array.Copy(cursos,c,ncur);
    return c;
  }

  public Curso Listar(int id)
  {
    for(int i = 0; i<ncur; i++)
      if(cursos[i].GetId() == id) return cursos[i];
    
    return null;
  }

  public void Atualizar(Curso c_velho,string descricao_nova)
  {
    c_velho.SetDescricao(descricao_nova);

    if(c_velho.GetCampus() != null)
      c_velho.GetCampus().CursoAtualizar(c_velho); // adiciona o novo curso ao campus
    if(c_velho.GetInstituto() != null)
    {
      c_velho.GetInstituto().CursoAtualizar(c_velho);
    }
  }

  public int Indice(Curso c)
  {
    for(int i=0; i<ncur; i++)
      if(cursos[i] == c) return i;
    return -1;
  }

  public void Excluir(Curso c)
  {
    int n = Indice(c);
    if(n == -1) return;
    for(int i = n; i<ncur-1; i++)
      cursos[i] = cursos[i+1];
    ncur--;

    Instituto ins = c.GetInstituto();
    Campus cam = c.GetCampus();
    if(c != null){
      ins.CursoExcluir(c);
      cam.CursoExcluir(c);
    }
  }

}