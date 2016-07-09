using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

// drunk po
// GEnerates erratic mous and keyboards movementas and input and generates system sounds and dfake dialogs to confuse the user 
// toppics:     
//  threads
//system.windowds.forms namespace and assembly
//hidden apps

#region main
namespace DunkPC
{
    class Program
    {

        public static Random _random = new Random();

       // public static int _sds = 10;
        //public static int _tds = 10; 



        /// <summary>
        /// Entry point 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


            //           if( args.Length >= 2 )

            //           {
            //              _sds = Convert.ToInt32(args[0]);
            //               _tds = Convert.ToInt32(args[1]);
            //          }

            // Threads that manipulare all the of inputs and outputs to the system


            Thread drunkMouse = new Thread(new ThreadStart(DrunkMouse));

            Thread drunkKeyboard = new Thread(new ThreadStart(DrunkKeyboard));

            Thread drunkSounds = new Thread(new ThreadStart(DrunkSound));

            Thread drunkPopup = new Thread(new ThreadStart(DrunkPopup));

            
            

          //  DateTime future = DateTime.Now.AddSeconds(_sds);
          //  Console.WriteLine("Waiting 10 seconds before starting threads");
          //  while(future > DateTime.Now)
           // {
                Thread.Sleep(1000);
         //   }

            //start threads 
            drunkMouse.Start();

            drunkKeyboard.Start();

            drunkSounds.Start();

            drunkPopup.Start();

            //Kill all threads and exit apps 

            Console.Read();
            drunkMouse.Abort();

            drunkKeyboard.Abort();

            drunkSounds.Abort();

            drunkPopup.Abort();

    //       future = DateTime.Now.AddSeconds(_tds);
   //         while (future > DateTime.Now)
  //          {
  //              Thread.Sleep(500);
  //          }
//            Console.WriteLine("Terminating all therads");

        }

        #endregion

        #region Thread fuctions 
        //random mouse movenments 
        #region Mouse
        public static void DrunkMouse()
        {

            int moveX = 0;
            int moveY = 0; 

            while(true)
            {
               // Console.WriteLine(Cursor.Position.ToString());
                
                //Random Movement
                moveX =_random.Next(20) - 5;
                moveY = _random.Next(20) - 6;

                Cursor.Position = new Point(Cursor.Position.X+moveX, Cursor.Position.Y + moveY);

                Thread.Sleep(500);
            }
        }
        #endregion

        //random keyboard output 
        #region Keyboard 
        public static void DrunkKeyboard()
        {
            Console.WriteLine("Drunk Keyboard Started");

            while (true)
            {
                char key = (char)(_random.Next(25)+65); 

                if (_random.Next(2) == 0)
                {
                    key = Char.ToLower(key);
                }

                SendKeys.SendWait(key.ToString());

                Thread.Sleep(_random.Next(100));
            }
        }
        #endregion

        #region sound 
        //random sounds 
        public static void DrunkSound()
        {
            Console.WriteLine("Drunk Sounds Started");
            while (true)
            {
                if(_random.Next(100)>50)
                {
                    switch(_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;

                        case 1:
                        SystemSounds.Beep.Play();
                        break;
                        case 2:
                        SystemSounds.Exclamation.Play();
                        break;
                        case 3:
                        SystemSounds.Hand.Play();
                        break;    
                        case 4:
                        SystemSounds.Question.Play();
                        break;
                    }

                    SystemSounds.Asterisk.Play();
                    Thread.Sleep(1000);
                }
              
                
            }
        }
        #endregion

        #region popup
        //random error popups 
        public static void DrunkPopup()
            {

            if (_random.Next(100) > 20)
            {

                switch(_random.Next(3))
                {
                    case 0:
                        MessageBox.Show("Operation has stopped working", "Task Manager", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        break;

                    case 1:
                        MessageBox.Show("System is running Low on resources");
                        break;

                    case 2:
                        MessageBox.Show("Trojan Detected, System Overdrive", "Task Manager", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        break;

  
                }

               


            }
             
           



            Console.WriteLine("Drunk Popups Started");
            while (true)
            {


                Thread.Sleep(500);
            }

        }
        #endregion
        #endregion
    }
}
