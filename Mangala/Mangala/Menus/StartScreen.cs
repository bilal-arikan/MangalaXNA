using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Arikan.GUI.Screens;
using Arikan.GUI.Components;

namespace Mangala
{
    class StartScreen : Screen
    {
        public Button buttonStart;
        Button buttonBack;
        Label labelOneTwo;
        public CheckBox checkOne;
        public CheckBox checkTwo;
        Label labelFirst;
        public CheckBox checkR;
        public CheckBox check1;
        public CheckBox check2;
        Label labelDifficult;
        public CheckBox checkEasy;
        public CheckBox checkNormal;
        public CheckBox checkHard;
        Label labelAlternative;
        public CheckBox checkOpen;
        public CheckBox checkClose;
        Label labelHole;
        public TrackBar trackHole;
        Label labelStone;
        public TrackBar trackStone;

        public StartScreen( int w, int h)
            : base(0,0,w,h)
        {
            Width = w;
            Heigth = h;

            labelOneTwo = new Label(Global.FontMenu, Color.Orange, 170, 20, "Oyun Sekli:");
            checkOne = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 180, 50, 40, "Tek Oyuncu");
            checkTwo = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 400, 50, 40, "Cift Oyuncu");
            labelFirst = new Label(Global.FontMenu, Color.Orange, 170, 100, "Baslayacak Kisi:");
            checkR = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 180, 130, 40, "Rastgele");
            check1 = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 330, 130, 40, "1.Oyuncu");
            check2 = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 480, 130, 40, "2.Oyuncu");
            labelDifficult = new Label(Global.FontMenu, Color.Orange, 170, 180, "Zorluk:");
            checkEasy = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 180, 210, 40, "Kolay");
            checkNormal = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 330, 210, 40, "Normal");
            checkHard = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 480, 210, 40, "Zor");
            labelAlternative = new Label(Global.FontMenu, Color.Orange, 170, 260, "Ince Ayar:");
            checkOpen = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 180, 290, 40, "Acik");
            checkClose = new CheckBox(Global.TextureHole, Global.TextureHole, Global.FontMenu, 400, 290, 40, "Kapali");
            labelHole = new Label(Global.FontMenu, Color.Orange, 170, 340, "Yuva Adedi:");
            trackHole = new TrackBar(Global.TextureButton, Global.TextureButton, Global.FontSkor, 170, 390, 200, 20, 40, 40, 5, 0, 2);
            labelStone = new Label(Global.FontMenu, Color.Orange, 420, 340, "Tas Adedi:");
            trackStone = new TrackBar(Global.TextureButton, Global.TextureButton, Global.FontSkor, 420, 390, 200, 20, 40, 40, 8, 0, 2);
            trackHole.Text = (trackHole.Value + 4).ToString();
            trackStone.Text = (trackStone.Value +2).ToString();
            checkOne.IsChecked = true;
            checkR.IsChecked = true;
            checkNormal.IsChecked = true;
            checkClose.IsChecked = true;
            checkOne.FontColor = Color.Orange; checkOne.CheckColor = Color.Orange;
            checkTwo.FontColor = Color.Orange; checkTwo.CheckColor = Color.Orange;
            checkR.FontColor = Color.Orange; checkR.CheckColor = Color.Orange;
            check1.FontColor = Color.Orange; check1.CheckColor = Color.Orange;
            check2.FontColor = Color.Orange; check2.CheckColor = Color.Orange;
            checkEasy.FontColor = Color.Orange; checkEasy.CheckColor = Color.Orange;
            checkNormal.FontColor = Color.Orange; checkNormal.CheckColor = Color.Orange;
            checkHard.FontColor = Color.Orange; checkHard.CheckColor = Color.Orange;
            checkOpen.FontColor = Color.Orange; checkOpen.CheckColor = Color.Orange;
            checkClose.FontColor = Color.Orange; checkClose.CheckColor = Color.Orange;
            labelDifficult.Shadow = true;
            labelFirst.Shadow = true;
            labelOneTwo.Shadow = true;
            labelAlternative.Shadow = true;
            labelHole.Shadow = true;
            labelStone.Shadow = true;
            trackHole.BarColor = Color.Orange;
            trackStone.BarColor = Color.Orange;
            buttonBack = new Button(Global.TextureButton, Global.FontMenu, Width - 120, Heigth - 50, 110, 40, "<-  Geri");
            buttonBack.ClickUp += delegate { this.Remove(); };
            buttonStart = new Button(Global.TextureButton, Global.FontMenu, 250, Heigth - 50, 300, 40, "BASLAT");
            buttonStart.ReleaseColor = Color.Orange;

            checkOne.Checked += checkOne_Checked;
            checkOne.Unchecked += checkOne_Unchecked;
            checkTwo.Checked += checkOne_Unchecked;
            checkTwo.Unchecked += checkOne_Checked;
            checkR.Checked += delegate { check1.IsChecked = false; check2.IsChecked = false; };
            check1.Checked += delegate { checkR.IsChecked = false; check2.IsChecked = false; };
            check2.Checked += delegate { checkR.IsChecked = false; check1.IsChecked = false; };
            checkEasy.Checked += delegate { checkNormal.IsChecked = false; checkHard.IsChecked = false; };
            checkNormal.Checked += delegate { checkEasy.IsChecked = false; checkHard.IsChecked = false; };
            checkHard.Checked += delegate { checkEasy.IsChecked = false; checkNormal.IsChecked = false; };
            checkOpen.Checked += checkOpen_Unchecked;
            checkOpen.Unchecked += checkOpen_Checked;
            checkClose.Checked += checkOpen_Checked;
            checkClose.Unchecked += checkOpen_Unchecked;
            trackHole.ValueChanged += delegate { trackHole.Text = (trackHole.Value + 4).ToString(); };
            trackStone.ValueChanged += delegate { trackStone.Text = (trackStone.Value + 2).ToString(); };
            
            Components.Add(buttonBack);
            Components.Add(buttonStart);
            Components.Add(labelOneTwo);
            Components.Add(checkOne);
            Components.Add(checkTwo);
            Components.Add(labelFirst);
            Components.Add(checkR);
            Components.Add(check1);
            Components.Add(check2);
            Components.Add(labelDifficult);
            Components.Add(checkEasy);
            Components.Add(checkNormal);
            Components.Add(checkHard);
            Components.Add(labelAlternative);
            Components.Add(checkOpen);
            Components.Add(checkClose);
        }

        void checkOpen_Unchecked(object sender)
        {
            checkOpen.IsChecked = true;
            checkClose.IsChecked = false;
            Components.Add(labelHole);
            Components.Add(trackHole);
            Components.Add(labelStone);
            Components.Add(trackStone);
        }

        void checkOpen_Checked(object sender)
        {
            checkOpen.IsChecked = false;
            checkClose.IsChecked = true;
            Components.Remove(labelHole);
            Components.Remove(trackHole);
            Components.Remove(labelStone);
            Components.Remove(trackStone);
        }

        void checkOne_Checked(object sender)
        {
            Global.SoundMove.Play(Global.Sound, 1f, 0f);
            if (!Components.Contains(labelDifficult))
            {
                Components.Add(labelDifficult);
                Components.Add(checkEasy);
                Components.Add(checkNormal);
                Components.Add(checkHard);
            }
            checkOne.IsChecked = true;
            checkTwo.IsChecked = false;
        }
        void checkOne_Unchecked(object sender)
        {
            Global.SoundMove.Play(Global.Sound, 1f, 0f);
            if (Components.Contains(labelDifficult))
            {
                Components.Remove(labelDifficult);
                Components.Remove(checkEasy);
                Components.Remove(checkNormal);
                Components.Remove(checkHard);
            }
            checkOne.IsChecked = false;
            checkTwo.IsChecked = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (!checkR.IsChecked && !check1.IsChecked && !check2.IsChecked || !checkEasy.IsChecked && !checkNormal.IsChecked && !checkHard.IsChecked)
                buttonStart.Enabled = false;
            else
                buttonStart.Enabled = true;


            base.Update(gameTime);
        }
    }
}
