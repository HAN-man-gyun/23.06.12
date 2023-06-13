using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work6_23._06._12_
{
    public class SecretCode
    {
        public string[] Code = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        Random ascii = new Random();
        const int countNumber = 20;
        int number1; // 값
        int number2; // 값
        string correct;         //정답 변수
        int score = 100;
        string input;
        int wrongCount = 0;

        public void shuffle()
        {//코드셔플기능
            for (int i = 0; i < countNumber; i++)
            {
                number1 = ascii.Next(0, 25);
                number2 = ascii.Next(0, 25);

                ShuffleOnce(ref Code[number1], ref Code[number2]);
            }
        }
        public void Play()
        {
            correct = Code[0];
            Console.WriteLine("문자를 입력해주세요");
            while (score > 0)
            {
                input = (Console.ReadLine()); //입력변수 및 입력받기
                Console.WriteLine("정답은 {0}입니다. ", correct);
                if (input == correct)
                {
                    Console.WriteLine("정답입니다! 점수는 {0}입니다.", score);
                    break;
                }
                else if (input != correct)
                {
                    wrongCount += 1;
                    score = score - 10;
                    if (((int)input[0]) >= 65 && (int)input[0] <= 90)
                    {
                        if (((int)(correct[0])) > ((int)(input[0])))
                        {
                            Console.WriteLine("정답은 입력보다 위에있습니다.");
                        }
                        else
                        {
                            Console.WriteLine("정답은 입력보다 아래에 있습니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("대문자를 입력해주십시오.");
                    }
                }
            }
        }
        public void ShuffleOnce(ref string firstNumber, ref string secondNumber)
        {
            string temp = "0";
            temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

    }
}
