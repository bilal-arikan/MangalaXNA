using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Arikan.GUI.Components;
using Arikan.GUI.Screens;

namespace Mangala
{
    class Hole : Button
    {
        int stones = 0;

        public int Stones
        {
            get { return stones; }
            set { 
                stones = value;
                this.Text = value.ToString();
            }
        }
        
        public Hole(Texture2D tex,SpriteFont font,int stones,int x, int y, int w, int h,Color color)
            : base(tex, font, x, y, w, h)
        {
            Stones = stones;
            this.ReleaseColor = color;
            //this.EnabledChanged += Hole_EnabledChanged;

        }

 /*       void Hole_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
                this.Color = Color.WhiteSmoke;
            else
                this.Color = ReleaseColor;
        }
*/
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
