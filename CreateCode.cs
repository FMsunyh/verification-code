using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CaptchaTest
{
    public class CreateCode
    {
        //������֤��ͼƬ
        public static Bitmap Create(string srs)
        {
            //����ͼƬ�����ĽǶ�
            int srseedangle = 40;
            //����ͼ��
            Bitmap srBmp = new Bitmap(srs.Length * 20, 20);
            //��ͼ
            Graphics srGraph = Graphics.FromImage(srBmp);
            //���ͼ��
            srGraph.Clear(Color.AliceBlue);
            //��ͼ�󻭱߿�
            srGraph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, srBmp.Width - 1, srBmp.Height - 1);
            //�����漴��
            Random srRandom = new Random();
            //���廭��
            Pen srPen = new Pen(Color.LightGray, 0);
            //�����
            for (int i = 0; i < 100; i++)
            {
                srGraph.DrawRectangle(srPen, srRandom.Next(1, srBmp.Width - 2), srRandom.Next(1, srBmp.Height - 2), 1, 1);
            }

            srPen = new Pen(Color.LightGreen, 0);
            //�����
            for (int i = 0; i < 100; i++)
            {
                srGraph.DrawRectangle(srPen, srRandom.Next(1, srBmp.Width - 2), srRandom.Next(1, srBmp.Height - 2), 1, 1);
            }

            //���ַ���ת��Ϊ�ַ�����
            char[] srchars = srs.ToCharArray();
            //��״�ı�
            StringFormat srFormat = new StringFormat(StringFormatFlags.NoClip);
            //�����ı���ֱ����
            srFormat.Alignment = StringAlignment.Center;
            //�����ı�ˮƽ����
            srFormat.LineAlignment = StringAlignment.Center;
            //����������ɫ
            Color[] srColors ={ Color.Black, Color.Red, Color.DarkBlue, Color.Blue, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //��������
            string[] srFonts ={ "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "����" };
            //ѭ������ÿ���ַ�
            for (int i = 0, j = srchars.Length; i < j; i++)
            {
                //�������� �����ֱ�Ϊ������ʽ �����С ��������
                Font srFont = new Font("Verdana", 12, FontStyle.Regular);//new Font(srFonts[srRandom.Next(5)], 12, FontStyle.Regular);
                //���ͼ��
                Brush srBrush = Brushes.Black;//new SolidBrush(srColors[srRandom.Next(7)]);
                //��������
                Point srPoint = new Point(16, 14);
                //������б�Ƕ�
                float srangle = 0;// srRandom.Next(-srseedangle, srseedangle);
                //��б
                srGraph.TranslateTransform(srPoint.X, srPoint.Y - 1);
                //srGraph.RotateTransform(srangle);
                //����ַ�
                srGraph.DrawString(srchars[i].ToString(), srFont, srBrush, 1, 1, srFormat);
                //�ع�����
                //srGraph.RotateTransform(-srangle);
                srGraph.TranslateTransform(1, -srPoint.Y);
            }
            srGraph.Dispose();
            return srBmp;
        }

        //������֤��
        public static string CreateRegionCode(int strlength)
        {
            string[] rBase = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Random rnd = new Random();
            string result = "";
            for (int i = 0; i < strlength; i++)
            {
                int r1 = rnd.Next(0, 10);
                string str_r1 = rBase[r1].Trim();
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks + i));//��������������������ӱ�������ظ�ֵ
                //���������ֽڱ����洢���������������λ��
                result += str_r1;
            }
            return result;
        }
    }
}
