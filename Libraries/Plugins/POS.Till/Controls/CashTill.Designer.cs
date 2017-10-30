namespace POS.Till.Controls
{
    partial class CashTill
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.txtTendered = new System.Windows.Forms.TextBox();
            this.lblAmountTendered = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeDue = new System.Windows.Forms.Label();
            this.lblAmountDueTotal = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn40 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.Location = new System.Drawing.Point(9, 13);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmountDue.TabIndex = 0;
            this.lblAmountDue.Text = "Amount Due";
            // 
            // txtTendered
            // 
            this.txtTendered.Location = new System.Drawing.Point(121, 41);
            this.txtTendered.Name = "txtTendered";
            this.txtTendered.Size = new System.Drawing.Size(100, 20);
            this.txtTendered.TabIndex = 3;
            this.txtTendered.TextChanged += new System.EventHandler(this.txtTendered_TextChanged);
            this.txtTendered.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTendered_KeyDown);
            this.txtTendered.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTendered_KeyPress);
            // 
            // lblAmountTendered
            // 
            this.lblAmountTendered.AutoSize = true;
            this.lblAmountTendered.Location = new System.Drawing.Point(9, 44);
            this.lblAmountTendered.Name = "lblAmountTendered";
            this.lblAmountTendered.Size = new System.Drawing.Size(92, 13);
            this.lblAmountTendered.TabIndex = 2;
            this.lblAmountTendered.Text = "Amount Tendered";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Location = new System.Drawing.Point(9, 73);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(67, 13);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change Due";
            // 
            // lblChangeDue
            // 
            this.lblChangeDue.AutoSize = true;
            this.lblChangeDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDue.Location = new System.Drawing.Point(121, 72);
            this.lblChangeDue.Name = "lblChangeDue";
            this.lblChangeDue.Size = new System.Drawing.Size(39, 13);
            this.lblChangeDue.TabIndex = 5;
            this.lblChangeDue.Text = "£0.00";
            // 
            // lblAmountDueTotal
            // 
            this.lblAmountDueTotal.AutoSize = true;
            this.lblAmountDueTotal.Location = new System.Drawing.Point(121, 15);
            this.lblAmountDueTotal.Name = "lblAmountDueTotal";
            this.lblAmountDueTotal.Size = new System.Drawing.Size(35, 13);
            this.lblAmountDueTotal.TabIndex = 1;
            this.lblAmountDueTotal.Text = "label4";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(12, 108);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(37, 33);
            this.btn1.TabIndex = 6;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(55, 108);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(37, 33);
            this.btn2.TabIndex = 7;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(98, 108);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(37, 33);
            this.btn3.TabIndex = 8;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(141, 108);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(37, 33);
            this.btn4.TabIndex = 9;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(184, 108);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(37, 33);
            this.btn5.TabIndex = 10;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(12, 147);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(37, 33);
            this.btn6.TabIndex = 11;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(55, 147);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(37, 33);
            this.btn7.TabIndex = 12;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(98, 147);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(37, 33);
            this.btn8.TabIndex = 13;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(141, 147);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(37, 33);
            this.btn9.TabIndex = 14;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(184, 147);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(37, 33);
            this.btn0.TabIndex = 15;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(227, 147);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(37, 33);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = ".";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn100
            // 
            this.btn100.Location = new System.Drawing.Point(184, 186);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(48, 33);
            this.btn100.TabIndex = 21;
            this.btn100.Text = "£100";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn10
            // 
            this.btn10.Location = new System.Drawing.Point(12, 186);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(37, 33);
            this.btn10.TabIndex = 17;
            this.btn10.Text = "£10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn20
            // 
            this.btn20.Location = new System.Drawing.Point(55, 186);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(37, 33);
            this.btn20.TabIndex = 18;
            this.btn20.Text = "£20";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn40
            // 
            this.btn40.Location = new System.Drawing.Point(98, 186);
            this.btn40.Name = "btn40";
            this.btn40.Size = new System.Drawing.Size(37, 33);
            this.btn40.TabIndex = 19;
            this.btn40.Text = "£40";
            this.btn40.UseVisualStyleBackColor = true;
            this.btn40.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btn50
            // 
            this.btn50.Location = new System.Drawing.Point(141, 186);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(37, 33);
            this.btn50.TabIndex = 20;
            this.btn50.Text = "£50";
            this.btn50.UseVisualStyleBackColor = true;
            this.btn50.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // CashTill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn40);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lblAmountDueTotal);
            this.Controls.Add(this.lblChangeDue);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblAmountTendered);
            this.Controls.Add(this.txtTendered);
            this.Controls.Add(this.lblAmountDue);
            this.Name = "CashTill";
            this.Size = new System.Drawing.Size(277, 263);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.TextBox txtTendered;
        private System.Windows.Forms.Label lblAmountTendered;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblChangeDue;
        private System.Windows.Forms.Label lblAmountDueTotal;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn40;
        private System.Windows.Forms.Button btn50;
    }
}
