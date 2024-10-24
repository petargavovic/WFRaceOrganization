using Common.Communication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Client.FrmEntities;

namespace Client
{
    public class Communication
    {

        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                if (_instance == null) _instance = new Communication();
                return _instance;
            }
        }

        Socket socket;
        Sender sender;
        Receiver receiver;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        internal Response RequestResponse(Operation operation, object argument)
        {
            Request request = new Request
            {
                Operation = operation,
                Argument = argument
            };
            sender.Send(request);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal object GetAll(IEntity entity, string where = null)
        {
            Operation operation;
            switch(entity.TableName)
            {
                case "Vozac":
                    operation = Operation.GetVozaci;
                    break;
                case "Trka":
                    operation = Operation.GetTrke;
                    break;
                case "RangLista":
                    operation = Operation.GetRangListe;
                    break;
                case "Kategorija":
                    operation = Operation.GetKategorije;
                    break;
                case "Ucinak":
                    operation = Operation.GetRezultati;
                    break;
                case "Korisnik":
                    operation = Operation.Login;
                    break;
                default: throw new Exception("Nepostojeći model!");
            }
            return RequestResponse(operation, where).Result;
        }

        internal Response LoadOne(IEntity entity)
        {
            Operation operation;
            switch (entity.TableName)
            {
                case "Vozac":
                    operation = Operation.LoadVozac;
                    break;
                case "Trka":
                    operation = Operation.LoadTrka;
                    break;
                case "RangLista":
                    operation = Operation.LoadRangLista;
                    break;
                default: throw new Exception("Nepostojeći model!");
            }
            return RequestResponse(operation, entity);
        }

        internal Response SaveEntity(IEntity entity, Operation operation = Operation.Login)
        {
            if(operation == Operation.Login)
            switch (entity.TableName)
            {
                case "Vozac":
                    operation = Operation.SaveVozac;
                    break;
                case "Trka":
                    operation = Operation.SaveTrka;
                    break;
            }
            return RequestResponse(operation, entity);
        }

        internal Response SaveEntities(List<IEntity> entities, Operation operation = Operation.SaveRezultati)
        {
            return RequestResponse(operation, entities);
        }

        internal Response Exit()
        {
            return RequestResponse(Operation.Exit, null);
        }

        internal Request Receive()
        {
            return (Request)receiver.Receive();
        }
    }
}
