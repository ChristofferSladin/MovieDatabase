using MovieDatabase.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisInfo
{
    public class App
    {
        public void Run()
        {
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("Filmer");
                Console.WriteLine("***************\n");
                Console.WriteLine("1: Hämta 'samtliga' filmer");
                Console.WriteLine("2: Hämta 'en' film");
                Console.WriteLine("0: Exit");

                // TIPS: Här borde man köra någon form att kontroll att rätt värde skrivs in
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GetMovies.GetJsonDataAll().Wait();
                        break;
                    case 2:
                        // TIPS: Låt användaren bestämma vilken id ska sökas
                        GetMovies.GetJsonDataOne("tt0001922").Wait();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
