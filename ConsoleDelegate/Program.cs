using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleDelegate
{
    class Program
    {
        public delegate int NumberChange(int number1, int number2);

        public static int AddNumber(int a,int b)
        {
            return (a + b);
        }
        public  int MultiplyNumber(int a, int b)
        {
            return (a * b);
        }
        public int MultiplyNumber1(int a, int b)
        {
            return (a * b);
        }
        public int MultiplyNumber2(int a, int b)
        {
            return (a * b);
        }
        delegate void Number(int x);

        delegate void MyDelegate(string str);
        public static void Hello(string str)
        {
            Console.WriteLine(" Hello,{0}!", str);
        }

        public static void GoodBye(string str)
        {
            Console.WriteLine(" GoodBye,{0}!", str);
        }
        public delegate void PrintString(string str);

        public static void WriteToConsole(string str)
        {
            Console.WriteLine(str);
        }
        public static void WriteToFile(string str)
        {
            System.IO.File.WriteAllText("e:\\firstfile.txt" ,str);
        }
        public static void SendString(PrintString ps)
        {
            ps("Hello Word");
        }
        
        private static bool IsDate(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, out dt);
        }
        static void Main(string[] args)
        {

			//Different Type Generics List
			List<List<object>> list = new List<List<object>>();

			List<object> list1 = new List<object>();
			list1.Add(1001); list1.Add(1002); list1.Add(1003);
			list.Add(list1);

			List<object> list2 = new List<object>();
			list1.Add("Sujay"); list1.Add("Adkar"); list1.Add("Sanjay");
			list.Add(list2);

			foreach(List<object> objectList in list)
			{
				foreach(var obj in objectList)
				{
					Console.WriteLine(obj);
				}
				Console.WriteLine();
			}
			Program p = new Program();
            NumberChange nc;
            NumberChange nc1 = new NumberChange(AddNumber);
            NumberChange nc2 = new NumberChange(p.MultiplyNumber);
            //multicast delegate
            nc = nc1;
            nc += nc2;
            Console.WriteLine("Addition is " + nc(10, 20));
            nc -= nc2;
            Console.WriteLine("Multiplication is " + nc(20, 10));


            PrintString ps1 = new PrintString(WriteToFile);
            PrintString ps2 = new PrintString(WriteToConsole);
            SendString(ps1);
            SendString(ps2);

            MyDelegate md1, md2, md3,md4;

            //MultiCast Delegate
            md1 = new MyDelegate(Hello);
            md2 = new MyDelegate(GoodBye);
            md3 = md1 + md2;
            md4 = md3 - md1;

            Console.WriteLine("Calling delegate md1");
            md1("A");

            Console.WriteLine("Calling delegate md2");
            md2("B");

            Console.WriteLine("Calling delegate md3");
            md3("C");

            Console.WriteLine("Calling delegate md4");
            md4("D");

            MyGenericsArray<int> intArray = new MyGenericsArray<int>(5);

            for(int ii=0;ii<5;ii++)
            {
                intArray.SetItem(ii,ii*5);
            }

            for(int ii=0;ii<5;ii++)
            {
                Console.Write(intArray.GetItem(ii) + " ");
            }

            int charSize = 53;
            MyGenericsArray<char> charArray = new MyGenericsArray<char>(charSize);

            for (int ii = 0; ii < charSize; ii++)
            {
                charArray.SetItem(ii, (char)(ii+64));
            }

            for (int ii = 0; ii < charSize; ii++)
            {
                Console.Write(charArray.GetItem(ii) + " ");
            }


            Number num = delegate (int x)
            {
                Console.WriteLine("Annoymous number {0}", x);
            };
            //Generic Delegate
            string date = "05/12/2013";
            Predicate<string> checkDate = d => IsDate(date);
            if(checkDate(date))
            {
                Console.WriteLine("Valid Date");
            }
            else
            {
                Console.WriteLine("Invalid Date");
            }
            Console.ReadLine();
        }
    }

    public class MyGenericsArray<T>
    {
        private T[] array;
        private List<T> list;
        public MyGenericsArray(int size)
        {
            list = new List<T>();
            //array = new T[size + 1];
        }

        public T GetItem(int index)
        {
            return list[index];
            //return array[index];
        }

        public void SetItem(int index, T value)
        {
            list.Add(value);
            //array[index] = value;    
        }

        delegate double CalcualteSimpleInterest(double param1, double param2, double param3);


    }
}
