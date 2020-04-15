using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface INotiDomain
    {
        void Noti(Message message);
    }
    public class NotiDomain
    {

        public void Noti(Message message)
        {
            FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
