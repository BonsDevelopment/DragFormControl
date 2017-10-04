using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragFormControl
{
    [Description("Drag form from a control handle without using pinvokes")]
    public class DragForm : Component
    {
        [Category("Behavior")]
        [Description("Control to make the form drag-able")]
        
        public Control MoveControl { get; set; }

        private Timer dragTimer = new Timer();

        private bool dragForm;
        private Point previousLocation;

        public DragForm()
        {
            dragTimer.Enabled = true;
            dragTimer.Interval = 1;
            dragTimer.Tick += new EventHandler(dragTimer_Tick);
        }

        private void dragTimer_Tick(object sender, EventArgs e)
        {
            if (MoveControl != null && MoveControl != new Form())
            {
                dragTimer.Enabled = false;
                MoveControl.MouseDown += new MouseEventHandler(Control_MouseDown);
                MoveControl.MouseMove += new MouseEventHandler(Control_MouseMove);
                MoveControl.MouseUp += new MouseEventHandler(Control_MouseUp);

            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            dragForm = false;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragForm)
            {
                MoveControl.Parent.Location = new Point(
                    (MoveControl.Parent.Location.X - previousLocation.X) + e.X, (MoveControl.Parent.Location.Y - previousLocation.Y) + e.Y);

                MoveControl.Parent.Update();
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm = true;
            previousLocation = e.Location;
        }
    }
}
