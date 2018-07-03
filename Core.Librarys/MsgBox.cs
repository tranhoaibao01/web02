using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Librarys
{
    public static class MsgBox
    {
        private static Form frmMsgBox01;
        private static Form frmMsgBox03;
        private static Form frmMsgBox05;
        private static Form frmMsgBox07;
        //private static Form frmMsgBox09;
        //private static Form frmMsgBox11;

        /// <summary>
        /// 01.
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            
            System.Windows.Forms.TableLayoutPanel tlpPanelMain;
            System.Windows.Forms.Label lbMessage;
            System.Windows.Forms.Panel pnButton;
            System.Windows.Forms.Button btnOK01;
            //
            // frmMsgBox01
            // Khởi tạo & định dạng Form
            //
            frmMsgBox01 = new Form();
            frmMsgBox01.Name = "frmMsgBox01";
            frmMsgBox01.Text = "";
            frmMsgBox01.StartPosition = FormStartPosition.CenterParent;
            frmMsgBox01.Size = new System.Drawing.Size(500, 300); // Kích thước form
            frmMsgBox01.MinimizeBox = false;
            frmMsgBox01.MaximizeBox = false;
            frmMsgBox01.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // lbMessage: lbMessage chứa chuỗi thông báo
            // 
            lbMessage = new System.Windows.Forms.Label();
            lbMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lbMessage.Location = new System.Drawing.Point(3, 50);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new System.Drawing.Size(478, 172);
            lbMessage.TabIndex = 2;
            lbMessage.Text = text;
            //
            // btnOK: Khai báo button OK
            //
            btnOK01 = new System.Windows.Forms.Button();
            btnOK01.Location = new System.Drawing.Point(478 - 75 - 25, 6);
            btnOK01.Name = "btnOK01";
            btnOK01.Size = new System.Drawing.Size(75, 23);
            btnOK01.TabIndex = 0;
            btnOK01.Text = "&Nhận";
            btnOK01.UseVisualStyleBackColor = true;
            btnOK01.Click += new System.EventHandler(btnOK01_Click);
            // 
            // pnButton: Panel chứa các button
            // 
            pnButton = new Panel();
            pnButton.Controls.Add(btnOK01);
            pnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            pnButton.Location = new System.Drawing.Point(3, 225);
            pnButton.Name = "pnButton";
            pnButton.Size = new System.Drawing.Size(478, 34);
            pnButton.TabIndex = 3;
            pnButton.ResumeLayout(false);
            //
            // tlp: TableLayoutPanel chia làm 1 cột, 2 dòng
            //
            tlpPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tlpPanelMain.ColumnCount = 1;
            tlpPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.Controls.Add(lbMessage, 0, 1);
            tlpPanelMain.Controls.Add(pnButton, 0, 2);
            tlpPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpPanelMain.Location = new System.Drawing.Point(0, 0);
            tlpPanelMain.Name = "tlpPanelMain";
            tlpPanelMain.RowCount = 3;
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tlpPanelMain.Size = new System.Drawing.Size(484, 262);
            tlpPanelMain.TabIndex = 4;
            //
            // Xử lý add các controls lên form
            //
            frmMsgBox01.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmMsgBox01.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmMsgBox01.ClientSize = new System.Drawing.Size(484, 262);
            frmMsgBox01.Controls.Add(tlpPanelMain);
            frmMsgBox01.ResumeLayout(false);

            return frmMsgBox01.ShowDialog();
        }

        /// <summary>
        /// 03.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption)
        {
            System.Windows.Forms.TableLayoutPanel tlpPanelMain;
            System.Windows.Forms.Label lbMessage;
            System.Windows.Forms.Panel pnButton;
            System.Windows.Forms.Button btnOK03;
            //
            // frmMsgBox01
            // Khởi tạo & định dạng Form
            //
            frmMsgBox03 = new Form();
            frmMsgBox03.Name = "frmMsgBox03";
            frmMsgBox03.Text = caption;
            frmMsgBox03.StartPosition = FormStartPosition.CenterParent;
            frmMsgBox03.Size = new System.Drawing.Size(500, 300); // Kích thước form
            frmMsgBox03.MinimizeBox = false;
            frmMsgBox03.MaximizeBox = false;
            frmMsgBox03.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // lbMessage: lbMessage chứa chuỗi thông báo
            // 
            lbMessage = new System.Windows.Forms.Label();
            lbMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lbMessage.Location = new System.Drawing.Point(3, 50);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new System.Drawing.Size(478, 172);
            lbMessage.TabIndex = 2;
            lbMessage.Text = text;
            //
            // btnOK: Khai báo button OK
            //
            btnOK03 = new System.Windows.Forms.Button();
            btnOK03.Location = new System.Drawing.Point(478 - 75 - 25, 6);
            btnOK03.Name = "btnOK03";
            btnOK03.Size = new System.Drawing.Size(75, 23);
            btnOK03.TabIndex = 0;
            btnOK03.Text = "&Nhận";
            btnOK03.UseVisualStyleBackColor = true;
            btnOK03.Click += new System.EventHandler(btnOK03_Click);
            // 
            // pnButton: Panel chứa các button
            // 
            pnButton = new Panel();
            pnButton.Controls.Add(btnOK03);
            pnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            pnButton.Location = new System.Drawing.Point(3, 225);
            pnButton.Name = "pnButton";
            pnButton.Size = new System.Drawing.Size(478, 34);
            pnButton.TabIndex = 3;
            pnButton.ResumeLayout(false);
            //
            // tlp: TableLayoutPanel chia làm 1 cột, 2 dòng
            //
            tlpPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tlpPanelMain.ColumnCount = 1;
            tlpPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.Controls.Add(lbMessage, 0, 1);
            tlpPanelMain.Controls.Add(pnButton, 0, 2);
            tlpPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpPanelMain.Location = new System.Drawing.Point(0, 0);
            tlpPanelMain.Name = "tlpPanelMain";
            tlpPanelMain.RowCount = 3;
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tlpPanelMain.Size = new System.Drawing.Size(484, 262);
            tlpPanelMain.TabIndex = 4;
            //
            // Xử lý add các controls lên form
            //
            frmMsgBox03.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmMsgBox03.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmMsgBox03.ClientSize = new System.Drawing.Size(484, 262);
            frmMsgBox03.Controls.Add(tlpPanelMain);
            frmMsgBox03.ResumeLayout(false);

            return frmMsgBox03.ShowDialog();
        }

        /// <summary>
        /// 05.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            System.Windows.Forms.TableLayoutPanel tlpPanelMain;
            System.Windows.Forms.Label lbMessage;
            System.Windows.Forms.Panel pnButton;
            System.Windows.Forms.Button btnAbort05;
            System.Windows.Forms.Button btnRetry05;
            System.Windows.Forms.Button btnIgnore05;
            System.Windows.Forms.Button btnOK05;
            System.Windows.Forms.Button btnCancel05;
            System.Windows.Forms.Button btnYes05;
            System.Windows.Forms.Button btnNo05;
            //
            // frmMsgBox01
            // Khởi tạo & định dạng Form
            //
            frmMsgBox05 = new Form();
            frmMsgBox05.Name = "frmMsgBox05";
            frmMsgBox05.Text = caption;
            frmMsgBox05.StartPosition = FormStartPosition.CenterParent;
            frmMsgBox05.Size = new System.Drawing.Size(500, 300); // Kích thước form
            frmMsgBox05.MinimizeBox = false;
            frmMsgBox05.MaximizeBox = false;
            frmMsgBox05.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // lbMessage: lbMessage chứa chuỗi thông báo
            // 
            lbMessage = new System.Windows.Forms.Label();
            lbMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lbMessage.Location = new System.Drawing.Point(3, 50);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new System.Drawing.Size(478, 172);
            lbMessage.TabIndex = 2;
            lbMessage.Text = text;

            #region Thêm vào các button
            // Abort: Hủy bỏ, kết thúc công việc
            btnAbort05 = new System.Windows.Forms.Button();
            //btnAbort05.Location = new System.Drawing.Point(478 - 75 - 50, 8);
            btnAbort05.Name = "btnAbort05";
            btnAbort05.Size = new System.Drawing.Size(75, 23);
            btnAbort05.TabIndex = 0;
            btnAbort05.Text = "&Hủy bỏ";
            btnAbort05.UseVisualStyleBackColor = true;
            btnAbort05.Click += new System.EventHandler(btnAbort05_Click);

            // Retry: Thử lại
            btnRetry05 = new System.Windows.Forms.Button();
            //btnRetry05.Location = new System.Drawing.Point(478 - 75 - 50 - 75 -10, 8);
            btnRetry05.Name = "btnRetry05";
            btnRetry05.Size = new System.Drawing.Size(75, 23);
            btnRetry05.TabIndex = 0;
            btnRetry05.Text = "&Thử lại";
            btnRetry05.UseVisualStyleBackColor = true;
            btnRetry05.Click += new System.EventHandler(btnRetry05_Click);

            // Ignore: Bỏ qua, vẫn chạy tiếp chương trình
            btnIgnore05 = new System.Windows.Forms.Button();
            //btnIgnore05.Location = new System.Drawing.Point(478 - 75 - 50 - 75 - 10 - 75 -10, 6);
            btnIgnore05.Name = "btnIgnore05";
            btnIgnore05.Size = new System.Drawing.Size(75, 23);
            btnIgnore05.TabIndex = 0;
            btnIgnore05.Text = "&Bỏ qua";
            btnIgnore05.UseVisualStyleBackColor = true;
            btnIgnore05.Click += new System.EventHandler(btnIgnore05_Click);

            // btnOK05: Nhận
            btnOK05 = new System.Windows.Forms.Button();
            //btnOK05.Location = new System.Drawing.Point(478 - 75 - 50, 6);
            btnOK05.Name = "btnOK05";
            btnOK05.Size = new System.Drawing.Size(75, 23);
            btnOK05.TabIndex = 0;
            btnOK05.Text = "&Nhận";
            btnOK05.UseVisualStyleBackColor = true;
            btnOK05.Click += new System.EventHandler(btnOK05_Click);

            // btnCancel05: Hủy
            btnCancel05 = new System.Windows.Forms.Button();
            //btnCancel05.Location = new System.Drawing.Point(478 - 75 - 50 - 75 - 10, 6);
            btnCancel05.Name = "btnCancel05";
            btnCancel05.Size = new System.Drawing.Size(75, 23);
            btnCancel05.TabIndex = 0;
            btnCancel05.Text = "&Hủy";
            btnCancel05.UseVisualStyleBackColor = true;
            btnCancel05.Click += new System.EventHandler(btnCancel05_Click);

            // btnYes05: Có
            btnYes05 = new System.Windows.Forms.Button();
            //btnYes05.Location = new System.Drawing.Point(478 - 75 - 50, 6);
            btnYes05.Name = "btnYes05";
            btnYes05.Size = new System.Drawing.Size(75, 23);
            btnYes05.TabIndex = 0;
            btnYes05.Text = "&Có";
            btnYes05.UseVisualStyleBackColor = true;
            btnYes05.Click += new System.EventHandler(btnYes05_Click);

            // btnNo05: Không
            btnNo05 = new System.Windows.Forms.Button();
            //btnNo05.Location = new System.Drawing.Point(478 - 75 - 50 - 75 - 10, 6);
            btnNo05.Name = "btnNo05";
            btnNo05.Size = new System.Drawing.Size(75, 23);
            btnNo05.TabIndex = 0;
            btnNo05.Text = "&Không";
            btnNo05.UseVisualStyleBackColor = true;
            btnNo05.Click += new System.EventHandler(btnNo05_Click);

            #endregion
            
            // 
            // pnButton: Panel chứa các button
            // 
            pnButton = new Panel();

            #region Thêm & định vị các button lên pnButton
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    btnAbort05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10 - 75 - 10, 6);
                    btnRetry05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnIgnore05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnAbort05);
                    pnButton.Controls.Add(btnRetry05);
                    pnButton.Controls.Add(btnIgnore05);

                    break;

                case MessageBoxButtons.OK:

                    btnOK05.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnOK05);

                    break;

                case MessageBoxButtons.OKCancel:

                    btnOK05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnOK05);
                    pnButton.Controls.Add(btnCancel05);

                    break;

                case MessageBoxButtons.RetryCancel:

                    btnRetry05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnRetry05);
                    pnButton.Controls.Add(btnCancel05);

                    break;

                case MessageBoxButtons.YesNo:

                    btnYes05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnNo05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnYes05);
                    pnButton.Controls.Add(btnNo05);

                    break;

                case MessageBoxButtons.YesNoCancel:

                    btnYes05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10 - 75 - 10, 6);
                    btnNo05.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnYes05);
                    pnButton.Controls.Add(btnNo05);
                    pnButton.Controls.Add(btnCancel05);

                    break;

                default: //OK

                    btnOK05.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnOK05);

                    break;
            }
            #endregion

            pnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            pnButton.Location = new System.Drawing.Point(3, 225);
            pnButton.Name = "pnButton";
            pnButton.Size = new System.Drawing.Size(478, 34);
            pnButton.TabIndex = 3;
            pnButton.ResumeLayout(false);
            //
            // tlp: TableLayoutPanel chia làm 1 cột, 2 dòng
            //
            tlpPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tlpPanelMain.ColumnCount = 1;
            tlpPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.Controls.Add(lbMessage, 0, 1);
            tlpPanelMain.Controls.Add(pnButton, 0, 2);
            tlpPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpPanelMain.Location = new System.Drawing.Point(0, 0);
            tlpPanelMain.Name = "tlpPanelMain";
            tlpPanelMain.RowCount = 3;
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tlpPanelMain.Size = new System.Drawing.Size(484, 262);
            tlpPanelMain.TabIndex = 4;
            //
            // Xử lý add các controls lên form
            //
            frmMsgBox05.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmMsgBox05.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmMsgBox05.ClientSize = new System.Drawing.Size(484, 262);
            frmMsgBox05.Controls.Add(tlpPanelMain);

            frmMsgBox05.ResumeLayout(false);

            return frmMsgBox05.ShowDialog();
        }

        /// <summary>
        /// 07. Còn đang chỉnh sửa
        /// chưa viết sự kiện cho các button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            System.Windows.Forms.Panel pnButton;
            System.Windows.Forms.TableLayoutPanel tlpPanelMain;
            System.Windows.Forms.PictureBox ptbBaner;
            System.Windows.Forms.TableLayoutPanel tlpPanelContent;
            System.Windows.Forms.PictureBox ptbIcon;
            System.Windows.Forms.Label lbMessage;
            //
            // Button
            //
            System.Windows.Forms.Button btnAbort07;
            System.Windows.Forms.Button btnRetry07;
            System.Windows.Forms.Button btnIgnore07;
            System.Windows.Forms.Button btnOK07;
            System.Windows.Forms.Button btnCancel07;
            System.Windows.Forms.Button btnYes07;
            System.Windows.Forms.Button btnNo07;
            //
            // frmMsgBox01
            // Khởi tạo & định dạng Form
            //
            frmMsgBox07 = new Form();
            frmMsgBox07.Name = "frmMsgBox07";
            frmMsgBox07.Text = caption;
            frmMsgBox07.StartPosition = FormStartPosition.CenterParent;
            frmMsgBox07.Size = new System.Drawing.Size(500, 300); // Kích thước form
            frmMsgBox07.MinimizeBox = false;
            frmMsgBox07.MaximizeBox = false;
            frmMsgBox07.FormBorderStyle = FormBorderStyle.FixedDialog;

            pnButton = new System.Windows.Forms.Panel();
            btnAbort07 = new System.Windows.Forms.Button();
            btnRetry07 = new System.Windows.Forms.Button();
            btnIgnore07 = new System.Windows.Forms.Button();
            btnOK07 = new System.Windows.Forms.Button();
            btnCancel07 = new System.Windows.Forms.Button();
            btnYes07 = new System.Windows.Forms.Button();
            btnNo07 = new System.Windows.Forms.Button();

            tlpPanelMain = new System.Windows.Forms.TableLayoutPanel();
            ptbBaner = new System.Windows.Forms.PictureBox();

            tlpPanelContent = new System.Windows.Forms.TableLayoutPanel();
            ptbIcon = new System.Windows.Forms.PictureBox();
            lbMessage = new System.Windows.Forms.Label();
            pnButton.SuspendLayout();
            tlpPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(ptbBaner)).BeginInit();
            tlpPanelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(ptbIcon)).BeginInit();

            // 
            // pnButton
            // 
            #region Thêm & định vị các button lên pnButton
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    btnAbort07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10 - 75 - 10, 6);
                    btnRetry07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnIgnore07.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnAbort07);
                    pnButton.Controls.Add(btnRetry07);
                    pnButton.Controls.Add(btnIgnore07);
                    break;
                case MessageBoxButtons.OK:
                    btnOK07.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnOK07);
                    break;
                case MessageBoxButtons.OKCancel:
                    btnOK07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel07.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnOK07);
                    pnButton.Controls.Add(btnCancel07);
                    break;
                case MessageBoxButtons.RetryCancel:
                    btnRetry07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel07.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnRetry07);
                    pnButton.Controls.Add(btnCancel07);
                    break;
                case MessageBoxButtons.YesNo:
                    btnYes07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnNo07.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnYes07);
                    pnButton.Controls.Add(btnNo07);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnYes07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10 - 75 - 10, 6);
                    btnNo07.Location = new System.Drawing.Point(478 - 75 - 25 - 75 - 10, 6);
                    btnCancel07.Location = new System.Drawing.Point(478 - 75 - 25, 6);

                    pnButton.Controls.Add(btnYes07);
                    pnButton.Controls.Add(btnNo07);
                    pnButton.Controls.Add(btnCancel07);
                    break;
                default: //OK
                    btnOK07.Location = new System.Drawing.Point(478 - 75 - 25, 6);
                    pnButton.Controls.Add(btnOK07);
                    break;
            }
            #endregion

            pnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            pnButton.Location = new System.Drawing.Point(3, 225);
            pnButton.Name = "pnButton";
            pnButton.Size = new System.Drawing.Size(478, 34);
            pnButton.TabIndex = 1;
            // 
            // tlpPanelMain
            // 
            tlpPanelMain.ColumnCount = 1;
            tlpPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.Controls.Add(pnButton, 0, 2);
            tlpPanelMain.Controls.Add(tlpPanelContent, 0, 1);
            tlpPanelMain.Controls.Add(ptbBaner, 0, 0);
            tlpPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpPanelMain.Location = new System.Drawing.Point(0, 0);
            tlpPanelMain.Name = "tlpPanelMain";
            tlpPanelMain.RowCount = 3;
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tlpPanelMain.Size = new System.Drawing.Size(484, 262);
            tlpPanelMain.TabIndex = 0;
            // 
            // ptbBaner
            // 
            ptbBaner.Dock = System.Windows.Forms.DockStyle.Fill;
            ptbBaner.Image = global::Core.Librarys.Properties.Resources.Baner_MsgBox_01;
            ptbBaner.Location = new System.Drawing.Point(3, 3);
            ptbBaner.Name = "ptbBaner";
            ptbBaner.Size = new System.Drawing.Size(478, 44);
            ptbBaner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ptbBaner.TabIndex = 3;
            ptbBaner.TabStop = false;

            #region Thêm vào các button
            // Abort: Hủy bỏ, kết thúc công việc
            btnAbort07 = new System.Windows.Forms.Button();
            btnAbort07.Name = "btnAbort07";
            btnAbort07.Size = new System.Drawing.Size(75, 23);
            btnAbort07.TabIndex = 0;
            btnAbort07.Text = "&Hủy bỏ";
            btnAbort07.UseVisualStyleBackColor = true;
            btnAbort07.Click += new System.EventHandler(btnAbort05_Click);

            // Retry: Thử lại
            btnRetry07 = new System.Windows.Forms.Button();
            btnRetry07.Name = "btnRetry07";
            btnRetry07.Size = new System.Drawing.Size(75, 23);
            btnRetry07.TabIndex = 0;
            btnRetry07.Text = "&Thử lại";
            btnRetry07.UseVisualStyleBackColor = true;
            btnRetry07.Click += new System.EventHandler(btnRetry05_Click);

            // Ignore: Bỏ qua, vẫn chạy tiếp chương trình
            btnIgnore07 = new System.Windows.Forms.Button();
            btnIgnore07.Name = "btnIgnore07";
            btnIgnore07.Size = new System.Drawing.Size(75, 23);
            btnIgnore07.TabIndex = 0;
            btnIgnore07.Text = "&Bỏ qua";
            btnIgnore07.UseVisualStyleBackColor = true;
            btnIgnore07.Click += new System.EventHandler(btnIgnore05_Click);

            // btnOK07: Nhận
            btnOK07 = new System.Windows.Forms.Button();
            btnOK07.Name = "btnOK07";
            btnOK07.Size = new System.Drawing.Size(75, 23);
            btnOK07.TabIndex = 0;
            btnOK07.Text = "&Nhận";
            btnOK07.UseVisualStyleBackColor = true;
            btnOK07.Click += new System.EventHandler(btnOK05_Click);

            // btnCancel07: Hủy
            btnCancel07 = new System.Windows.Forms.Button();
            btnCancel07.Name = "btnCancel07";
            btnCancel07.Size = new System.Drawing.Size(75, 23);
            btnCancel07.TabIndex = 0;
            btnCancel07.Text = "&Hủy";
            btnCancel07.UseVisualStyleBackColor = true;
            btnCancel07.Click += new System.EventHandler(btnCancel05_Click);

            // btnYes07: Có
            btnYes07 = new System.Windows.Forms.Button();
            btnYes07.Name = "btnYes07";
            btnYes07.Size = new System.Drawing.Size(75, 23);
            btnYes07.TabIndex = 0;
            btnYes07.Text = "&Có";
            btnYes07.UseVisualStyleBackColor = true;
            btnYes07.Click += new System.EventHandler(btnYes05_Click);

            // btnNo07: Không
            btnNo07 = new System.Windows.Forms.Button();
            btnNo07.Name = "btnNo07";
            btnNo07.Size = new System.Drawing.Size(75, 23);
            btnNo07.TabIndex = 0;
            btnNo07.Text = "&Không";
            btnNo07.UseVisualStyleBackColor = true;
            btnNo07.Click += new System.EventHandler(btnNo05_Click);

            #endregion
            // 
            // tlpPanelContent
            // 
            tlpPanelContent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            tlpPanelContent.ColumnCount = 2;
            tlpPanelContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tlpPanelContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelContent.Controls.Add(ptbIcon, 0, 1);
            tlpPanelContent.Controls.Add(lbMessage, 1, 1);
            tlpPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpPanelContent.Location = new System.Drawing.Point(3, 53);
            tlpPanelContent.Name = "tlpPanelContent";
            tlpPanelContent.RowCount = 2;
            tlpPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            tlpPanelContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpPanelContent.Size = new System.Drawing.Size(478, 166);
            tlpPanelContent.TabIndex = 2;
            // 
            // ptbIcon
            // 
            ptbIcon.Dock = System.Windows.Forms.DockStyle.Top;

            switch (icon)
            {
                case MessageBoxIcon.Asterisk: // MessageBoxIcon.Information 
                    ptbIcon.Image = global::Core.Librarys.Properties.Resources.Button_Info_Icon_64_01;
                    break;
                case MessageBoxIcon.Error: // MessageBoxIcon.Hand, MessageBoxIcon.Stop
                    ptbIcon.Image = global::Core.Librarys.Properties.Resources.Button_Error_Icon_64_01;
                    break;
                case MessageBoxIcon.Exclamation: // MessageBoxIcon.Warning
                    ptbIcon.Image = global::Core.Librarys.Properties.Resources.Exclamatio_Icon_64_01;
                    break;
                case MessageBoxIcon.None:
                    //ptbIcon.Image = global::Core.Librarys.Properties.Resources.info64;
                    break;
                case MessageBoxIcon.Question:
                    ptbIcon.Image = global::Core.Librarys.Properties.Resources.Button_Help_icon_64_01;
                    break;
                default:
                    break;
            }

            ptbIcon.Location = new System.Drawing.Point(3, 13);
            ptbIcon.Name = "ptbIcon";
            ptbIcon.Size = new System.Drawing.Size(44, 44);
            ptbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ptbIcon.TabIndex = 0;
            ptbIcon.TabStop = false;
            // 
            // lbMessage
            // 
            lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lbMessage.Location = new System.Drawing.Point(53, 10);
            lbMessage.Name = "lbMessage";
            lbMessage.Size = new System.Drawing.Size(422, 156);
            lbMessage.TabIndex = 1;
            lbMessage.Text = text;
            // 
            // TestForm1
            // 
            frmMsgBox07.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmMsgBox07.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmMsgBox07.ClientSize = new System.Drawing.Size(484, 262);
            frmMsgBox07.Controls.Add(tlpPanelMain);
            frmMsgBox07.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            frmMsgBox07.MaximizeBox = false;
            frmMsgBox07.MinimizeBox = false;
            frmMsgBox07.Name = "TestForm1";
            frmMsgBox07.Text = "Thông báo";
            ((System.ComponentModel.ISupportInitialize)(ptbBaner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ptbIcon)).EndInit();
            frmMsgBox07.ResumeLayout(false);

            return frmMsgBox07.ShowDialog();
        }

        /// <summary>
        /// 9.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultButton"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons button, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {

            return 0;
        }

        /// <summary>
        /// 11.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultButton"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons button, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {

            return 0;
        }

        #region Định nghĩa các sự kiện button

        private static void btnOK01_Click(object sender, EventArgs e)
        {
            frmMsgBox01.DialogResult = DialogResult.OK;
            frmMsgBox01.Dispose();
        }

        private static void btnOK03_Click(object sender, EventArgs e)
        {
            frmMsgBox03.DialogResult = DialogResult.OK;
            frmMsgBox03.Dispose();
        }

        /// <summary>
        /// btnAbort05
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnAbort05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.Abort;
            frmMsgBox05.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnRetry05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.Retry;
            frmMsgBox05.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnIgnore05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.Ignore;
            frmMsgBox05.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnOK05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.OK;
            frmMsgBox05.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnCancel05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.Cancel;
            frmMsgBox05.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnYes05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.Yes;
            frmMsgBox05.Dispose();
        }

        private static void btnNo05_Click(object sender, EventArgs e)
        {
            frmMsgBox05.DialogResult = DialogResult.No;
            frmMsgBox05.Dispose();
        }

        #endregion 
    }
}
