namespace WinFormsEvents
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Cyan;
            label1.BorderStyle = BorderStyle.FixedSingle;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            Load += Form1_Resize;
            Click += Click_Form1;
            this.MouseClick += RightClick;
            this.MouseHover += RestingMouse;

            label1.MouseClick += RightClick;
            label1.Click += Click_label1;
            label1.MouseHover += RestingMouse;
            ResumeLayout(false);
        }


        private void RestingMouse(object sender, EventArgs e)
        {
            Text = $"X:{MousePosition.X}, Y = {MousePosition.Y}";
        }
        private void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Text = $"Width = {ClientSize.Width},Height = {ClientSize.Height}";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            label1.Size = new Size(this.ClientSize.Width - 50, this.ClientSize.Height -50);
            label1.Location = new Point((this.ClientSize.Width - label1.Width)/2, (this.ClientSize.Height - label1.Height)/2);
        }

        private void Click_label1(object sender, EventArgs e)
        {
           label1.Text = "You are clicking in the box";

            int borderMargin = 5;

            Point mousePos = this.PointToClient(MousePosition);

            if (mousePos.Y <= label1.Top + borderMargin)
                label1.Text = "Click detected on the top border!";
            else if (mousePos.X <= label1.Left + borderMargin)
                label1.Text = "Click detected on the left border!";
            else if (mousePos.Y >= label1.Bottom-borderMargin)
                label1.Text = "Click detected on the bottom border!";
            else if (mousePos.X >= label1.Right-borderMargin)
                label1.Text = "Click detected on the right border!";
            else
                label1.Text = "You are clicking inside the box.";
        }

        private void Click_Form1(object sender, EventArgs e)
        {
            int borderMargin = 5;

            Point mousePos = this.PointToClient(MousePosition);

            if (mousePos.Y >= label1.Top - borderMargin && mousePos.Y <= label1.Top)
                label1.Text = "Click detected on the top border!";
            else if (mousePos.X >= label1.Left - borderMargin && mousePos.X <= label1.Left)
                label1.Text = "Click detected on the left border!";
            else if (mousePos.Y >= label1.Bottom && mousePos.Y <= label1.Bottom + borderMargin)
                label1.Text = "Click detected on the bottom border!";
            else if (mousePos.X >= label1.Right && mousePos.X <= label1.Right + borderMargin)
                label1.Text = "Click detected on the right border!";
            else
                label1.Text = "You are clicking outside the box.";
        }


        private Label label1;
    }
}
