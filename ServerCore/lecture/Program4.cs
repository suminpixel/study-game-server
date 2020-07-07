// using System;
// using System.Threading;
// using System.Threading.Tasks;
// // 핵심 기능
// namespace ServerCore
// {

  
//     class Program4
//     {

//         static int number = 0;
//         static object _obj = new Object();

//         static void Thread_1(){
//             for(int i = 0; i < 10000; i++){

//                 try{
//                     Monitor.Enter(_obj); //크리티컬 섹션의 문제를 해결하기 위해 _obj의 점유권을 지정
//                     number++;
//                 }finally{
//                     Monitor.Exit(_obj); //잠금 해제
//                 }
               
//                 Monitor.Exit(_obj); //잠금 해제
             
//             }
//         }

//         static void Thread_2(){
//             for(int i = 0; i < 10000; i++){
                
//                 //DeadLock 데드락 :  만약에 누군가가 계속 해당 자원을 공유하고 있으면 하염없이 기다려야 한다.
//                 //원시적 해결 방법은 다음과 같다.
//                 //해결방법 1. Monitor.Enter() - try{}finally{} - Monitor.Exit();
//                 //해결방법 2. lock(_obj){}
                
//                 lock(_obj){
//                      number++;
//                 }

//                 //lock 의 한계 : 
//                 // 멀티 쓰레드 환경에서 서로 동일한 락을 얻기위해 경쟁하는 케이스가 생길 수 있음
//                 // 1. Monitor.TryEnter(시간) //n초동안 락을 얻지 못하면 포기
//                 // 2. 결론 ?-> 데드락이 일어나는 상황을 어떻게든 디버깅하여 이유를 추적하고 고침
//             }
//         }

        
//         static void Main(string[] args)
//         {
            
//                 Task t1 = new Task(Thread_1);
//                 Task t2 = new Task(Thread_2);
//                 t1.Start();
//                 t2.Start();

//                 Task.WaitAll(t1, t2);
//                 Console.WriteLine(number);

               
                
//         }
//     }
// }
