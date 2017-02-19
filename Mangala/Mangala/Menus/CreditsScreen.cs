using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Arikan.GUI.Screens;
using Arikan.GUI.Components;

namespace Mangala
{
    class CreditsScreen : Screen
    {
        Label label1;
        Label label2;
        public Button buttonBack;

        public CreditsScreen(int w,int h)
            : base(0,0,w,h)
        {
            label1 = new Label( Global.FontMenu, Color.Orange, 100, 200, "Yapimci:   Bilal ARIKAN");
            label2 = new Label( Global.FontMenu, Color.Orange, 50, 250, "Kurallar:  Ayrintili bilgi www.mangala.com.tr sitesinde mevcuttur.");
            label1.Shadow = true;
            label2.Shadow = true;
            buttonBack = new Button( Global.TextureButton, Global.FontMenu, w - 120, h - 50, 110, 40, "<-  Geri");
            buttonBack.ClickUp += delegate { this.Remove(); };

            Components.Add(label1);
            Components.Add(label2); 
            Components.Add(buttonBack);
        }
    }
}
