namespace Plot_that_line
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerFinal = new DateTimePicker();
            button2 = new Button();
            LastYear = new CheckBox();
            LastMonth = new CheckBox();
            LastWeek = new CheckBox();
            Fantom = new CheckBox();
            Celsius = new CheckBox();
            BitTorrent = new CheckBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(12, 68);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(576, 261);
            formsPlot1.TabIndex = 0;
            formsPlot1.Load += formsPlot1_Load;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(28, 335);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 2;
            dateTimePickerStart.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Location = new Point(251, 335);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(200, 23);
            dateTimePickerFinal.TabIndex = 4;
            dateTimePickerFinal.TabStop = false;
            dateTimePickerFinal.UseWaitCursor = true;
            dateTimePickerFinal.ValueChanged += dateTimePickerFinal_ValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(492, 335);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LastYear
            // 
            LastYear.AccessibleName = "LastYear";
            LastYear.AutoSize = true;
            LastYear.Location = new Point(609, 92);
            LastYear.Margin = new Padding(3, 2, 3, 2);
            LastYear.Name = "LastYear";
            LastYear.Size = new Size(69, 19);
            LastYear.TabIndex = 7;
            LastYear.Text = "LastYear";
            LastYear.UseVisualStyleBackColor = true;
            LastYear.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // LastMonth
            // 
            LastMonth.AutoSize = true;
            LastMonth.Location = new Point(608, 132);
            LastMonth.Name = "LastMonth";
            LastMonth.Size = new Size(83, 19);
            LastMonth.TabIndex = 8;
            LastMonth.Text = "LastMonth";
            LastMonth.UseVisualStyleBackColor = true;
            LastMonth.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LastWeek
            // 
            LastWeek.AutoSize = true;
            LastWeek.Location = new Point(608, 173);
            LastWeek.Name = "LastWeek";
            LastWeek.Size = new Size(76, 19);
            LastWeek.TabIndex = 9;
            LastWeek.Text = "LastWeek";
            LastWeek.UseVisualStyleBackColor = true;
            LastWeek.CheckedChanged += LastDay_CheckedChanged;
            // 
            // Fantom
            // 
            Fantom.AutoSize = true;
            Fantom.Location = new Point(741, 92);
            Fantom.Name = "Fantom";
            Fantom.Size = new Size(67, 19);
            Fantom.TabIndex = 10;
            Fantom.Text = "Fantom";
            Fantom.UseVisualStyleBackColor = true;
            Fantom.CheckedChanged += Fantom_CheckedChanged;
            // 
            // Celsius
            // 
            Celsius.AutoSize = true;
            Celsius.Location = new Point(741, 132);
            Celsius.Name = "Celsius";
            Celsius.Size = new Size(63, 19);
            Celsius.TabIndex = 11;
            Celsius.Text = "Celsius";
            Celsius.UseVisualStyleBackColor = true;
            Celsius.CheckedChanged += Celsius_CheckedChanged;
            // 
            // BitTorrent
            // 
            BitTorrent.AutoSize = true;
            BitTorrent.Location = new Point(741, 173);
            BitTorrent.Name = "BitTorrent";
            BitTorrent.Size = new Size(77, 19);
            BitTorrent.TabIndex = 12;
            BitTorrent.Text = "BitTorrent";
            BitTorrent.UseVisualStyleBackColor = true;
            BitTorrent.CheckedChanged += BitTorrent_CheckedChanged;
            // 
            // Form1
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 654);
            Controls.Add(BitTorrent);
            Controls.Add(Celsius);
            Controls.Add(Fantom);
            Controls.Add(LastWeek);
            Controls.Add(LastMonth);
            Controls.Add(LastYear);
            Controls.Add(button2);
            Controls.Add(dateTimePickerFinal);
            Controls.Add(dateTimePickerStart);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ScottPlot.WinForms.FormsPlot formsPlot1;
        public DateTimePicker dateTimePickerStart;
        public DateTimePicker dateTimePickerFinal;
        public Button button2;
        public CheckBox LastYear;
        public CheckBox LastMonth;
        public CheckBox LastWeek;
        public CheckBox Fantom;
        public CheckBox Celsius;
        public CheckBox BitTorrent;
    }
}
