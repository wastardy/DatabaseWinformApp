namespace DB_Lab
{
    partial class exportExpert
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnXls = new System.Windows.Forms.RadioButton();
            this.rbtnDoc = new System.Windows.Forms.RadioButton();
            this.rbtnTsv = new System.Windows.Forms.RadioButton();
            this.rbtnTxt = new System.Windows.Forms.RadioButton();
            this.btnXML = new System.Windows.Forms.Button();
            this.btnComObj = new System.Windows.Forms.Button();
            this.btnOLEDB = new System.Windows.Forms.Button();
            this.btnStream = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnXls);
            this.panel1.Controls.Add(this.rbtnDoc);
            this.panel1.Controls.Add(this.rbtnTsv);
            this.panel1.Controls.Add(this.rbtnTxt);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(144, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 97);
            this.panel1.TabIndex = 16;
            // 
            // rbtnXls
            // 
            this.rbtnXls.AutoSize = true;
            this.rbtnXls.Location = new System.Drawing.Point(95, 55);
            this.rbtnXls.Name = "rbtnXls";
            this.rbtnXls.Size = new System.Drawing.Size(49, 25);
            this.rbtnXls.TabIndex = 3;
            this.rbtnXls.Text = "xls";
            this.rbtnXls.UseVisualStyleBackColor = true;
            // 
            // rbtnDoc
            // 
            this.rbtnDoc.AutoSize = true;
            this.rbtnDoc.Location = new System.Drawing.Point(95, 16);
            this.rbtnDoc.Name = "rbtnDoc";
            this.rbtnDoc.Size = new System.Drawing.Size(65, 25);
            this.rbtnDoc.TabIndex = 2;
            this.rbtnDoc.Text = "doc";
            this.rbtnDoc.UseVisualStyleBackColor = true;
            // 
            // rbtnTsv
            // 
            this.rbtnTsv.AutoSize = true;
            this.rbtnTsv.Location = new System.Drawing.Point(21, 55);
            this.rbtnTsv.Name = "rbtnTsv";
            this.rbtnTsv.Size = new System.Drawing.Size(56, 25);
            this.rbtnTsv.TabIndex = 1;
            this.rbtnTsv.Text = "tsv";
            this.rbtnTsv.UseVisualStyleBackColor = true;
            // 
            // rbtnTxt
            // 
            this.rbtnTxt.AutoSize = true;
            this.rbtnTxt.Checked = true;
            this.rbtnTxt.Location = new System.Drawing.Point(21, 16);
            this.rbtnTxt.Name = "rbtnTxt";
            this.rbtnTxt.Size = new System.Drawing.Size(53, 25);
            this.rbtnTxt.TabIndex = 0;
            this.rbtnTxt.TabStop = true;
            this.rbtnTxt.Text = "txt";
            this.rbtnTxt.UseVisualStyleBackColor = true;
            // 
            // btnXML
            // 
            this.btnXML.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.Location = new System.Drawing.Point(315, 76);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(110, 35);
            this.btnXML.TabIndex = 15;
            this.btnXML.Text = "XML";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // btnComObj
            // 
            this.btnComObj.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComObj.Location = new System.Drawing.Point(315, 34);
            this.btnComObj.Name = "btnComObj";
            this.btnComObj.Size = new System.Drawing.Size(110, 36);
            this.btnComObj.TabIndex = 14;
            this.btnComObj.Text = "Com Obj";
            this.btnComObj.UseVisualStyleBackColor = true;
            this.btnComObj.Click += new System.EventHandler(this.btnComObj_Click);
            // 
            // btnOLEDB
            // 
            this.btnOLEDB.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOLEDB.Location = new System.Drawing.Point(315, 117);
            this.btnOLEDB.Name = "btnOLEDB";
            this.btnOLEDB.Size = new System.Drawing.Size(110, 35);
            this.btnOLEDB.TabIndex = 13;
            this.btnOLEDB.Text = "OLE DB";
            this.btnOLEDB.UseVisualStyleBackColor = true;
            this.btnOLEDB.Click += new System.EventHandler(this.btnOLEDB_Click);
            // 
            // btnStream
            // 
            this.btnStream.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStream.Location = new System.Drawing.Point(27, 76);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(110, 35);
            this.btnStream.TabIndex = 12;
            this.btnStream.Text = "Stream";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // exportExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 185);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.btnComObj);
            this.Controls.Add(this.btnOLEDB);
            this.Controls.Add(this.btnStream);
            this.Name = "exportExpert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export to file";
            this.Load += new System.EventHandler(this.exportExpert_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnXls;
        private System.Windows.Forms.RadioButton rbtnDoc;
        private System.Windows.Forms.RadioButton rbtnTsv;
        private System.Windows.Forms.RadioButton rbtnTxt;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.Button btnComObj;
        private System.Windows.Forms.Button btnOLEDB;
        private System.Windows.Forms.Button btnStream;
    }
}