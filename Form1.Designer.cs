namespace FIghtGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.killsField = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.Player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.healthField = new System.Windows.Forms.Label();
            this.ammoField = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // killsField
            // 
            this.killsField.AutoSize = true;
            this.killsField.BackColor = System.Drawing.Color.IndianRed;
            this.killsField.Location = new System.Drawing.Point(292, 28);
            this.killsField.Name = "killsField";
            this.killsField.Size = new System.Drawing.Size(43, 20);
            this.killsField.TabIndex = 1;
            this.killsField.Text = "Kills :";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(968, 20);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(195, 29);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::FIghtGame.Properties.Resources.up;
            this.Player.Location = new System.Drawing.Point(459, 266);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(71, 100);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Player.TabIndex = 4;
            this.Player.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MAinGameTimerEvent);
            // 
            // healthField
            // 
            this.healthField.AutoSize = true;
            this.healthField.BackColor = System.Drawing.Color.LimeGreen;
            this.healthField.Location = new System.Drawing.Point(887, 28);
            this.healthField.Name = "healthField";
            this.healthField.Size = new System.Drawing.Size(60, 20);
            this.healthField.TabIndex = 5;
            this.healthField.Text = "Health :";
            // 
            // ammoField
            // 
            this.ammoField.AutoSize = true;
            this.ammoField.BackColor = System.Drawing.Color.IndianRed;
            this.ammoField.Location = new System.Drawing.Point(21, 28);
            this.ammoField.Name = "ammoField";
            this.ammoField.Size = new System.Drawing.Size(61, 20);
            this.ammoField.TabIndex = 6;
            this.ammoField.Text = "Ammo :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1198, 671);
            this.Controls.Add(this.ammoField);
            this.Controls.Add(this.healthField);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.killsField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ammo;
        private Label killsField;
        private ProgressBar healthBar;
        private PictureBox Player;
        private Label healthField;
        private Label ammoField;
        private System.Windows.Forms.Timer GameTimer;
    }
}