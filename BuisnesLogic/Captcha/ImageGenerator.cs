using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BusinessLogic.Captcha
{
    /// <summary>
    /// Generate small image from text
    /// </summary>
    public class ImageGenerator
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }
        
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGenerator"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="width">The width.</param>
        /// <param name="heigth">The heigth.</param>
        public ImageGenerator(string text, int width = 200, int heigth = 40)
        {
            Text = text;
            Width = width;
            Height = heigth;
        }

        /// <summary>
        /// Generates the image.
        /// </summary>
        private Bitmap GenerateImage()
        {
            var random = new Random();
        
            var bitmap = new Bitmap(
              Width, Height,
              PixelFormat.Format32bppArgb);

            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width, Height);

            var hatchBrush = new HatchBrush(
              HatchStyle.SmallConfetti,
              Color.DarkBlue,
              Color.WhiteSmoke);
            g.FillRectangle(hatchBrush, rect);

            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;

            do
            {
                fontSize--;
                font = new Font(
                  FontFamily.GenericSansSerif,
                  fontSize,
                  FontStyle.Bold);
                size = g.MeasureString(Text, font);
            } while (size.Width > rect.Width);

            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var path = new GraphicsPath();
            path.AddString(
              Text,
              font.FontFamily,
              (int)font.Style,
              font.Size, rect,
              format);
            const float v = 4F;
            PointF[] points =
      {
        new PointF(
          random.Next(rect.Width) / v,
          random.Next(rect.Height) / v),
        new PointF(
          rect.Width - random.Next(rect.Width) / v,
          random.Next(rect.Height) / v),
        new PointF(
          random.Next(rect.Width) / v,
          rect.Height - random.Next(rect.Height) / v),
        new PointF(
          rect.Width - random.Next(rect.Width) / v,
          rect.Height - random.Next(rect.Height) / v)
      };
            var matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            hatchBrush = new HatchBrush(
              HatchStyle.LargeConfetti,
              Color.Blue,
              Color.Black);
            g.FillPath(hatchBrush, path);

            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m / 50);
                int h = random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            return bitmap;
        }

        /// <summary>
        /// Gets the get image.
        /// </summary>
        public Bitmap GetImage
        {
            get
            {
                return GenerateImage();
            }
        }
    }
}
