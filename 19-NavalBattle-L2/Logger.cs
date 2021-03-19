using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _19_NavalBattle_L2
{
    class Logger
    {
        private TextBox _logArea;

        public Logger(TextBox logArea)
        {
            _logArea = logArea;
        }

        public void LogMessage(string message)
        {
            _logArea.Text = message + System.Environment.NewLine + _logArea.Text;
        }

        public void LogShot(string who, Coordinates target, bool hit)
        {
            string message = $"{who} shoots at {target}";
            if (hit)
                message += " and hits";
            LogMessage(message);
        }
    }
}
