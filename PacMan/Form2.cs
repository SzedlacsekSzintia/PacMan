using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace PacMan
{
    
    public partial class Form2 : Form
    {        
        Model model;
        bool down, up, left, right, GameOver;
        int score_, playerSpeed, orangeSpeed, redSpeed, blueSpeed, pinkSpeed;

        int Pac_way;
        int y;  //Blinky
        int y_I;  //Inky
        int y_P;  //Pinky
        int y_C;  //Clyde

        //Ha nincs megadva különböző változó nevekkel akkor nagyjából hasonló irányokba fognak menni a szellemek
        int y3=0;  //Blinky
        int y3_I = 0;  //Inky
        int y3_P = 0;  //Pinky
        int y3_C = 0;  //Clyde

        int ignore = 0;

        public Form2(Model mod)
        {
            model = mod;

            InitializeComponent();
            KeyDown += new System.Windows.Forms.KeyEventHandler(DownKey);
            KeyUp += new System.Windows.Forms.KeyEventHandler(UpKey);
            ResetTheGame();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DownKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpKey(object sender, KeyEventArgs e) //Nem megy végtelenségig PacMan
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (e.KeyCode == Keys.Enter && GameOver == true)
            {
                ResetTheGame();
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void GameTimer(object sender, EventArgs e)
        {          
            Score.Text = "Score : " + score_;
            
            if (left == true)
            {
                PacMan.Left -= playerSpeed;
                PacMan.Image = Properties.Resources.pac_mans_head_left;
                Pac_way = 1;
            }

            if (right == true)
            {
                PacMan.Left += playerSpeed;
                PacMan.Image = Properties.Resources.pac_mans_head;
                Pac_way = 2;
            }

            if (down == true)
            {
                PacMan.Top += playerSpeed;
                PacMan.Image = Properties.Resources.pac_mans_head_bottom;
                Pac_way = 3;
            }

            if (up == true)
            {
                PacMan.Top -= playerSpeed;
                PacMan.Image = Properties.Resources.pac_mans_head_top;
                Pac_way = 4;
            }

            // "Teleport" a pálya másik oldalára
            // balra-jobbra

            if (PacMan.Left < -10)
            {
                PacMan.Left = 780;
            }

            if (PacMan.Left > 780)
            {
                PacMan.Left = -10;
            }

            //föl-le
            //if (PacMan.Top < -10)
            //{
            //    PacMan.Top = 600;
            //}
            //
            //if (PacMan.Top > 600)
            //{
            //    PacMan.Top = 0;
            //}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true) //Mi trténik amikor felvesszük a coinokat... amúgy pontok
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds))
                        {   
                            if (ignore == 0)
                            {
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"E:\C#\C# 2. félév\PacMan\bin\Debug\WakaWavSpeed.wav");
                                player.Play();
                            }
                            ignore++;
                            if (ignore > 1)
                            {
                                ignore = 0;
                            }
                            score_ += 1;
                           
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "Wall") //Mi történik amikor PACMAN falba ütközik
                    {  
                        if (PacMan.Bounds.IntersectsWith(wall1.Bounds) || PacMan.Bounds.IntersectsWith(wall2.Bounds) || PacMan.Bounds.IntersectsWith(wall3.Bounds) || PacMan.Bounds.IntersectsWith(wall4.Bounds) || PacMan.Bounds.IntersectsWith(wall5.Bounds) || PacMan.Bounds.IntersectsWith(wall6.Bounds) || PacMan.Bounds.IntersectsWith(wall7.Bounds) || PacMan.Bounds.IntersectsWith(wall8.Bounds) || PacMan.Bounds.IntersectsWith(wall9.Bounds) || PacMan.Bounds.IntersectsWith(wall10.Bounds) || PacMan.Bounds.IntersectsWith(wall11.Bounds) || PacMan.Bounds.IntersectsWith(wall12.Bounds) || PacMan.Bounds.IntersectsWith(wall13.Bounds) || PacMan.Bounds.IntersectsWith(wall14.Bounds) || PacMan.Bounds.IntersectsWith(wall15.Bounds) || PacMan.Bounds.IntersectsWith(wall16.Bounds) || PacMan.Bounds.IntersectsWith(wall17.Bounds) || PacMan.Bounds.IntersectsWith(wall18.Bounds) || PacMan.Bounds.IntersectsWith(wall19.Bounds) || PacMan.Bounds.IntersectsWith(wall20.Bounds) || PacMan.Bounds.IntersectsWith(wall21.Bounds) || PacMan.Bounds.IntersectsWith(wall22.Bounds))
                        {
                            if (Pac_way == 1) //Ellentétes irányba kell menni
                            {
                                PacMan.Left += playerSpeed;
                                PacMan.Image = Properties.Resources.pac_mans_head_left;    
                            }

                            if (Pac_way == 2)
                            {
                                PacMan.Left -= playerSpeed;
                                PacMan.Image = Properties.Resources.pac_mans_head;  
                            }

                            if (Pac_way == 3)
                            {
                                PacMan.Top -= playerSpeed;
                                PacMan.Image = Properties.Resources.pac_mans_head_bottom;
                            }

                            if (Pac_way == 4)
                            {
                                PacMan.Top += playerSpeed;
                                PacMan.Image = Properties.Resources.pac_mans_head_top;
                            }
                        }
                    }

                    if ((string)x.Tag == "Blinky" || (string)x.Tag == "Pinky" || (string)x.Tag == "Inky" || (string)x.Tag == "Clyde") //Mi történik amikor szellembe ütközünk
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds))
                        {
                            ThaGameIsOver("You loose this right now.");
                            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@"E:\C#\C# 2. félév\PacMan\bin\Debug\PacManDeathWav.wav");
                            player1.Play();
                        }
                    }
                }
            }

