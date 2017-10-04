using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    public static class DragExtensionMethod2
    {
        private static bool dragForm;
        private static Point previousLocation;
        private static Control _controlInput;

        public static void Dragable2(this Control ctrl)
        {
            _controlInput = ctrl;

            ctrl.MouseDown += new MouseEventHandler(ctrl_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(ctrl_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(ctrl_MouseUp);
        }

        private static void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            dragForm = false;
        }

        private static void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragForm)
            {
                _controlInput.Parent.Location = new Point(
                    (_controlInput.Parent.Location.X - previousLocation.X) + e.X, (_controlInput.Parent.Location.Y - previousLocation.Y) + e.Y);

                _controlInput.Parent.Update();
            }
        }

        private static void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm = true;
            previousLocation = e.Location;
        }
    }

