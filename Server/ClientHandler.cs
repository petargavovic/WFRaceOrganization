using Common.Communication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Sender sender;
        private Receiver receiver;
        private Socket socket;

        Converter<IEntity, Ucinak> converterU;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
            converterU = Ucinak.EntityToUcinak;
        }

        public void HandleRequest()
        {
            while (true)
            {
                Request req = (Request)receiver.Receive();
                Response r = ProcessRequest(req);
                sender.Send(r);
                if (req.Operation == Operation.Exit)
                {
                    Stop();
                    break;
                }
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                string where = null;
                if (req.Operation.ToString().StartsWith("Get") || req.Operation == Operation.Login)
                {
                    if (req.Argument != null)
                        where = req.Argument.ToString();
                }
                switch (req.Operation)
                {
                    case Operation.Login:
                        r.Result = Controller.Instance.Login(where);
                        break;
                    case Operation.GetKategorije:
                        r.Result = Controller.Instance.GetKategorije();
                        break;
                    case Operation.GetRezultati:
                        r.Result = Controller.Instance.GetUcinci(where);
                        break;
                    case Operation.GetRangListe:
                        r.Result = Controller.Instance.GetRangListe(where);
                        break;
                    case Operation.GetTrke:
                        r.Result = Controller.Instance.GetTrke(where);
                        break;
                    case Operation.GetVozaci:
                        r.Result = Controller.Instance.GetVozaci(where);
                        break;
                    case Operation.LoadVozac:
                        r.Result = Controller.Instance.LoadVozac((Vozac)req.Argument);
                        break;
                    case Operation.LoadTrka:
                        r.Result = Controller.Instance.LoadTrka((Trka)req.Argument);
                        break;
                    case Operation.LoadRangLista:
                        r.Result = Controller.Instance.LoadRangLista((RangLista)req.Argument);
                        break;
                    case Operation.SaveRezultati:
                        Controller.Instance.SaveRezultati(((List<IEntity>)req.Argument).ConvertAll(converterU));
                        r.Result = req.Argument;
                        break;
                    case Operation.SaveTrka:
                        r.Result = Controller.Instance.SaveTrka((Trka)req.Argument);
                        break;
                    case Operation.SaveVozac:
                        r.Result = Controller.Instance.SaveVozac((Vozac)req.Argument);
                        break;
                }
            }
            catch (Exception ex)
            {
                r.Exception = ex;
                Debug.WriteLine(ex.Message);
            }
            return r;
        }

        public void Stop()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket.Dispose();
            socket = null;
            Server.clientHandlers.Remove(this);
        }
    }
}
