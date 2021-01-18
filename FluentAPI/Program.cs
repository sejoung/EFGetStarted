using System;
using System.Linq;

namespace FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {

                db.Add(new Blog {Url = "http://blogs.msdn.com/adonet"});
                db.SaveChanges();
                Console.WriteLine("Querying for a blog");
         
                db.Blogs.ToList().ForEach((b) =>
                {
                    Console.WriteLine(b.ToString());
                });


            }
        }
    }
}
