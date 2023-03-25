// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

class program
{
    public static void Main(string[] args)
    {
        SayaTubeVideo tube = new SayaTubeVideo("Tutorial Design By Contract - Mochamad Rizky Evan Ramadhan");
       
         for(int i = 0; i < 100; i++)
         {
             tube.IncreasePlayCount(10000000);
         }
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
        Debug.Assert(t.Length <= 100 && t != null, "judul video memiliki panjang maksimal 100 karakter dan tidak berupa null.");        
        //melakukan generate secara random sepanjang 5 digit dengan di isi angka acak di antara 10000, 99999
        var random = new Random();
        this.id = random.Next(10000, 99999);
        playCount = 0;
        title = t;
       
        
    }

    public void IncreasePlayCount(int p)
    {
        //memastikan kondisi apakah sesuai dengan inputan apa tidak
        Debug.Assert( p <= 10000000, "Input penambahan play count maksimal 10.000.000 per panggilan method-nya.");
        //block try and catch untuk meminimalisir error code, fungsi try untuk mencoba apakah ada error pada code atau tidak
        //fungsi catch untuk menangkap code yang tidak bisa di convert
        try
        {

            //checked melakukan exception error pada overflow
            checked { this.playCount += p; }
        }
        catch(OverflowException error)
        {
            Console.WriteLine(error.Message);
        }
    }
    
    public void PrintVideoDetails()
    {
        //melakukan pemanggilan id,title dan playCount
        Console.WriteLine("Id : "  + this.id);
        Console.WriteLine("Title : " + this.title);
        Console.WriteLine("PlayCount : " + this.playCount);
    }
}
