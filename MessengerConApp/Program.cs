using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models.Classes;
using Handlers.Classes;
using Models.Interfaces;

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

                User currentUser = users[0];
                int FromUserId = currentUser.Id;
                int ToDetinationId = 2;

                IEnumerable<User> UsersInTheDiscussion = from user in users
                                                         where user.Id == FromUserId || 
                                                               user.Id == ToDetinationId
                                                         select user;
                var conversation = from message in messages
                                   from user in UsersInTheDiscussion
                                   where message.FromUserId == user.Id &&
                                         message.Destination == Destination.User
                                   select new
                                   {
                                       Id = message.Id,
                                       UserId = user.Id,
                                       CreationTime = message.CreationTime,
                                       Text = message.Text,
                                       ImagePath = user.ImagePath,
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       Email = user.Email,
                                       Status = Status.User,
                                       Attarhcments = (from attachment in attachments 
                                                      where attachment.MessageId == message.Id 
                                                      select attachment)
                                   };

                foreach (var m in conversation)
                {
                    Console.WriteLine("===================================");
                    Console.WriteLine($"{m.ImagePath}");
                    Console.WriteLine($"{m.CreationTime}");
                    Console.WriteLine($"{m.FirstName} {m.LastName}({m.Status})");
                    Console.WriteLine($"{m.Email}");
                    Console.WriteLine($"{m.Text}");
                    Console.WriteLine((m.Attarhcments.Count() > 0) ? m.Attarhcments.First().Value : "");
                    Console.WriteLine("===================================");
                }
            }
            Console.ReadKey();
        }
    }
}
