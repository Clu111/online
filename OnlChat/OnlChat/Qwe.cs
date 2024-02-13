using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace qwq
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Qwe : Rew
    {
        List<Wer> users = new List<Wer>();
        int NextId = 1;
        public int Connect(string name)
        {
            Wer user = new Wer()
            {
                ID = NextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            NextId++;

            SendMsg(user.Name + " Подключился к чату!", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(user.Name + " Покинул чат!", 0);
            }
        }



        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += " : " + user.Name + " ";
                }
                answer += msg;
            }
        }
    }
}