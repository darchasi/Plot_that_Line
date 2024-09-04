using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot_that_line
{
    public class Date_Picker : DateTimePicker
    {
        private bool droppedDown = false;

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            e.Handled = true;
        }
    }

    
}
