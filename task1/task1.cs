using System;
class A
{
    static void Main()
    {
        int n = 0;
        int m = 0;
        int path = 1;
        Input(ref n, ref m);
        B b1 = new B(n, m, ref path);
        Console.WriteLine("Полученный путь: "+path);
    }
    static void Input(ref int n, ref int m)
    {
        int index = 0;
        while (index <2)
        {
            char c; int x;
            if (index == 0) { c = 'n'; } else { c = 'm'; }
            Console.WriteLine("Введите "+c);
            string str = Console.ReadLine();
            bool B = int.TryParse(str, out x);
            if ((x < 1))
            {
                Console.WriteLine("Введено неправильное значение\n * Значение должно быть больше 0\n * Значение должно являться ЦЕЛЫМ числом");
            }
            else
            {
                if (index == 0) { index++; n = x; }
                else { index++; m = x; }
            }
        }
    }
}
class B
{
    public B(int n, int m, ref int path)
    {
        int index = 1;
        do
        {
            index=(index+(m-1))%n;
            switch (index)
            {
                case 0: path = path * 10 + n; break;
                case 1: break;
                default: path = path * 10 + index; break;
            }
        } while (index != 1);


    }
}