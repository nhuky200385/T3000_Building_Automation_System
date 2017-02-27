﻿namespace T3000Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class HandleControl : UserControl
    {
        #region DesignerProperties

        private float _value = 0.0F;
        [Description("Value for handle"), Category("Data")]
        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                valueLabel.Text = $"{_value.ToString("F1")} F";
            }
        }

        private int _handleWidth = 50;
        [Description("Handle width"), Category("Appearance")]
        public int HandleWidth {
            get { return _handleWidth; }
            set {
                _handleWidth = value;

                if (DesignMode)
                {
                    Invalidate();
                }
            }
        }

        private int _handleHeight = 10;
        [Description("Handle height"), Category("Appearance")]
        public int HandleHeight {
            get { return _handleHeight; }
            set {
                _handleHeight = value;

                if (DesignMode)
                {
                    Invalidate();
                }
            }
        }

        private Color _borderColor = Color.White;
        [Description("Color for border"), Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;

                if (DesignMode)
                {
                    Invalidate();
                }
            }
        }

        #endregion

        public Rectangle HandleRectangle { get; set; }
        public Rectangle TextRectangle { get; set; }
        public GraphicsPath HandlePath { get; set; }
        public GraphicsPath TextPath { get; set; }

        public HandleControl()
        {
            InitializeComponent();

            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            using (var brush = new SolidBrush(BackColor))
            {
                graphics.FillPath(brush, HandlePath);
                graphics.FillPath(brush, TextPath);
            }
            using (var pen = new Pen(BorderColor))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                graphics.DrawPath(pen, HandlePath);
                graphics.DrawPath(pen, TextPath);
            }
            using (var brush = new SolidBrush(BackColor))
            {
                var rect = HandleRectangle;
                rect.Inflate(2, -1);
                graphics.FillRectangle(brush, rect);
                rect.Inflate(-2, 1);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            HandleRectangle = new Rectangle(0, Height / 2 - HandleHeight / 2, HandleWidth + 1, HandleHeight);
            TextRectangle = new Rectangle(HandleWidth, 0, Width - HandleWidth - 1, Height - 1);
            HandlePath = GraphicsUtilities.CreateRoundedRectanglePath(HandleRectangle, 4);
            TextPath = GraphicsUtilities.CreateRoundedRectanglePath(TextRectangle, 8);

            Region = new Region(HandlePath);
            Region.Union(new Region(TextPath));
        }
    }
}