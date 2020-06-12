namespace WindowsFormsApplication15
{
    partial class Chat
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
            this.Connect = new System.Windows.Forms.Button();
            this.txName = new System.Windows.Forms.TextBox();
            this.txt_Text = new System.Windows.Forms.TextBox();
            this.rb_chat = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_stt = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(541, 12);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 16;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.button4_Click);
            // 
            // txName
            // 
            this.txName.Location = new System.Drawing.Point(178, 379);
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(285, 20);
            this.txName.TabIndex = 15;
            // 
            // txt_Text
            // 
            this.txt_Text.Location = new System.Drawing.Point(214, 15);
            this.txt_Text.Name = "txt_Text";
            this.txt_Text.Size = new System.Drawing.Size(285, 20);
            this.txt_Text.TabIndex = 14;
            // 
            // rb_chat
            // 
            this.rb_chat.Location = new System.Drawing.Point(178, 60);
            this.rb_chat.Name = "rb_chat";
            this.rb_chat.Size = new System.Drawing.Size(577, 292);
            this.rb_chat.TabIndex = 13;
            this.rb_chat.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(166, 417);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(0, 13);
            this.lb_stt.TabIndex = 17;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(-1, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(161, 424);
            this.checkedListBox1.TabIndex = 18;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(756, 419);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lb_stt);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.txName);
            this.Controls.Add(this.txt_Text);
            this.Controls.Add(this.rb_chat);
            this.Controls.Add(this.button1);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox txName;
        private System.Windows.Forms.TextBox txt_Text;
        private System.Windows.Forms.RichTextBox rb_chat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}