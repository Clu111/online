using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace qwq
{
    [ServiceContract(CallbackContract = typeof(Rew))]

    public interface Rew
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);

    }

    public interface RewCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);
    }
}