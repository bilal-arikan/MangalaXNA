using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Arikan.GUI.Components;
using Arikan.GUI.Screens;
using System.Threading;

namespace Mangala
{
    class MangalaGame : Screen
    {
        public enum Difficult { Easy, Normal, Hard };
        public Difficult CurrentDifficult;
        int Width = 0;
        int Heigth = 0;
        Player Player1;
        Player Player2;
        Color p1Color = Color.Orange;
        Color p2Color = Color.SkyBlue;

        Vector2 PositionBoard = new Vector2(40, 100);
        List<Hole> Holes = new List<Hole>();
        public Button buttonBack;
        public Button buttonWinner;
        bool TwoPlayer = false;

        public MangalaGame(int w, int h, bool twoPlayer,int whichFirst, Difficult dif,int holeNumber,int stoneNumber)
            : base(0,0,w,h)
        {
            TwoPlayer = twoPlayer;
            CurrentDifficult = dif;
            Width = w;
            Heigth = h;
            if (twoPlayer)
            {
                Player1 = new Player(holeNumber, stoneNumber, w, h, p1Color, true, "1. Oyuncu");
                Player2 = new Player(holeNumber, stoneNumber, w, h, p2Color, false, "2. Oyuncu");
                for (int i = 0; i < Player1.Holes.Count - 1; i++)
                {
                    Player1.Holes[i].ClickUp += hole_ClickUp1;
                }
                for (int i = 0; i < Player2.Holes.Count - 1; i++)
                {
                    Player2.Holes[i].ClickUp += hole_ClickUp2;
                }
            }
            else
            {
                Player1 = new Player(holeNumber, stoneNumber, w, h, p1Color, true, "1. Oyuncu");
                Player2 = new Player(holeNumber, stoneNumber, w, h, p2Color, false, "Yapay Zeka");
                for (int i = 0; i < Player1.Holes.Count - 1; i++)
                {
                    Player1.Holes[i].ClickUp += hole_ClickUp1;
                }
                /*for (int i = 0; i < Player2.Holes.Count - 1; i++)
                {
                    Player2.Holes[i].ClickUp += hole_ClickUp2;
                }*/
                Player2.Think += hole_Think;
            }
            buttonBack = new Button( Global.TextureButton, Global.FontMenu, Width - 120, h - 50, 110, 40, "<-  Cikis");
            buttonBack.ClickUp += delegate { this.Remove(); };
            buttonWinner = new Button( Global.TextureHole, Global.FontMenu, Width / 2  - 200, Heigth/2 - 100, 400, 200);
            buttonWinner.ClickUp += delegate { this.Remove(); };
            buttonWinner.Visible = false;
            buttonWinner.Enabled = false;            
            Components.Add(buttonBack);
            Components.Add(Player1);
            Components.Add(Player2);
            Components.Add(buttonWinner);

            
            Player2.Enabled = false;
            Player1.Enabled = false;
            if(whichFirst == 0)
                if ((new Random()).Next() % 2 == 1)
                {
                    Player2.Enabled = true;
                    Player1.Color = Color.WhiteSmoke;
                }
                else
                {
                    Player1.Enabled = true;
                    Player2.Color = Color.WhiteSmoke;
                }
            else if(whichFirst == 1)
            {
                Player1.Enabled = true;
                Player2.Color = Color.WhiteSmoke;
            }
            else
            {
                Player2.Enabled = true;
                Player1.Color = Color.WhiteSmoke;
            }
        }

