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
using IoTHelpers.Gpio.Modules;          //added for access to gpio
using System.Threading.Tasks;

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Sr04UltrasonicDistanceSensor ultrasonic;
        public dynamic distance;
        public MainPage() 
        {
            this.InitializeComponent();
            ultrasonic = new Sr04UltrasonicDistanceSensor(triggerPinNumber: 12, echoPinNumber: 16);
            ultrasonic.DistanceChanged += ultrasonic_DistanceChanged;
                        
        }

        public void ultrasonic_DistanceChanged(object sender, EventArgs e)
        {
         
            double? dist = ultrasonic.GetDistance();
            distance = dist.ToString();

        }



    }
}