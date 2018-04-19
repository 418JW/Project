using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice
{
    public class Employee
    {
    private string uname;
    private string fname;
    private string lname;
    private string address;
    private string position;

    
        public Employee()
        {
            
        }
        public string getun()
        {
            return uname;
        }
        public string getfn()
        {
            return fname;
        }
        public string getln()
        {
            return lname;
        }
        public string getad()
        {
            return address;
        }
        public string getpo()
        {
            return position;
        }

        public string setun(string u)
        {
            return uname=u;
        }
        public string setfn(string f)
        {
            return fname = f;
        }
        public string setln(string l)
        {
            return lname = l;
        }
        public string setad(string a)
        {
            return address = a;
        }
        public string setpo(string p)
        {
            return position = p;
        }


    }
}