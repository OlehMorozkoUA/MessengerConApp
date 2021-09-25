using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models.Classes;
using Handlers.Classes;

namespace MessengerConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var MessengerDb = new MessengerDbContext())
            {
                List<Attachment> attachments = Services<Attachment>.ToList(MessengerDb.Attachments);
                List<Group> groups = Services<Group>.ToList(MessengerDb.Groups);
                List<Message> messages = Services<Message>.ToList(MessengerDb.Messages);
                List<User> users = Services<User>.ToList(MessengerDb.Users);

                var conversation = from u in users
                                   select u;

                foreach (var u in conversation) Console.WriteLine(u.Id);
            }
            Console.ReadKey();
        }
    }
}
