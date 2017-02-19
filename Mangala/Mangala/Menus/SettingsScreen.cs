using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Arikan.GUI.Screens;
using Arikan.GUI.Components;

namespace Mangala
{
    class SettingsScreen : Screen
    {
        Label labelSpeed;
        Label labelSound;
        Label labelMusic;
        TrackBar trackSpeed;
        TrackBar trackSound;
        TrackBar trackMusic;
        Button buttonBack;

        public SettingsScreen(int w, int h)
            : base(0,0,w,h)
        {
            labelSpeed = new Label(Global.FontSkor, Color.Orange, 100, 100, "Oyun Hizi:");
            labelSound = new Label(Global.FontSkor, Color.Orange, 100, 200, "Ses          :");
            labelMusic = new Label(Global.FontSkor, Color.Orange, 100, 300, "Music      :");
            labelSpeed.Shadow = true;
            labelSound.Shadow = true;
            labelMusic.Shadow = true;
            trackSpeed = new TrackBar(Global.TextureButton, Global.TextureButton, Global.FontSkor, 300, 110, 300, 20, 50, 80, 11, 1, 10);
            trackSound = new TrackBar(Global.TextureButton, Global.TextureButton, Global.FontSkor, 300, 210, 300, 20, 50, 80, 10, 0, 5);
            trackMusic = new TrackBar(Global.TextureButton, Global.TextureButton, Global.FontSkor, 300, 310, 300, 20, 50, 80, 10, 0, 5);
            trackSpeed.Color = Color.Orange;
            trackSound.Color = Color.Orange;
            trackMusic.Color = Color.Orange;
            trackSpeed.BarColor = Color.Orange;
            trackSound.BarColor = Color.Orange;
            trackMusic.BarColor = Color.Orange;
            trackSpeed.Text = trackSpeed.Value.ToString();
            trackSound.Text = trackSound.Value.ToString();
            trackMusic.Text = trackMusic.Value.ToString();
            Global.Speed = 300 / trackSpeed.Value + 100;
            Global.Sound = (float)trackSound.Value / 10f;
            Global.Music = (float)trackMusic.Value / 10f;
            trackSpeed.ValueChanged += delegate { trackSpeed.Text = trackSpeed.Value.ToString(); Global.Speed = 300 / trackSpeed.Value + 100; };
            trackSound.ValueChanged += delegate { trackSound.Text = trackSound.Value.ToString(); Global.Sound = (float)trackSound.Value / 10f; };
            trackMusic.ValueChanged += delegate { trackMusic.Text = trackMusic.Value.ToString(); Global.Music = (float)trackMusic.Value / 10f; };

            buttonBack = new Button(Global.TextureButton, Global.FontMenu, w - 120, h - 50, 110, 40, "<-  Geri");
            buttonBack.ClickUp += delegate { this.Remove(); };

            Components.Add(labelSpeed);
            Components.Add(labelSound);
            Components.Add(labelMusic);
            Components.Add(trackSpeed);
            Components.Add(trackSound);
            Components.Add(trackMusic);
            Components.Add(buttonBack);
        }
    }
}
