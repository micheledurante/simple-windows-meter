namespace NiceMeter
{
    partial class MainWindow
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.Hardware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HardwareValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeColumns = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.CausesValidation = false;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.ColumnHeadersVisible = false;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hardware,
            this.HardwareValue});
            this.GridView.EnableHeadersVisualStyles = false;
            this.GridView.Location = new System.Drawing.Point(8, 8);
            this.GridView.Name = "gridView";
            this.GridView.RowHeadersVisible = false;
            this.GridView.Size = new System.Drawing.Size(316, 464);
            this.GridView.TabIndex = 1;
            this.GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Hardware
            // 
            this.Hardware.HeaderText = "Hardware";
            this.Hardware.Name = "Hardware";
            this.Hardware.ReadOnly = true;
            // 
            // HardwareValue
            // 
            this.HardwareValue.HeaderText = "HardwareValue";
            this.HardwareValue.Name = "HardwareValue";
            this.HardwareValue.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 481);
            this.ControlBox = false;
            this.Controls.Add(this.GridView);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NiceMeter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hardware;
        private System.Windows.Forms.DataGridViewTextBoxColumn HardwareValue;
    }
}

