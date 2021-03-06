﻿using System;
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

        /// <summary>
        /// Gets/sets if the data display automatically follows the execution cursor
        /// </summary>
        private bool Follow
        {
            get => FollowCheck.Checked;
            set => FollowCheck.Checked = value;
        }

        /// <summary>
        /// Gets the page number of the cursor relative to the current display page
        /// </summary>
        private int CursorPagePos => CursorPos < 0 ? (CursorPos - (PageLen - 1)) / PageLen : CursorPos / PageLen;

        /// <summary>
        /// Gets if the simulation is running. set to false to stop simulation. setting to true should only be done by <see cref="Run"/>
        /// </summary>
        private bool Running
        {
            get => StopButton.Enabled;
            set
            {
                TickButton.Enabled = RunButton.Enabled = !value;
                StopButton.Enabled = value;
            }
        }

        // -- rendering settings -- //

        private const float yOffset = 70;
        private const float xPadding = 10;

        private const float yDiffFactor = -0.007f;

        private const int dispRows = 8;
        private const int dispCols = 8;

        private const int PageLen = dispRows * dispCols;

        private Brush TextBrush = new SolidBrush(Color.Black);
        private Brush GhostBrush = new SolidBrush(Color.LightGray);

        private Pen BorderPen = new Pen(Color.Green);
        private Font TextFont = new Font(FontFamily.GenericMonospace, 16);

        // -- simulation settings -- //

        private const int FrameSleepTime = 10;
        private const int StepsPerFrame = 10000;

        // ------------------------- //

        public TuringPlayer()
        {
            InitializeComponent();

            // allocate the turing machine
            Turing = new Turing();

            //DEBUG
            //if (!Turing.LoadRules("2expab.txt")) MessageBox.Show("error loading rules");
            //if (!Turing.LoadData("data.txt")) MessageBox.Show("error loading data");

            // initialize for execution
            Init();

            // -------------

            Running = false; // flag not running for button states

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

            // if we're following the cursor make sure it's in focus
            if (Follow) FocusCursor();

            // get render cursor
            float x = xPadding;
            float y = yOffset;

            // get size of a cell
            float w = (ClientRectangle.Width - 2 * xPadding) / dispCols;
            float ww = (ClientRectangle.Width - 2 * xPadding) / 5;
            float h = (ClientRectangle.Height - yOffset) / (8 + dispRows);
            float ydiff = yDiffFactor * (h - TextFont.Size) * h;

            // state line
            g.DrawString("State", TextFont, TextBrush, x, y);
            g.DrawString(Turing.State.ToString(), TextFont, TextBrush, x + ww, y);
            y += h;

            // tick line
            g.DrawString("Tick", TextFont, TextBrush, x, y);
            g.DrawString(Ticks.ToString(), TextFont, TextBrush, x + ww, y);
            y += h;

            // new line
            y += h;

            // highlight cursor position if it's on screen
            if (CursorPos >= -dispCols && CursorPos < (dispRows + 1) * dispCols)
                g.DrawRectangle(BorderPen, x + ((CursorPos + dispCols) % dispCols) * w, y + ((CursorPos + dispCols) / dispCols) * h + ydiff, w, h);

            // get data iterator (begins with ghost row
            Turing.DataIterator iter = RenderPoint - dispCols;

            // display top ghost row
            for (int col = 0; col < dispCols; ++col)
            {
                g.DrawString(iter.Value.ToString(), TextFont, GhostBrush, x + col * w, y);
                ++iter;
            }
            y += h;

            // display the solid elements
            for (int row = 0; row < dispRows; ++row)
            {
                for (int col = 0; col < dispCols; ++col)
                {
                    g.DrawString(iter.Value.ToString(), TextFont, TextBrush, x + col * w, y);
                    ++iter;
                }
                y += h;
            }

            // display bottom ghost row
            for (int col = 0; col < dispCols; ++col)
            {
                g.DrawString(iter.Value.ToString(), TextFont, GhostBrush, x + col * w, y);
                ++iter;
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

        /// <summary>
        /// Initialzes the display for execution
        /// </summary>
        public void Init()
        {
            // set up rendering data
            RenderPoint = Turing.Pos;
            CursorPos = 0;

            // zero tick count
            Ticks = 0;

            // redraw display
            Invalidate();
        }

        /// <summary>
        /// Advances the display by the specified number of pages
        /// </summary>
        /// <param name="count">the number of pages to advance by</param>
        private void Advance(int count)
        {
            // only do this if count is non-zero
            if (count != 0)
            {
                // account for page offset
                RenderPoint += count * PageLen;
                CursorPos -= count * PageLen;
            }
        }
        private void FocusCursor()
        {
            // undo the relative page offset
            Advance(CursorPagePos);
        }

        private bool Tick()
        {
            // get the rule that's about to be executed
            Turing.Rule rule = Turing.GetExecutingRule();
            // if there is none, no-op
            if (rule == null) return false;

            // apply the rule
            Turing.Tick();
            ++Ticks;

            // account for the offset in the renderer
            CursorPos += rule.Offset;

            return true;
        }
        private async void Run()
        {
            // don't do this if we're already running a simulation
            if (Running) return;
            // set running state
            Running = true;

            // while in running state
            while (Running)
            {
                // tick the machine
                for (int i = 0; i < StepsPerFrame; ++i)
                {
                    // if any tick fails
                    if (!Tick())
                    {
                        // stop simulation and redraw display
                        Running = false;
                        Invalidate();

                        // immediate return (ensures calling Run() again within interval of redrawing/waiting doesn't cause multiple runners)
                        return;
                    }
                }

                // redraw display
                Invalidate();

                // sleep
                await Task.Delay(FrameSleepTime);
            }
        }

        private void TickButton_Click(object sender, EventArgs e)
        {
            // if we're in simulation mode do nothing (shouldn't ever happen since tick button is disabled during simulation)
            if (Running) return;

            // if we apply a tick, redraw display
            if (Tick()) Invalidate();
        }
        private void RunButton_Click(object sender, EventArgs e)
        {
            // start simulation
            Run();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            // request sim stop
            Running = false;
        }

        private void PrevDataButton_Click(object sender, EventArgs e)
        {
            Advance(-1);
            Invalidate();
        }
        private void DataCurrentButton_Click(object sender, EventArgs e)
        {
            FocusCursor();
            Invalidate();
        }
        private void NextDataButton_Click(object sender, EventArgs e)
        {
            Advance(1);
            Invalidate();
        }

        private void FollowCheck_CheckedChanged(object sender, EventArgs e)
        {
            // if we set it to true, focus on the cursor
            if (FollowCheck.Checked)
            {
                FocusCursor();
                Invalidate();
            }
        }

        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            // when opening the menu we should stop simulating
            Running = false;
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (Turing.LoadRules(d.FileName))
                    {
                        // redraw display
                        Invalidate();
                    }
                    else MessageBox.Show("Failed to load the rules file");
                }
            }
        }
        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (Turing.LoadData(d.FileName))
                    {
                        // initialize for execution
                        Init();
                    }
                    else MessageBox.Show("Failed to load the data file");
                }
            }
        }
    }
}
