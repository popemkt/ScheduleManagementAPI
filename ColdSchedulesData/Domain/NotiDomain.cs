using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.Domain
{
    public interface INotiDomain
    {

    }
    public class NotiDomain
    {

        public void Noti(Message message)
        {
            FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
