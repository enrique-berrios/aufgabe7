namespace Kommunikationskoordinator
{
    class Mobilephone 
    {
        string ?PhoneNumber {get; set;}
        bool PhoneState;
        bool ConnectionState;
        enum OS {A, B};
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
        string ?Position {get; set;}
        void ringAnAlarm()
        {
            System.Console.WriteLine();
        }
    }
    class Kommunikationskoordinator
    {
        static void Main(string[] args)
        {

        }
    }
}