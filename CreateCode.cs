using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CaptchaTest
{
    public class CreateCode
    {
        //产生验证码图片
        public static Bitmap Create(string srs)
        {
            //定义图片弯曲的角度
            int srseedangle = 40;
            //定义图象
            Bitmap srBmp = new Bitmap(srs.Length * 20, 20);
            //画图
            Graphics srGraph = Graphics.FromImage(srBmp);
            //清空图象
            srGraph.Clear(Color.AliceBlue);
            //给图象画边框
            srGraph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, srBmp.Width - 1, srBmp.Height - 1);
            //定义随即数
            Random srRandom = new Random();
            //定义画笔
            Pen srPen = new Pen(Color.LightGray, 0);
            //画噪点
            for (int i = 0; i < 100; i++)
            {
                srGraph.DrawRectangle(srPen, srRandom.Next(1, srBmp.Width - 2), srRandom.Next(1, srBmp.Height - 2), 1, 1);
            }

            srPen = new Pen(Color.LightGreen, 0);
            //画噪点
            for (int i = 0; i < 100; i++)
            {
                srGraph.DrawRectangle(srPen, srRandom.Next(1, srBmp.Width - 2), srRandom.Next(1, srBmp.Height - 2), 1, 1);
            }

            //将字符串转化为字符数组
            char[] srchars = srs.ToCharArray();
            //封状文本
            StringFormat srFormat = new StringFormat(StringFormatFlags.NoClip);
            //设置文本垂直居中
            srFormat.Alignment = StringAlignment.Center;
            //设置文本水平居中
            srFormat.LineAlignment = StringAlignment.Center;
            //定义字体颜色
            Color[] srColors ={ Color.Black, Color.Red, Color.DarkBlue, Color.Blue, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //定义字体
            string[] srFonts ={ "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            //循环画出每个字符
            for (int i = 0, j = srchars.Length; i < j; i++)
            {
                //定义字体 参数分别为字体样式 字体大小 字体字形
                Font srFont = new Font("Verdana", 12, FontStyle.Regular);//new Font(srFonts[srRandom.Next(5)], 12, FontStyle.Regular);
                //填充图形
                Brush srBrush = Brushes.Black;//new SolidBrush(srColors[srRandom.Next(7)]);
                //定义坐标
                Point srPoint = new Point(16, 14);
                //定义倾斜角度
                float srangle = 0;// srRandom.Next(-srseedangle, srseedangle);
                //倾斜
                srGraph.TranslateTransform(srPoint.X, srPoint.Y - 1);
                //srGraph.RotateTransform(srangle);
                //填充字符
                srGraph.DrawString(srchars[i].ToString(), srFont, srBrush, 1, 1, srFormat);
                //回归正常
                //srGraph.RotateTransform(-srangle);
                srGraph.TranslateTransform(1, -srPoint.Y);
            }
            srGraph.Dispose();
            return srBmp;
        }

        //产生验证码
        public static string CreateRegionCode(int strlength)
        {
            string[] rBase = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Random rnd = new Random();
            string result = "";
            for (int i = 0; i < strlength; i++)
            {
                int r1 = rnd.Next(0, 10);
                string str_r1 = rBase[r1].Trim();
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks + i));//更换随机数发生器的种子避免产生重复值
                //定义两个字节变量存储产生的随机数字区位码
                result += str_r1;
            }
            return result;
        }
    }
}
