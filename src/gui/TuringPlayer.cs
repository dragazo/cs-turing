using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace turing
{
    public partial class TuringPlayer : Form
    {
        private Turing Turing;
        private Turing.DataIterator RenderPoint;
        private int CursorPos;

        private ulong Ticks;

        // -- rendering settings -- //

        private const float yOffset = 70;
        private const float xPadding = 10;

        private const float dispHeight = 30;

        private const float dispCursorYOffset = -3;

        private const int dispRows = 8;
        private const int dispCols = 8;

        private Brush TextBrush = new SolidBrush(Color.Black);
        private Brush GhostBrush = new SolidBrush(Color.LightGray);

        private Pen BorderPen = new Pen(Color.Green);
        private Font TextFont = new Font(FontFamily.GenericMonospace, 16);

        // ------------------------ //

        public TuringPlayer()
        {
            InitializeComponent();

            // allocate the turing machine and set up the render point
            Turing = new Turing();
            RenderPoint = Turing.Pos;
            CursorPos = 0;

            Ticks = 0;

            // -------------

            Resize += (o, e) => Invalidate();
        }

        private bool __Disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!__Disposed)
            {
                if (disposing)
                {
                    components?.Dispose(); // from auto-generated code (they hinted it might be null)

                    // -- dispose stuff we allocated -- //

                    TextBrush.Dispose();
                    GhostBrush.Dispose();

                    BorderPen.Dispose();
                    TextFont.Dispose();
                }

                base.Dispose(disposing);
                __Disposed = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);         // ensure we call base for event pumping
            Graphics g = e.Graphics; // get shorthand graphics handle

            // get render cursor
            float x = xPadding;
            float y = yOffset;

            // get size of a cell
            float w = (ClientRectangle.Width - 2 * xPadding) / dispCols;
            float ww = (ClientRectangle.Width - 2 * xPadding) / 5;
            float h = dispHeight;

            // state line
            g.DrawString("State", TextFont, TextBrush, x, y);
            g.DrawString(Turing.State.ToString(), TextFont, TextBrush, x + ww, y);
            y += h;

            // tick line
            g.DrawString("Tick", TextFont, TextBrush, x, y);
            g.DrawString(Turing.State.ToString(), TextFont, TextBrush, x + ww, y);
            y += h;

            // new line
            y += h;

            // get data iterator (begins with ghost row
            Turing.DataIterator iter = RenderPoint - dispCols;

            // display top ghost row
            for (int col = 0; col < dispCols; ++col)
            {
                g.DrawString(iter.Value.ToString(), TextFont, GhostBrush, x + col * w, y);
                iter += 1;
            }
            y += h;

            // highlight cursor position
            g.DrawRectangle(BorderPen, x + (CursorPos % dispCols) * w, y + (CursorPos / dispCols) * h + dispCursorYOffset, w, h);

            // display the solid elements
            for (int row = 0; row < dispRows; ++row)
            {
                for (int col = 0; col < dispCols; ++col)
                {
                    g.DrawString(iter.Value.ToString(), TextFont, TextBrush, x + col * w, y);
                    iter += 1;
                }
                y += h;
            }

            // display bottom ghost row
            for (int col = 0; col < dispCols; ++col)
            {
                g.DrawString(iter.Value.ToString(), TextFont, GhostBrush, x + col * w, y);
                iter += 1;
            }
            y += h;

            // new line
            y += h;

            g.DrawString("State", TextFont, TextBrush, x + 0 * ww, y);
            g.DrawString("Input", TextFont, TextBrush, x + 1 * ww, y);
            g.DrawString("Output", TextFont, TextBrush, x + 2 * ww, y);
            g.DrawString("Next", TextFont, TextBrush, x + 3 * ww, y);
            g.DrawString("Offset", TextFont, TextBrush, x + 4 * ww, y);
            y += h;

            Turing.Rule rule = Turing.GetExecutingRule();

            g.DrawString(rule != null ? rule.CurrentState.ToString() : "N/A", TextFont, TextBrush, x + 0 * ww, y);
            g.DrawString(rule != null ? rule.Input.ToString() : "N/A", TextFont, TextBrush, x + 1 * ww, y);
            g.DrawString(rule != null ? rule.Output.ToString() : "N/A", TextFont, TextBrush, x + 2 * ww, y);
            g.DrawString(rule != null ? rule.NextState.ToString() : "N/A", TextFont, TextBrush, x + 3 * ww, y);
            g.DrawString(rule != null ? rule.Offset.ToString() : "N/A", TextFont, TextBrush, x + 4 * ww, y);
            y += h;
        }
    }
}
