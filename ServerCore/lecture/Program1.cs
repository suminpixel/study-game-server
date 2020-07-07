/* 
using System;
using System.Threading;
using System.Threading.Tasks;
// 핵심 기능
*/

// namespace ServerCore
// {

//     class Program1
//     {
//         volatile static bool _stop = false; //전역변수는 모든 쓰레드에서 동시접근

//         //tip : volatile(볼라틱 키워드)는 c#에서 해당 변수가 포함된 코드를 변형 및 최적화 하지 말라는 표기
//         //릴리즈 모드와 개발 모드가 달라, 컴파일러에 의해 최적화가 되고나면 코드가 변형된다. 특히 멀티쓰레딩에서 무한루프에 빠질 가능성이 있다.
//         //볼라틱 키워드는 언어별로 스펙이 다르기때문에 쓰지말고 매모리배리어 등으로 대체
//         static void ThreadMain(){
//             Console.WriteLine("쓰레드 시작!");
//             while(_stop == false){
//                 //누군가가 stop 신호를 주길 기다림
//             }
//             Console.WriteLine("쓰레드 종료!");
//         }
//         static void MainTread(object state){

            
//             for(int i = 0; i < 5; ++i){
//                 Console.WriteLine("Hello Thread!");
//             }
          
//         }
//         static void Main(string[] args)
//         {
//             Task t = new Task(()=> {while(true){}}, TaskCreationOptions.LongRunning); //TaskCreationOptions.LongRunning : 오래걸리는 일이라는 것을 명시, 워커 쓰레드를 소모하지 않고 
//             t.Start();
//             //tip: Task => 쓰레드가 할 일의 단위를 정의해서 사용 //쓰레드풀 무한 대기 를 해결하는 방법중 하나

//             Thread.Sleep(1000);
//             _stop = true;

//             Console.WriteLine("Stop 호출!");
//             Console.WriteLine("종료 대기중!");
//             t.Wait(); //태스크가 끝날때까지 기다림
//             Console.WriteLine("종료 성공!");


        
//             /*
//             ThreadPool.SetMinThreads(1, 1); // 최소 쓰레드 수
//             ThreadPool.SetMaxThreads(5, 5); // 최대 쓰레드 수
//             for(int i = 0; i < 5; ++i){
//                 ThreadPool.QueueUserWorkItem((obj)=>{while (true){ }}); // <- 이런식으로 만들면 쓰레드(워커)가 영영 돌아오지 않음
//             }

//             ThreadPool.QueueUserWorkItem(MainTread); //파라매터로 WaitCallback
//             //tip: C# 쓰레드 풀
//             //쓰레드를 직접 만들어 관리하는게 부담스럽다면, 쓰레드 풀을 사용
//             //풀이라는 공간에 잠시 가능한 쓰레드들을 대기시켜 두었다가 필요할때 사용할 수 있도록 함
//             //기본은 백그라운드로 실행한다.
//             //스레드를 필요할때마다 그때그때 만든다는것은 상당한자원을 소모하는 일이기 때문
//             //하지만 쓰레드 풀도 먹통이 될 수 있음
//             */


//             /*
//             //전통적인 쓰레드 생성법
//             Thread t = new Thread(MainTread); //기본 : 포그라운드 스레드 생성
//             t.IsBackground = true;
//             t.Start(); //생성된 쓰레드는 함수가 종료되면 소멸 
//             Console.WriteLine("Wating for Thread!");
        
//             t.Join(); //스레드가 끝날때까지 기다린 후 다음 코드 실행

//             Console.WriteLine("Hello World!");
//             */
//             while(true){
                
//             }
//         }
//     }
// }
