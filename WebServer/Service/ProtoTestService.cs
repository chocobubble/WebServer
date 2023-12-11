using System;
using Google.Protobuf;
using WebServer.Protos;

namespace WebServer.Service
{
	public class ProtoTestService
	{
		private HelloRequest _helloRequest;

		public ProtoTestService()
		{
			_helloRequest = new HelloRequest();
			_helloRequest.Name = "Hello";
		}

		public string Hello()
		{
			return _helloRequest.Name;
		}

		public string SerializeHello()
		{
			byte[] bytes = _helloRequest.ToByteArray();

			FileStream fileStream = new FileStream("test.bin", FileMode.Create);
			fileStream.Write(bytes, 0, bytes.Length);
			fileStream.Close();

			FileStream openStream = new FileStream("test.bin", FileMode.Open);
			byte[] inBytes = new byte[openStream.Length];
			openStream.Read(inBytes, 0, inBytes.Length);
			openStream.Close();

			HelloRequest newHello = HelloRequest.Parser.ParseFrom(inBytes);


			return newHello.Name;

        }
	}
}

