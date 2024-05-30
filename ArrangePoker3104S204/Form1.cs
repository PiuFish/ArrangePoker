using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangePoker3104S204
{
    public partial class Form1 : Form
    {
        int[] pokers = new int[52];//隨機分配排組用的陣列
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < 52; i++) //將初始陣列裡的值都設為0
            {
                pokers[i] = 0;
            }
        }
        private void btnShowImage_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();//隨機亂數
            for (int pokernum = 1; pokernum <= 52; pokernum++)
            {
                for (; ; )
                {
                    int pokerPosition = rnd.Next(52);//亂數物件最大值為52-1
                    if (pokers[pokerPosition] == 0)
                    {
                        pokers[pokerPosition] = pokernum;
                        break;
                    }
                    else continue;
                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x <= 13; x++)
                {
                    PictureBox poker = new PictureBox();
                    poker.Click += poker_Click;
                    this.Controls.Add(poker); 
                    poker.Size = new Size(80, 120); 
                    poker.Location = new Point(x * 90, (y+1) * 130);
                    int num = x + y * 13;
                    poker.Image = Image.FromFile( "pokerback2.jpg");
                    poker.Tag = pokers[num - 1] + ".png" + "|" + "0";//在tag屬性中記錄檔名和正1反2
                    poker.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        }

        private void poker_Click(object sender, EventArgs e)
        {
            PictureBox poker =(PictureBox)sender;//sender是被點擊的poker
            string tagdata = (string)poker.Tag;//轉字串
            string[] pokerdata = tagdata.Split('|');//Split為切割字串，()內是判斷切割的字元
            string imagefiledata = pokerdata[0];//圖片檔名
            string side = pokerdata[1];//正反面
            if (side == "0")
            {
                side = "1";
                poker.Image = Image.FromFile(imagefiledata);
            }
            else{
                side = "0";
                poker.Image = Image.FromFile("pokerback2.jpg");
            }
            poker.Tag = imagefiledata + "|" + side; //將更新過的資料再記錄進tag裡
        }


    }
}
