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
