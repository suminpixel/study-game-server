
/*
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ServerCore
{


    class Program3
    {

        static int number = 0;

        static void Thread_1(){
            for(int i = 0; i < 10000; i++){
                Interlocked.Increment(ref number); //ref : 변수의 참조(주소)값
                // tip: interlocked : number을 여러과정으로 += 하지 않고 한번에 -> race condition 문제 해결
                // 동시다발경합 X 원자적으로 실행순서 보장됨. 그러나 그만큼 다른 쓰레드가 자원을 돌려(공유)받기 위한 대기시간을 가짐 -> 느림.

                //실제로 일어나는 number 변수 증가
                
                //크리티컬 섹션
                //int temp = number; 
                //temp += 1; 
                //number = temp; 
                
             
            }
        }

        static void Thread_2(){
            for(int i = 0; i < 10000; i++){
                
                Interlocked.Decrement(ref number);
            }
        }

        
        static void Main(string[] args)
        {
            
                Task t1 = new Task(Thread_1);
                Task t2 = new Task(Thread_2);
                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2);
                Console.WriteLine(number);

                //tip: race condition 
                //공유자원에 다수의 접근권한이 동시에 부여되면서, 
                //조작순서, 연산 등에 오작동을 일으키는 문제

                //해결 방법 -> atomic 원자적으로 덧셈 뺄셈할것 (Interlocked)
                //A의 집행검을 인벤에서 빼라
                //B의 집행검을 인벤에서 넣어라
                
        }
    }
}

*/