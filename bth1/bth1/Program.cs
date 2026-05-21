 public class Program
    {
    public delegate void ShowLog(string message);
    static public void Info(string s)
    {
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine(string.Format("[INFO]: {0}", s));
        Console.ResetColor();
    }
    static public void Warning(string s)
    {
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine(string.Format("[WARNING]: {0}", s));
        Console.ResetColor();

    }
    public static void Swap<T>(ref T a, ref T b)
    {
        T tmp;
        tmp = a;
        a = b;
        b = tmp;
    }
    public static int Sum(int a,int b) => a + b;
    public static int Signal(int a, int b) => a - b; //if(a > b ) else false;
    public static 
    public static void Main(string[] args)
    {
        Info("Thong bao 1");
        Warning("Thong bao 2");
        ShowLog showLog = null;
        showLog = Info;
        showLog("Thong bao");
        showLog = Warning;
        showLog("Thong bao");
        if (showLog != null)
            showLog.Invoke("Thong bao");
        showLog?.Invoke("Thong bao");
        showLog += Info;
        showLog += Warning;
        showLog += Warning;
        showLog?.Invoke("Thong bao");

        Action action;
        Action<string> action1;
        Action<string,string,string> action2;
        action1 = Info;
        action1?.Invoke("Thong bao action");
        Func<int, int, int> tinhtong, tinhhieu;
        tinhtong = Sum;
        tinhhieu = Signal;
        Console.WriteLine("Tong hai so la: " + tinhtong(4, 6));
        Console.WriteLine("Hieus hai so la: " + tinhhieu(5, 1));
        Console.ReadKey();

       

    }
}
