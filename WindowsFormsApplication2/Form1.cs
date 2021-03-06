﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;//Обьявление таймера
        int m, s; // Минуты , секуны

        bool indicator = true;
        int x, y;
        int counter = 0;
        int[,] field = new int[32, 32];
        public Button but = new Button();
        public Form1()
        {
            int i,j;
            InitializeComponent();            
            for (i = 1; i < 31; i++)                            //генерация кнопок
            {
                for (j = 1; j < 31; j++)
                {
                    but = new Button();
                    but.Size = new Size(25, 25);                //размер кнопки
                    but.Location = new Point(i*25, j*25);       //ее позиция
                    but.Click += new EventHandler(but_Click);   //действие при клике
                    but.Text = " ";
                    this.Controls.Add(but);
                }
            }
        }

        public void but_Click(object sender, EventArgs e)       //действие при нажатии 
        {
            but = (Button)sender;
            x = (but.Location.X / 25);
            y = (but.Location.Y / 25);
            string location = x + ":" + y;
            //MessageBox.Show(location);
            if (indicator)
            {
                but.Text = "X";
                field[x, y] = 1;
                indicator = false;
            }
            else
            {
                but.Text = "O";
                field[x, y] = 2;
                indicator = true;
            }
            but.Enabled = false;
            counter++;
            Check();
        }

        private void Check()
        {
                if (field[x + 1, y] == field[x, y] && field[x + 2, y] == field[x, y] && field[x - 1, y] == field[x, y] && field[x - 2, y] == field[x, y]                 || /* горизонталь, если последний элемент по середине*/
                    field[x, y + 1] == field[x, y] && field[x, y + 2] == field[x, y] && field[x, y - 1] == field[x, y] && field[x, y - 2] == field[x, y]                 || /* вертикаль, если последний элемент по середине*/
                    field[x - 1, y - 1] == field[x, y] && field[x - 2, y - 2] == field[x, y] && field[x + 1, y + 1] == field[x, y] && field[x + 2, y + 2] == field[x, y] || /* диагональ слева на право,  элемент по середине*/
                    field[x + 1, y - 1] == field[x, y] && field[x + 2, y - 2] == field[x, y] && field[x - 1, y + 1] == field[x, y] && field[x - 2, y + 2] == field[x, y] || /* диагональ справа на лево,  элемент по середине*/
                    field[x - 1, y] == field[x, y] && field[x - 2, y] == field[x, y] && field[x - 3, y] == field[x, y] && field[x - 4, y] == field[x, y]                 || /* если последний элемент крайний справа*/
                    field[x + 1, y + 1] == field[x, y] && field[x + 2, y + 2] == field[x, y] && field[x + 3, y + 3] == field[x, y] && field[x +4 , y + 4] == field[x, y] || /* диагональ слева на право,  крайний сверху*/
                    field[x - 1, y - 1] == field[x, y] && field[x - 2, y - 2] == field[x, y] && field[x - 3, y - 3] == field[x, y] && field[x - 4, y - 4] == field[x, y] || /* диагональ слева на право,  крайний снизу*/
                    field[x - 1, y + 1] == field[x, y] && field[x - 2, y + 2] == field[x, y] && field[x - 3, y + 3] == field[x, y] && field[x - 4, y + 4] == field[x, y] || /* диагональ справа на лево,  крайний сверху*/
                    field[x + 1, y - 1] == field[x, y] && field[x + 2, y - 2] == field[x, y] && field[x + 3, y - 3] == field[x, y] && field[x + 4, y - 4] == field[x, y] || /* диагональ справа на лево,  крайний снизу*/
                    field[x + 1, y] == field[x, y] && field[x + 2, y] == field[x, y] && field[x + 3, y] == field[x, y] && field[x + 4, y] == field[x, y]                 || /* если последний элемент крайний слева*/
                    field[x, y + 1] == field[x, y] && field[x, y + 2] == field[x, y] && field[x, y + 3] == field[x, y] && field[x, y + 4] == field[x, y]                 || /* если последний элемент крайний сверху*/
                    field[x, y - 1] == field[x, y] && field[x, y - 2] == field[x, y] && field[x, y - 3] == field[x, y] && field[x, y - 4] == field[x, y]                 || /* если последний элемент крайний снизу*/
                    field[x + 1, y] == field[x, y] && field[x - 1, y] == field[x, y] && field[x - 2, y] == field[x, y] && field[x - 3, y] == field[x, y]                 || /* если последний элемент предпоследний справа*/
                    field[x - 1, y] == field[x, y] && field[x + 1, y] == field[x, y] && field[x + 2, y] == field[x, y] && field[x + 3, y] == field[x, y]                 || /* если последний элемент предпоследний слева*/
                    field[x, y - 1] == field[x, y] && field[x, y + 1] == field[x, y] && field[x, y + 2] == field[x, y] && field[x, y + 3] == field[x, y]                 || /* если последний элемент предпоследний сверху*/
                    field[x, y + 1] == field[x, y] && field[x, y - 1] == field[x, y] && field[x, y - 2] == field[x, y] && field[x, y - 3] == field[x, y]                 || /* если последний элемент предпоследний снизу*/
                    field[x - 1, y - 1] == field[x, y] && field[x + 1, y + 1] == field[x, y] && field[x + 2, y + 2] == field[x, y] && field[x + 3, y + 3] == field[x, y] || /*диагональ справа на лево, предпоследний сверху*/ 
                    field[x + 1, y + 1] == field[x, y] && field[x - 1, y - 1] == field[x, y] && field[x - 2, y - 2] == field[x, y] && field[x - 3, y - 3] == field[x, y] || /*диагональ справа на лево, предпоследний снизу*/
                    field[x + 1, y - 1] == field[x, y] && field[x - 1, y + 1] == field[x, y] && field[x - 2, y + 2] == field[x, y] && field[x - 3, y + 3] == field[x, y] || /* диагональ справа на лево,  предпоследний сверху*/
                    field[x + 1, y - 1] == field[x, y] && field[x - 1, y + 1] == field[x, y] && field[x - 2, y + 2] == field[x, y] && field[x - 3, y + 3] == field[x, y]    /* диагональ справа на лево,  предпоследний снизу*/
                    )
                {
                    if (!indicator)
                    {
                    t.Stop();//Остановка таймера при победе
                    MessageBox.Show("Победили Х");
                   

                }
                    else
                    {
                    t.Stop();//Остановка таймера при победе
                    MessageBox.Show("Победили О");
                     }
                DialogResult dialogResult = MessageBox.Show("Перезапустить Игру?", "Уведомление", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();//если да
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close(); //если нет
                }


            }
                else if(counter == 900)
            {
                MessageBox.Show("Ничья");
            }
            /*}*/
        }

        private void игратьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1) Договоритесь, кто из участников будет ходить крестиками или ноликами.\n2) Первый игрок ставит фигуру в любую из клеточек, после чего ход переходит следующему участнику.\n3) Второй игрок рисует символ в свободной клеточке, и ход возвращается к первому участнику.\n4) Игра продолжается пока не заполнятся все клетки, или один из участников не сделает цепочку из пяти одинаковых символов.Причём ряд идёт по горизонтали, вертикали или диагонали");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа сделана в рамках выполнения лабораторной работы по курсу- Групповая динамика\nГруппа №5\nХарченко Денис\nГорбунов Никита");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void включитьТаймерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //старт таймера
        
        //стоп таймера
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
            
        }

        private void включитьТаймерToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            t.Start();
        }

        private void остановитьВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Stop();
            
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void стратегииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Стержневой победной тактикой при игре «5 в ряд» является построение «вилок», т.е.таких пересечений, которые не дают вероятности противнику строить пятерки, в этом случае крупна вероятность победы начинающего игрока.Впрочем построение ряда больше 5 не является победой.В тоже время существует одно лимитация в правилах: 1 - й игрок ставит свою фигуру в центр поля, а дальше оба игрока могут ставить свои символы произвольно, при этом 2 - й игрок может сменить цвет.");
        }

        private void помошьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // окно с выбором игрока
            if (f.ShowDialog() == DialogResult.Yes)
            {
                indicator = true;
            }
            else
            {
                indicator = false;
            }

            //Таймер
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;



        }
        //Метод таймера
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            s += 1;
            Invoke(new Action(() =>
            {
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                    if (m ==10)//Таймер на 10 минут
                    {
                        Application.DoEvents();
                      
                        t.Stop();
                        Application.DoEvents();
                        DialogResult dialogResult = MessageBox.Show("Вы не успели завершить игру за 10 мин .Время вышло\nПерезапустить игру?", "Уведомление", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Application.Restart();//если да
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            this.Close(); //если нет
                        }


                    }
                }
                if (m==60)
                {
                    m = 0;
                    
                }
                textBox1.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }
    }
}