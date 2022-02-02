using System;
using System.Collections.Generic;

class MainClass
{
  private static Ninstituto ninstituto = new Ninstituto();
  private static Ncampus ncampus = new Ncampus();
  private static Ncurso ncurso = new Ncurso();
  private static Ndiretoria ndiretoria = new Ndiretoria();
  private static Naluno naluno = new Naluno();
  private static Nprofessor nprofessor = new Nprofessor();
  private static Nambiente nambiente = new Nambiente();
  
  static void Main(string[] args)
  {
    int op = 0;
    Console.WriteLine("|-|-|- SISTEMA ACADEMICO -|-|-|");
    do
    {
      try{
        op = Menu();
        switch(op)
        {
          case 1: InstitutoInserir(); break;
          case 2: InstitutoListar(); break;
          case 3: InstitutoAtualizar(); break;
          case 4: InstitutoExcluir(); break;
          case 5: CampusInserir(); break;
          case 6: CampusListar(); break;
          case 7: CampusAtualizar(); break;
          case 8: CampusExcluir(); break;
          case 9: CursoInserir(); break;
          case 10: CursoListar(); break;
          case 11: CursoAtualizar(); break;
          case 12: CursoExcluir(); break;
          case 13: DiretoriaInserir(); break;
          case 14: DiretoriaListar(); break;
          case 15: DiretoriaAtualizar(); break;
          case 16: DiretoriaExcluir(); break;
          case 17: AlunoInserir(); break;
          case 18: AlunoListar(); break;
          case 19: AlunoAtualizar(); break;
          case 20: AlunoExcluir(); break;
          case 21: ProfessorInserir(); break;
          case 22: ProfessorListar(); break;
          case 23: ProfessorAtualizar(); break;
          case 24: ProfessorExcluir(); break;
          case 25: AmbienteInserir(); break;
          case 26: AmbienteListar(); break;
          case 27: AmbienteAtualizar(); break;
          case 28: AmbienteExcluir(); break;             
        }
      }
      catch(Exception erro){
        Console.WriteLine(erro.Message);
        op = 50;
      }
    }while(op != 0);
    Console.WriteLine("Finalizado.");
  }

