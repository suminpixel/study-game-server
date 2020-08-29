
using System;
using System.Threading;
using System.Threading.Tasks;
// 컨텍스트 스위칭
// CPU 코어가 TASK를 수행하다가, 인터럽트 혹은 스케쥴링에 의해 다른 일을 수행해야 할때 
// 현재 업무 상태를 레지스터에 저장(무슨일을/어디까지 수행했는지) 한 후 다른 업무로 스위칭 하는것 


// auto reset event 오토 리셋 이벤트 / manudal reset event 매뉴얼 리셋 이벤트
// 락을 구현하는 마지막 방법


namespace ServerCore
{
    

    class Lock{
        
        // 문을 닫고 여는것을 커널단이 자동으로 해줌 boolean 값으로 표현 가능 
        AutoResetEvent _avaliable = new AutoResetEvent(true); //열린 \상태 
        

        public void Accquire(){

        }
        public void Release(){

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
