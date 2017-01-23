using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    //class to take a correct button from keyboard
    class Inputs
    {
        //create this object to remember the list of available buttons;
        private static Hashtable keyTable = new Hashtable();

        // Function that i try to know if a keyboard button was pressed and change his state (true/false)
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key]= state;
        }

        //Function to check the correct button was pressed
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
                return false;

            return (bool) keyTable[key];
        }
    }
}
