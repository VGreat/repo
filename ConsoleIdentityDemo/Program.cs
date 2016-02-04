using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIdentityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Claim claim = new Claim("Name","Rahul");
            //Claim newClaim = new Claim(ClaimTypes.Country,"India");

            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Andras")
                , new Claim(ClaimTypes.Country, "Sweden")
                , new Claim(ClaimTypes.Gender, "M")
                , new Claim(ClaimTypes.Surname, "Nemes")
                , new Claim(ClaimTypes.Email, "hello@me.com")
                , new Claim(ClaimTypes.Role, "IT")
            };

            foreach (var item in claimCollection)
            {
                Console.WriteLine("{0}:{1}",item.Type, item.Value);
            }


            
            //ClaimsIdentity claimIdentity = new ClaimsIdentity(claimCollection);
            //Console.WriteLine(claimIdentity.IsAuthenticated);
            
            ClaimsIdentity claimID = WindowsIdentity.GetCurrent();
            foreach (var item in claimID.Claims)
            {
                Console.WriteLine("{0}:{1}", item.Type, item.Value);
            }
            
            
            Console.ReadLine();
        }
    }
}
