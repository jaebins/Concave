
namespace Omok
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.but_SinglePlay = new System.Windows.Forms.Button();
            this.but_MakeRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AddressInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(202, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "싱글 플레이";
            // 
            // but_SinglePlay
            // 
            this.but_SinglePlay.Location = new System.Drawing.Point(191, 72);
            this.but_SinglePlay.Name = "but_SinglePlay";
            this.but_SinglePlay.Size = new System.Drawing.Size(130, 39);
            this.but_SinglePlay.TabIndex = 1;
            this.but_SinglePlay.Text = "싱글 플레이";
            this.but_SinglePlay.UseVisualStyleBackColor = true;
            this.but_SinglePlay.Click += new System.EventHandler(this.but_SinglePlay_Click);
            // 
            // but_MakeRoom
            // 
            this.but_MakeRoom.Location = new System.Drawing.Point(191, 184);
            this.but_MakeRoom.Name = "but_MakeRoom";
            this.but_MakeRoom.Size = new System.Drawing.Size(130, 31);
            this.but_MakeRoom.TabIndex = 3;
            this.but_MakeRoom.Text = "방만들기";
            this.but_MakeRoom.UseVisualStyleBackColor = true;
            this.but_MakeRoom.Click += new System.EventHandler(this.but_MakeRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(202, 141);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(105, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "멀티 플레이";
            // 
            // AddressInput
            // 
            this.AddressInput.Font = new System.Drawing.Font("나눔고딕", 8F, System.Drawing.FontStyle.Bold);
            this.AddressInput.Location = new System.Drawing.Point(191, 274);
            this.AddressInput.Name = "AddressInput";
            this.AddressInput.Size = new System.Drawing.Size(130, 20);
            this.AddressInput.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(121, 276);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "주소 입력";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "입장하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 325);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddressInput);
            this.Controls.Add(this.but_MakeRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_SinglePlay);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_SinglePlay;
        private System.Windows.Forms.Button but_MakeRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddressInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}