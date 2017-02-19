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
using Arikan.GUI;

namespace Mangala
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int ScreenWidth = 800;
        int ScreenHeigth = 480;

        MangalaGame mangala;
        SplashScreen splashScreen;
        MenuScreen mainMenu;
        CreditsScreen credits;
        SettingsScreen settings;
        StartScreen start;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeigth;
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GUISet.Initialize(this, spriteBatch);
            Global.LoadContent(this);

            splashScreen = new SplashScreen(ScreenWidth, ScreenHeigth);
            mainMenu = new MenuScreen(ScreenWidth, ScreenHeigth);
            credits = new CreditsScreen(ScreenWidth, ScreenHeigth);
            settings = new SettingsScreen(ScreenWidth, ScreenHeigth);
            start = new StartScreen(ScreenWidth, ScreenHeigth);
            credits.Initialize();
            mainMenu.Initialize();
            splashScreen.Initialize();

            start.buttonStart.ClickUp += buttonStart_ClickUp;
            mainMenu.buttonOnePlayer.ClickUp += buttonOnePlayer_ClickUp;
            mainMenu.buttonTwoPlayer.ClickUp += buttonTwoPlayer_ClickUp;
            mainMenu.buttonAlternative.ClickUp += buttonAlternative_ClickUp;
            mainMenu.buttonSettings.ClickUp += buttonSettings_ClickUp;
            mainMenu.buttonCredits.ClickUp += buttonCredits_ClickUp;
            mainMenu.buttonExit.ClickUp += delegate { this.Exit(); };
            credits.Closed += credits_Closed;
            settings.Closed += settings_Closed;
            start.Closed += start_Closed;

            this.Components.Add(mainMenu);
        }

        void start_Closed(object sender)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            Components.Add(mainMenu);
        }
        void mangala_Closed(object sender)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            mangala.Enabled = false;
            Components.Add(mainMenu);
        }
        void settings_Closed(object sender)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            Components.Add(mainMenu);
        }
        void credits_Closed(object sender)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            Components.Add(mainMenu);
        }


        void buttonOnePlayer_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            mangala = new MangalaGame(ScreenWidth, ScreenHeigth, false, 0, MangalaGame.Difficult.Hard, 6, 4);
            mangala.Closed += mangala_Closed;
            this.Components.Add(mangala);
            this.Components.Remove(mainMenu);
            mangala.Visible = true;
        }

        void buttonTwoPlayer_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            mangala = new MangalaGame(ScreenWidth, ScreenHeigth, true, 0, MangalaGame.Difficult.Hard, 6, 4);
            mangala.Closed += mangala_Closed;
            this.Components.Add(mangala);
            this.Components.Remove(mainMenu);
            mangala.Visible = true;
        }
        void buttonAlternative_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            this.Components.Add(start);
            this.Components.Remove(mainMenu);
        }

        void buttonSettings_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            this.Components.Add(settings);
            this.Components.Remove(mainMenu);
        }
        void buttonCredits_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            this.Components.Add(credits);
            this.Components.Remove(mainMenu);
        }
        void buttonStart_ClickUp(object sender, MouseEventHandler e)
        {
            Global.SoundClick.Play(Global.Sound, 1f, 0f);
            MangalaGame.Difficult diffEnum = MangalaGame.Difficult.Easy;
            int whichStart = 0;

            if (start.checkEasy.IsChecked)
                diffEnum = MangalaGame.Difficult.Easy;
            else if (start.checkNormal.IsChecked)
                diffEnum = MangalaGame.Difficult.Normal;
            else if (start.checkHard.IsChecked)
                diffEnum = MangalaGame.Difficult.Hard;

            if (start.checkR.IsChecked)
                whichStart = 0;
            else if (start.check1.IsChecked)
                whichStart = 1;
            else if (start.check2.IsChecked)
                whichStart = 2;

            if(start.checkOpen.IsChecked)
                mangala = new MangalaGame( ScreenWidth, ScreenHeigth, !start.checkOne.IsChecked, whichStart, diffEnum, start.trackHole.Value + 4, start.trackStone.Value + 2);
            else
                mangala = new MangalaGame( ScreenWidth, ScreenHeigth, !start.checkOne.IsChecked, whichStart, diffEnum, 6, 4);

            mangala.Closed += mangala_Closed;
            this.Components.Add(mangala);
            this.Components.Remove(start);
            mangala.Visible = true;
        }
        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);
            spriteBatch.Begin();
            spriteBatch.Draw(Global.TextureBackGround, new Rectangle(0, 0, ScreenWidth, ScreenHeigth), Color.White);

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
