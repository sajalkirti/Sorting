using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Quantity> inpLst=new List<Quantity>(){
            new Quantity{name="sajal = 3 sajag" ,count=0},
            new Quantity{name="4 kirti = 2 sajal" ,count=0},
            new Quantity{name="6 kirti = 3 nupur" ,count=0},
            new Quantity{name="6 sajal = 3 pink" ,count=0},
            new Quantity{name="3 pink = 2 ali" ,count=0}
        };
        List<Quantity> lst=new List<Quantity>();
        /*split*/
        string []str=(inpLst[0].name).Split('=');
        
        int l1=1;
        int l2=1;
        string s1="";
        string s2="";
        if((str[0].Split(' ')).Length>2)
        {
            l1=Convert.ToInt32((str[0].Split(' '))[0]);
            s1=(str[0].Split(' '))[1];
        }
        else
        {
            s1=(str[0].Split(' '))[0];
        }
        if((str[1].Split(' ')).Length>2)
        {
            l2=Convert.ToInt32((str[1].Split(' '))[1]);
            s2=(str[1].Split(' '))[2];
        }
        else
        {
            s2=(str[1].Split(' '))[1];
        }
        inpLst[0].count=1;
        Quantity q=new Quantity()
        {
            name=s1,
            count=l1
        };
        
        Quantity q1=new Quantity()
        {
            name=s2,
            count=l2
        };
        lst.Add(q);
        lst.Add(q1);
        
        int count=1;
        int i=1;
        while(count!=inpLst.Count)
        {
           if(inpLst[i].count==0)
             if(Calculate(lst,inpLst[i].name)==1)
             {
                 inpLst[i].count=1;
                 count++;
             }
             i++;
            if(i==inpLst.Count)
            {
                i=1;
            }
        }
        /*end split*/
        
        //Calculate(lst,"4 sajal = 15 Pankaj");
        lst.Sort(new QuantityToCompare());
        minimize(lst,lst[0].count);
        string result="";
        for(int p=0;p<lst.Count;p++)
        {
            
            result+=lst[p].count+""+lst[p].name+" = ";
        }
        result=result.Substring(0,result.Length-3);
        Console.WriteLine(result);
    }
    
    public static void minimize(List<Quantity>lst,int k)
    {
        int check=0;
        int i=2;
        while(i<=k)
        {
            check=0;
            for(int l=0;l<lst.Count;l++)
            {
                if(lst[l].count%i!=0)
                {
                    check=1;
                    i++;
                    break;
                }
            }
            if(check==0)
            {
                for(int l=0;l<lst.Count;l++)
                {
                    lst[l].count=lst[l].count/i;
                }
            }
        }
        
    }
    public static int  Calculate(List<Quantity>lst,string input)
    {
        string []str=input.Split('=');
        int l1=1;
        int l2=1;
        string s1="";
        string s2="";
        if((str[0].Split(' ')).Length>2)
        {
            l1=Convert.ToInt32((str[0].Split(' '))[0]);
            s1=(str[0].Split(' '))[1];
        }
        else
        {
            s1=(str[0].Split(' '))[0];
        }
        if((str[1].Split(' ')).Length>2)
        {
            l2=Convert.ToInt32((str[1].Split(' '))[1]);
            s2=(str[1].Split(' '))[2];
        }
        else
        {
            s2=(str[1].Split(' '))[1];
        }
        
        int lcm=1;
        for(int i=0;i<lst.Count;i++)
        {
            if(s1.Equals(lst[i].name))
            {
                lcm=(l1*lst[i].count)/GCD(l1,lst[i].count);
                mult(lst,lcm/lst[i].count);
                Quantity q=new Quantity()
                {
                    name=s2,
                    count=(lcm/l1)*l2
                };
                lst.Add(q);
                return 1;
            }
            else if(s2.Equals(lst[i].name))
            {
                lcm=(l2*lst[i].count)/GCD(l2,lst[i].count);
                mult(lst,lcm/lst[i].count);
                Quantity q=new Quantity()
                {
                    name=s1,
                    count=(lcm/l2)*l1
                };
                lst.Add(q);
                return 1;
            }
        }
        return 0;
        
        
    }
    static void mult(List<Quantity>lst,int k)
    {
        for(int i=0;i<lst.Count;i++)
        {
            lst[i].count=lst[i].count*k;
        }
        
    }
    public static int GCD(int a,int b)
    {
        if(b>a)
        {
            int temp=a;
            a=b;
            b=temp;
        }
        if(a%b==0)
        {
            return b;
        }
        return GCD(b,a%b);
    }
}
public class Quantity{
    public string name;
    public int count;
}
public class QuantityToCompare:IComparer<Quantity>
{
   
    public int Compare(Quantity ob1, Quantity ob2) {
        Quantity q1=ob1;
        Quantity q2=ob2;
        if(q1.count==q2.count)
            return 0;
        else if(q1.count>q2.count)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}

