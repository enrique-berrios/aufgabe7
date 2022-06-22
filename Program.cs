namespace Kommunikationskoordinator
{
    class Mobilephone 
    {
        public string ?PhoneNumber {get; set;}
        public string ?PhoneState;
        public string ?ConnectionState;
        public string ?OS;
        void makeACall(string number)
        {

        }
        void receiveACall(string incomingNumber)
        {
            System.Console.WriteLine();
        }
        void sendAMessage(string number)
        {

        }
        void receiveAMessage(string incomingNumber, string text)
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
        void ringAnAlarm()
        {
            System.Console.WriteLine();
        }
    }
    class Kommunikationskoordinator
    {
        static void Main(string[] args)
        {
            string pathSmartPhoneDataCsv = @"SmartPhoneData.csv";
            Smartphone erstesSmartphone = null;
            Smartphone zweitesSmartphone = null;
            if(File.Exists(pathSmartPhoneDataCsv))
            {
                string[] smartphoneAsCsvString = File.ReadAllLines(pathSmartPhoneDataCsv);

                erstesSmartphone = new Smartphone(smartphoneAsCsvString[1]);
                zweitesSmartphone = new Smartphone(smartphoneAsCsvString[2]);
            }
            System.Console.WriteLine(erstesSmartphone.PhoneNumber);
            System.Console.WriteLine(erstesSmartphone.OS);
            System.Console.WriteLine(erstesSmartphone.PhoneState);            
            System.Console.WriteLine(erstesSmartphone.ConnectionState);
            System.Console.WriteLine(erstesSmartphone.positionLatitude);
            System.Console.WriteLine(erstesSmartphone.positionLongitude);
            System.Console.WriteLine(zweitesSmartphone);
        }
    }
}