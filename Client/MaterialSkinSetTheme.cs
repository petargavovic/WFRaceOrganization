using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    internal class MaterialSkinSetTheme
    {
        public static MaterialSkinManager.Themes theme = MaterialSkinManager.Themes.LIGHT;
        public static ColorScheme colorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        public static void SetTheme(MaterialForm frm)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(frm);
            materialSkinManager.Theme = theme;
            materialSkinManager.ColorScheme = colorScheme;
        }
    }
}
