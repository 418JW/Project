using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice
{
    public class employee
    {
    private string uname;
    private string fname;
    private string lname;
    private string address;
    private string position;

    
        public employee(string un, string fn, string ln, string ad, string po)
        {
            uname = un;
            fname = fn;
            lname = ln;
            address = ad;
            position = po;
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


    }
}