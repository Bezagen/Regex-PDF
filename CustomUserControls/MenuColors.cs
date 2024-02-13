using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFReader.CustomUserControls
{
    public class MenuColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(47, 79, 79); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(47, 79, 79); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(51, 153, 255); }
        }
    }
}
