using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slider
{
    class Program
    {
        static void Main(string[] args)
        {
            Program game = new Program();
            //game start
            if (args.Length != 0)
                game.Run(args);
            else
            {
                string s = Console.ReadLine();
                string[] str;
                str = s.Split();
                while (game.Run(str))
                {
                    s = Console.ReadLine();
                    str = s.Split();
                }
            }
        }

        public void SyntaxMsg()
        {
            string[] str={"Syntax : slider numrows numcols",
                              "0 < numrows <= 9",
                              "0 < numcols <= 9"};
            //print the syntax message
            foreach (string s in str)
            {
                Console.WriteLine(s);
            }
        }

        public void PrintMenu()
        {
            string[] str ={"m  : print this menu",
                          "p  : print the puzzle",
                          "nX : new puzzle. X is the puzzle seed",
                          "rX : shift row X right",
                          "cX : shift col X down",
                          "x  : exit the program"};
            //print the menu
            foreach (string s in str)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public void PrintPuzzle(Puzzle p)
        {
            //print the puzzle
            for (int i = 0; i < p.get_rows(); i++)
            {
                Console.Write("{0,-2}|", i);
                for (int j = 0; j < p.get_cols(); j++)
                {
                    Console.Write("{0,3}", p.get_grid()[i, j]);
                }
                Console.WriteLine();
                if (i == p.get_rows() - 1)
                {
                    Console.Write("--+");
                    for (int k = 0; k < p.get_cols(); k++)
                    {
                        Console.Write("---");
                    }
                    Console.WriteLine();
                    Console.Write("  |");
                    for (int l = 0; l < p.get_cols(); l++)
                    {
                        Console.Write("{0,3}", l);
                    }
                    Console.WriteLine("\n");
                }
            }
           

        }

        public bool Run(string[] mStr)
        {
            int rows, cols;
            if (mStr.Count() != 2)
            {
                this.SyntaxMsg();
                return true;
            }
            else
            {
                rows = int.Parse(mStr[0]);
                cols = int.Parse(mStr[1]);
                if (rows <= 0 || rows > 9 || cols <= 0 || rows > 9)
                {
                    this.SyntaxMsg();
                    return true;
                }
            }
            Puzzle puz = new Puzzle(rows, cols);
            int x, suff = 0;
            char ch;
            string s;
            Console.WriteLine("\nSlider Start.\n");
            this.PrintMenu();
            this.PrintPuzzle(puz);
            //input command
            while (true)
            {
                Console.Write("Enter command => ");
                ch = (char)Console.Read();
                s = Console.ReadLine();
                int.TryParse(s, out x);
                switch (ch)
                {
                    case'm':
                        if (s.Length != 0)
                            goto default;
                        this.PrintMenu();
                        break;
                    case'p':
                        if (s.Length != 0)
                            goto default;
                        this.PrintPuzzle(puz);
                        break;
                    case'n':
                        puz.Shuffle(x);
                        suff = 1;
                        this.PrintPuzzle(puz);
                        break;
                    case'r':
                        if (x < 0 || x >= rows)
                            goto default;
                        puz.MoveRowRight(x);
                        suff = 1;
                        this.PrintPuzzle(puz);
                        break;
                    case'c':
                        if (x < 0 || x >= cols)
                            goto default;
                        puz.MoveColDown(x);
                        suff = 1;
                        this.PrintPuzzle(puz);
                        break;
                    case'x':
                        return false;
                    default:
                        Console.WriteLine("Invalid command entered.");
                        this.PrintMenu();
                        continue;
                }
                //when solved,print the message
                if (puz.isSolved()&&suff==1)
                {
                    Console.WriteLine("CONGRATULATIONS.You have solved the puzzle.");
                    suff = 0;
                }
            }
        }
    }
}
