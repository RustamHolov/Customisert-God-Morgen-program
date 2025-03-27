public class Greeting{
    public string GetToday() => $"{DateTime.Now:dddd d MMMM} of {DateTime.Now:yyyy}, {DateTime.Now:HH:mm} on the clock";

    public string GetDayPart(int dayHour){
        return dayHour switch{                          // dayHour is DateTime.Now.Hour (for now time).
            <= 7 => "early Morning",
            <= 11 => "morning-noon",
            <= 13 => "afternoon-noon",
            <= 18 => "late afternoon",
            <= 23 => "evening",
            > 0 => "nigth",
        };
    }
    public int GetHoursUntilTomorrow() => 24 - DateTime.Now.Hour;

    public string GetHeader(){
        return $"Today is {GetToday()} and it's {GetDayPart(DateTime.Now.Hour)}. {GetHoursUntilTomorrow()} hours until tomorrow.";
    }
    public string GetPersonalGreeting(string name){
        name = char.ToUpper(name[0]) + name.Substring(1);   // if name was typed with leading lower case letter
        return $"Hi,{name}! It's pleasure to greet you on this wonderful {GetDayPart(DateTime.Now.Hour)}!";
    }
    public string GetZodiac(DateTime birthDate){
        bool birthBefore(int month, int day) => birthDate <= new DateTime(birthDate.Year, month, day);
        return "Zodiac sign" switch{
            _ when birthBefore(1,19) => "Capricorn",
            _ when birthBefore(2,18) => "Aquarius",
            _ when birthBefore(3,20) => "Pisces",
            _ when birthBefore(4,19) => "Aries",
            _ when birthBefore(5,20) => "Taurus",
            _ when birthBefore(6,20) => "Gemini",
            _ when birthBefore(7,22) => "Cancer",
            _ when birthBefore(8,22) => "Leo",
            _ when birthBefore(9,22) => "Virgo",
            _ when birthBefore(10,22) => "Libra",
            _ when birthBefore(11,21) => "Scorpio",
            _ when birthBefore(12,21) => "Sagittarius",
            _ => "Capricorn"
        };
    }

    public int DaysBetween(DateTime end, DateTime start){
        TimeSpan difference = end - start;
        return (int)difference.TotalDays;
    }

    public string GetHoroscope(DateTime birthDate) => $"You were born {DaysBetween(DateTime.Now, birthDate)} days before and your zodiac sign is {GetZodiac(birthDate)}. A lot of happiness awaits you this month.";


}