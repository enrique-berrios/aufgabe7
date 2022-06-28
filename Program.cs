namespace Kommunikationskoordinator
{
    class Test : Smartphone
    {
        public int ?TestNummer;
        public string ?TestName;
        public string ?ReceiverPhoneNumber;
        public Test()
        {

        }
        public Test(string csvString)
        {
            string[] csvEntries = csvString.Split(',');

            TestNummer = Convert.ToInt16(csvEntries[0]);
            TestName = csvEntries[1];
            PhoneNumber = csvEntries[2];
            ReceiverPhoneNumber = csvEntries[3];
        }
        public void askTest()
        {
            if (TestName == "Alarm")
            {
                ringAnAlarm();
            }
            if (TestName == "Anruf")
            {
                makeACall(ReceiverPhoneNumber);
            }
            /*if (TestName == "Position")
            {
                ();
            }*/
        }
        public override string ToString()
        {
            return TestNummer + " " + TestName + " " + PhoneNumber + " " + ReceiverPhoneNumber;
        }
    }
    class Mobilephone 
    {
        public string ?PhoneNumber {get; set;}
        public string ?PhoneState;
        public string ?ConnectionState;
        public string ?OS;
        public void makeACall(string number)
        {

        }
        public void receiveACall(string incomingNumber)
        {
            System.Console.WriteLine();
        }
        void sendAMessage(string number)
        {

        }
        public void receiveAMessage(string incomingNumber, string text)
        {
            System.Console.WriteLine();
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
            System.Console.WriteLine();
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
                    System.Console.WriteLine(aTest.ToString());
                }
            }
                
            /* // Ausgabe von Smartphone Properties
            System.Console.WriteLine(erstesSmartphone.PhoneNumber);
            System.Console.WriteLine(erstesSmartphone.OS);
            System.Console.WriteLine(erstesSmartphone.PhoneState);            
            System.Console.WriteLine(erstesSmartphone.ConnectionState);
            System.Console.WriteLine(erstesSmartphone.positionLatitude);
            System.Console.WriteLine(erstesSmartphone.positionLongitude);
            */
        }
    }
}