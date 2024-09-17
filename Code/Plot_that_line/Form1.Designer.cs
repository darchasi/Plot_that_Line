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
            button1 = new Button();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerFinal = new DateTimePicker();
            button2 = new Button();
            LastYear = new CheckBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(14, 91);
            formsPlot1.Margin = new Padding(3, 4, 3, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(658, 348);
            formsPlot1.TabIndex = 0;
            formsPlot1.Load += formsPlot1_Load;
            // 
            // button1
            // 
            button1.Location = new Point(715, 124);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 1;
            button1.Text = "Phantom";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(808, 264);
            dateTimePickerStart.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(228, 27);
            dateTimePickerStart.TabIndex = 2;
            dateTimePickerStart.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Location = new Point(823, 327);
            dateTimePickerFinal.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(228, 27);
            dateTimePickerFinal.TabIndex = 4;
            dateTimePickerFinal.TabStop = false;
            dateTimePickerFinal.UseWaitCursor = true;
            dateTimePickerFinal.ValueChanged += dateTimePickerFinal_ValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(966, 396);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LastYear
            // 
            LastYear.AccessibleName = "LastYear";
            LastYear.AutoSize = true;
            LastYear.Location = new Point(868, 91);
            LastYear.Name = "LastYear";
            LastYear.Size = new Size(85, 24);
            LastYear.TabIndex = 7;
            LastYear.Text = "LastYear";
            LastYear.UseVisualStyleBackColor = true;
            LastYear.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Form1
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 872);
            Controls.Add(LastYear);
            Controls.Add(button2);
            Controls.Add(dateTimePickerFinal);
            Controls.Add(dateTimePickerStart);
            Controls.Add(button1);
            Controls.Add(formsPlot1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button button1;
        private DateTimePicker dateTimePickerStart;
        public DateTimePicker dateTimePickerFinal;
        private Button button2;
        private CheckBox LastYear;
    }
}