  public static int Menu()
  {
    Console.WriteLine("\n==================MENU==================");
    Console.WriteLine("1 - Instituto Inserir");
    Console.WriteLine("2 - Instituto Listar");
    Console.WriteLine("3 - Instituto Atualizar");
    Console.WriteLine("4 - Instituto Excluir \n");
    Console.WriteLine("5 - Campus Inserir");
    Console.WriteLine("6 - Campus Listar");
    Console.WriteLine("7 - Campus Atualizar");
    Console.WriteLine("8 - Campus Excluir \n");
    Console.WriteLine("9 - Curso Inserir");
    Console.WriteLine("10 - Curso Listar");
    Console.WriteLine("11 - Curso Atualizar");
    Console.WriteLine("12 - Curso Excluir\n");
    Console.WriteLine("13 - Diretoria Inserir");
    Console.WriteLine("14 - Diretoria Listar");
    Console.WriteLine("15 - Diretoria Atualizar");
    Console.WriteLine("16 - Diretoria Excluir\n");
    Console.WriteLine("17 - Aluno Inserir");
    Console.WriteLine("18 - Aluno Listar");
    Console.WriteLine("19 - Aluno Atualizar");
    Console.WriteLine("20 - Aluno Excluir\n");
    Console.WriteLine("21 - Professor Inserir");
    Console.WriteLine("22 - Professor Listar");
    Console.WriteLine("23 - Professor Atualizar");
    Console.WriteLine("24 - Professor Excluir\n");
    Console.WriteLine("25 - Ambiente Inserir");
    Console.WriteLine("26 - Ambiente Listar");
    Console.WriteLine("27 - Ambiente Atualizar");
    Console.WriteLine("28 - Ambiente Excluir\n");     
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void InstitutoInserir()
  {
    Console.WriteLine("--> Inserindo Instituto: ");
    Console.WriteLine("Informe o Id do instituto: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a descricao do instituto: ");
    string descricao = Console.ReadLine();
    
    Instituto i = new Instituto(id,descricao);
    ninstituto.Inserir(i);
  }

  public static void InstitutoListar()
  {
    Console.WriteLine("--> Listando Instituto: ");
    Instituto[] ins = ninstituto.Listar();
    if(ins.Length == 0)
    {
      Console.WriteLine("Nenhum Instituto cadastrado. ");
      return;
    }
    foreach(Instituto i in ins) Console.WriteLine(i);
    Console.WriteLine();
  }

  public static void InstitutoAtualizar()
  {
    Console.WriteLine("--> Atualizando Instituto: ");
    InstitutoListar();
    Console.WriteLine("Informe o Id do instituto a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe uma descricao: ");
    string descricao = Console.ReadLine();

    Instituto i = new Instituto(id,descricao);
    ninstituto.Atualizar(i);
    Console.WriteLine();
  }


  public static void InstitutoExcluir()
  {
    Console.WriteLine("--> Excluindo Instituto: ");
    InstitutoListar();
    Console.WriteLine("Informe o Id para excluir instituto: ");
    int id = int.Parse(Console.ReadLine());

    Instituto i = ninstituto.Listar(id);
    ninstituto.Excluir(i);
    Console.WriteLine();
  }

  public static void CampusInserir()
  {
    Console.WriteLine("--> Inserindo campus: ");
    Console.WriteLine("Informe o Id do campus: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a descricao do campus: ");
    string descricao = Console.ReadLine();
    InstitutoListar();
    Console.WriteLine("Informe o id do instituto do campus: ");
    int idinstituto = int.Parse(Console.ReadLine());
  
    Instituto i = ninstituto.Listar(idinstituto);
    Campus c = new Campus(id,descricao,i);
    ncampus.Inserir(c);
    Console.WriteLine();
  }

  public static void CampusListar()
  {
    InstitutoListar();
    Console.WriteLine("Escolha o instituto dos campus a serem listados: ");
    int id = int.Parse(Console.ReadLine());
    Instituto ins = ninstituto.Listar(id); // retorna o instituto correspondente.
    Campus[] cam = ins.CampusListar(); // retorna apenas os campus do instituto informado.
    if(cam.Length == 0)
    {
      Console.WriteLine("Nenhum campus cadastrado. ");
      return;
    }
    Array.Sort(cam);
    Console.WriteLine("--> Listando campus: ");
    foreach(Campus i in cam) Console.WriteLine(i);
    Console.WriteLine();
  }

  public static Instituto CampusListar_returnI()
  {
    InstitutoListar();
    Console.WriteLine("Escolha o instituto dos campus a serem listados: ");
    int id = int.Parse(Console.ReadLine());
    Instituto ins = ninstituto.Listar(id); // retorna o instituto correspondente.
    Campus[] cam = ins.CampusListar(); // retorna apenas os campus do instituto informado.
    if(cam.Length == 0)
    {
      Console.WriteLine("Nenhum campus cadastrado. ");
      return null;
    }
    Array.Sort(cam);
    Console.WriteLine("--> Listando campus: ");
    foreach(Campus i in cam) Console.WriteLine(i);
    Console.WriteLine();
    return ins;
  }

  public static void CampusAtualizar()
  {
    InstitutoListar();
    Console.WriteLine("Escolha o instituto dos campus a serem atualizados: ");
    int id_i = int.Parse(Console.ReadLine());
    Instituto ins = ninstituto.Listar(id_i); 
    Campus[] cam = ins.CampusListar();
    Console.WriteLine("--> Atualizando Campus: ");
    foreach(Campus c1 in cam) Console.WriteLine(c1);
    Console.WriteLine();
    Console.WriteLine("Informe o Id do campus a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a descricao do campus: ");
    string descricao_nova = Console.ReadLine();

    Campus c_velho = ins.CampusListar(id);
    ncampus.Atualizar(c_velho,descricao_nova);
    Console.WriteLine();
  }

  public static void CampusExcluir()
  { 
    //---------- CampusListar()---------
    InstitutoListar();
    Console.WriteLine("Escolha o instituto dos campus a serem listados: ");
    int id = int.Parse(Console.ReadLine());
    Instituto ins = ninstituto.Listar(id); // retorna o instituto correspondente.
    Campus[] cam = ins.CampusListar(); // retorna apenas os campus do instituto informado.
    if(cam.Length == 0)
    {
      Console.WriteLine("Nenhum campus cadastrado. ");
      return;
    }
    Array.Sort(cam);
    Console.WriteLine("--> Listando campus: ");
    foreach(Campus i in cam) Console.WriteLine(i);
    Console.WriteLine();
    //-----------------------------------
    Console.WriteLine("--> Excluindo Campus: ");
    Console.WriteLine("Informe o Id do Campus a ser excluir: ");
    int id_Campus = int.Parse(Console.ReadLine());

    Campus c = ins.CampusListar(id_Campus);
    ncampus.Excluir(c);
    Array.Sort(cam);
    Console.WriteLine();
  }

  public static void CursoInserir()
  {
    int aux = 0;
    
    Console.WriteLine("--> Inserindo curso: ");
    Console.WriteLine("Informe o Id do curso: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a descricao do curso: ");
    string descricao = Console.ReadLine();

    while(aux == 0){  // posteriomente: Fazer ligação dos Id com índice do instituto/campus/curso(N sendo necessário informar).
      InstitutoListar();
      Console.WriteLine("Deseja inserir o curso em qual instituto(Id): ");
      int id_Ins = int.Parse(Console.ReadLine());
      Console.WriteLine(); 
      Instituto ins = ninstituto.Listar(id_Ins); 
      Campus[] campus = ins.CampusListar();

      Console.WriteLine("--> Listando Campus: ");
      foreach(Campus c1 in campus) Console.WriteLine(c1);
      Console.WriteLine();
      Console.WriteLine("Informe o Id do campus para inserir o curso: ");
      int id_Cam = int.Parse(Console.ReadLine());
      Campus cam = ins.CampusListar(id_Cam);
      Curso c = new Curso(id,descricao,ins,cam);
      ncurso.Inserir(c);
      Console.WriteLine();
      Console.WriteLine("Deseja adicionar o curso em outro campus?\n SIM - 0\n NAO - 1");
      aux = int.Parse(Console.ReadLine());
      Console.WriteLine();
    }
  }
  public static void CursoListar()
  {
    Console.WriteLine("--> Listando cursos: ");
    Curso[] c = ncurso.Listar();
    foreach(Curso i in c) Console.WriteLine(i);
    if(c.Length == 0)
    {
      Console.WriteLine("Nenhum Curso cadastrado. ");
      return;
    }
  }

  public static void CursoAtualizar()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que o curso está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Curso[] cursos = cam.CursoListar();
    foreach(Curso c in cursos) Console.WriteLine(c);
    Console.WriteLine();
    if(cursos.Length == 0)
    {
      Console.WriteLine("Nenhum Curso cadastrado. ");
      return;
    }

    Console.WriteLine("--> Atualizando curso: ");
    Console.WriteLine("Informe o Id do curso a ser atualizado: ");
    int id_cur = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira a nova descricao: ");
    string descricao = Console.ReadLine();
    
    Curso curso_velho = cam.CursoListar(id_cur);
    ncurso.Atualizar(curso_velho,descricao);
    
  }

