using System;


namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterInfoUsuario();
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: Adicionar Alunos
                        Aluno aluno = new Aluno();
                        
                        
                        Console.WriteLine("Informe o nome do Aluno");
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno");
                        
                        if(Decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Formato do valor inserido está incorreto");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach(var a in alunos)
                        {   
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Nome do Aluno: {a.Nome}");
                                Console.WriteLine($"Nota do Aluno: {a.Nota}");    
                            }
                           
                        }

                        break;

                    case "3":
                        //TODO: Calcular média geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        Conceito conceitoGeral;
                        for(int i = 0; i < alunos.Length;i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;

                            }       
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Média Geral = {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterInfoUsuario();
            }
            
        }

        private static string ObterInfoUsuario()
        {
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
