using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Arikan.GUI.Components;
using Arikan.GUI.Screens;

namespace Mangala
{
    class SplashScreen : Screen
    {
        int Width = 0;
        int Heigth = 0;

        Label gameName;
        Label gameNameS;
        public ProgressBar progress1;

        public SplashScreen(int w,int h)
            : base(0,0,w,h)
        {
            Width = w;
            Heigth = h;
        }

        public override void Initialize()
        {
            gameName = new Label(
                Global.FontSplash,
                Color.SteelBlue,
                20, 20, "MANGALA");
            gameNameS = new Label(
                Global.FontSplash,
                Color.DarkGray,
                25, 25, "MANGALA");
            progress1 = new ProgressBar(
                Global.TextureButton,
                Global.TextureButton,
                Global.FontSplash,
                20,
                Heigth - 60,
                Width - 40,
                40,
                3,
                100, 0, 0);
            this.Components.Add(gameNameS);
            this.Components.Add(gameName);
            this.Components.Add(progress1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > 3)
                this.Remove();

            base.Update(gameTime);
        }
    }
}
