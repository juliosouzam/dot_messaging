using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Services.Queue
{
    public interface IMessagingQueue
    {
        public void SendingMessage<T>(T message);
    }
}