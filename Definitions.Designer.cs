
namespace Signs
{
    partial class Definitions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.term = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.RichTextBox();
            this.showAnswer = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.onlyImportant = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Термин";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Определение";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // term
            // 
            this.term.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.term.Location = new System.Drawing.Point(19, 28);
            this.term.Name = "term";
            this.term.ReadOnly = true;
            this.term.Size = new System.Drawing.Size(660, 44);
            this.term.TabIndex = 2;
            this.term.TextChanged += new System.EventHandler(this.term_TextChanged);
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.description.Location = new System.Drawing.Point(19, 91);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(660, 330);
            this.description.TabIndex = 3;
            this.description.Text = "";
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // showAnswer
            // 
            this.showAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showAnswer.Location = new System.Drawing.Point(19, 427);
            this.showAnswer.Name = "showAnswer";
            this.showAnswer.Size = new System.Drawing.Size(253, 61);
            this.showAnswer.TabIndex = 4;
            this.showAnswer.Text = "Показать ответ";
            this.showAnswer.UseVisualStyleBackColor = true;
            this.showAnswer.Click += new System.EventHandler(this.showAnswer_Click);
            // 
            // next
            // 
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.next.Location = new System.Drawing.Point(560, 427);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(119, 61);
            this.next.TabIndex = 5;
            this.next.Text = "Далее";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // onlyImportant
            // 
            this.onlyImportant.AutoSize = true;
            this.onlyImportant.Checked = true;
            this.onlyImportant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlyImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onlyImportant.Location = new System.Drawing.Point(290, 438);
            this.onlyImportant.Name = "onlyImportant";
            this.onlyImportant.Size = new System.Drawing.Size(255, 41);
            this.onlyImportant.TabIndex = 6;
            this.onlyImportant.Text = "Только важные";
            this.onlyImportant.UseVisualStyleBackColor = true;
            this.onlyImportant.CheckedChanged += new System.EventHandler(this.onlyImportant_CheckedChanged);
            // 
            // Definitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.onlyImportant);
            this.Controls.Add(this.next);
            this.Controls.Add(this.showAnswer);
            this.Controls.Add(this.description);
            this.Controls.Add(this.term);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Definitions";
            this.Text = "Определения";
            this.Load += new System.EventHandler(this.Definitions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Definitions_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox term;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Button showAnswer;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.CheckBox onlyImportant;
    }
}