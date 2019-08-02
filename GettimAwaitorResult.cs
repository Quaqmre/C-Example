using System;
using System.Linq;
using System.Threading.Tasks;

public class Example
{
    /*

    async olmayan main metodunda eğer bir async metot çağırmak istiyorsak sonucunu
    await ile beklemeyebiliriz asyncmetot.Result ile de sonucu bekliyip alıp
    işliyebiliriz
     */
    static async Task Main()
    {
        var x = ShowTodaysInfo();
        Console.WriteLine(x);
        var b = await ShowTodaysInfo();
        System.Console.WriteLine(b);
    }

    private static async Task<string> ShowTodaysInfo()
    {
        string ret = $"Today is {DateTime.Today:D}\n" +
                     "Today's hours of leisure: " +
                     $"{await GetLeisureHours()}";
        return ret;
    }

    static async Task<int> GetLeisureHours()
    {
        // Task.FromResult is a placeholder for actual work that returns a string.  
        var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());

        // The method then can process the result in some way.  
        int leisureHours;
        if (today.First() == 'S')
            leisureHours = 16;
        else
            leisureHours = 5;

        return leisureHours;
    }
}
// The example displays output like the following:
//       Today is Wednesday, May 24, 2017
//       Today's hours of leisure: 5
// </Snippet >