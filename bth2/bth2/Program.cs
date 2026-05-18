using System;
using System.Net;
using System.Threading;
namespace ASYNCHRONOUS
{
    public class Asynchronous01
    {
        //phương thức mô tả một tác vụ có nhiều bước thực hiện
        static void DoSomeThing(int count, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs}... start");
                Console.ResetColor();
            }
            for (int i = 1; i <= count; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,8} {i,2}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs}... end");
                Console.ResetColor();
            }
        }
        static void DoSomeThing1(int count, string mgs, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs}... start");
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"{mgs,8} {i,2}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"{mgs}... end");
            Console.ResetColor();
        }
        //Task không có tham số
        static Task Task1()
        {
            Task t1 = new Task(
                () => { DoSomeThing(4, "work1", ConsoleColor.Red); }
                );
            t1.Start();
            t1.Wait();
             Console.WriteLine("Work1 da hoan thanh");
            return t1;
        }
        //Task có tham số
        static Task Task2()
        {
            Task t2 = new Task(
                (object obj) => {
                    string taskName = obj.ToString();
                    DoSomeThing(5, taskName, ConsoleColor.Green);
                }
                , "work2");
            t2.Start();
            return t2;
        }
        // Task bất đồng bộ, không có tham số
        static async Task Task3()
        {
            Task t3 = new Task(
                (object obj) => {
                    string taskName = obj.ToString();
                    DoSomeThing(5, taskName, ConsoleColor.Yellow);
                }
                , "work3");
            t3.Start();
            await t3;
            Console.WriteLine("Work3 da hoan thanh");
        }
        // Task bất đồng bộ, có tham số
        static Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
                () =>
                {
                    DoSomeThing(5, "work4", ConsoleColor.Cyan);
                    return "Return work4";
                });
            t4.Start();
            return t4;
        }
        // Task bất đồng bộ, có tham số
        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>(
                (object obj) => {
                    string taskName = obj.ToString();
                    DoSomeThing(5, taskName, ConsoleColor.Magenta);
                    return "Return work5";
                }
                , "work5");
            t5.Start();
            string kq = await t5;
            return kq;                                                                                              
        }
        static async Task<string> Task6()
        {
            Task<string> t6 = new Task<string>(
                (object obj) =>   {
                string taskName = obj.ToString();
                DoSomeThing(10, taskName, ConsoleColor.Magenta);
                return "Return work6";
            }                         
            , "work6");
            t6.Start();
            string hh = await t6;
            return hh;
        }
        public static void Main(string[] agrs)
        {
            //synchronous
             DoSomeThing1(3, "work1", ConsoleColor.Blue);
             DoSomeThing1(4, "work2", ConsoleColor.Green);
            DoSomeThing1(5, "work3", ConsoleColor.Yellow);
            Console.Out.WriteLine("Hello world");

            //Asynchronous
            //Gọi thực hiện các task bất động bộ để thấy cơ chế thực hiện của chương trình
            Task t1 = Task1(); //Thread riêng
                               Task t2 = Task2(); //Thread riêng
                               Task t3 = Task3();
            DoSomeThing(6, "work3", ConsoleColor.Yellow); //Thread riêng
            Console.Out.WriteLine("Hello world");
            Console.ReadKey();
            Task<string> t6 = Task6();   // gọi task
            t6.Wait();                   // ĐỢI task chạy xong

            Console.WriteLine(t6.Result);

            DoSomeThing(8, "work6-main", ConsoleColor.Red);

            Console.ReadKey();
        }
    }
}
