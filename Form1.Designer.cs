namespace Simplex
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxConstrains = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVariables = new System.Windows.Forms.ComboBox();
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.dataGridViewEquation = new System.Windows.Forms.DataGridView();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.dataGridViewSimplex = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewFunc = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity of constrains";
            // 
            // comboBoxConstrains
            // 
            this.comboBoxConstrains.AllowDrop = true;
            this.comboBoxConstrains.FormattingEnabled = true;
            this.comboBoxConstrains.Location = new System.Drawing.Point(180, 26);
            this.comboBoxConstrains.Name = "comboBoxConstrains";
            this.comboBoxConstrains.Size = new System.Drawing.Size(58, 28);
            this.comboBoxConstrains.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantity of variables";
            // 
            // comboBoxVariables
            // 
            this.comboBoxVariables.AllowDrop = true;
            this.comboBoxVariables.DisplayMember = "1,2,3,4,5,6,7";
            this.comboBoxVariables.FormattingEnabled = true;
            this.comboBoxVariables.Location = new System.Drawing.Point(416, 26);
            this.comboBoxVariables.Name = "comboBoxVariables";
            this.comboBoxVariables.Size = new System.Drawing.Size(58, 28);
            this.comboBoxVariables.TabIndex = 3;
            this.comboBoxVariables.ValueMember = "1,2,3,4,5,6,7";
            // 
            // buttonFill
            // 
            this.buttonFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFill.Location = new System.Drawing.Point(568, 18);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(107, 43);
            this.buttonFill.TabIndex = 4;
            this.buttonFill.Text = "Fill";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(709, 18);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(107, 43);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // dataGridViewEquation
            // 
            this.dataGridViewEquation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewEquation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquation.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewEquation.Location = new System.Drawing.Point(27, 74);
            this.dataGridViewEquation.Name = "dataGridViewEquation";
            this.dataGridViewEquation.RowHeadersWidth = 20;
            this.dataGridViewEquation.RowTemplate.Height = 29;
            this.dataGridViewEquation.Size = new System.Drawing.Size(447, 157);
            this.dataGridViewEquation.TabIndex = 6;
            // 
            // buttonCalc
            // 
            this.buttonCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalc.Location = new System.Drawing.Point(510, 188);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(306, 43);
            this.buttonCalc.TabIndex = 7;
            this.buttonCalc.Text = "Calculate";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // dataGridViewSimplex
            // 
            this.dataGridViewSimplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSimplex.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewSimplex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimplex.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSimplex.Location = new System.Drawing.Point(27, 305);
            this.dataGridViewSimplex.Name = "dataGridViewSimplex";
            this.dataGridViewSimplex.RowHeadersWidth = 51;
            this.dataGridViewSimplex.RowTemplate.Height = 29;
            this.dataGridViewSimplex.Size = new System.Drawing.Size(789, 288);
            this.dataGridViewSimplex.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Simplex table";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(641, 261);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(175, 27);
            this.textBoxResult.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Result = ";
            // 
            // dataGridViewFunc
            // 
            this.dataGridViewFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFunc.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunc.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewFunc.Location = new System.Drawing.Point(510, 101);
            this.dataGridViewFunc.Name = "dataGridViewFunc";
            this.dataGridViewFunc.RowHeadersWidth = 20;
            this.dataGridViewFunc.RowTemplate.Height = 29;
            this.dataGridViewFunc.Size = new System.Drawing.Size(306, 73);
            this.dataGridViewFunc.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Function";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 615);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewFunc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewSimplex);
            this.Controls.Add(this.buttonCalc);
            this.Controls.Add(this.dataGridViewEquation);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.comboBoxVariables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxConstrains);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Simplex Method";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBoxConstrains;
        private Label label2;
        private ComboBox comboBoxVariables;
        private Button buttonFill;
        private Button buttonClear;
        private DataGridView dataGridViewEquation;
        private Button buttonCalc;
        private Label label3;
        public DataGridView dataGridViewSimplex;
        private TextBox textBoxResult;
        private Label label4;
        private DataGridView dataGridViewFunc;
        private Label label5;
    }
}