//GHOSTS MOVING -----------------------------------------------------------------------------------Blinky, The Red Ghost's Moves----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Random rand = new Random();
            
            if( blinky.Bounds.IntersectsWith(cp1.Bounds) || blinky.Bounds.IntersectsWith(cp2.Bounds) || blinky.Bounds.IntersectsWith(cp3.Bounds) || blinky.Bounds.IntersectsWith(cp4.Bounds) || blinky.Bounds.IntersectsWith(cp5.Bounds) || blinky.Bounds.IntersectsWith(cp6.Bounds) || blinky.Bounds.IntersectsWith(cp7.Bounds) || blinky.Bounds.IntersectsWith(cp8.Bounds) || blinky.Bounds.IntersectsWith(cp9.Bounds) || blinky.Bounds.IntersectsWith(cp10.Bounds) ||
                blinky.Bounds.IntersectsWith(cp11.Bounds) || blinky.Bounds.IntersectsWith(cp12.Bounds) || blinky.Bounds.IntersectsWith(cp13.Bounds) || blinky.Bounds.IntersectsWith(cp14.Bounds) || blinky.Bounds.IntersectsWith(cp15.Bounds) || blinky.Bounds.IntersectsWith(cp16.Bounds) || blinky.Bounds.IntersectsWith(cp17.Bounds) || blinky.Bounds.IntersectsWith(cp18.Bounds) || blinky.Bounds.IntersectsWith(cp19.Bounds) || blinky.Bounds.IntersectsWith(cp20.Bounds) ||
                blinky.Bounds.IntersectsWith(cp21.Bounds) || blinky.Bounds.IntersectsWith(cp22.Bounds) || blinky.Bounds.IntersectsWith(cp23.Bounds) || blinky.Bounds.IntersectsWith(cp24.Bounds) || blinky.Bounds.IntersectsWith(cp25.Bounds) || blinky.Bounds.IntersectsWith(cp26.Bounds) || blinky.Bounds.IntersectsWith(cp27.Bounds) || blinky.Bounds.IntersectsWith(cp28.Bounds) || blinky.Bounds.IntersectsWith(cp29.Bounds) || blinky.Bounds.IntersectsWith(cp30.Bounds) ||
                blinky.Bounds.IntersectsWith(cp31.Bounds) || blinky.Bounds.IntersectsWith(cp32.Bounds))
            {
                y3++;
                if(y3==1)   //Ha megüti előszőr a cp-t..
                {
                    int y2 = rand.Next(0, 5);
                    if (y2 == 1)
                    {
                        blinky.Left += redSpeed; //jobbra
                        y = 1;
                    }
                    if (y2 == 2)
                    {
                        blinky.Top += redSpeed; //Lefelé
                        y = 2;
                    }
                    if (y2 == 3)
                    {
                        blinky.Left -= redSpeed; //Balra
                        y = 3;
                    }
                    if (y2 == 4)
                    {
                        blinky.Top -= redSpeed; //Felfelé
                        y = 4;
                    }
                }
                if (y == 1)   //Ha már az y_I nem 1..
                {
                    blinky.Left += redSpeed; //jobbra
                }
                if (y == 2)
                {
                    blinky.Top += redSpeed; //Lefelé
                }
                if (y == 3)
                {
                    blinky.Left -= redSpeed; //Balra
                }
                if (y == 4)
                {
                    blinky.Top -= redSpeed; //Felfelé
                }
                if (y3>15)  // Ha az y meghaladta a 15 ignorálást akkor..
                {
                    y3 = 0;
                }
                
            }
            else  //Csak halad az adott irányba
            {
                if (y==1)
                {
                    blinky.Left += redSpeed; //jobbra
               
                }
                if (y == 2)
                {
                    blinky.Top += redSpeed; //Lefelé
                }
                if (y == 3)
                {
                    blinky.Left -= redSpeed; //Balra
                }
                if (y == 4)
                {
                    blinky.Top -= redSpeed; //Felfelé
                }
            }

            if (blinky.Bounds.IntersectsWith(wall1.Bounds) || blinky.Bounds.IntersectsWith(wall2.Bounds) || blinky.Bounds.IntersectsWith(wall3.Bounds) || blinky.Bounds.IntersectsWith(wall4.Bounds) || blinky.Bounds.IntersectsWith(wall5.Bounds) || blinky.Bounds.IntersectsWith(wall6.Bounds)
            || blinky.Bounds.IntersectsWith(wall7.Bounds) || blinky.Bounds.IntersectsWith(wall8.Bounds) || blinky.Bounds.IntersectsWith(wall9.Bounds) || blinky.Bounds.IntersectsWith(wall10.Bounds) || blinky.Bounds.IntersectsWith(wall11.Bounds) || blinky.Bounds.IntersectsWith(wall12.Bounds) 
            || blinky.Bounds.IntersectsWith(wall3.Bounds) || blinky.Bounds.IntersectsWith(wall14.Bounds) || blinky.Bounds.IntersectsWith(wall15.Bounds) || blinky.Bounds.IntersectsWith(wall16.Bounds) || blinky.Bounds.IntersectsWith(wall17.Bounds) || blinky.Bounds.IntersectsWith(wall18.Bounds)
            || blinky.Bounds.IntersectsWith(wall19.Bounds) || blinky.Bounds.IntersectsWith(wall20.Bounds) || blinky.Bounds.IntersectsWith(wall21.Bounds) || blinky.Bounds.IntersectsWith(wall22.Bounds))
            {

                if (y == 1)
                {
                    blinky.Left -= redSpeed + 10; //Balra
                }
                if (y == 2)
                {
                    blinky.Top -= redSpeed + 10; //Fölfelé
                }
                if (y == 3)
                {
                    blinky.Left += redSpeed + 10; //Jobbra
                }
                if (y == 4)
                {
                    blinky.Top += redSpeed + 10; //Lefelé
                }
                y = rand.Next(0, 5);
            }

            if (blinky.Left < -10)
            {
                blinky.Left = 780;
            }

            if (blinky.Left > 780)
            {
                blinky.Left = -10;
            }
