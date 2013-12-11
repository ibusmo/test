using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testGit1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            arr = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    arr[i, j] = '_';

            int[,] pos = new int[3, 2];
            pos[0, 0] = 1; pos[0, 1] = 1;
            pos[1, 0] = 9; pos[1, 1] = 9;
            pos[2, 0] = 10; pos[2, 1] = 10;
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                 //str += pos[i, 0].ToString() + pos[i, 1].ToString() + " ";
                radCalArea(pos[i, 0], pos[i, 1]);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    str += arr[i, j].ToString() + "_";
                }
                str += "\r\n";
            }
                textBox1.Text = str;

        }
        private char[,] arr;
        private int size=30;
        private int borderX = 30;
        private int borderY = 30;
        private int rad=3;

        private bool isOnRadian(double x, double y, double xdat, double ydat) {
            if (xdat >= 0 && xdat < borderX && ydat >= 0 && ydat < borderY && (arr[(int)xdat, (int)ydat] == '_'))
            {
                if (!true)
                {
                    return true;
                }
                else if (Math.Round(Math.Sqrt(Math.Pow(xdat - x, 2) + Math.Pow(ydat - y, 2))) <= rad)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        Random X = new Random();
        private void radCalArea(int x, int y){
            char a = (char)(X.Next(50, 100));
            for (int i = 0; i <= rad; i++)
            {
                for (int j = 0; j <= rad; j++) 
                {
                    if (isOnRadian(x, y, x-i, y-j))
                    {
                        arr[x - i, y - j] = a;
                        //arr[x - i, y - j] = 'W';
                    }
                    if (isOnRadian(x, y, x+i, y-j))
                    {
                        arr[x + i, y - j] = a;
                        //arr[x + i, y - j] = 'X';
                    }
                    if (isOnRadian(x, y, x+i, y+j))
                    {
                        arr[x + i, x + j] = a;
                        //arr[x + i, x + j] = 'Y';
                    }
                    if (isOnRadian(x, y, x-i, y+j))
                    {
                        arr[x - i, y + j] = a;
                        //arr[x - i, y + j] = 'Z';
                    }
                }
            }
        }
    }
}
