public class Program
{
    public delegate void ShowLog(string message);
    // Phương thức Info tương đồng với ShowLog (tham số, kiểu trả về)
    static public void Info(string s)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Format("Info: {0}", s));
        Console.ResetColor();
    }
    // Phương thức Warning tương đồng với ShowLog (tham số, kiểu trả về)
    static public void Warning(string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(string.Format("Waring: {0}", s));
        Console.ResetColor();
    }

    //Sử dụng Generic trong khai báo hàm    
    public static void Swap<T>(ref T a, ref T b)
    {
        T tmp;
        tmp = a;
        a = b;
        b = tmp;
    }
    public static int Sum(int a, int b) => a + b;
    public static void Main(string[] agrs)
    {
        Info("Thông báo 1");	// cách gọi phương thức thông thường
        Warning("Thông báo 2");	//cách gọi phương thức thông thường
        // Sử dụng delegate để tham chiếu đến các phương thức cùng dạng
        ShowLog showLog = null;
        showLog = Info;         // showLog gán bằng phương thức Info
        showLog("Thông báo");   // Thi hành delegate chính là thi hành Info
        showLog = Warning;      // showLog gán bằng phương thức Warning
        showLog("Thông báo");   // Thi hành delegate chính là thi hành Info
        if (showLog != null)
            showLog.Invoke("Thông báo");
        //Dùng Invoke thì phải kiểm tra biến tham chiếu có khác null không
        showLog?.Invoke("Thông báo");
        //tương đương với cách viết dùng if kiểm tra null

        //gán nhiều phương thức vào biến delegate
        showLog += Info;
        // có thể tham chiếu nhiều lần và nối các lần thực hiện các hàm vào biến delegate
        showLog += Info;
        showLog += Warning;
        showLog += Warning;
        showLog?.Invoke("Thông báo");

        // Sử dụng các delegate có sẵn như Action, không có kiểu dữ liệu trả về để gọi thực hiện các phương thức
        Action action;
        Action<string> action1;
        action1 = Info;
        action1?.Invoke("Thông báo Action");
        // Sử dụng Func, có dữ liệu trả về là tham số cuối cùng trong Func
        Func<int, int, int> tinhtong;
        tinhtong = Sum;
        Console.WriteLine("Tong hai so la: " + tinhtong(4, 6));
        Console.ReadKey();
    }
}
