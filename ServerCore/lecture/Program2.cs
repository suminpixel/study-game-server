/* using System;
using System.Threading;
using System.Threading.Tasks;
// 핵심 기능
namespace ServerCore
{

    class Program
    {
        static volatile int x = 0;
        static volatile int y = 0;
        static volatile int r1 = 0;
        static volatile int r2 = 0;


        static void Thread_1(){
            y = 1; // Store y 
            // tip:  메모리 베리어 > 멀티 쓰레딩 환경에서는 명령 순서가 바뀔 수 있으므로 메모리 배리어 를 씀
            // 쓰는 이유 = 코드 재 배치 방지 / 가시성
            // 종류 1. Full Memory Barrier (변수 store/ load 동작의 코드 재배치 둘다 막음)
            // 종류 2. Store Memory Barrier (store 만 막음)
            // 종류 3. Load Memory Barrier (load 만 막음)

            Thread.MemoryBarrier();

            r1 = x; // Load x
        }

        static void Thread_2(){

            x = 1;
            
            Thread.MemoryBarrier(); //메모리 베리어 

            r2 = y;
        }

        static void Main(string[] args)
        {
            int count = 0;
            while(true){
                count ++ ;
                x =  y = r1 = r1 = 0;
                Task t1 = new Task(Thread_1);
                Task t2 = new Task(Thread_2);
                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2);
                if(r1== 0 && r2==0){
                    break;
                }
            }
            Console.WriteLine($"{count} 번 만에 빠져");
            //tip: cpu (하드웨어) 의 최적화
            //x, y, r1, r2 등의 값 변형 등이 의존성이 없는 
            //없는 경우 자기멋대로 함수실행 , 명령 순서 등을 뒤집어서 최적화를 실행한다던지 최적화를 한다.

            //-> 멀티 쓰레딩 환경에서는 명령 순서가 꼬이는것이 매우 중요한 이슈이다.
        }
    }
}
 */