namespace Charts
{
    partial class charts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.check_temp = new System.Windows.Forms.CheckBox();
            this.check_humidity = new System.Windows.Forms.CheckBox();
            this.check_uv = new System.Windows.Forms.CheckBox();
            this.check_damp = new System.Windows.Forms.CheckBox();
            this.check_methane = new System.Windows.Forms.CheckBox();
            this.check_wind = new System.Windows.Forms.CheckBox();
            this.make_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // check_temp
            // 
            this.check_temp.AutoSize = true;
            this.check_temp.Checked = true;
            this.check_temp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_temp.Location = new System.Drawing.Point(13, 13);
            this.check_temp.Name = "check_temp";
            this.check_temp.Size = new System.Drawing.Size(86, 17);
            this.check_temp.TabIndex = 0;
            this.check_temp.Text = "Temperature";
            this.check_temp.UseVisualStyleBackColor = true;
            // 
            // check_humidity
            // 
            this.check_humidity.AutoSize = true;
            this.check_humidity.Checked = true;
            this.check_humidity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_humidity.Location = new System.Drawing.Point(13, 37);
            this.check_humidity.Name = "check_humidity";
            this.check_humidity.Size = new System.Drawing.Size(66, 17);
            this.check_humidity.TabIndex = 1;
            this.check_humidity.Text = "Humidity";
            this.check_humidity.UseVisualStyleBackColor = true;
            // 
            // check_uv
            // 
            this.check_uv.AutoSize = true;
            this.check_uv.Checked = true;
            this.check_uv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_uv.Location = new System.Drawing.Point(13, 61);
            this.check_uv.Name = "check_uv";
            this.check_uv.Size = new System.Drawing.Size(41, 17);
            this.check_uv.TabIndex = 2;
            this.check_uv.Text = "UV";
            this.check_uv.UseVisualStyleBackColor = true;
            // 
            // check_damp
            // 
            this.check_damp.AutoSize = true;
            this.check_damp.Checked = true;
            this.check_damp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_damp.Location = new System.Drawing.Point(13, 85);
            this.check_damp.Name = "check_damp";
            this.check_damp.Size = new System.Drawing.Size(54, 17);
            this.check_damp.TabIndex = 3;
            this.check_damp.Text = "Damp";
            this.check_damp.UseVisualStyleBackColor = true;
            // 
            // check_methane
            // 
            this.check_methane.AutoSize = true;
            this.check_methane.Checked = true;
            this.check_methane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_methane.Location = new System.Drawing.Point(13, 109);
            this.check_methane.Name = "check_methane";
            this.check_methane.Size = new System.Drawing.Size(68, 17);
            this.check_methane.TabIndex = 4;
            this.check_methane.Text = "Methane";
            this.check_methane.UseVisualStyleBackColor = true;
            // 
            // check_wind
            // 
            this.check_wind.AutoSize = true;
            this.check_wind.Checked = true;
            this.check_wind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_wind.Location = new System.Drawing.Point(13, 133);
            this.check_wind.Name = "check_wind";
            this.check_wind.Size = new System.Drawing.Size(51, 17);
            this.check_wind.TabIndex = 5;
            this.check_wind.Text = "Wind";
            this.check_wind.UseVisualStyleBackColor = true;
            // 
            // make_btn
            // 
            this.make_btn.Location = new System.Drawing.Point(137, 60);
            this.make_btn.Name = "make_btn";
            this.make_btn.Size = new System.Drawing.Size(156, 65);
            this.make_btn.TabIndex = 6;
            this.make_btn.Text = "Choose file and make charts";
            this.make_btn.UseVisualStyleBackColor = true;
            this.make_btn.Click += new System.EventHandler(this.make_btn_Click);
            // 
            // charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 328);
            this.Controls.Add(this.make_btn);
            this.Controls.Add(this.check_wind);
            this.Controls.Add(this.check_methane);
            this.Controls.Add(this.check_damp);
            this.Controls.Add(this.check_uv);
            this.Controls.Add(this.check_humidity);
            this.Controls.Add(this.check_temp);
            this.Name = "charts";
            this.Text = "Make charts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox check_temp;
        private System.Windows.Forms.CheckBox check_humidity;
        private System.Windows.Forms.CheckBox check_uv;
        private System.Windows.Forms.CheckBox check_damp;
        private System.Windows.Forms.CheckBox check_methane;
        private System.Windows.Forms.CheckBox check_wind;
        private System.Windows.Forms.Button make_btn;
    }
}

