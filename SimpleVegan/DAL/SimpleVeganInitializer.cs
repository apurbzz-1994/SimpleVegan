using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleVegan.Models;

namespace SimpleVegan.DAL
{
    public class SimpleVeganInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SimpleVeganContext>
    {
        protected override void Seed(SimpleVeganContext context)
        {

            //in case data tables get dropped due to changes in schema, these will be automatically inserted into the
            //database.
            var events = new List<Event>
            {
                new Event{Title="Vegan Cookoff", Description="Enjoy a full day of sharing vegan recipes and eating delicious food!", Venue="12/7 Federation Square, Melbourne 3162", EDate="10/12/2018", ETime="10:00:00AM", EventDate=DateTime.Parse("2018-12-10"), Duration=2},
                new Event{Title="Yoga 101", Description="Learn the antient art of Yoga and about all its benefits!", Venue="Monash University Caulfield Campus",EDate="11/11/2018", ETime="10:00:00AM", EventDate=DateTime.Parse("2018-11-11"), Duration=4},
                new Event{Title="A day with Evanna Lynch", Description="Meet the Harry Potter actress who also happens to be a profound vegan activist.", Venue="Monash University Clayton Campus",EDate="13/11/2018", ETime="10:00:00AM", EventDate=DateTime.Parse("2018-11-13"), Duration=3}
            };

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var members = new List<Member>
            {
                new Member{ FirstName="Apurba", LastName="Nath", userId="67ccf085-2a0c-43c2-8926-5ddf39d6ae53"},
                new Member{ FirstName="Admin", LastName="Admin", userId="9acace74-8ed1-402b-a3db-f704e79539a5"}
            };

            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }

            
        }

}
