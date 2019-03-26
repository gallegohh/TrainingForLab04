using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// NuGet -> Microsoft.WebSockets
using Microsoft.Web.WebSockets;

namespace TrainingForLab04.ws
{
    public class echo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new WebSocket());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class WebSocket : WebSocketHandler
    {
        public override void OnMessage(string message)
        {
            this.Send(">" + message);
        }

        public override void OnOpen()
        {
            this.Send("CONECTADO");
        }

        public override void OnClose()
        {
            this.Send("DESCONECTADO");
        }

        public override void OnError()
        {
            this.Send("Algo malo ha ocurrido");
        }
    }
}