using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragFormControl
{
    /// <summary>
    /// Drag form from a control using pinvokes.
    /// </summary>
    /// 
    [Description("Drag form from a control handle using pinvokes")]
    public class pDragForm: Component
    {
        [Flags]
        enum Messages
        {
            WM_NCLBUTTONDOWN = 0xA1,
            HT_CAPTION = 0x2
        }

        [Category("Behavior")]
        [Description("Control to make form drag-able, uses pinvokes")]    
        public Control MoveControl { get; set; }

        private Timer dragTimer = new Timer();

        public pDragForm()
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
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                pInvokes.ReleaseCapture();
                pInvokes.SendMessage(MoveControl.Parent.Handle, (int)Messages.WM_NCLBUTTONDOWN, (int)Messages.HT_CAPTION, 0);

            }
        }
    }
}
