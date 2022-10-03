using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LABB2_Neliz
{
    /*Jag valde att endast göra en klass som ärver av den abstrakta klassen som implementerar det bifogade interfacet
     eftersom att typen av köksapparat ska matas in från användare. Här har jag alla metoder som körs i programmet.*/
    public class ApplianceManager : KitchenAppliance
    {
        //inkapsling då egenskaper o listan är privat o endast nås inom den här klassen
        string Type { get; set; }
        string Brand { get; set; }
        bool IsFunctioning { get; set; }
        bool untilItsRight;
        List<ApplianceManager> appliances = new List<ApplianceManager>();
        public ApplianceManager()
        {
            this.Type = Type;
            this.Brand = Brand;
            this.IsFunctioning = IsFunctioning;
        }
        public void Create()
        {
            untilItsRight = true;
            ApplianceManager newappliance = new ApplianceManager();

            Console.WriteLine(":::::::::::NEW APPLIANCE::::::::");

            Console.Write("\tType : ");
            string inputType = Console.ReadLine();
            Console.Write("\tBrand : ");
            string inputBrand = Console.ReadLine();
            Console.Write("\tIs it broken? y/n\n >");
            while (untilItsRight)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        newappliance.IsFunctioning = false;
                        Console.WriteLine($"\tA new {inputType} has ben added.");
                        newappliance.Brand = inputBrand;
                        newappliance.Type = inputType;
                        appliances.Add(newappliance);
                        untilItsRight = false;
                        break;
                    case "n":
                        newappliance.IsFunctioning = true;
                        Console.WriteLine($"\tA new {inputType} has ben added.");
                        newappliance.Brand = inputBrand;
                        newappliance.Type = inputType;
                        appliances.Add(newappliance);
                        untilItsRight = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Either y/n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        public override void Use()
        {
           
            try
            {
                if (appliances.Count == 0)
                {
                    Console.WriteLine("\n\tThere are no appliances to use right now. Add some first!\n");
                }
                else
                {
                    Console.WriteLine("\tChoose the appliance you would like to use: \n");
                    Choose();
                    int val = Convert.ToInt32((Console.ReadLine()));
                    if (appliances[val - 1].IsFunctioning == true)
                    {
                        Console.WriteLine($"\t|The {appliances[val - 1].Type} is being used.|\n");
                    }
                    else if (appliances[val - 1].IsFunctioning == false)
                    {
                        Console.WriteLine($"\t|The {appliances[val - 1].Type} is broken...|\n ");
                    }

                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n**Choose from the list and only use numbers!**\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        // listappliances listar upp sparade apparater med full info, onumrerat
        public void ListAppliances()
        {
            Console.WriteLine(":::::::Available appliances:::::::");
            if (appliances.Count == 0) Console.WriteLine("\n\tThere are no appliances available.\n");
            else
            {
                for (int i = 0; i < appliances.Count; i++)
                {
                    if (appliances[i].IsFunctioning == true)
                        Console.WriteLine($"\n>\t{appliances[i].Type}\n\t{appliances[i].Brand}\n\tFunctioning: Yes\n");
                    else if (appliances[i].IsFunctioning == false)
                        Console.WriteLine($"\n>\t{appliances[i].Type}\n\t{appliances[i].Brand}\n\tFunctioning: No\n");
                }
            }
        }
        // choose metoden listar upp sparade apparater, numrerat med endast typ och används för val vid radering och användning
        //av apparater
        public void Choose()
        {

            int j = 1;
            for (int i = 0; i < appliances.Count; i++)
            {
                Console.WriteLine("\t" + j + ". " + appliances[i].Type);
                j++;
            }


        }
        //anropas i början av programmet så de alltid finns något i listan
        public void FyllLista()
        {
            var appliance1 = new ApplianceManager();
            appliance1.Type = "Toaster";
            appliance1.Brand = "Electrolux";
            appliance1.IsFunctioning = true;
            appliances.Add(appliance1);
            var appliance2 = new ApplianceManager();
            appliance2.Type = "Boiler";
            appliance2.Brand = "SMEG";
            appliance2.IsFunctioning = false;
            appliances.Add(appliance2);
            var appliance3 = new ApplianceManager();
            appliance3.Type = "Microwave";
            appliance3.Brand = "Samsung";
            appliance3.IsFunctioning = true;
            appliances.Add(appliance3);

            
        }
        public void RemoveAppliance()
        {
            if (appliances.Count == 0)
            {
                Console.WriteLine("\n\tThere are no appliances to remove. \n");
            }
            else
            {
                Console.WriteLine("\tWich appliance would you like to remove?");
                Choose();
                try
                {
                    int val = Int32.Parse(Console.ReadLine());
                    appliances.RemoveAt(val - 1);
                    Console.WriteLine("\tThe chosen appliance has been removed.");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t**Choose from the list, and only numbers!**\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    RemoveAppliance();
                }

            }
        }
    }
}