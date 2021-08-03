using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Common
{
    public static class Misc
    {
       
        public static bool ConfirmationDialog()
        {
            var dialogResult = MessageBox.Show("هل انت متأكد من رغبتك في الحذف؟",
                "حذف", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
