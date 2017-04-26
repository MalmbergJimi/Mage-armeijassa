﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace mage
{
    public sealed partial class Kivi : UserControl
    {

        public double LocationX { get; set; }   // Rynkyllä sijainti X
        public double LocationY { get; set; } // Rynkyllä sijainti Y
        public Kivi()
        {
            this.InitializeComponent();
            Width = 80; Height = 40;
        }

        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}