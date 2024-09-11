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
            // button1
            // 
            button1.Location = new Point(626, 93);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Phantom";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(707, 198);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 2;
            dateTimePickerStart.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Location = new Point(720, 245);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(200, 23);
            dateTimePickerFinal.TabIndex = 4;
            dateTimePickerFinal.TabStop = false;
            dateTimePickerFinal.UseWaitCursor = true;
            dateTimePickerFinal.ValueChanged += dateTimePickerFinal_ValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(845, 297);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 654);
            Controls.Add(button2);
            Controls.Add(dateTimePickerFinal);
            Controls.Add(dateTimePickerStart);
            Controls.Add(button1);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button button1;
        private DateTimePicker dateTimePickerStart;
        public DateTimePicker dateTimePickerFinal;
        private Button button2;
    }
}
