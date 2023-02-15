using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServerSide
{
   class MsgCollections1
    {
        public int cntS =0;
        public string[] MsgTosendBack = {"Idle Settling Ready,Discharging Water", "VE744S0MD000700000C6000","ACK, Pressure set", " ACK WaterDischarged Completed", "ACK VECode Set"};
        public string appendMsgToReturn = null;
        public void StatusMessage()
        {
        }
        public void ArrayClear()
        {
            //Array.Clear(MsgTosendBack, 0, MsgTosendBack.Length);
            cntS = 0;
            Thread.Sleep(20);
           
        }

    }
   
}



