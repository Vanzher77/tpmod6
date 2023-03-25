// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

class program
{
    public static void Main(string[] args)
    {
        SayaTubeVideo tube = new SayaTubeVideo("Tutorial Design By Contract - Mochamad Rizky Evan Ramadhan");
        tube.IncreasePlayCount(0);
        tube.PrintVideoDetails();
    }
}

public class SayaTubeVideo
{
    int id;
    string title;
    int playCount;

    public SayaTubeVideo(string t)
    {
        var random = new Random();
        this.id = random.Next(10000, 99999);
        playCount = 0;
        title = t;
        
    }

    public void IncreasePlayCount(int p)
    {
        //block try and catch untuk meminimalisir error code, fungsi try untuk mencoba apakah ada error pada code atau tidak
        //fungsi catch untuk menangkap code yang tidak bisa di convert
        try
        {
            int playcount = (int)p;
        }
        catch(OverflowException error)
        {
            Console.WriteLine(error.Message);
        }
    }
    
    public void PrintVideoDetails()
    {
        Console.WriteLine("Id : "  + this.id);
        Console.WriteLine("Tittle : " + this.title);
        Console.WriteLine("PlayCount : " + this.playCount);
    }
}
