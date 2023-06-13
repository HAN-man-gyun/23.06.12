using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace work7_23._06._12_
{
    public class Tictacto
    {
        Random position = new Random();
        public string[,] array = new string[3,3];
        public int humPosX; //인간이 놓을 가로좌표
        public int humPosY; //인간이 놓을 세로좌표

        public int comPosX; //컴퓨터가 놓을 가로좌표
        public int comPosY; //컴퓨가 놓은 세로좌표
        public int shuffleCount = 20; //섞은 횟수
        public bool victory = false; //승리를 확인하는 변수 
        
        public void Initialize()//초기화
        {
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    array[h,w] = "*\t";
                }
            }
        }
        public void PrintMap()//출력
        {
            for(int height=0; height<3; height++)
            {
                for(int width=0; width<3; width++)
                {
                    Console.Write(array[height, width]);
                }
                Console.WriteLine();
            }
        }
        public void HumanDrawing() //인간의 그리기
        {
            while (true)
            {
                Console.WriteLine("좌표를 입력해 주십시오");
                int drawingHeight = int.Parse(Console.ReadLine());
                int drawingWidth = int.Parse(Console.ReadLine());
                if (array[drawingHeight, drawingWidth] == "*\t")
                {
                    array[drawingHeight, drawingWidth] = "x\t";
                    break;
                }
            }
        }
        public void Drawing() //그리기
        {
            array[comPosX, comPosY] = "o\t";
        }
        public void ComputeDrawing() //컴퓨터의 그리기
        {
            if (array[comPosX, comPosY] == "*\t")
            {
                Console.WriteLine("컴퓨터가 그리기전1");
                comPosX = position.Next(0, 3);
                comPosY = position.Next(0, 3);

                Console.WriteLine("[while문 안쪽] comPosX{0} 와 comPosY{1}", comPosX, comPosY);
                Console.WriteLine("컴퓨터가 입력한 좌표{0},{1}", comPosX, comPosY);
                Drawing();
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("컴퓨터가 그리기전2");
                    comPosX = position.Next(0, 3);
                    comPosY = position.Next(0, 3);
                    if (array[comPosX, comPosY] == "*\t")
                    {
                        Console.WriteLine("[while문 안쪽] comPosX{0} 와 comPosY{1}", comPosX, comPosY);
                        Console.WriteLine("컴퓨터가 입력한 좌표{0},{1}", comPosX, comPosY);
                        Drawing();
                        break;
                    }
                }
                
            }
            
        }

        public void IdentifyVictory() //승리인지확인
        {
            if (((array[0, 0] == "x\t") && (array[0,1] == "x\t")) && (array[0,2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[1, 0] == "x\t") && (array[1, 1] == "x\t")) && (array[1, 2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[2, 0] == "x\t") && (array[2, 1] == "x\t")) && (array[2, 2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[0, 0] == "x\t") && (array[1, 0] == "x\t")) && (array[2, 0] == "x\t"))
            {
                victory = true;
            }
            else if (((array[0, 1] == "x\t") && (array[1, 1] == "x\t")) && (array[1, 2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[0, 2] == "x\t") && (array[1, 2] == "x\t")) && (array[2, 2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[0, 0] == "x\t") && (array[1, 1] == "x\t")) && (array[2, 2] == "x\t"))
            {
                victory = true;
            }
            else if (((array[0, 2] == "x\t") && (array[1, 1] == "x\t")) && (array[2, 0] == "x\t"))
            {
                victory = true;
            }

        }

public void Play()
        {
            while (victory == false)
            {
                PrintMap();
                HumanDrawing();
                Console.WriteLine("[내가입력한후] comPosX{0} 와 comPosY{1}", comPosX, comPosY);
                IdentifyVictory();
                if (victory == true)
                {
                    break;
                }
                ComputeDrawing();
                Console.WriteLine("[컴퓨터가 입력한후]");
                IdentifyVictory();
                if (victory == true)
                {
                    break;
                }
                Console.Clear();
            }
            PrintMap();
            Console.WriteLine("축하합니다! 게임에서 승리했습니다!");

        }
     
    }
}
