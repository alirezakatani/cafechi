
namespace WindowsFormsApp1
{
    partial class Form15
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
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(807, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 42);
            this.label8.TabIndex = 22;
            this.label8.Text = "شماره تراکنش";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(696, 499);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(771, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 42);
            this.label1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(904, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 42);
            this.label2.TabIndex = 16;
            this.label2.Text = "زمان";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(502, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 24);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.Click += new System.EventHandler(this.s);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(502, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 22);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MRT_Ramollah", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(502, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 67);
            this.button1.TabIndex = 25;
            this.button1.Text = "مشاهده لیست قبلی";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MRT_Ramollah", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(761, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 67);
            this.button2.TabIndex = 26;
            this.button2.Text = "مشاهده لیست بعدی";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 393);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(999, 286);
            this.dataGridView1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(166, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 42);
            this.label3.TabIndex = 28;
            this.label3.Text = "بازخورد";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 236);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = "nice food";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(904, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 42);
            this.label4.TabIndex = 30;
            this.label4.Text = "امتیاز";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(502, 254);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(227, 22);
            this.textBox2.TabIndex = 32;
            this.textBox2.Text = "5";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MRT_Ramollah", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.Location = new System.Drawing.Point(25, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(234, 67);
            this.button3.TabIndex = 33;
            this.button3.Text = "ثبت بازخورد و امتیاز";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(502, 164);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(227, 24);
            this.comboBox2.TabIndex = 35;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MRT_Casablanca", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(855, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 42);
            this.label5.TabIndex = 34;
            this.label5.Text = "شماره غذا";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MRT_Ramollah", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button4.Location = new System.Drawing.Point(262, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(234, 67);
            this.button4.TabIndex = 36;
            this.button4.Text = "مشاهده کلیه بازخورد ها";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.shutterstock_300372164;
            this.ClientSize = new System.Drawing.Size(996, 672);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form15";
            this.Text = "Form15";
            this.Load += new System.EventHandler(this.Form15_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
    }
}