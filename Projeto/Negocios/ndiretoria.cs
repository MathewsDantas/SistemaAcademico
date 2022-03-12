using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;

class Ndiretoria
{
  private int ndir;
  private Diretoria[] diretorias = new Diretoria[5];

  private Ndiretoria(){}
  static Ndiretoria obj = new Ndiretoria();
  public static Ndiretoria Singleton { get => obj;}
  
  public void Inserir(Diretoria d)
  {
    if(diretorias.Length == ndir)
    {
      Array.Resize(ref diretorias, 2*diretorias.Length);
    }
    int max = 0;
    for(int i = 0; i<ndir; i++)
      if(diretorias[i].GetId() > max) max = diretorias[i].GetId();
    
    d.SetId(max + 1);

    diretorias[ndir] = d;
    ndir++;
    Campus cam = d.GetCampus();
    cam.DiretoriaInserir(d);
  }

  public void Salvar()
  {
    Arquivo<Diretoria[]> d = new Arquivo<Diretoria[]>();
    d.Salvar("./diretoria.xml",Listar());
  }

  public void Abrir()
  {
    Arquivo<Diretoria[]> d = new Arquivo<Diretoria[]>();
    diretorias = d.Abrir("./diretoria.xml");
    ndir = diretorias.Length;
    AtualizarCampus();
  }

  public void AtualizarCampus()
  {
    for(int i = 0; i<ndir; i++)
    {
      Diretoria d = diretorias[i];

      Campus cam = Ncampus.Singleton.ListarId(d.CampusId);
      if(cam != null){
        d.SetCampus(cam);
        cam.DiretoriaInserir(d);
      }
    }
  }
  
  public Diretoria[] Listar()
  {
    Diretoria[] d = new Diretoria[ndir];
    Array.Copy(diretorias,d,ndir);
    return d;
  }

  public int Indice(Diretoria d)
  {
    for(int i=0; i<ndir; i++)
      if(diretorias[i] == d) return i;
    return -1;
  }

  public Diretoria Listar(int id)
  {
    for(int i = 0; i<ndir; i++)
      if(diretorias[i].GetId() == id) return diretorias[i];
    
    return null;
  }

  public void Excluir(Diretoria d)
  {
    
    int n = Indice(d);
    if(n == -1) return;
    for(int i = n; i<ndir-1; i++)
      diretorias[i] = diretorias[i+1];
    ndir--;

    Campus cam = d.GetCampus();
    if(d != null){
      cam.DiretoriaExcluir(d);
    }
    
    List<Professor> p = d.ProfessorListar();
    foreach(Professor i in p.ToList()) Nprofessor.Singleton.Excluir(i);
    
    List<Aluno> a = d.AlunoListar();
    foreach(Aluno i in a.ToList()) Naluno.Singleton.Excluir(i);
    
    List<Ambiente> am = d.AmbienteListar();
    foreach(Ambiente i in am.ToList()) Nambiente.Singleton.Excluir(i);
  }

  public void Atualizar(Diretoria d_velha,string descricao_nova)
  {
  d_velha.SetDescricao(descricao_nova);

  if(d_velha.GetCampus() != null)
    d_velha.GetCampus().DiretoriaAtualizar(d_velha); // adiciona o novo curso ao campus
  }
  

}