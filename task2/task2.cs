using System;
using System.Collections;

class A
{
    static void Main()
    {
        float r = -1, x0 = 0, y0 = 0;
        bool test=false;
        Circle(ref r, ref x0,ref y0, ref test);
        if (test==true)
        {
            B b=new B(ref r, ref x0, ref y0);
        }
    }
    static void Circle(ref float r0, ref float x0, ref float y0, ref bool test)
    {
        int check=0;
        StreamReader path = new StreamReader("file1.txt");
        while (!path.EndOfStream)
        {
            string line = path.ReadLine();
            line+=' ';
            string str="";
            int flag=0;
            foreach (char c in line)
            {
                if((c==' '))
                {
                    bool b=false;
                    if(str!="") {
                        switch(check){
                        case 0: flag=1; break;
                        case 1: flag=2; break;
                        case 12: flag=3; break;
                    }
                    }
                    switch(flag){
                        case 1: b=float.TryParse(str,out x0); break;
                        case 2: b=float.TryParse(str,out y0); break;
                        case 3: b=float.TryParse(str,out r0); break;
                    }
                    if (b==true){check=check*10+flag;}
                    flag=0;
                    str="";
                }
                else{str+=c;}
            }
        }
        path.Close();
        int[] a = new int[check.ToString().Length];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = check % 10;
                check /= 10;
            }
            if((a.Contains(1))&&((a.Contains(2)))&&((a.Contains(3)))){
                test=true;
            }
    }
}
class B
{
    public B(ref float r, ref float x0, ref float y0)
    {
        StreamReader path = new StreamReader("file2.txt");
        while (!path.EndOfStream)
        {
            float x1=0,y1=0;
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
                    if(str!="") {if(check==0) {flag=1;} else {if(check==1) {flag=2;}}}
                    switch(flag){
                        case 1: b=float.TryParse(str,out x1); break;
                        case 2: b=float.TryParse(str,out y1); break;
                    }
                    if (b==true){check=check*10+flag;}
                    flag=0;
                    str="";
                }
                else{str+=c;}
            }
            int[] a = new int[check.ToString().Length];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = check % 10;
                check /= 10;
            }
            if((a.Contains(1))&&((a.Contains(2)))){
                float distance=(float)Math.Sqrt((x1-x0)*(x1-x0)+(y1-y0)*(y1-y0));
                if(distance==r){Console.WriteLine("0");}
                if(distance<r){Console.WriteLine("1");}
                if(distance>r){Console.WriteLine("2");}
            }
        }
        path.Close();
    }
}