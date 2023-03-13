using System.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        //chars
        char Nullen_in_NM = '0';
        char Einsen_in_NM = '1';
        //ints
        int Part1;
        int Part2;
        int Part3;
        int Part4;
        int DezPart1;
        int DezPart2;
        int DezPart3;
        int DezPart4;
        int NetzMaske;
        int Hoch_Hosts;
        int Hoch_Netze;
        int Einsen;
        int Netzcounter;
        int Hosts_counter;
        //double
        double NetzID_Lösung;
        double ErsteIP;
        double LetzeIP;
        double Broadcast;
        double NetzID = 0;
        double Hosts;
        double Netze;
        double GanzeHosts;
        double RestHosts;
        //strings
        string Binär_NM;
        string BitPart1;
        string BitPart2;
        string BitPart3;
        string BitPart4;
        string Part1_NM;
        string Part2_NM;
        string Part3_NM;
        string Part4_NM;
        string IP_Adresse;
        //Eingabe IP-Adresse
        Console.Write("Geben sie die IP-Adresse ein: ");
        IP_Adresse = Console.ReadLine();
        //IP Adresse aufteilen und in Variablen speichern
        string[] Parts_IP = IP_Adresse.Split('.');
        Part1 = int.Parse(Parts_IP[0]);
        Part2 = int.Parse(Parts_IP[1]);
        Part3 = int.Parse(Parts_IP[2]);
        Part4 = int.Parse(Parts_IP[3]);
        //In Binär schreibweise ändern
        BitPart1 = Convert.ToString(Part1, 2).PadLeft(8, '0');
        BitPart2 = Convert.ToString(Part2, 2).PadLeft(8, '0');
        BitPart3 = Convert.ToString(Part3, 2).PadLeft(8, '0');
        BitPart4 = Convert.ToString(Part4, 2).PadLeft(8, '0');
        
        //Eingabe der Subnetzmaske
        Console.Write("Geben sie die Subnetzmaske ein: ");
        //Subnetzmaske in Binär
        NetzMaske = int.Parse(Console.ReadLine());
        Binär_NM = "";
        for (int i = 0; i < 32; i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                Binär_NM += ".";
            }
            if (i < NetzMaske)
            {
                Binär_NM += "1";
            }
            else
            {
                Binär_NM += "0";
            }
        }
        string[] Parts_NM = Binär_NM.Split('.');
        Part1_NM = Parts_NM[0];
        Part2_NM = Parts_NM[1];
        Part3_NM = Parts_NM[2];
        Part4_NM = Parts_NM[3];
        //In Binär schreibweise ändern
        DezPart1 = Convert.ToInt32(Part1_NM, 2);
        DezPart2 = Convert.ToInt32(Part2_NM, 2);
        DezPart3 = Convert.ToInt32(Part3_NM, 2);
        DezPart4 = Convert.ToInt32(Part4_NM, 2);

        Einsen = Binär_NM.Count(c => c == Einsen_in_NM);
        Hoch_Netze = 8 - (Einsen % 8);
        Netze = Math.Pow(2, Hoch_Netze);
        Hoch_Hosts = Binär_NM.Count(c => c == Nullen_in_NM);
        Hosts = Math.Pow(2, Hoch_Hosts);
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine();
        Console.WriteLine("Die IP-Adresse: " + Part1 + "." + Part2 + "." + Part3 + "." + Part4);
        Console.WriteLine("In Binär: " + BitPart1 + "." + BitPart2 + "." + BitPart3 + "." + BitPart4);
        Console.WriteLine();
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine();
        Console.WriteLine("Die Subnetzmaske: " + DezPart1 + "." + DezPart2 + "." + DezPart3 + "." + DezPart4);
        Console.WriteLine("In Binär: " + Binär_NM);
        Console.WriteLine();
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine();
        Console.WriteLine("Mögliche Hosts: " + (Hosts - 2));
        Console.WriteLine("Mögliche Subnetze: " + Netze);
        Console.WriteLine();

        if (NetzMaske >= 24)
        {
            NetzID = 0;
            while (NetzID < Part4)
            {
                NetzID += Hosts;
            }
            ErsteIP = NetzID - Hosts + 1;
            LetzeIP = NetzID - 2;
            Broadcast = NetzID - 1;
            NetzID_Lösung = NetzID - Hosts;
            Console.WriteLine("Die Erste IP-Adresse: " + Part1 + "." + Part2 + "." + Part3 + "." + ErsteIP);
            Console.WriteLine("Die letzte IP-Adresse: " + Part1 + "." + Part2 + "." + Part3 + "." +LetzeIP);
            Console.WriteLine("Broadcast: " + Part1 + "." + Part2 + "." + Part3 + "." + Broadcast);
            Console.WriteLine("Netz-ID: " + Part1 + "." + Part2 + "." + Part3 + "." + NetzID_Lösung);
            
        }
        else if(NetzMaske >= 16 && NetzMaske < 24)
        {

            Hosts_counter = Convert.ToInt32(256 / Netze);
            NetzID = 0;
            while (NetzID < Part3)
            {
                NetzID += Hosts_counter;
            }
            Part3 = Convert.ToInt32(NetzID - Hosts_counter);
            Console.WriteLine("Die Erste IP-Adresse: " + Part1 + "." + Part2 + "." + Part3 + ".1");
            Console.WriteLine("Die Letzte IP-Adresse: " + Part1 + "." + Part2 + "." + (NetzID - 1) + ".254");
            Console.WriteLine("Broadcast: " + Part1 + "." + Part2 + "." + (NetzID - 1) + ".255");
            Console.WriteLine("NetzID_Lösung: " + Part1 + "." + Part2 + "." + Part3 + ".0");
        }
        else if(NetzMaske >= 8 && NetzMaske < 16)
        {
            Hosts_counter = Convert.ToInt32(256 / Netze);
            NetzID = 0;
            while (NetzID < Part2)
            {
                NetzID += Hosts_counter;
            }
            Part2 = Convert.ToInt32(NetzID - Hosts_counter);
            Console.WriteLine("Die Erste IP-Adresse: " + Part1 + "." + Part2 + ".0.1");
            Console.WriteLine("Die Letzte IP-Adresse: " + Part1 + "." + (NetzID - 1) + ".254.255");
            Console.WriteLine("Broadcast: " + Part1 + "." + (NetzID - 1) + ".255.255");
            Console.WriteLine("NetzID_Lösung: " + Part1 + "." + Part2 + ".0.0");
        }
        else
        {
            Hosts_counter = Convert.ToInt32(256 / Netze);
            NetzID = 0;
            while (NetzID < Part1)
            {
                NetzID += Hosts_counter;
            }
            Part1 = Convert.ToInt32(NetzID - Hosts_counter);
            Console.WriteLine("Die Erste IP-Adresse: " + Part1 + ".0.0.1");
            Console.WriteLine("Die Letzte IP-Adresse: " + (NetzID - 1) + ".254.255.255");
            Console.WriteLine("Broadcast: " + (NetzID - 1) + ".255.255.255");
            Console.WriteLine("NetzID_Lösung: " + Part1 + ".0.0.0");
        }
    }
}