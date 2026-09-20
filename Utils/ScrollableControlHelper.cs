using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKtx.Utils
{
    public static class ScrollableControlHelper
    {
        public static void Configure(Control container, int minimumContentHeight = 680)
        {
            var originalLocations = new Dictionary<Control, Point>();
            foreach (Control child in container.Controls)
            {
                originalLocations[child] = child.Location;
            }

            var scrollBar = new VScrollBar
            {
                Dock = DockStyle.Right,
                SmallChange = 24,
                LargeChange = 120,
                Visible = false
            };

            void UpdateScrollBar()
            {
                int contentBottom = minimumContentHeight;
                foreach (Control child in container.Controls)
                {
                    if (child != scrollBar)
                    {
                        contentBottom = Math.Max(contentBottom, originalLocations[child].Y + child.Height + 12);
                    }
                }

                int viewportHeight = container.ClientSize.Height;
                int maximum = Math.Max(0, contentBottom - viewportHeight);
                scrollBar.Maximum = Math.Max(0, maximum + scrollBar.LargeChange - 1);
                scrollBar.Visible = maximum > 0;
                scrollBar.Value = Math.Min(scrollBar.Value, maximum);
                ApplyOffset(scrollBar.Value);
            }

            void ApplyOffset(int offset)
            {
                foreach (Control child in container.Controls)
                {
                    if (child != scrollBar && originalLocations.TryGetValue(child, out Point location))
                    {
                        child.Location = new Point(location.X, location.Y - offset);
                    }
                }
            }

            scrollBar.Scroll += (_, _) => ApplyOffset(scrollBar.Value);
            container.Controls.Add(scrollBar);
            container.Resize += (_, _) => UpdateScrollBar();

            void HandleMouseWheel(object? sender, MouseEventArgs e)
            {
                if (!scrollBar.Visible) return;
                int nextValue = scrollBar.Value - e.Delta / 2;
                scrollBar.Value = Math.Max(scrollBar.Minimum, Math.Min(scrollBar.Maximum, nextValue));
                ApplyOffset(scrollBar.Value);
            }

            AttachMouseWheel(container, HandleMouseWheel);
            UpdateScrollBar();
        }

        private static void AttachMouseWheel(Control control, MouseEventHandler handler)
        {
            control.MouseWheel += handler;
            foreach (Control child in control.Controls)
            {
                if (child is not VScrollBar)
                {
                    AttachMouseWheel(child, handler);
                }
            }
        }
    }
}