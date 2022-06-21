class Mobilephone 
{
    string ?PhoneNumber {get; set;}
    bool PhoneState;
    bool ConnectionState;
    string ?OS {get; set;}

    void receiveACall(string incomingNumber)
    {

    }
    void receiveAMassage(string incomingNumber, string text)
    {

    }
}
class Smartphone : Mobilephone
{
    string ?Position {get; set;}
    void ringAnAlarm()
    {

    }
}
