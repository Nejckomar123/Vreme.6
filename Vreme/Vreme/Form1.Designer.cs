namespace Vreme
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelForecast = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(301, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelCity
            // 
            this.labelCity.AccessibleName = "labelLat";
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(298, 185);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(30, 13);
            this.labelCity.TabIndex = 1;
            this.labelCity.Tag = "labelLat";
            this.labelCity.Text = "City: ";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AccessibleName = "labelLon";
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(298, 198);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(37, 13);
            this.labelTemperature.TabIndex = 2;
            this.labelTemperature.Text = "Temp:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(298, 211);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Description:";
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Location = new System.Drawing.Point(298, 224);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(50, 13);
            this.labelHumidity.TabIndex = 4;
            this.labelHumidity.Text = "Humidity:";
            this.labelHumidity.Click += new System.EventHandler(this.labelHumidity_Click);
            // 
            // labelForecast
            // 
            this.labelForecast.AutoSize = true;
            this.labelForecast.Location = new System.Drawing.Point(298, 237);
            this.labelForecast.Name = "labelForecast";
            this.labelForecast.Size = new System.Drawing.Size(51, 13);
            this.labelForecast.TabIndex = 5;
            this.labelForecast.Text = "Forecast:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter City:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Press \'Enter\'";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelForecast);
            this.Controls.Add(this.labelHumidity);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Weather";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelForecast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

