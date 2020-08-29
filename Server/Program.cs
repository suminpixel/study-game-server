using System;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. DNS (Domain Name System) -> IP 세팅
            // IP 주소를 하드코딩하면 서버 이전, 분리등을 유연하게 관리하기 어렵다.
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);

            //구글만큼 대규모 사이트는는 여러 Address가 있기때문에 배열이 주어진다.
            //실습을 위해 그중 1개를 뽑아옴
            IPAddress ipAddr = ipHost.AddressList[0];

            //해당 아이피로 접근하면 7777포트를 열어줌
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);



            // 2. 소켓 생성
            // 허용 어드레스, 소켓타입, 프로토콜형태를 인자로 담아 소켓을 만듬
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // 3. 소켓 바인딩 / 리스닝
            listenSocket.Bind(endPoint);

            //backlog 최대 대기수
            listenSocket.Listen(10);

            try
            {
                while (true)
                {
                    Console.WriteLine("Listening...");

                    //4. 데이터 받기
                    Socket clientSocket = listenSocket.Accept(); //blocking 함수 : accept 될때까지 해당 지문 이후 실행이 되지 않음

                    byte[] recvBuff = new byte[1024];
                    int recvBytes = clientSocket.Receive(recvBuff);
                    String recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                    Console.WriteLine($"[From Client] : {recvData}");

                    //4. 데이터 보내기

                    byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome To server");
                    clientSocket.Send(sendBuff);

                    //5. 연결(소켓)종료
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }

    
    }
}

/*
네트워크란?
라우터 -> 스위치 -> 개인 PC 
스위치와 개인 PC를 네트워크라고 하는데,
같은 네트워크 선상에 있는가 다른 네트워크 선상에 있는가에 따라 다름


#### 네트워크 모델 TCP/IP 모델 
어플리케이션(HTTP, DNS) -> 트랜스 포트(전송 정책, TCP, UDP 프로토콜 정립) -> 네트워크 (목적지 경로 설정, 라우터, IPv4, IPv6) -> 데이터링크(이더넷, PPP, 내부망 경로) -> 피지컬 레이어 (신호 변환 장치, 케이블선)

송신측에서는 위 단계를 통해 패킷을 하나하나 붙이다가 
수신측에서는 역순으로 하나씩 까면서(해석하면서) 데이터 통신



#### 오류체크
인터넷이 만약 안된다, 저런 계층(모델)을 하나하나 체크, 테스트 해가면서 범인을 찾을 수 있음


#### 소켓 통신

32

*/