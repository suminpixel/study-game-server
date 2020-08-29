/*
using System;
using System.Threading;
using System.Threading.Tasks;
// 락 구현 연습
// tip: 
// 멀티쓰레딩 환경에서 락은 디버깅의 60~70% 비중을 차지하는 주요 이슈다.
// 1.spinLock : 다른 스레드가 lock을 점유하고 있을때 해당 lock이 반환 될 때 까지 확인하며 대기하는것
//               -> 짧게 대기한다는 확신이 있다면 Context Switching 보다 더 나음

namespace ServerCore
{

    class SpinLock{
        volatile int _locked = 0; // tip: volatile : 가시성 보장
        public void Accquire(){
            while(true){
                //버전 1
                //int original = Interlocked.Exchange(ref _locked, 1); //Atomic 하게 변수의 값 지정하는 방법 : 원자 단위 연산으로 변수를 지정된 값으로 설정합니다.
                //if(original == 1){
                //  break;
                //}

                //버전 2
                //CAS 
                int expected = 0;
                int desired = 1; 
                if(Interlocked.CompareExchange(ref _locked, desired, expected) == expected){
                     break;
                }

                //휴식 지정
                Thread.Sleep(1); //무조건 휴식
                Thread.Sleep(0); //조건부 양보 (우선순위를 따져서 본인 우선순위가 높으면 본인)
                Thread.Yield(); //양보 (지금 실행이 가능한 쓰레드가 있으면 양보 => 실행가능한 쓰레드가 없으면 본인)
                
            }
          
        }
        
        public void Release(){
            _locked = 0;
        }
    }
  
    class Program
    {

        static int number = 0;
        static SpinLock _lock = new SpinLock();
    
        static void Thread_1(){
            for(int i = 0; i < 10; i++){
                _lock.Accquire();
                number++;
                _lock.Release();
            }
        }

        static void Thread_2(){
            for(int i = 0; i < 10; i++){
                _lock.Accquire();
                number--;
                _lock.Release();
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

               
                
        }
    }
}
*/