        void hole_ClickUp1(object sender, MouseEventHandler e)
        {
            Thread thread1 = new Thread(new ThreadStart(delegate { 
                int indexP1 = 0;
                int indexP2 = 0;
                bool pass = true;
                bool win = true;

                if (((Hole)sender).Stones > 0)
                {
                    Player1.Enabled = false;
                    int Step = ((Hole)sender).Stones;
                    ((Hole)sender).Stones = 0;
                    indexP1 = Player1.Holes.IndexOf((Hole)sender) + 1 ;

                    for (int i = 1; i <= Step; i++)
                    {
                        if (indexP1 < (Player1.Holes.Count))
                        {
                            if (i == Step)
                            {
                                if (indexP1 == Player1.Holes.Count-1)
                                {
                                    Player1.Holes[indexP1].Stones++;
                                    pass = false;
                                }
                                else if (Player1.Holes[indexP1].Stones == 0)
                                {
                                    Player1.Holes[indexP1].Stones++;
                                    Player1.Holes[Player1.Holes.Count - 1].Stones += Player2.Holes[Player2.Holes.Count - indexP1 - 2].Stones;
                                    Player2.Holes[Player2.Holes.Count - indexP1 - 2].Stones = 0;
                                    Player1.Holes[Player1.Holes.Count - 1].Stones += 1;
                                    Player1.Holes[indexP1].Stones = 0;
                                }
                                else
                                {
                                    Player1.Holes[indexP1].Stones++;
                                    indexP1++;
                                }
                            }
                            else
                            {
                                Player1.Holes[indexP1].Stones++;
                                indexP1++;
                            }
                        }
                        else if (indexP2 < (Player2.Holes.Count-1))
                        {
                            if (i == Step)
                            {
                                Player2.Holes[indexP2].Stones++;
                                if (Player2.Holes[indexP2].Stones % 2 == 0)
                                {
                                    Player1.Holes[Player1.Holes.Count - 1].Stones += Player2.Holes[indexP2].Stones;
                                    Player2.Holes[indexP2].Stones = 0;
                                }
                                else
                                {
                                    indexP2++;
                                }
                            }
                            else
                            {
                                Player2.Holes[indexP2].Stones++;
                                indexP2++;
                            }
                        }
                        else
                        {
                            indexP1 = 0;
                            indexP2 = 0;
                            i--;
                        }
                        Global.SoundMove.Play(Global.Sound, 1f, 0f);
                        Thread.Sleep(Global.Speed);
                    }
                    if (Player2.Holes.GetRange(0, Player2.Holes.Count - 1).TrueForAll(AllZero) || Player1.Holes.GetRange(0, Player1.Holes.Count - 1).TrueForAll(AllZero))
                        win = true;
                    else
                        win = false;

                    if (win)
                    {
                        for (int j = 0; j < Player2.Holes.Count - 1; j++)
                        {
                            Player1.HomeHole.Stones += Player2.Holes[j].Stones;
                            Player2.Holes[j].Stones = 0;
                        }
                        EndGame();
                    }
                    else if (pass)
                    {
                        Player1.Enabled = false;
                        Player2.Enabled = true;
                        Player1.Color = Color.WhiteSmoke;
                        Player2.Color = p2Color;
                    }
                    else
                    {
                        Player1.Enabled = true;
                    }
                }
            }));
            thread1.Start();
            
        }
        void hole_ClickUp2(object sender, MouseEventHandler e)
        {
            Thread thread1 = new Thread(new ThreadStart(delegate { 
                int indexP1 = 0;
                int indexP2 = 0;
                bool pass = true;
                bool win = true;

                if (((Hole)sender).Stones > 0)
                {
                    Player2.Enabled = false;
                    int Step = ((Hole)sender).Stones;
                    ((Hole)sender).Stones = 0;
                    indexP2 = Player2.Holes.IndexOf((Hole)sender) + 1;

                    for (int i = 1; i <= Step; i++)
                    {
                        if (indexP2 < (Player2.Holes.Count))
                        {
                            if (i == Step)
                            {
                                if (indexP2 == Player2.Holes.Count - 1)
                                {
                                    Player2.Holes[indexP2].Stones++;
                                    pass = false;
                                }
                                else if (Player2.Holes[indexP2].Stones == 0)
                                {
                                    Player2.Holes[indexP2].Stones++;
                                    Player2.Holes[Player2.Holes.Count - 1].Stones += Player1.Holes[Player1.Holes.Count - indexP2 - 2].Stones;
                                    Player1.Holes[Player1.Holes.Count - indexP2 - 2].Stones = 0;
                                    Player2.Holes[Player2.Holes.Count - 1].Stones += 1;
                                    Player2.Holes[indexP2].Stones = 0;
                                }
                                else
                                {
                                    Player2.Holes[indexP2].Stones++;
                                    indexP2++;
                                }
                            }
                            else
                            {
                                Player2.Holes[indexP2].Stones++;
                                indexP2++;
                            }
                        }
                        else if (indexP1 < (Player1.Holes.Count-1))
                        {
                            if (i == Step)
                            {
                                Player1.Holes[indexP1].Stones++;
                                if (Player1.Holes[indexP1].Stones % 2 == 0)
                                {
                                    Player2.Holes[Player2.Holes.Count - 1].Stones += Player1.Holes[indexP1].Stones;
                                    Player1.Holes[indexP1].Stones = 0;
                                }
                                else
                                {
                                    indexP1++;
                                }
                            }
                            else
                            {
                                Player1.Holes[indexP1].Stones++;
                                indexP1++;
                            }
                        }
                        else
                        {
                            indexP1 = 0;
                            indexP2 = 0;
                            i--;
                        }
                        Global.SoundMove.Play(Global.Sound, 1f, 0f);
                        Thread.Sleep(Global.Speed);
                    }
                    if (Player1.Holes.GetRange(0, Player1.Holes.Count - 1).TrueForAll(AllZero) || Player2.Holes.GetRange(0, Player2.Holes.Count - 1).TrueForAll(AllZero))
                        win = true;
                    else
                        win = false;

                    if (win)
                    {
                        for (int j = 0; j < Player1.Holes.Count - 1; j++)
                        {
                            Player2.HomeHole.Stones += Player1.Holes[j].Stones;
                            Player1.Holes[j].Stones = 0;
                        }
                        EndGame();
                    }
                    else if (pass)
                    {
                        Player2.Enabled = false;
                        Player1.Enabled = true;
                        Player2.Color = Color.WhiteSmoke;
                        Player1.Color = p1Color;
                    }
                    else
                    {
                        Player2.Enabled = true;
                    }
                }
            }));
            thread1.Start();
        }
        void hole_Think(object sender)
        {
            int SumHoles = Player2.Holes.Count + Player1.Holes.Count;
            Thread thread1 = new Thread(new ThreadStart(delegate {
                int id = -1;
                int max = 0;
                Thread.Sleep(2 * Global.Speed);
                for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                {
                    if (Player2.Holes[i].Stones > 0 && Player2.Holes[i].Stones == Player2.Holes.Count - i - 1)
                    {
                        hole_ClickUp2(Player2.Holes[i], new MouseEventHandler());
                        return;
                    }
                }
                if ( CurrentDifficult == Difficult.Normal || CurrentDifficult == Difficult.Hard)
                for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                {
                    if (Player2.Holes[i].Stones > 0 && Player2.Holes[i].Stones + i > Player2.Holes.Count - 1 && Player2.Holes[i].Stones + i < Player2.Holes.Count + Player1.Holes.Count - 1)
                    {
                        if (Player1.Holes[Player2.Holes[i].Stones + i - Player2.Holes.Count].Stones % 2 == 1)
                        {
                            hole_ClickUp2(Player2.Holes[i], new MouseEventHandler());
                            return;
                        }
                    }
                }
                if (CurrentDifficult == Difficult.Hard)
                    for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                    {
                        if (Player2.Holes[i].Stones > Player2.Holes.Count - 2)
                        {
                            hole_ClickUp2(Player2.Holes[i], new MouseEventHandler());
                            return;
                        }
                    }
                if (CurrentDifficult == Difficult.Easy || CurrentDifficult == Difficult.Normal )
                {
                    for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                    {
                        if (Player2.Holes[i].Stones > 0 && Player2.Holes[i].Stones < Player2.Holes.Count - i - 1)
                        {
                            if (Player2.Holes[i + Player2.Holes[i].Stones].Stones == 0)
                            {
                                hole_ClickUp2(Player2.Holes[i], new MouseEventHandler());
                                return;
                            }
                        }
                    }
                }
                if (CurrentDifficult == Difficult.Hard)
                    for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                    {
                        if (Player2.Holes[i].Stones > 0 && Player2.Holes[i].Stones < Player2.Holes.Count - i - 1)
                        {
                            if (Player2.Holes[i + Player2.Holes[i].Stones].Stones == 0)
                            {
                                if (max < Player1.Holes[Player2.Holes.Count - Player2.Holes[i].Stones - i - 2].Stones)
                                {
                                    max = Player1.Holes[Player2.Holes.Count - Player2.Holes[i].Stones - i - 2].Stones;
                                    id = i;
                                }
                            }
                        }
                    }
                if(id != -1)
                {
                    hole_ClickUp2(Player2.Holes[id], new MouseEventHandler());
                    return;
                }

                int trying = 10;
                while (trying > 0)
                {
                    int rand = (new Random()).Next(0, Player2.Holes.Count - 2);
                    if (Player2.Holes[rand].Stones > 0)
                    {
                        hole_ClickUp2(Player2.Holes[rand], new MouseEventHandler());
                        return;
                    }
                    trying--;
                }
                for (int i = Player2.Holes.Count - 2; i >= 0; i--)
                {
                    if (Player2.Holes[i].Stones > 0)
                    {
                        hole_ClickUp2(Player2.Holes[i], new MouseEventHandler());
                        return;
                    }
                }
            }));
            thread1.Start();
        }
        void EndGame()
        {
            Player2.Color = Color.WhiteSmoke;
            Player1.Color = Color.WhiteSmoke;
            Player1.Enabled = false;
            Player2.Enabled = false;
            buttonWinner.Visible = true;
            buttonWinner.Enabled = true;
            
            if (Player1.HomeHole.Stones == Player2.HomeHole.Stones)
            {
                buttonWinner.ReleaseColor = Color.WhiteSmoke;
                buttonWinner.Text = "...Beraberlik...";
                Global.SoundLose.Play(Global.Music, 0.2f, 0f);
            }
            else if (Player1.HomeHole.Stones > Player2.HomeHole.Stones)
            {
                buttonWinner.ReleaseColor = p1Color;
                buttonWinner.HoverColor = p1Color;
                buttonWinner.Text = "Kazanan...  "+Player1.Name;
                Global.SoundWin.Play(Global.Music, 1f, 0f);
            }
            else
            {
                buttonWinner.ReleaseColor = p2Color;
                buttonWinner.HoverColor = p2Color;
                buttonWinner.Text = "Kazanan...  "+Player2.Name;
                if (TwoPlayer)
                    Global.SoundWin.Play(Global.Music, 1f, 0f);
                else
                    Global.SoundLose.Play(Global.Music, 0.2f, 0f);

            }
        }
        bool AllZero(Hole hole)
        {
            if (hole.Stones == 0)
                return true;
            else
                return false;
        }
    }
}
