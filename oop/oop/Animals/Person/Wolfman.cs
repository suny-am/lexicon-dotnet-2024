internal class Wolfman : Wolf, IPerson
{
    void IPerson.Talk()
    {
        Console.WriteLine("*Howling ensues*");
    }
}