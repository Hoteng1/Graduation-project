using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    static public class StaticMethods
    {
        static public void SwitchCursor()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
             
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }
}
