using System;
using System.Collections;

class A
{
    static void Main()
    {
        int result=0;
        B b=new B(ref result);
        Console.WriteLine($"Минимальное количество ходов:{result}");
    }
}
class B
{
    public B(ref int result)
    {
        StreamReader path = new StreamReader("file1.txt");
        List<int> nums=new List<int>();
        while (!path.EndOfStream)
        {
            int x=0;
            int check=0;
            string line = path.ReadLine();
            line+=' ';
            string str="";
            int flag=0;
            foreach (char c in line)
            {
                if((c==' '))
                {
                    bool b=false;
                    if(str!="") {if(check==0) {flag=1;} }
                    switch(flag){
                        case 1: b=int.TryParse(str,out x); break;
                    }
                    if (b==true){check=check*10+flag;}
                    flag=0;
                    str="";
                }
                else{str+=c;}
            }
            if(check>0){nums.Add(x);}
        }
        path.Close();
        var avg=Math.Round((double)nums.Sum()/(double)nums.Count);
        foreach(int num in nums)
        {
            result+=Convert.ToInt32(Math.Abs(num-avg));
        }
    }
}