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
  private static Ndisciplina ndisciplina = new Ndisciplina();
  private static Nturmadiario nturmadiario = new Nturmadiario();

  private static Aluno alunologin = null;
  private static Professor professorlogin = null;  

  static void Main(string[] args)
  {

    //VARIAVEIS MENU
    int op = 0;
    int perfil = 0;


    //INICIO DO MENU
    Console.WriteLine("|-|-|- SISTEMA ACADEMICO -|-|-|");
    do
    {
      try{

          //PERFIL USUARIO
          if (perfil == 0)
          {
            op = 0;
            perfil = MenuUsuario();  
          }

          //PERFIL ALUNO
          if (perfil == 1 && alunologin == null)
          {
            op = MenuAlunoLogin();
            switch(op)
            {
              case 1: AlunoLogin(); break;
              case 99: perfil = 0; break;
            }
          }
          if (perfil == 1 && alunologin != null)
          {
            op = MenuAlunoLogout();
          } 

          //PERFIL PROFESSOR
          if (perfil == 2 && professorlogin == null)
          {
            op = MenuProfessorLogin(); 
            switch(op)
            {
              case 1: ProfessorLogin(); break;
              case 99: perfil = 0; break;
            }                 
          }
          if (perfil == 2 && professorlogin != null)
          {
            op = MenuProfessorLogout();      
          } 

          //PERFIL COORDENAÇÃO
          if (perfil == 3)
          {
            op = MenuCoordenacao();  
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
              case 29: DisciplinaInserir(); break;
              case 30: DisciplinaListar(); break;
              case 31: DisciplinaAtualizar(); break;
              case 32: DisciplinaExcluir(); break;
              case 33: TurmaInserir(); break;
              case 34: TurmaListar(); break;
              case 35: TurmaAtualizar(); break;
              case 36: TurmaExcluir(); break; case 99: perfil = 0; break;    

            }        
          } 
        } 
          catch(Exception erro)
          {
            Console.WriteLine(erro.Message);
            op = 50;
          }
    }while(op != 0);
    Console.WriteLine("Finalizado.");
  }       

  public static int MenuUsuario()
  {
    Console.WriteLine("\n===============MENU================");
    Console.WriteLine("1 - Entrar como Aluno");
    Console.WriteLine("2 - Entrar como Professor");
    Console.WriteLine("3 - Entrar como Coordenação");    
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuCoordenacao()
  {
    Console.WriteLine("\n==================MENU COORDENAÇÃO==================");
    Console.WriteLine("1 - Instituto Inserir    19 - Aluno Atualizar");
    Console.WriteLine("2 - Instituto Listar     20 - Aluno Excluir ");
    Console.WriteLine("3 - Instituto Atualizar  21 - Professor Inserir        ");
    Console.WriteLine("4 - Instituto Excluir    22 - Professor Listar    ");
    Console.WriteLine("5 - Campus Inserir       23 - Professor Atualizar  ");
    Console.WriteLine("6 - Campus Listar        24 - Professor Excluir");
    Console.WriteLine("7 - Campus Atualizar     25 - Ambiente Inserir");
    Console.WriteLine("8 - Campus Excluir       26 - Ambiente Listar");
    Console.WriteLine("9 - Curso Inserir        27 - Ambiente Atualizar ");
    Console.WriteLine("10 - Curso Listar        28 - Ambiente Excluir ");
    Console.WriteLine("11 - Curso Atualizar     29 - Disciplina Inserir ");
    Console.WriteLine("12 - Curso Excluir       30 - Disciplina Listar");
    Console.WriteLine("13 - Diretoria Inserir   31 - Disciplina Atualizar");
    Console.WriteLine("14 - Diretoria Listar    32 - Disciplina Excluir");
    Console.WriteLine("15 - Diretoria Atualizar 33 - Turma Inserir ");
    Console.WriteLine("16 - Diretoria Excluir   34 - Turma Listar");
    Console.WriteLine("17 - Aluno Inserir       35 - Turma Atualizar");
    Console.WriteLine("18 - Aluno Listar        36 - Turma Excluir");    
    Console.WriteLine("99 - Logout\n");        
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuAlunoLogout()
  {
    Console.WriteLine("\n==================MENU ALUNO==================");
    Console.WriteLine("1 - Turma Listar");
    Console.WriteLine("2 - Nota Listar");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuAlunoLogin()
  {
    Console.WriteLine("\n==================MENU==================");
    Console.WriteLine("1 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }  

  public static int MenuProfessorLogout()
  {
    Console.WriteLine("\n==================MENU PROFESSOR==================");
    Console.WriteLine("1 - Turma Listar");
    Console.WriteLine("2 - Aluno Listar");
    Console.WriteLine("3 - Nota Inserir");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuProfessorLogin()
  {
    Console.WriteLine("\n==================MENU==================");
    Console.WriteLine("1 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("Informe sua opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }  
  //FIM DO MENU 


  //FUNÇÕES MAIN

  public static void AlunoLogin()
  {

    Console.WriteLine("----- Login do Aluno -----");
    AlunoListar();
    Console.Write("Informe o código do aluno para logar");
    int id = int.Parse(Console.ReadLine());
    // Procura o aluno com esse id
    alunologin = naluno.Listar(id);
  }
  public static void AlunoLogout()
  {
    Console.WriteLine("----- Logout do Aluno -----");
    alunologin = null;
  }

  public static void ProfessorLogin()
  {
    Console.WriteLine("----- Login do Professor -----");
    ProfessorListar();
    Console.Write("Informe o código do professor para logar");
    int id = int.Parse(Console.ReadLine());
    // Procura o aluno com esse id
    professorlogin = nprofessor.Listar(id);
  }
  public static void ProfessorLogout()
  {
    Console.WriteLine("----- Logout do Professor -----");
    professorlogin = null;
  }


  public static void InstitutoInserir()
  {
    Console.WriteLine("--> Inserindo Instituto: ");
    
    Console.WriteLine("Informe a descricao do instituto: ");
    string descricao = Console.ReadLine();
    
    Instituto i = new Instituto(descricao);
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

    Instituto i = new Instituto(descricao);
    i.SetId(id);
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
    
    Console.WriteLine("Informe a descricao do campus: ");
    string descricao = Console.ReadLine();
    InstitutoListar();
    Console.WriteLine("Informe o id do instituto do campus: ");
    int idinstituto = int.Parse(Console.ReadLine());
  
    Instituto i = ninstituto.Listar(idinstituto);
    Campus c = new Campus(descricao,i);
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
      Curso c = new Curso(descricao,ins,cam);
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
     
      Console.WriteLine("Digite a descricao da diretoria: ");
      string descricao = Console.ReadLine();

      Instituto ins = CampusListar_returnI();
      Console.WriteLine("Informe o Id do campus para inserir a diretoria: ");
      int id_campus = int.Parse(Console.ReadLine());
      Campus cam = ins.CampusListar(id_campus);
      Diretoria d = new Diretoria(descricao, cam);
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
    long matricula = long.Parse(Console.ReadLine());

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
    if (alns.Count == 0)
    { 
      Console.WriteLine("Nenhum Aluno Cadastrado");
    }
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
    long matricula = long.Parse(Console.ReadLine());

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
    long matricula = long.Parse(Console.ReadLine());

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
    if (prfs.Count == 0)
    { 
      Console.WriteLine("Nenhum Professor Cadastrado");
    }
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
    long matricula = long.Parse(Console.ReadLine());

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
  
  public static void DisciplinaInserir()
  {
    Console.WriteLine("--> Inserindo Disciplina: ");

    Console.WriteLine("Digite a descricao da Disciplina: ");
    string descricao = Console.ReadLine();
    Console.WriteLine("\nDigite o periodo(Vesp/Matu) da Disciplina: ");
    string periodo = Console.ReadLine();
    
    CursoListar();
    Console.WriteLine("\nInforme o Id do curso para inserir a Disciplina: ");
    int id_cur = int.Parse(Console.ReadLine());
    Curso curso = ncurso.Listar(id_cur);

    Disciplina disc = new Disciplina(descricao,periodo,curso);
    ndisciplina.Inserir(disc);
  }

  public static void DisciplinaListar()
  {
    Console.WriteLine("--> Listando Disciplinas: ");
    List<Disciplina> disc = ndisciplina.Listar();
    foreach(Disciplina d in disc) Console.WriteLine(d);
    if(disc.Count == 0) Console.WriteLine("Nenhuma disciplina cadastrada. ");
  }

  public static void DisciplinaAtualizar()
  {
    Console.WriteLine("--> Atualizando Disciplina: ");
    DisciplinaListar();
    Console.WriteLine("Insira o Id da Disciplina que deseja atualizar: ");
    int id_disc = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a nova descricao da Disciplina: ");
    string descricao = Console.ReadLine();
    Console.WriteLine("Digite o novo periodo(Vesp/Matu) da Disciplina: ");
    string periodo = Console.ReadLine();

    CursoListar();
    Console.WriteLine("Informe o Id do curso para inserir a Disciplina: ");
    int id_cur = int.Parse(Console.ReadLine());
    Curso curso = ncurso.Listar(id_cur);

    Disciplina disciplina = new Disciplina(descricao,periodo,curso);
    disciplina.SetId(id_disc);
    ndisciplina.Atualizar(disciplina);
  }

  public static void DisciplinaExcluir()
  {
    Console.WriteLine("--> Excluindo Disciplina: ");
    DisciplinaListar();
    Console.WriteLine("Insira o Id da Disciplina que deseja Excluir: ");
    int id_disc = int.Parse(Console.ReadLine());
    Disciplina disciplina = ndisciplina.Listar(id_disc);
    ndisciplina.Excluir(disciplina);
  }
  

  public static void TurmaInserir()
  {
    Console.WriteLine("--> Inserindo Turmas: ");
    DisciplinaListar();
    Console.WriteLine("Informe o Id da Disciplina em que deseja criar uma turma: ");
    int id_disc = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o semestre da turma(20xx.x):");
    string semestre = Console.ReadLine();
    Console.WriteLine("Informe a hora do inicio da aula: ");
    int hora_inicio = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a hora do fim da aula: ");
    int hora_fim = int.Parse(Console.ReadLine());

    Disciplina disciplina = ndisciplina.Listar(id_disc);
    Turmadiario turma = new Turmadiario(semestre,hora_inicio,hora_fim,disciplina);
    nturmadiario.Inserir(turma);
  }

  public static void TurmaListar()
  {
    Console.WriteLine("--> Listando Turmas: ");
    List<Turmadiario> turm = nturmadiario.Listar();
    foreach(Turmadiario t in turm) Console.WriteLine(t);
    if(turm.Count == 0) Console.WriteLine("Nenhuma turma cadastrada. ");
  }

  public static void TurmaAtualizar()
  {
    Console.WriteLine("--> Atualizando Turma: ");
    TurmaListar();
    Console.WriteLine("Insira o Id da Turma que deseja atualizar: ");
    int id_turma = int.Parse(Console.ReadLine());
    Console.WriteLine("Insira o semestre da turma(20xx.x):");
    string semestre = Console.ReadLine();
    Console.WriteLine("Informe a hora do inicio da aula: ");
    int hora_inicio = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a hora do fim da aula: ");
    int hora_fim = int.Parse(Console.ReadLine());

    DisciplinaListar();
    Console.WriteLine("Informe o Id da disciplina para inserir a Turma: ");
    int id_disc = int.Parse(Console.ReadLine());
    Disciplina disciplina = ndisciplina.Listar(id_disc);

    Turmadiario turma = new Turmadiario(semestre,hora_inicio,hora_fim, disciplina);
    turma.SetId(id_turma);
    nturmadiario.Atualizar(turma);
  }

  public static void TurmaExcluir()
  {
    Console.WriteLine("--> Excluindo Turma: ");
    TurmaListar();
    Console.WriteLine("Insira o Id da Turma que deseja Excluir: ");
    int id_turma = int.Parse(Console.ReadLine());
    Turmadiario turma = nturmadiario.Listar(id_turma);
    nturmadiario.Excluir(turma);
  }

}