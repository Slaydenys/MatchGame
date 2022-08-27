﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsofSecondsElapsed;
        int matshesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsofSecondsElapsed++;
            TimeTextBlock.Text = (tenthsofSecondsElapsed / 10F).ToString("0.0s");
            if(matshesFound == 8)
            {
                timer.Stop();
                TimeTextBlock.Text = TimeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐙","🐙",

                "🐡","🐡",

                "🐘","🐘",

                "🐳","🐳",

                "🐪","🐪",

                "🦕","🦕",

                "🦙","🦙",

                "🐷","🐷",

            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if(textBlock.Name != "TimeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);

                    string nextEmoji = animalEmoji[index];

                    textBlock.Text = nextEmoji;

                    animalEmoji.RemoveAt(index);
                }
               

            }

            timer.Start();
            tenthsofSecondsElapsed = 0;
            matshesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool finddingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (finddingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                finddingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matshesFound++;
                textBlock.Visibility = Visibility.Hidden;
                finddingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                finddingMatch = false;
            }

        }


        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (matshesFound == 8)
            {
                SetUpGame();
            }
            {
            }
            {


            }
        }
    }
}

