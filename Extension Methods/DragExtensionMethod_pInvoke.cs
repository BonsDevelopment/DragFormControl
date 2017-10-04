using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    public static class DragExtensionMethod
    {
        enum Messages
        {
            WM_NCLBUTTONDOWN = 0xA1,
            HT_CAPTION = 0x2
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void Dragable(this Control ctrl)
        {
            ctrl.MouseDown += new MouseEventHandler((sender,e) => {

                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(ctrl.Parent.Handle, (int)Messages.WM_NCLBUTTONDOWN, (int)Messages.HT_CAPTION, 0);
                }

            });
        } 
                
    }

