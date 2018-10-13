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
        
    }
}