//GHOSTS MOVING -------------------------------------------------------------------------------Inky, The Blue Ghost's Moves------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (inky.Bounds.IntersectsWith(cp1.Bounds) || inky.Bounds.IntersectsWith(cp2.Bounds) || inky.Bounds.IntersectsWith(cp3.Bounds) || inky.Bounds.IntersectsWith(cp4.Bounds) || inky.Bounds.IntersectsWith(cp5.Bounds) || inky.Bounds.IntersectsWith(cp6.Bounds) || inky.Bounds.IntersectsWith(cp7.Bounds) || inky.Bounds.IntersectsWith(cp8.Bounds) || inky.Bounds.IntersectsWith(cp9.Bounds) || inky.Bounds.IntersectsWith(cp10.Bounds) ||
               inky.Bounds.IntersectsWith(cp11.Bounds) || inky.Bounds.IntersectsWith(cp12.Bounds) || inky.Bounds.IntersectsWith(cp13.Bounds) || inky.Bounds.IntersectsWith(cp14.Bounds) || inky.Bounds.IntersectsWith(cp15.Bounds) || inky.Bounds.IntersectsWith(cp16.Bounds) || inky.Bounds.IntersectsWith(cp17.Bounds) || inky.Bounds.IntersectsWith(cp18.Bounds) || inky.Bounds.IntersectsWith(cp19.Bounds) || inky.Bounds.IntersectsWith(cp20.Bounds) ||
               inky.Bounds.IntersectsWith(cp21.Bounds) || inky.Bounds.IntersectsWith(cp22.Bounds) || inky.Bounds.IntersectsWith(cp23.Bounds) || inky.Bounds.IntersectsWith(cp24.Bounds) || inky.Bounds.IntersectsWith(cp25.Bounds) || inky.Bounds.IntersectsWith(cp26.Bounds) || inky.Bounds.IntersectsWith(cp27.Bounds) || inky.Bounds.IntersectsWith(cp28.Bounds) || inky.Bounds.IntersectsWith(cp29.Bounds) || inky.Bounds.IntersectsWith(cp30.Bounds) ||
               inky.Bounds.IntersectsWith(cp31.Bounds) || inky.Bounds.IntersectsWith(cp32.Bounds))
            {
                y3_I++;
                if (y3_I == 1)   //Ha megüti előszőr a cp-t..
                {
                    int y2 = rand.Next(0, 5);
                    if (y2 == 1)
                    {
                        inky.Left += blueSpeed; //jobbra
                        y_I = 1;
                    }
                    if (y2 == 2)
                    {
                        inky.Top += blueSpeed; //Lefelé
                        y_I = 2;
                    }
                    if (y2 == 3)
                    {
                        inky.Left -= blueSpeed; //Balra
                        y_I = 3;
                    }
                    if (y2 == 4)
                    {
                        inky.Top -= blueSpeed; //Felfelé
                        y_I = 4;
                    }
                }
                if (y_I == 1)  //Ha már az y_I nem 1..
                {
                    inky.Left += blueSpeed; //jobbra
                }
                if (y_I == 2)
                {
                    inky.Top += blueSpeed; //Lefelé
                }
                if (y_I == 3)
                {
                    inky.Left -= blueSpeed; //Balra
                }
                if (y_I == 4)
                {
                    inky.Top -= blueSpeed; //Felfelé
                }
                if (y3_I > 15) // Ha az y_I meghaladta a 15 ignorálást akkor..
                {
                    y3_I = 0;
                }

            }
            else //Csak halad az adott irányba
            {
                if (y_I == 1)
                {
                    inky.Left += blueSpeed; //jobbra
                }
                if (y_I == 2)
                {
                    inky.Top += blueSpeed; //Lefelé
                }
                if (y_I == 3)
                {
                    inky.Left -= blueSpeed; //Balra
                }
                if (y_I == 4)
                {
                    inky.Top -= blueSpeed; //Felfelé
                }
            }

            if (inky.Bounds.IntersectsWith(wall1.Bounds) || inky.Bounds.IntersectsWith(wall2.Bounds) || inky.Bounds.IntersectsWith(wall3.Bounds) || inky.Bounds.IntersectsWith(wall4.Bounds) || inky.Bounds.IntersectsWith(wall5.Bounds) || inky.Bounds.IntersectsWith(wall6.Bounds) || inky.Bounds.IntersectsWith(wall7.Bounds) || inky.Bounds.IntersectsWith(wall8.Bounds) || inky.Bounds.IntersectsWith(wall9.Bounds) || inky.Bounds.IntersectsWith(wall10.Bounds) 
                || inky.Bounds.IntersectsWith(wall11.Bounds) || inky.Bounds.IntersectsWith(wall12.Bounds) || inky.Bounds.IntersectsWith(wall3.Bounds) || inky.Bounds.IntersectsWith(wall14.Bounds) || inky.Bounds.IntersectsWith(wall15.Bounds) || inky.Bounds.IntersectsWith(wall16.Bounds) || inky.Bounds.IntersectsWith(wall17.Bounds) || inky.Bounds.IntersectsWith(wall18.Bounds) || inky.Bounds.IntersectsWith(wall19.Bounds) || inky.Bounds.IntersectsWith(wall20.Bounds) || inky.Bounds.IntersectsWith(wall21.Bounds) || inky.Bounds.IntersectsWith(wall22.Bounds))
            {

                if (y_I == 1)
                {
                    inky.Left -= blueSpeed + 10; //Balra
                }
                if (y_I == 2)
                {
                    inky.Top -= blueSpeed + 10; //Fölfelé
                }
                if (y_I == 3)
                {
                    inky.Left += blueSpeed + 10; //Jobbra
                }
                if (y_I == 4)
                {
                    inky.Top += blueSpeed + 10; //Lefelé
                }
                y_I = rand.Next(0, 5);
            }

            if (inky.Left < -10)
            {
                inky.Left = 780;
            }

            if (inky.Left > 780)
            {
                inky.Left = -10;
            }
