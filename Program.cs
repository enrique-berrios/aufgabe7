using System.Text;

namespace Kommunikationskoordinator
{
    class Test
    {
        public int ?TestNummer;
        public string ?TestName;
        public string firstNumber;
        public string ?ReceiverPhoneNumber;
        public Test()
        {

        }
        public Test(string csvString)
        {
            string[] csvEntries = csvString.Split(',');

            TestNummer = Convert.ToInt16(csvEntries[0]);
            TestName = csvEntries[1];
            firstNumber = csvEntries[2];
            ReceiverPhoneNumber = csvEntries[3];
        }
        public void askTest(Smartphone smartphone)
        {
            if (TestName == "Alarm")
            {
                //if (PhoneNumber == smartphone.PhoneNumber)
                {
                    smartphone.ringAnAlarm();
                } 
            }
            if (TestName == "Anruf")
            {
            //    if (PhoneNumber == smartphone.PhoneNumber)
               {
                    smartphone.makeACall(ReceiverPhoneNumber);
               }
            }
            if (TestName == "Position")
            {
                // if (PhoneNumber == smartphone.PhoneNumber)
                {
                    smartphone.printPosition();
                }
            }
        }
        public override string ToString()
        {
            return TestNummer + " " + TestName + " " + firstNumber + " " + ReceiverPhoneNumber;
        }
    }
    public class Mobilephone
    {
        public string? PhoneNumber { get; set; }
        public string PhoneState { get; set; }
        public string ConnectionState { get; set; }
        public string OS { get; set; }

        public Mobilephone()
        {
            PhoneNumber = "110";
            PhoneState = "silent";
            ConnectionState = "offline";
            OS = "OS_A";
        }
        public Mobilephone(string phone_number, string phone_state, string connection_state, string OS)
        {
            this.PhoneNumber = phone_number;
            this.PhoneState = phone_state;
            this.ConnectionState = connection_state;
            this.OS = OS;
        }
        public void makeACall(string number)
        {
            if (ConnectionState == "online")
            {
                System.Console.WriteLine("{0} wird angerufen.", number);
            }
            else
            {
                System.Console.WriteLine("Verbindung unterbrochen. Es kann kein Sprachanruf durchgeführt werden.");
            }
        }
        public void receiveACall(string incomingNumber)
        {
            if (ConnectionState == "online" && PhoneState == "normal")
            {
                System.Console.WriteLine("Eingehender Anruf von {0}", incomingNumber);
            }

        }
        public void sendAMessage(/*string number, string text*/ Mobilephone phone, string text)
        {
            if (phone.ConnectionState == "online" && phone.OS == "OS_A" && ConnectionState == "online")
            {
                Console.WriteLine("Nachricht wird an {0} gesendet.", phone.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Die Nachricht kann nicht gesendet werden.\nMögliche Ursachen\n-unterbrochene Verbindung\n-Empfänger ist nicht online\nEmpfänger hat falsches Betriebssystem");
            }

        }
        public void receiveAMessage(string incomingNumber, string text)
        {
            if (ConnectionState == "online" && PhoneState == "normal" && OS == "OS_A")
            {
                Console.WriteLine("Neue Nachricht von {0}\n{1}", incomingNumber, text);
            }
        }
    }
    
    
    class Smartphone : Mobilephone
    {
        public string ?positionLatitude {get; set;}
        public string ?positionLongitude {get; set;}
        public Smartphone() 
        {

        }
        public Smartphone(string csvString)
        {
            string[] csvEntries = csvString.Split(',');

            PhoneNumber = csvEntries[0];
            OS = csvEntries[1];
            PhoneState = csvEntries[2];
            ConnectionState = csvEntries[3];
            positionLatitude = csvEntries[4];
            positionLongitude = csvEntries[5];
        }
        public void ringAnAlarm()
        {
            if (OS == "OS_B")
            {
                System.Console.WriteLine("ALarm! Alarm!");
            }
        }
        public void printPosition()
        {
            if(positionLatitude != null && positionLongitude != null)
            {
                Console.WriteLine("Sie befinden sich an dieser Position: {0}, {1}", positionLatitude, positionLongitude);
            }
        }
        public override string ToString()
        {
            return "Handydaten:\nHandynummer: " + PhoneNumber + "\nBetriebssystem: " + OS + "\nKlingelton: " + PhoneState
            + "\nVerbindungsstatus: " + ConnectionState + "\nPosition: " + positionLatitude + " | " + positionLongitude + "\n";
        }
    }
    class Kommunikationskoordinator
    {
        static void Main(string[] args)
        {
            // Dateiname von Smartphone Data
            string pathSmartPhoneDataCsv = @"SmartPhoneData.csv";

            // Smartphone Liste erstellen
            List<Smartphone> smartphones = new List<Smartphone>();

            // Speichern von einer Zeile in einen String Array Eintrag
            if(File.Exists(pathSmartPhoneDataCsv))
            {
                // Zeile lesen
                string[] smartphoneAsCsvString = File.ReadAllLines(pathSmartPhoneDataCsv);

                // Daten des 1- bzw. 2-ten Index übergeben (0-ter Eintrag ist Tabellenkopf - keine Daten)
                smartphones.Add(new Smartphone(smartphoneAsCsvString[1]));
                smartphones.Add(new Smartphone(smartphoneAsCsvString[2]));
                smartphones.Add(new Smartphone(smartphoneAsCsvString[3]));

                foreach (Smartphone aSmartphone in smartphones)
                {
                    System.Console.WriteLine(aSmartphone.ToString());
                }   
            }

            // Test-Liste erstellen
            List<Test> tests = new List<Test>();

            // Dateiname von Services Tests
            string pathServicesTestsCsv = @"ServicesTests.csv";

            // Tests einlesen
            if (File.Exists(pathServicesTestsCsv))
            {
                string[] servicesTests = File.ReadAllLines(pathServicesTestsCsv);

                tests.Add(new Test(servicesTests[1]));
                tests.Add(new Test(servicesTests[2]));
                tests.Add(new Test(servicesTests[3]));
                tests.Add(new Test(servicesTests[4]));

                foreach (Test aTest in tests)
                {
                    aTest.askTest(smartphones[1]);
                    aTest.askTest(smartphones[2]);
                    aTest.askTest(smartphones[3]);
                }
            }
            // smartphones[1].makeACall("03231");
            // smartphones[1].receiveACall("01234");
            // smartphones[1].printPosition();
            // smartphones[1].ringAnAlarm();
            // smartphones[2].sendAMessage(smartphones[1], "Hallo!");
            // smartphones[2].receiveAMessage("02123", "Hi!");
        }
    }
}