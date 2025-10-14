using System.Xml.Serialization;

Console.WriteLine("Hello, World!");

public class CheapPrinter() : IPrinter
{
    public void Printer(object document)
    {
        //Do something;
    }
}

public interface IPrinter { void Printer(object document); }
public interface IScaner { void Scan(object document); }
public interface IFax {  void Fax(object document); }


