using System;

namespace Prj_Jogo_da_Velha
{
    //Classe Program.
    class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;

            Jogo novojogo = new Jogo();
            Player Jogador = new Player();
            CPU IA = new CPU();
            string resp = "S";

            while (resp == "S")
            {
                Console.Clear();

                if (resp == "S")
                {
                    novojogo.CriaTabuleiro();
                    novojogo.PrintaTabuleiro();
                    int turno = 0;

                    while (!novojogo.gameOver)
                    {
                        turno++;
                        Jogador.VezJogador(novojogo);

                        if (!novojogo.VerficiaVencedor(turno))
                        {
                            turno++;
                            IA.VezIA(novojogo, turno);
                            novojogo.VerficiaVencedor(turno);
                        }
                        else
                        {
                            Console.Clear();
                            novojogo.VerficiaVencedor(turno);
                            novojogo.PrintaTabuleiro();
                        }
                    }

                    resp = "A";
                }
                Console.WriteLine("Fim de Jogo!\nQuer jogar novamente? S\\N");

                while (resp != "S" && resp != "N")
                {
                    if (resp != "S" && resp != "N")
                    {
                        Console.WriteLine("Responda apenas com S ou N!");
                    }
                    resp = Convert.ToString(Console.ReadLine());
                    resp = resp.ToUpper();
                }
            }
            Console.Write("Aperte qualquer tecla para continuar . . . ");
            Console.ReadKey(true);
        }
    }

    //Classe Jogo.
    public class Jogo
    {
        public char J_simbolo = 'X';
        public char IA_simbolo = 'O';
        public bool gameOver = false;
        public char[,] tabuleiro = new char[3, 3];
        public int linhaE, colunaE;

        //Cria o tabuleiro.
        public void CriaTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }
            gameOver = false;
        }
        //Printa o Tabuleiro.
        public void PrintaTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}", tabuleiro[i, j]);
                }
                Console.WriteLine();
            }
        }
        //Verifica quem venceu.
        public bool VerficiaVencedor(int turno)
        {
            if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2])
            {
                if (tabuleiro[0, 0] != '-')
                {
                    Console.WriteLine("{0} venceu!\n", tabuleiro[0, 0]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2])
            {
                if (tabuleiro[1, 0] != '-')
                {
                    Console.WriteLine("{0} venceu!\n", tabuleiro[1, 0]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2])
            {
                if (tabuleiro[2, 0] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[2, 0]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0])
            {
                if (tabuleiro[0, 0] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[0, 0]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1])
            {
                if (tabuleiro[0, 1] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[0, 1]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2])
            {
                if (tabuleiro[0, 2] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[0, 2]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
            {
                if (tabuleiro[0, 0] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[0, 0]);
                    gameOver = true;
                    return true;
                }
            }
            else if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
            {
                if (tabuleiro[0, 2] != '-')
                {
                    Console.WriteLine("{0} Venceu!\n", tabuleiro[0, 2]);
                    gameOver = true;
                    return true;
                }
            }
            else if (turno >= 9)
            {
                Console.WriteLine("O jogo empatou.\n");
                gameOver = true;
                return true;
            }

            gameOver = false;
            return false;
        }
    }

    //Classe Player.
    class Player : Jogo
    {
        //Verifica se a posição esta livre.
        public void VezJogador(Jogo obj)
        {
            bool EstaLivre = true;
            while (EstaLivre)
            {
                PegaPosicao();
                if (obj.tabuleiro[linhaE, colunaE] != '-')
                {
                    Console.WriteLine("Posição já preenchida!");
                }
                else
                {
                    EstaLivre = false;
                    obj.tabuleiro[linhaE, colunaE] = 'X';
                }
            }
        }
        //Pega as posições.
        public void PegaPosicao()
        {
            linhaE = -1;
            colunaE = -1;
            while (linhaE < 0 || linhaE > 2)
            {
                Console.Write("\nEscolha a LINHA, entre 0 - 2 : ");
                linhaE = Convert.ToInt32(Console.ReadLine());
            }
            while (colunaE < 0 || colunaE > 2)
            {
                Console.Write("Escolha a COLUNA, entre 0 - 2 : ");
                colunaE = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    //Classe CPU.
    class CPU : Jogo
    {
        int cpuL, cpuC;
        //Segunda função inteligente.
        public void VezIA(Jogo obj, int turno)
        {
            int posL, posC;

            if (IAmove(obj, turno, IA_simbolo, out posL, out posC))
            {
                obj.tabuleiro[posL, posC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (IAmove(obj, turno, J_simbolo, out posL, out posC))
            {
                obj.tabuleiro[posL, posC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            IAmove(obj, turno, J_simbolo, out posL, out posC);
            obj.tabuleiro[posL, posC] = 'O';
            Console.Clear();
            obj.PrintaTabuleiro();
            return;
        }

        //Movimentos da IA.
        public bool IAmove(Jogo obj, int turno, char Simbolo, out int posL, out int posC)
        {
            posL = 0;
            posC = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (obj.tabuleiro[i, j] == '-')
                    {
                        obj.tabuleiro[i, j] = Simbolo;
                        if (!obj.VerficiaVencedor(turno))
                        {
                            obj.tabuleiro[i, j] = '-';
                            posL = i;
                            posC = j;
                            continue;
                        }
                        else if (obj.VerficiaVencedor(turno))
                        {
                            obj.tabuleiro[i, j] = '-';
                            posL = i;
                            posC = j;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Função inteligente.
        public void IA_Turno(Jogo obj)
        {
            if (D_Primaria(obj, J_simbolo, cpuC, cpuL) || D_Primaria(obj, IA_simbolo, cpuC, cpuL))
            {
                obj.tabuleiro[cpuL, cpuC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (D_Secundaria(obj, J_simbolo, cpuC, cpuL) || D_Secundaria(obj, IA_simbolo, cpuC, cpuL))
            {
                obj.tabuleiro[cpuL, cpuC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Linhas(obj, J_simbolo, 0, cpuC) || Linhas(obj, IA_simbolo, 0, cpuC))
            {
                obj.tabuleiro[0, cpuC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Linhas(obj, J_simbolo, 1, cpuC) || Linhas(obj, IA_simbolo, 1, cpuC))
            {
                obj.tabuleiro[1, cpuC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Linhas(obj, J_simbolo, 2, cpuC) || Linhas(obj, IA_simbolo, 2, cpuC))
            {
                obj.tabuleiro[2, cpuC] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Colunas(obj, J_simbolo, 0, out cpuL) || Colunas(obj, IA_simbolo, 0, out cpuL))
            {
                obj.tabuleiro[cpuL, 0] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Colunas(obj, J_simbolo, 1, out cpuL) || Colunas(obj, IA_simbolo, 1, out cpuL))
            {
                obj.tabuleiro[cpuL, 1] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else if (Colunas(obj, J_simbolo, 2, out cpuL) || Colunas(obj, IA_simbolo, 2, out cpuL))
            {
                obj.tabuleiro[cpuL, 2] = 'O';
                Console.Clear();
                obj.PrintaTabuleiro();
                return;
            }
            else
            {
                MelhorPosicao(obj, cpuL, cpuC);
                if (cpuL != -1 && cpuC != -1)
                {
                    obj.tabuleiro[cpuL, cpuC] = 'O';
                    Console.Clear();
                    obj.PrintaTabuleiro();
                    return;
                }
            }
        }

        //Verificia a chance de vencer nas linhas com dois. (Máquina)
        private bool Linhas(Jogo obj, char Simbolo, int linha, int coluna)
        {
            coluna = -1;
            int cont = 0;

            for (int j = 0; j < 3; j++)
            {
                if (obj.tabuleiro[linha, j] == Simbolo)
                {
                    cont++;
                }
                else if (obj.tabuleiro[linha, j] == '-')
                {
                    coluna = j;
                }
            }
            if (cont == 2 && coluna != -1)
            {
                return true; //É possível ganhar na linha.
            }
            else
            {
                return false; //Não é possível ganhar na linha.
            }
        }

        //Verificia a chance de vencer nas colunas com dois. (Máquina)
        private bool Colunas(Jogo obj, char Simbolo, int coluna, out int linha)
        {
            linha = -1;
            int cont = 0;

            for (int j = 0; j < 3; j++)
            {
                if (obj.tabuleiro[j, coluna] == Simbolo)
                {
                    cont++;
                }
                else if (obj.tabuleiro[j, coluna] == '-')
                {
                    linha = j;
                }
            }
            if (cont == 2 && linha != -1)
            {
                return true; //É possível ganhar na coluna.
            }
            else
            {
                return false; //Não é possível ganhar na coluna.
            }
        }

        //Verificia a chance de vencer na diagonal primária com dois. (Máquina)
        private bool D_Primaria(Jogo obj, char Simbolo, int coluna, int linha)
        {
            linha = -1;
            coluna = -1;
            int cont = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        if (obj.tabuleiro[i, j] == Simbolo)
                        {
                            cont++;
                        }
                        else if (obj.tabuleiro[i, j] == '-')
                        {
                            coluna = j;
                            linha = i;
                        }
                    }
                }
            }
            if (cont == 2 && linha != -1 && coluna != -1)
            {
                return true; //É possível ganhar na diagonal primária.
            }
            else
            {
                return false; //Não é possível ganhar na diagonal primária.
            }
        }

        //Verificia a chance de vencer na diagonal secundária com dois. (Máquina)
        private bool D_Secundaria(Jogo obj, char Simbolo, int coluna, int linha)
        {
            linha = -1;
            coluna = -1;
            int cont = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i + j == 2)
                    {
                        if (obj.tabuleiro[i, j] == Simbolo)
                        {
                            cont++;
                        }
                        else if (obj.tabuleiro[i, j] == '-')
                        {
                            coluna = j;
                            linha = i;
                        }
                    }
                }
            }
            if (cont == 2 && linha != -1 && coluna != -1)
            {
                return true; //É possível ganhar na diagonal secundária.
            }
            else
            {
                return false; //Não é possível ganhar na diagonal secundária.
            }
        }

        //Verifica a melhor posição. (Máquina)
        private void MelhorPosicao(Jogo obj, int linha, int coluna)
        {
            linha = -1;
            coluna = -1;

            if (linhaE == colunaE)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == j)
                        {
                            if (obj.tabuleiro[i, j] == '-')
                            {
                                linha = i;
                                coluna = j;
                                return;
                            }
                        }
                    }
                }
            }

            if (linhaE + colunaE == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i + j == 2)
                        {
                            if (obj.tabuleiro[i, j] == '-')
                            {
                                linha = i;
                                coluna = j;
                                return;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (obj.tabuleiro[colunaE, j] == '-')
                {
                    linha = linhaE;
                    coluna = j;
                    return;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (obj.tabuleiro[j, colunaE] == '-')
                {
                    linha = j;
                    coluna = colunaE;
                    return;
                }
            }
        }
    }
}