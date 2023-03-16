using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //creating variables
            int scripts;
            int questions;
            int subtotal;
            int totalmarks = 0;
            int lecturers;
            int newlectamount;
            int spl;
            methods useobj = new methods();


            //Asking and collecting data
            Console.WriteLine("Enter the number of scripts");
            scripts = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of questions");
            questions = Convert.ToInt32(Console.ReadLine());


            //For loop to ask the subtotal of each question and giving a total back
            for (int i = 1; i < questions + 1; i++)
            {
                Console.WriteLine("Enter the subtotal of marks for question " + i);
                subtotal = Convert.ToInt32(Console.ReadLine());
                totalmarks = totalmarks + subtotal;

            }


            Console.WriteLine("Enter the number of lecturers");
            lecturers = Convert.ToInt32(Console.ReadLine());

            //Calc the scripts per lecturer
            newlectamount = useobj.checklecturer(scripts, lecturers);

            spl = scripts / newlectamount;

            //print it all out
            Console.WriteLine("\n\nThe Amount of required lecturers is:" +newlectamount + " lecturers will have to mark: " + spl + " each");
            useobj.timecalculator(totalmarks, spl);


        } 
    }

    class methods {

        //creating variables
        double seconds;
        double minutes;
        double hours = 0;
        double spl;

        //creating method to calc time and asking for totalmarks 
        public void timecalculator(int totalmarks,int numOfScripts) {

            
            //Calc as given in text
            seconds = (totalmarks * numOfScripts)*2;
            while (seconds >=60) {

                seconds = seconds - 60;

                minutes++;
            
            }

            //checking for remainder
            if (seconds>30) {

                minutes++;
            
            
            }
            //calc hours
            while (minutes >= 60)
            {

                minutes = minutes - 60;

                hours++;
            }



            Console.WriteLine("This should take each lecturer: " + hours + "hrs and " + minutes + "mins");
        }


        public int checklecturer(int scripts, int lecturers) {

            //gets scripts per lecturer
            spl = (double)scripts / (double)lecturers;

            //keeps checking if scripts of lecturer is a whole number until it is
            while ((spl%1)!=0) {


                //adding 1 to lecturers until you get to a whole number
                lecturers++;
                spl = (double)scripts / (double)lecturers;




            }




            return lecturers;
        }
    
    }


   
}
