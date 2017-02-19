using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Mangala
{
    static class Global
    {
        public static Texture2D TextureButton;
        public static Texture2D TextureBoard;
        public static Texture2D TextureBackGround;
        public static Texture2D TextureHole;
        public static SpriteFont FontSplash;
        public static SpriteFont FontMenu;
        public static SpriteFont FontSkor;
        public static SoundEffect SoundMove;
        public static SoundEffect SoundClick;
        public static SoundEffect SoundWin;
        public static SoundEffect SoundLose;

        public static void LoadContent(Game game)
        {
            TextureButton = game.Content.Load<Texture2D>("brick1");
            TextureBoard = game.Content.Load<Texture2D>("Board2");
            TextureBackGround = game.Content.Load<Texture2D>("Background");
            TextureHole = game.Content.Load<Texture2D>("circle_grey");
            FontSplash = game.Content.Load<SpriteFont>("SplashFont");
            FontMenu = game.Content.Load<SpriteFont>("MenuFont");
            FontSkor = game.Content.Load<SpriteFont>("SkorFont");
            SoundMove = game.Content.Load<SoundEffect>("Boing");
            SoundClick = game.Content.Load<SoundEffect>("Swordswi");
            SoundWin = game.Content.Load<SoundEffect>("music4");
            SoundLose = game.Content.Load<SoundEffect>("Lose");

        }

        public static int Speed = 300;
        public static float Music = 0.5f;
        public static float Sound = 0.2f;
    }
}