//GHOSTS MOVING -------------------------------------------------------------------------------Pnky, The Pink Ghost's Moves---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (pinky.Bounds.IntersectsWith(cp1.Bounds) || pinky.Bounds.IntersectsWith(cp2.Bounds) || pinky.Bounds.IntersectsWith(cp3.Bounds) || pinky.Bounds.IntersectsWith(cp4.Bounds) || pinky.Bounds.IntersectsWith(cp5.Bounds) || pinky.Bounds.IntersectsWith(cp6.Bounds) || pinky.Bounds.IntersectsWith(cp7.Bounds) || pinky.Bounds.IntersectsWith(cp8.Bounds) || pinky.Bounds.IntersectsWith(cp9.Bounds) || pinky.Bounds.IntersectsWith(cp10.Bounds) ||
               pinky.Bounds.IntersectsWith(cp11.Bounds) || pinky.Bounds.IntersectsWith(cp12.Bounds) || pinky.Bounds.IntersectsWith(cp13.Bounds) || pinky.Bounds.IntersectsWith(cp14.Bounds) || pinky.Bounds.IntersectsWith(cp15.Bounds) || pinky.Bounds.IntersectsWith(cp16.Bounds) || pinky.Bounds.IntersectsWith(cp17.Bounds) || pinky.Bounds.IntersectsWith(cp18.Bounds) || pinky.Bounds.IntersectsWith(cp19.Bounds) || pinky.Bounds.IntersectsWith(cp20.Bounds) ||
               pinky.Bounds.IntersectsWith(cp21.Bounds) || pinky.Bounds.IntersectsWith(cp22.Bounds) || pinky.Bounds.IntersectsWith(cp23.Bounds) || pinky.Bounds.IntersectsWith(cp24.Bounds) || pinky.Bounds.IntersectsWith(cp25.Bounds) || pinky.Bounds.IntersectsWith(cp26.Bounds) || pinky.Bounds.IntersectsWith(cp27.Bounds) || pinky.Bounds.IntersectsWith(cp28.Bounds) || pinky.Bounds.IntersectsWith(cp29.Bounds) || pinky.Bounds.IntersectsWith(cp30.Bounds) ||
               pinky.Bounds.IntersectsWith(cp31.Bounds) || pinky.Bounds.IntersectsWith(cp32.Bounds))
            {
                y3_P++;
                if (y3_P == 1)   //Ha megüti előszőr a cp-t..
                {
                    int y2 = rand.Next(0, 5);
                    if (y2 == 1)
                    {
                        pinky.Left += pinkSpeed; //jobbra
                        y_P = 1;
                    }
                    if (y2 == 2)
                    {
                        pinky.Top += pinkSpeed; //Lefelé
                        y_P = 2;
                    }
                    if (y2 == 3)
                    {
                        pinky.Left -= pinkSpeed; //Balra
                        y_P = 3;
                    }
                    if (y2 == 4)
                    {
                        pinky.Top -= pinkSpeed; //Felfelé
                        y_P = 4;
                    }
                }
                if (y_P == 1)  //Ha már az y_I nem 1..
                {
                    pinky.Left += pinkSpeed; //jobbra
                }
                if (y_P == 2)
                {
                    pinky.Top += pinkSpeed; //Lefelé
                }
                if (y_P == 3)
                {
                    pinky.Left -= pinkSpeed; //Balra
                }
                if (y_P == 4)
                {
                    pinky.Top -= pinkSpeed; //Felfelé
                }
                if (y3_P > 15) // Ha az y_I meghaladta a 15 ignorálást akkor..
                {
                    y3_P = 0;
                }

            }
            else //Csak halad az adott irányba
            {
                if (y_P == 1)
                {
                    pinky.Left += pinkSpeed; //jobbra
                }
                if (y_P == 2)
                {
                    pinky.Top += pinkSpeed; //Lefelé
                }
                if (y_P == 3)
                {
                    pinky.Left -= pinkSpeed; //Balra
                }
                if (y_P == 4)
                {
                    pinky.Top -= pinkSpeed; //Felfelé
                }
            }

            if (pinky.Bounds.IntersectsWith(wall1.Bounds) || pinky.Bounds.IntersectsWith(wall2.Bounds) || pinky.Bounds.IntersectsWith(wall3.Bounds) || pinky.Bounds.IntersectsWith(wall4.Bounds) || pinky.Bounds.IntersectsWith(wall5.Bounds) || pinky.Bounds.IntersectsWith(wall6.Bounds) || pinky.Bounds.IntersectsWith(wall7.Bounds) || pinky.Bounds.IntersectsWith(wall8.Bounds) || pinky.Bounds.IntersectsWith(wall9.Bounds) || pinky.Bounds.IntersectsWith(wall10.Bounds)
                || pinky.Bounds.IntersectsWith(wall11.Bounds) || pinky.Bounds.IntersectsWith(wall12.Bounds) || pinky.Bounds.IntersectsWith(wall3.Bounds) || pinky.Bounds.IntersectsWith(wall14.Bounds) || pinky.Bounds.IntersectsWith(wall15.Bounds) || pinky.Bounds.IntersectsWith(wall16.Bounds) || pinky.Bounds.IntersectsWith(wall17.Bounds) || pinky.Bounds.IntersectsWith(wall18.Bounds) || pinky.Bounds.IntersectsWith(wall19.Bounds) || pinky.Bounds.IntersectsWith(wall20.Bounds) || pinky.Bounds.IntersectsWith(wall21.Bounds) || pinky.Bounds.IntersectsWith(wall22.Bounds))
            {

                if (y_P == 1)
                {
                    pinky.Left -= pinkSpeed + 10; //Balra
                }
                if (y_P == 2)
                {
                    pinky.Top -= pinkSpeed + 10; //Fölfelé
                }
                if (y_P == 3)
                {
                    pinky.Left += pinkSpeed + 10; //Jobbra
                }
                if (y_P == 4)
                {
                    pinky.Top += pinkSpeed + 10; //Lefelé
                }
                y_P = rand.Next(0, 5);
            }

            if (pinky.Left < -10)
            {
                pinky.Left = 780;
            }

            if (pinky.Left > 780)
            {
                pinky.Left = -10;
            }


