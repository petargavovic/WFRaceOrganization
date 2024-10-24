using Common.Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class PonasanjeForme
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public static void ResizeControl(Rectangle r, Control c, Rectangle originalFormSize, int width, int height)
        {
            float xRatio = (float)(width) / originalFormSize.Width;
            float yRatio = (float)(height) / originalFormSize.Height;

            int newX = (int)(r.Width * xRatio);
            int newY = (int)(r.Height * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        public static void ResizeListViewColumns(ListView listView, int width = 0)
        {
            float colPercentage = 1f / listView.Columns.Count;
            int colWidth;
            if (width <= 1)
                colWidth = (int)(colPercentage * listView.ClientRectangle.Width) - width;
            else
                colWidth = (int)(colPercentage * width);
            for (int i = 0; i < listView.Columns.Count; i++)
                listView.Columns[i].Width = colWidth;
            if (width <= 1)
                listView.Columns[1].Width = listView.Width / listView.Columns.Count;
        }

        public void LoadSizes(ref Rectangle[] nizVelicina, Rectangle[] nizElemenata)
        {
            for (int i = 0; i < nizElemenata.Length; i++)
            {
                Rectangle r = nizElemenata[i];
                nizVelicina[i] = new Rectangle(r.Location.X, r.Location.Y, r.Width, r.Height);
            }
        }

        public static void ButtonImageInit(Button[] btns, Image[] imgs)
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Paint += (sender, e) => PaintButton(sender, e, imgs[i - 1]);
            }
        }

        private static void PaintButton(object sender, PaintEventArgs e, Image image)
        {
            Button button = (Button)sender;

            float scaleX = (float)button.Width / image.Width;
            float scaleY = (float)button.Height / image.Height;
            float scale = Math.Max(scaleX, scaleY);

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            int x = (button.Width - newWidth) / 2;
            int y = (button.Height - newHeight) / 2;

            e.Graphics.DrawImage(image, x, y, newWidth, newHeight);
        }

        public static void PaintRows(DataGridView dgv)
        {
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                switch (((IEntity)dgvr.DataBoundItem).Status)
                {
                    case Status.Added:
                        dgvr.DefaultCellStyle.BackColor = Color.LawnGreen;
                        break;
                    case Status.Modified:
                        dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case Status.Unchanged:
                        dgvr.DefaultCellStyle.BackColor = Color.White;
                        break;
                    case Status.Deleted:
                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            }
        }

        public static void NacrtajStartnuLiniju(GraphicsPath path, Graphics g)
        {
            using (Pen pen = new Pen(Color.Blue, 2))  // Line color and width
            {
                // Ensure the path has enough points
                if (path.PointCount < 2)
                    return;

                // Get the first two points of the path
                PointF startPoint = path.PathPoints[0];
                PointF nextPoint = path.PathPoints[1];

                // Calculate the tangent vector from the starting point to the next point
                float dx = nextPoint.X - startPoint.X;
                float dy = nextPoint.Y - startPoint.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);

                // Normalize the tangent vector
                dx /= length;
                dy /= length;

                // Calculate the normal (perpendicular) vector
                float normalX = -dy;
                float normalY = dx;

                // Define the half-length of the starting line
                float halfLineLength = 10;  // Adjust this value to shorten or lengthen the starting line

                // Calculate the endpoints of the starting line centered on the startPoint
                PointF endPoint1 = new PointF(
                    startPoint.X + normalX * halfLineLength,
                    startPoint.Y + normalY * halfLineLength
                );

                PointF endPoint2 = new PointF(
                    startPoint.X - normalX * halfLineLength,
                    startPoint.Y - normalY * halfLineLength
                );

                // Draw the starting line
                g.DrawLine(pen, endPoint1, endPoint2);
            }
        }

        public static void CentrirajPut(GraphicsPath path, float targetX, float targetY)
        {
            // Calculate the bounding box of the path
            RectangleF pathBounds = path.GetBounds();

            // Determine the offset needed to center the path at the target coordinates
            float offsetX = targetX - (pathBounds.Left + pathBounds.Width / 2);
            float offsetY = targetY - (pathBounds.Top + pathBounds.Height / 2);

            // Create a translation matrix
            Matrix translationMatrix = new Matrix();
            translationMatrix.Translate(offsetX, offsetY);

            // Apply the translation matrix to the path
            path.Transform(translationMatrix);
        }

        public static float DuzinaPuta(GraphicsPath path)
        {
            float length = 0f;
            var points = path.PathPoints;
            for (int i = 0; i < points.Length - 1; i++)
            {
                length += Distance(points[i], points[i + 1]);
            }
            return length;
        }

        public static float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
