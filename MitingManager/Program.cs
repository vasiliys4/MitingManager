using MitingManager.Model;
using MitingManager.Model.Operations;

internal class Program
{
    public static List<Meeting> MeetingList = new();
    public static List<Meeting> Meetings = new();
    private static void Main(string[] args)
    {
        IMeetingAdd meetingAdd = new MeetingAdd(Meetings);
        IShow show = new Show(Meetings);
        IMeetingRemove meetingRemove = new MeetingRemove();
        IMeetingChange meetingChange = new MeetingChange();
        ExportInFile exportInFile = new ExportInFile();
        var tmp = true;
        while (tmp)
        {
            Console.WriteLine("1. Добавить встречу.");
            Console.WriteLine("2. Показать все встречи.");
            Console.WriteLine("3. Показать записи на определенную дату.");
            Console.WriteLine("4. Заменить запись.");
            Console.WriteLine("5. Удалить запись.");
            Console.WriteLine("6. Выход.");
            var i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    Console.Clear();
                    Meetings.Add(meetingAdd.ValidationData());
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    show.ShowAll();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Введите дату за которую хотите посмотреть встречи\nмесяц.число");
                    while (tmp)
                    {
                        var Date = Console.ReadLine();
                        string[] date = Date.Split('.');
                        if (date.Length == 2)
                        {
                            DateOnly dateOnly = new DateOnly(2023, int.Parse(date[0]), int.Parse(date[1]));
                            show.ShowMeeting(dateOnly, MeetingList);
                            tmp = false;
                        }
                    }                                      
                    tmp = true;
                    Console.WriteLine("Если хотите экспортировать расписание на день в файл нажмите: 1");
                    Console.WriteLine("Если хотите выйти в меню нажмите 2");
                    var str = int.Parse(Console.ReadLine());
                    if (str == 1)
                    {
                        exportInFile.Export(MeetingList);
                    }
                    if (str == 2)
                    {

                    }
                    break;
                case "4":
                    Console.Clear();
                    show.ShowAll();
                    Console.WriteLine("Выбирите какую встречу изменить");
                    var nomer = int.Parse(Console.ReadLine());
                    meetingChange.Change(nomer, Meetings, meetingAdd.ValidationData());
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    show.ShowAll();
                    meetingRemove.Remove(Meetings);
                    Console.Clear();
                    break;
                case "6":
                    tmp = false;
                    break;
                default:
                    break;
            }
        }
    }
}