//GHOSTS MOVING -------------------------------------------------------------------------------Clyde, The Orange Ghost's Moves---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (clyde.Bounds.IntersectsWith(cp1.Bounds) || clyde.Bounds.IntersectsWith(cp2.Bounds) || clyde.Bounds.IntersectsWith(cp3.Bounds) || clyde.Bounds.IntersectsWith(cp4.Bounds) || clyde.Bounds.IntersectsWith(cp5.Bounds) || clyde.Bounds.IntersectsWith(cp6.Bounds) || clyde.Bounds.IntersectsWith(cp7.Bounds) || clyde.Bounds.IntersectsWith(cp8.Bounds) || clyde.Bounds.IntersectsWith(cp9.Bounds) || clyde.Bounds.IntersectsWith(cp10.Bounds) ||
               clyde.Bounds.IntersectsWith(cp11.Bounds) || clyde.Bounds.IntersectsWith(cp12.Bounds) || clyde.Bounds.IntersectsWith(cp13.Bounds) || clyde.Bounds.IntersectsWith(cp14.Bounds) || clyde.Bounds.IntersectsWith(cp15.Bounds) || clyde.Bounds.IntersectsWith(cp16.Bounds) || clyde.Bounds.IntersectsWith(cp17.Bounds) || clyde.Bounds.IntersectsWith(cp18.Bounds) || clyde.Bounds.IntersectsWith(cp19.Bounds) || clyde.Bounds.IntersectsWith(cp20.Bounds) ||
               clyde.Bounds.IntersectsWith(cp21.Bounds) || clyde.Bounds.IntersectsWith(cp22.Bounds) || clyde.Bounds.IntersectsWith(cp23.Bounds) || clyde.Bounds.IntersectsWith(cp24.Bounds) || clyde.Bounds.IntersectsWith(cp25.Bounds) || clyde.Bounds.IntersectsWith(cp26.Bounds) || clyde.Bounds.IntersectsWith(cp27.Bounds) || clyde.Bounds.IntersectsWith(cp28.Bounds) || clyde.Bounds.IntersectsWith(cp29.Bounds) || clyde.Bounds.IntersectsWith(cp30.Bounds) ||
               clyde.Bounds.IntersectsWith(cp31.Bounds) || clyde.Bounds.IntersectsWith(cp32.Bounds))
            {
                y3_C++;
                if (y3_C == 1)   //Ha megüti előszőr a cp-t..
                {
                    int y2 = rand.Next(0, 5);
                    if (y2 == 1)
                    {
                        clyde.Left += orangeSpeed; //jobbra
                        y_C = 1;
                    }
                    if (y2 == 2)
                    {
                        clyde.Top += orangeSpeed; //Lefelé
                        y_C = 2;
                    }
                    if (y2 == 3)
                    {
                        clyde.Left -= orangeSpeed; //Balra
                        y_C = 3;
                    }
                    if (y2 == 4)
                    {
                        clyde.Top -= orangeSpeed; //Felfelé
                        y_C = 4;
                    }
                }
                if (y_C == 1)  //Ha már az y_I nem 1..
                {
                    clyde.Left += orangeSpeed; //jobbra
                }
                if (y_C == 2)
                {
                    clyde.Top += orangeSpeed; //Lefelé
                }
                if (y_C == 3)
                {
                    clyde.Left -= orangeSpeed; //Balra
                }
                if (y_C == 4)
                {
                    clyde.Top -= orangeSpeed; //Felfelé
                }
                if (y3_C > 15) // Ha az y_I meghaladta a 15 ignorálást akkor..
                {
                    y3_C = 0;
                }

            }
            else //Csak halad az adott irányba
            {
                if (y_C == 1)
                {
                    clyde.Left += orangeSpeed; //jobbra
                }
                if (y_C == 2)
                {
                    clyde.Top += orangeSpeed; //Lefelé
                }
                if (y_C == 3)
                {
                    clyde.Left -= orangeSpeed; //Balra
                }
                if (y_C == 4)
                {
                    clyde.Top -= orangeSpeed; //Felfelé
                }
            }

            if (clyde.Bounds.IntersectsWith(wall1.Bounds) || clyde.Bounds.IntersectsWith(wall2.Bounds) || clyde.Bounds.IntersectsWith(wall3.Bounds) || clyde.Bounds.IntersectsWith(wall4.Bounds) || clyde.Bounds.IntersectsWith(wall5.Bounds) || clyde.Bounds.IntersectsWith(wall6.Bounds) || clyde.Bounds.IntersectsWith(wall7.Bounds) || clyde.Bounds.IntersectsWith(wall8.Bounds) || clyde.Bounds.IntersectsWith(wall9.Bounds) || clyde.Bounds.IntersectsWith(wall10.Bounds)
                || clyde.Bounds.IntersectsWith(wall11.Bounds) || clyde.Bounds.IntersectsWith(wall12.Bounds) || clyde.Bounds.IntersectsWith(wall3.Bounds) || clyde.Bounds.IntersectsWith(wall14.Bounds) || clyde.Bounds.IntersectsWith(wall15.Bounds) || clyde.Bounds.IntersectsWith(wall16.Bounds) || clyde.Bounds.IntersectsWith(wall17.Bounds) || clyde.Bounds.IntersectsWith(wall18.Bounds) || clyde.Bounds.IntersectsWith(wall19.Bounds) || clyde.Bounds.IntersectsWith(wall20.Bounds) || clyde.Bounds.IntersectsWith(wall21.Bounds) || clyde.Bounds.IntersectsWith(wall22.Bounds))
            {

                if (y_C == 1)
                {
                    clyde.Left -= orangeSpeed + 10; //Balra
                }
                if (y_C == 2)
                {
                    clyde.Top -= orangeSpeed + 10; //Fölfelé
                }
                if (y_C == 3)
                {
                    clyde.Left += orangeSpeed + 10; //Jobbra
                }
                if (y_C == 4)
                {
                    clyde.Top += orangeSpeed + 10; //Lefelé
                }
                y_C = rand.Next(0, 5);
            }

            if (clyde.Left < -10)
            {
                clyde.Left = 780;
            }

            if (clyde.Left > 780)
            {
                clyde.Left = -10;
            }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (score_ == 117)
            {
                ThaGameIsOver("You won this right now...");
                MessageBox.Show("Lucker.");  
            }
        }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ResetTheGame()
        {      
            Score.Text = "Score : 0"; //label1
            score_ = 0;

            orangeSpeed = 6;
            redSpeed = 6;
            blueSpeed = 6;
            pinkSpeed = 6;

            playerSpeed = 6;

            GameOver = false;

            PacMan.Left = 24; //PacMan's Location 
            PacMan.Top = 63;

            clyde.Left = 320; //Clyde, the orange ghost's Location
            clyde.Top = 98;

            inky.Left = 320; //Inky, the blue ghost's Location
            inky.Top = 430;

            pinky.Left = 384; //Pinky, the pink ghost's Location
            pinky.Top = 98;

            blinky.Left = 384; //Blinky, the red ghost's Location
            blinky.Top = 430;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            GameTimer_.Start();
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ThaGameIsOver(string message)
        {
            GameOver = true;
            GameTimer_.Stop();

            Score.Text = "Score : " + score_ + Environment.NewLine + message;
        }     
    }
}