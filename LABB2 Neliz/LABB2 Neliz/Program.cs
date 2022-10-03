

using LABB2_Neliz;
/* Hej micke!
 Har haft roligt med LABB2 och hoppas att jag inte missat något eller gjort något fel. Har främst använt mig av TRY/CATCH för 
felhantering. 
    OM du har någon tid över alls hade jag jättegärna velat få lite feedback på hur jag valt att skriva programmet 
i relation till uppgiften - skulle jag ha haft mindre i klassen 'appliancemanager' o mer i main? 
        tack på förhand!*/

//innan programmet drar igång skapar jag ett objekt av min klass Appliancemanager för att kunna nå metoderna som är i klassen
//anropar även metoden som ska lägga nåt i listan så det inte är tomt, samt en int variabel för menyval och en bool för while loopen.
ApplianceManager anv = new ApplianceManager();
anv.FyllLista();
int val = 0;
bool kör = true;
while (kör)
{
    menu();
    switch (val)
    {
        case 1:
           
            anv.Use();
            break;
        case 2:
            anv.Create();
            break;
        case 3:
            anv.ListAppliances();
            break;
        case 4:
            anv.RemoveAppliance();
            break;
        case 5:
            kör = false;
            Console.WriteLine("::::::::::::::Good bye!:::::::::::::");
            break;
    }
}
void menu()
{
    Console.WriteLine(":::::::::KITCHENAPPLIANCES:::::::::\n\t[1]. Use appliance\n\t[2]. Add appliance\n\t[3]. List appliances\n\t[4]. Remove appliance\n\t[5]. End program\n::::::::::::::::::::::::::::::::::::\n");
    try
    {
        val = Int32.Parse(Console.ReadLine());
        if (val > 5 || val < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose between[1], [2], [3], [4] or [5].");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Only numbers !");
        Console.ForegroundColor = ConsoleColor.White;
    }

}

