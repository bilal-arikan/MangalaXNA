using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Arikan.GUI.Components;

namespace Mangala
{
    class Player : DrawableGameComponent
    {
        public List<Hole> Holes = new List<Hole>();
        public int Index = 0;
        public bool OurTurn = false;
        public Label labelName;
        public Label labelNameShadow;
        public Color Color
        {
            get { return HomeHole.ReleaseColor; }
            set
            {
                foreach (Hole h in Holes)
                {
                    h.ReleaseColor = value;
                }
            }
        }
        public Hole HomeHole
        {
            get { return Holes[Holes.Count - 1]; }
        }
        public String Name
        {
            get { return labelName.Text; }
        }
        public delegate void ThinkEvent1(object sender);
        public event ThinkEvent1 Think;
        public Player(int smallHoleCount,int stoneCount, int Width, int Heigth, Color color,bool up,String name)
            : base(Arikan.GUI.GUISet.Game)
        {
            int block = (int)((float)Width / (float)((smallHoleCount + 2) * 4 + smallHoleCount + 4));
            int difference = 0;


            if (!up){
                difference = 4 * block;
                for (int i = 1; i <= smallHoleCount; i++)
                {
                    Holes.Add(new Hole(Global.TextureHole, Global.FontSkor, stoneCount,
                         Width - (1 + (i * 5)) * block -5*block, Heigth / 2 - difference - 2 * block, 4 * block, 4 * block, color));
                }
                Holes.Add(new Hole(Global.TextureHole, Global.FontSkor, 0,
                   block, Heigth / 2 - difference - 2 * block, 4 * block, 12 * block, color));
                labelName = new Label( Global.FontMenu, color, block, Heigth / 2 - 8 * block, name);
                labelNameShadow = new Label( Global.FontMenu, Color.Black, block + 1, Heigth / 2 - 8 * block + 1, name);
            }
            else{
                difference = -4 * block;
                for (int i = 1; i <= smallHoleCount; i++)
                {
                    Holes.Add(new Hole(Global.TextureHole, Global.FontSkor, stoneCount,
                       (1 + (i * 5)) * block, Heigth / 2 - difference - 2 * block, 4 * block, 4 * block, color));
                }
                Holes.Add(new Hole(Global.TextureHole, Global.FontSkor, 0,
                    (6 + (smallHoleCount * 5)) * block, Heigth / 2 - difference - 2 * block - 8 * block, 4 * block, 12 * block, color));
                labelName = new Label( Global.FontMenu, color, Width - block - 150, Heigth / 2 + 6 * block, name);
                labelNameShadow = new Label( Global.FontMenu, Color.Black, Width - block - 150 + 1, Heigth / 2 + 6 * block +1, name);

            }

            this.EnabledChanged +=Player_EnabledChanged;
        }

        private void Player_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled){
                foreach (Hole h in Holes)
                {
                    h.Enabled = true;

                }
                if(Think != null)
                    Think(this);
            }
            else
                foreach (Hole h in Holes)
                {
                    h.Enabled = false;
                }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Hole h in Holes)
            {
                h.Update(gameTime);
            }
            labelName.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Hole h in Holes)
            {
                h.Draw(gameTime);
            }
            labelNameShadow.Draw(gameTime);
            labelName.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
