using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultyWorkloadSystem.Helpers
{
    public class GradientPanel : Panel
    {
        //Create properties to define the colors for gradient's top and bottom
        public Color gradientTop { get; set; }
        public Color gradientBottom { get; set; }
        //Create constructor for gradient panel class
        public GradientPanel()
        {
            //Subscribe to the resize event to handle when the control's size changes
            this.Resize += GradientPanel_Resize;
        }
        private void GradientPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); //this marks the control as needing to be redrawn
        }
        //override the onPaint method to draw a gradient background
        protected override void OnPaint(PaintEventArgs e)
        {
            //create a lineargradientbrush with the specified top and bottom gradient colors
            LinearGradientBrush linear = new LinearGradientBrush(
                this.ClientRectangle, // this area to fill with the gradient
                this.gradientTop, // the starting color 
                this.gradientBottom, // the end color
                90F // the angle of the gradient
                );
            //get the graphics context for drawing
            Graphics g = e.Graphics;
            // fill the entire control area with the gradient
            g.FillRectangle(linear, this.ClientRectangle);
            // call the base class onPaint to ensure any additional painting is done
            base.OnPaint(e);
        }

    }
}
