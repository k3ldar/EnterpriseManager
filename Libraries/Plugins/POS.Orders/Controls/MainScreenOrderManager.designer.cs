namespace POS.Orders.Controls
{
    partial class OrderDispatchControl
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbIgnoreChecks = new System.Windows.Forms.CheckBox();
            this.lblDateReceived = new System.Windows.Forms.Label();
            this.btnDispatch = new System.Windows.Forms.Button();
            this.btnCleanAddress = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOutstandingOrders = new System.Windows.Forms.Label();
            this.btnStaffNotes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbIgnoreChecks
            // 
            this.cbIgnoreChecks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIgnoreChecks.AutoSize = true;
            this.cbIgnoreChecks.Location = new System.Drawing.Point(324, 376);
            this.cbIgnoreChecks.Name = "cbIgnoreChecks";
            this.cbIgnoreChecks.Size = new System.Drawing.Size(95, 17);
            this.cbIgnoreChecks.TabIndex = 16;
            this.cbIgnoreChecks.Text = "Ignore Checks";
            this.cbIgnoreChecks.UseVisualStyleBackColor = true;
            // 
            // lblDateReceived
            // 
            this.lblDateReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateReceived.AutoSize = true;
            this.lblDateReceived.Location = new System.Drawing.Point(14, 377);
            this.lblDateReceived.Name = "lblDateReceived";
            this.lblDateReceived.Size = new System.Drawing.Size(0, 13);
            this.lblDateReceived.TabIndex = 15;
            // 
            // btnDispatch
            // 
            this.btnDispatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDispatch.Location = new System.Drawing.Point(435, 372);
            this.btnDispatch.Name = "btnDispatch";
            this.btnDispatch.Size = new System.Drawing.Size(75, 23);
            this.btnDispatch.TabIndex = 14;
            this.btnDispatch.Text = "Dispatch";
            this.btnDispatch.UseVisualStyleBackColor = true;
            this.btnDispatch.Click += new System.EventHandler(this.btnDispatch_Click);
            // 
            // btnCleanAddress
            // 
            this.btnCleanAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanAddress.Location = new System.Drawing.Point(407, 106);
            this.btnCleanAddress.Name = "btnCleanAddress";
            this.btnCleanAddress.Size = new System.Drawing.Size(103, 23);
            this.btnCleanAddress.TabIndex = 13;
            this.btnCleanAddress.Text = "Clean Address";
            this.btnCleanAddress.UseVisualStyleBackColor = true;
            this.btnCleanAddress.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.Location = new System.Drawing.Point(407, 77);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(103, 23);
            this.btnPrintInvoice.TabIndex = 12;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLabel.Location = new System.Drawing.Point(407, 48);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(103, 23);
            this.btnPrintLabel.TabIndex = 11;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(435, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlOrderItems
            // 
            this.pnlOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrderItems.AutoScroll = true;
            this.pnlOrderItems.Location = new System.Drawing.Point(16, 178);
            this.pnlOrderItems.Name = "pnlOrderItems";
            this.pnlOrderItems.Size = new System.Drawing.Size(494, 188);
            this.pnlOrderItems.TabIndex = 9;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(16, 65);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(0, 19);
            this.lblCustomer.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(16, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 19);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeperator.CausesValidation = false;
            this.pnlSeperator.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSeperator.Location = new System.Drawing.Point(16, 40);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(494, 2);
            this.pnlSeperator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // lblOutstandingOrders
            // 
            this.lblOutstandingOrders.AutoSize = true;
            this.lblOutstandingOrders.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingOrders.Location = new System.Drawing.Point(13, 13);
            this.lblOutstandingOrders.Name = "lblOutstandingOrders";
            this.lblOutstandingOrders.Size = new System.Drawing.Size(131, 19);
            this.lblOutstandingOrders.TabIndex = 0;
            this.lblOutstandingOrders.Text = "Outstanding Orders:";
            // 
            // btnStaffNotes
            // 
            this.btnStaffNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaffNotes.Location = new System.Drawing.Point(407, 136);
            this.btnStaffNotes.Name = "btnStaffNotes";
            this.btnStaffNotes.Size = new System.Drawing.Size(103, 23);
            this.btnStaffNotes.TabIndex = 17;
            this.btnStaffNotes.Text = "button1";
            this.btnStaffNotes.UseVisualStyleBackColor = true;
            this.btnStaffNotes.Click += new System.EventHandler(this.btnStaffNotes_Click);
            // 
            // OrderDispatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 407);
            this.Controls.Add(this.btnStaffNotes);
            this.Controls.Add(this.cbIgnoreChecks);
            this.Controls.Add(this.lblDateReceived);
            this.Controls.Add(this.btnDispatch);
            this.Controls.Add(this.btnCleanAddress);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.btnPrintLabel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pnlOrderItems);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOutstandingOrders);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainScreenOrderManager";
            this.Text = "Order Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblOutstandingOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.FlowLayoutPanel pnlOrderItems;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnCleanAddress;
        private System.Windows.Forms.Button btnDispatch;
        private System.Windows.Forms.Label lblDateReceived;
        private System.Windows.Forms.CheckBox cbIgnoreChecks;
        private System.Windows.Forms.Button btnStaffNotes;
    }
}