using System;
namespace Kommunikationskoordinator
{
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
        string? Position { get; set; }
        public void ringAnAlarm()
        {
            if (OS == "OS_B")
            {
                System.Console.WriteLine("ALarm! Alarm!");
            }
        }

        public void printPosition()
        {
            if(Position != null)
            {
                Console.WriteLine("Sie befinden sich an dieser Position: {0}", Position);
            }
        }
        public Smartphone(string phone_number, string connection_state, string phone_state, string OS, string position) : base(phone_number, connection_state, phone_state, OS)
        {
            this.PhoneNumber = phone_number;
            this.ConnectionState = connection_state;
            this.PhoneState = phone_state;
            this.OS = OS;
            this.Position = position;
        }
    }
    class Kommunikationskoordinator
    {
        static void Main(string[] args)
        {

        }
    }
}
