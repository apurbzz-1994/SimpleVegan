using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleVegan.DAL;
using SimpleVegan.Models;
using System.Data.Entity;
using System.Linq;

namespace SignalRChat
{
    public class ToDoHub : Hub
    {
        private SimpleVeganContext db = new SimpleVeganContext();
        public void Send(string name, string message)
        {
            var userFirstName = db.Members.ToList().SingleOrDefault(a => string.Equals(a.userId, name));

            Clients.All.addNewMessageToPage(userFirstName.FirstName, message);
        }
    }
}