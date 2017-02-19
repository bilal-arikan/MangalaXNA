using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Arikan.GUI.Screens;
using Arikan.GUI.Components;

namespace Mangala
{
    class MenuScreen : Screen
    {
        int Width = 0;
        int Heigth = 0;

        public Button buttonOnePlayer;
        public Button buttonTwoPlayer;
        public Button buttonAlternative;
        public Button buttonSettings;
        public Button buttonCredits;
        public Button buttonExit;

        public MenuScreen(int w, int h)
            : base(0,0,w,h)
        {
            Width = w;
            Heigth = h;
        }

        public override void Initialize()
        {

            int buttonH = 50;
            int ara = 10;
            buttonOnePlayer = new Button(Global.TextureButton, Global.FontMenu, 20, (buttonH + ara), 250, buttonH, "Tek Oyuncu");
            buttonTwoPlayer = new Button(Global.TextureButton, Global.FontMenu, 20, 2 * (buttonH + ara), 250, buttonH, "Cift Oyuncu");
            buttonAlternative = new Button(Global.TextureButton, Global.FontMenu, 20, 3 * (buttonH + ara), 250, buttonH, "Alternatif Oyun");
            buttonSettings = new Button(Global.TextureButton, Global.FontMenu, 20, 4 * (buttonH + ara), 250, buttonH, "Ayarlar");
            buttonCredits = new Button(Global.TextureButton, Global.FontMenu, 20, 5 * (buttonH + ara), 250, buttonH, "Yapimci");
            buttonExit = new Button(Global.TextureButton, Global.FontMenu, 20, 6 * (buttonH + ara), 250, buttonH, "Cikis");
            //buttonOnePlayer.Enabled = false;
            this.Components.Add(buttonOnePlayer);
            this.Components.Add(buttonTwoPlayer);
            this.Components.Add(buttonAlternative);
            this.Components.Add(buttonSettings);
            this.Components.Add(buttonCredits);
            this.Components.Add(buttonExit);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            
            base.LoadContent();

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        

    }
}
