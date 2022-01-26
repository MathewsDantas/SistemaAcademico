using System;

class MainClass
{
  private static Ninstituto ninstituto = new Ninstituto();
  private static Ncampus ncampus = new Ncampus();
  private static Ncurso ncurso = new Ncurso();
  
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
    Console.WriteLine("12 - Curso Excluir");
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

    Console.WriteLine("--> Excluindo curso: ");
    Console.WriteLine("Informe o Id do curso a ser excluido: ");
    int id_cur = int.Parse(Console.ReadLine());
    
    Curso cur = cam.CursoListar(id_cur);
    ncurso.Excluir(cur);
  }
}