  public static void CursoExcluir()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que o curso que deseja excluir está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Curso[] cursos = cam.CursoListar();
    foreach(Curso c in cursos) Console.WriteLine(c);
    Console.WriteLine();
    if(cursos.Length == 0)
    {
      Console.WriteLine("Nenhum Curso cadastrado. ");
      return;
    }
    Console.WriteLine("--> Excluindo curso: ");
    Console.WriteLine("Informe o Id do curso a ser excluido: ");
    int id_cur = int.Parse(Console.ReadLine());
    
    Curso cur = cam.CursoListar(id_cur);
    ncurso.Excluir(cur);
  }

  public static void DiretoriaInserir()
  {
    int aux = 0;
    while (aux == 0)
    {

      Console.WriteLine("--> Inserindo diretoria: ");
      Console.WriteLine("Informe o Id da diretoria");
      int id = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a descricao da diretoria");
      string descricao = Console.ReadLine();

      Instituto ins = CampusListar_returnI();
      Console.WriteLine("Informe o Id do campus para inserir a diretoria: ");
      int id_campus = int.Parse(Console.ReadLine());
      Campus cam = ins.CampusListar(id_campus);
      Diretoria d = new Diretoria(id, descricao, cam);
      ndiretoria.Inserir(d);
      Console.WriteLine();
      Console.WriteLine("Deseja adicionar a diretoria em outro campus?\n SIM - 0\n NAO - 1");
      aux = int.Parse(Console.ReadLine());
      Console.WriteLine();
    
    }
  }
  public static void DiretoriaListar()
  {
    Console.WriteLine("--> Listando diretorias: ");
    Diretoria[] d = ndiretoria.Listar();
    foreach( Diretoria i in d) Console.WriteLine(i);
    if(d.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
  }

  
  public static void DiretoriaExcluir()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que a diretoria que deseja excluir está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);

    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
    Console.WriteLine();

    Console.WriteLine("--> Excluindo Diretoria: ");
    Console.WriteLine("Informe o Id da diretoria a ser excluido: ");

    int id_dir = int.Parse(Console.ReadLine());

    Diretoria dir = cam.DiretoriaListar(id_dir);

    ndiretoria.Excluir(dir);
    
  }

    public static void DiretoriaAtualizar()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que a diretoria está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    Console.WriteLine();
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
    Console.WriteLine("--> Atualizando diretoria: ");
    Console.WriteLine("Informe o Id da diretoria a ser atualizado: ");
    int id_dir = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira a nova descricao: ");
    string descricao = Console.ReadLine();
    
    Diretoria diretoria_velha = cam.DiretoriaListar(id_dir);
    ndiretoria.Atualizar(diretoria_velha,descricao);
    
  }

  public static void AlunoInserir()
  {
    Console.WriteLine("--> Inserindo aluno: ");
    
    Console.WriteLine("Digite o nome do aluno: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe a matricula do aluno: ");
    int matricula = int.Parse(Console.ReadLine());

    Instituto ins = CampusListar_returnI();
    Console.WriteLine("Informe o Id do Campus do aluno: ");
    int id_cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_cam);
    Diretoria[] dir = cam.DiretoriaListar();
    foreach(Diretoria d in dir) Console.WriteLine(d);
    Console.WriteLine("\nInforme o Id da diretoria do aluno: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir_aln = cam.DiretoriaListar(id_dir);

    Aluno al = new Aluno(nome,matricula,dir_aln);
    naluno.Inserir(al);
  }

  public static void AlunoListar()
  {
    Console.WriteLine("--> Listando alunos ");
    List<Aluno> alns = naluno.Listar();
    foreach(Aluno a in alns) Console.WriteLine(a);
  }

  public static void AlunoAtualizar()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus do aluno está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    Console.WriteLine();
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }

    Console.WriteLine("Informe o Id da diretoria que o aluno está presente: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Aluno> alns = dir.AlunoListar();
    foreach(Aluno a in alns) Console.WriteLine(a);
    Console.WriteLine();
    if(alns.Count == 0)
    {
      Console.WriteLine("Nenhum Aluno encontrado. ");
      return;
    }
    Console.WriteLine("--> Atualizando aluno: ");
    Console.WriteLine("Insira o Id do aluno a ser atualizado: ");
    int id_aln = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o novo nome: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Insira a nova matricula: ");
    int matricula = int.Parse(Console.ReadLine());

    Aluno al = new Aluno(nome,matricula,dir);
    al.SetId(id_aln);
    naluno.Atualizar(al);
  }

  public static void AlunoExcluir()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que o aluno está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);

    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
    Console.WriteLine();
    Console.WriteLine("Informe o Id da diretoria do aluno: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Aluno> alns = dir.AlunoListar();
    foreach(Aluno a in alns) Console.WriteLine(a);
    Console.WriteLine();
    if(alns.Count == 0)
    {
      Console.WriteLine("Nenhum Aluno encontrado. ");
      return;
    }
    Console.WriteLine("--> Excluindo Aluno: ");
    Console.WriteLine("Informe o Id do aluno a ser excluido: ");
    int id_Alns = int.Parse(Console.ReadLine());
    

    Aluno aln = dir.AlunoListar(id_Alns);
    naluno.Excluir(aln);
  }

  public static void ProfessorInserir()
  {
    Console.WriteLine("--> Inserindo Professor: ");
    
    Console.WriteLine("Digite o nome do Professor: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe a matricula do Professor: ");
    int matricula = int.Parse(Console.ReadLine());

    Instituto ins = CampusListar_returnI();
    Console.WriteLine("Informe o Id do Campus do Professor: ");
    int id_cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_cam);
    Diretoria[] dir = cam.DiretoriaListar();
    foreach(Diretoria d in dir) Console.WriteLine(d);
    Console.WriteLine("\nInforme o Id da diretoria do Professor: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir_prf = cam.DiretoriaListar(id_dir);

    Professor pr = new Professor(nome,matricula,dir_prf);
    nprofessor.Inserir(pr);
  }

  public static void ProfessorListar()
  {
    Console.WriteLine("--> Listando Professores ");
    List<Professor> prfs = nprofessor.Listar();
    foreach(Professor p in prfs) Console.WriteLine(p);
  }

  public static void ProfessorAtualizar()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus do Professor está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    Console.WriteLine();
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }

    Console.WriteLine("Informe o Id da diretoria que o Professor está presente: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Professor> prfs = dir.ProfessorListar();
    foreach(Professor p in prfs) Console.WriteLine(p);
    Console.WriteLine();
    if(prfs.Count == 0)
    {
      Console.WriteLine("Nenhum Professor encontrado. ");
      return;
    }
    Console.WriteLine("--> Atualizando Professor: ");
    Console.WriteLine("Insira o Id do Professor a ser atualizado: ");
    int id_prf = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o novo nome: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Insira a nova matricula: ");
    int matricula = int.Parse(Console.ReadLine());

    Professor pr = new Professor(nome,matricula,dir);
    pr.SetId(id_prf);
    nprofessor.Atualizar(pr);
  }

  public static void  ProfessorExcluir()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que o Professor está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);

    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
    Console.WriteLine();
    Console.WriteLine("Informe o Id da diretoria do Professor: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Professor> prfs = dir.ProfessorListar();
    foreach(Professor p in prfs) Console.WriteLine(p);
    Console.WriteLine();
    if(prfs.Count == 0)
    {
      Console.WriteLine("Nenhum Professor encontrado. ");
      return;
    }
    Console.WriteLine("--> Excluindo Professor: ");
    Console.WriteLine("Informe o Id do Professor a ser excluido: ");
    int id_Prfs = int.Parse(Console.ReadLine());
    

    Professor prf = dir.ProfessorListar(id_Prfs);
    nprofessor.Excluir(prf);
  }



  public static void AmbienteInserir()
  {
    Console.WriteLine("--> Inserindo ambiente: ");
    
    Console.WriteLine("Digite o nome do ambiente: ");
    string espaco = Console.ReadLine();

    Instituto ins = CampusListar_returnI();
    Console.WriteLine("Informe o Id do Campus do ambiente: ");
    int id_cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_cam);
    Diretoria[] dir = cam.DiretoriaListar();
    foreach(Diretoria d in dir) Console.WriteLine(d);
    Console.WriteLine("\nInforme o Id da diretoria do ambiente: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir_amb = cam.DiretoriaListar(id_dir);

    Ambiente amb = new Ambiente(espaco,dir_amb);
    nambiente.Inserir(amb);
  }

  public static void AmbienteListar()
  {
    Console.WriteLine("--> Listando ambientes: ");
    List<Ambiente> ambs = nambiente.Listar();
    foreach(Ambiente a in ambs) Console.WriteLine(a);
  }

  public static void AmbienteAtualizar()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus do ambiente está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);
    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    Console.WriteLine();
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }

    Console.WriteLine("Informe o Id da diretoria que o ambiente está presente: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Ambiente> ambs = dir.AmbienteListar();
    foreach(Ambiente a in ambs) Console.WriteLine(a);
    Console.WriteLine();
    if(ambs.Count == 0)
    {
      Console.WriteLine("Nenhum Ambiente encontrado. ");
      return;
    }
    Console.WriteLine("--> Atualizando ambiente: ");
    Console.WriteLine("Insira o Id do ambiente a ser atualizado: ");
    int id_amb = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o novo espaco: ");
    string espaco = Console.ReadLine();


    Ambiente amb = new Ambiente(espaco,dir);
    amb.SetId(id_amb);
    nambiente.Atualizar(amb);
  }

  public static void AmbienteExcluir()
  {
    Instituto ins = CampusListar_returnI();
    
    Console.WriteLine("Informe o Id do Campus em que o ambiente está: ");
    int id_Cam = int.Parse(Console.ReadLine());
    Campus cam = ins.CampusListar(id_Cam);

    Diretoria[] diretorias = cam.DiretoriaListar();
    foreach(Diretoria d in diretorias) Console.WriteLine(d);
    if(diretorias.Length == 0)
    {
      Console.WriteLine("Nenhuma Diretoria cadastrada. ");
      return;
    }
    Console.WriteLine();
    Console.WriteLine("Informe o Id da diretoria do ambiente: ");
    int id_dir = int.Parse(Console.ReadLine());
    Diretoria dir = cam.DiretoriaListar(id_dir);
    List<Ambiente> ambs = dir.AmbienteListar();
    foreach(Ambiente a in ambs) Console.WriteLine(a);
    Console.WriteLine();
    if(ambs.Count == 0)
    {
      Console.WriteLine("Nenhum Ambiente encontrado. ");
      return;
    }
    Console.WriteLine("--> Excluindo Ambiente: ");
    Console.WriteLine("Informe o Id do ambiente a ser excluido: ");
    int id_Ambs = int.Parse(Console.ReadLine());
    

    Ambiente amb = dir.AmbienteListar(id_Ambs);
    nambiente.Excluir(amb);
  }
}