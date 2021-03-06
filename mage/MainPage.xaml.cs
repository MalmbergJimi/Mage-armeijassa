﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Luodaan magehahmo
        private Magehahmo magehahmo;
        // Luodaan Listat joihin oliot laitetaan
        private List<Tellu> tellut;
        private List<Maata> maat;
        private List<Maapala> maapalat;
        private List<Skappari> skapparit;
        private List<Isomaapala> isotpalat;
        private List<Auto> autot;
        private List<Rynkky> rynkyt;
        private List<Kivi> kivet;

        //Rynkkylöydetty
        private bool rynkkyloydetty = false;
        // Laitetaan muuttujiin mitkä näppäimet ovat painettuina tai päästettyinä
        private bool UpPressed;
        private bool LeftPressed;
        private bool RightPressed;

        // Luodaan ajastin
        private DispatcherTimer timer;

        //Ääni
        private MediaElement mediaElement;
        private MediaElement mediaElement2;
        private MediaElement mediaElement3;
        private MediaElement mediaElement4;
        private MediaElement mediaElement5;

        // Taustamusiikki
        public MainPage()
        {
            this.InitializeComponent();

            
            // Vaihdetaan oletus StartUp mode
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            //FPS Mittari pois
            App.Current.DebugSettings.EnableFrameRateCounter = false;

            magehahmo = new Magehahmo
            {
                LocationX = 0,     // Määritetään magehahmon aloitussijainti
                LocationY = 520,
                Jumping = false                
            };

            //Kivi lista
            kivet = new List<Kivi>();
            Kivi kivi = new Kivi();
            kivet.Add(kivi);
            kivi.LocationX = 0; kivi.LocationY = 650;
            kivi.SetLocation();

            // MAAT LISTA
            maat = new List<Maata>();
            // Luodaan maa1
            Maata maa1 = new Maata();
            maat.Add(maa1);
            maa1.LocationX = 0; maa1.LocationY = 650;
            maa1.SetLocation();
            
            // Luodaan MAAPALA!
            //Lista
            maapalat = new List<Maapala>();
            //Palat
            Maapala mpala1 = new Maapala();
            maapalat.Add(mpala1);
            mpala1.LocationX = 100; mpala1.LocationY = 620;
            mpala1.SetLocation();
            //Palat
            Maapala mpala2 = new Maapala();
            maapalat.Add(mpala2);
            mpala2.LocationX = 150; mpala2.LocationY = 620;
            mpala2.SetLocation();
            //Palat
            Maapala mpala3 = new Maapala();
            maapalat.Add(mpala3);
            mpala3.LocationX = 200; mpala3.LocationY = 620;
            mpala3.SetLocation();
            //Pala4
            Maapala mpala4 = new Maapala();
            maapalat.Add(mpala4);
            mpala4.LocationX = 550; mpala4.LocationY = 620;
            mpala4.SetLocation();
            //Pala5
            Maapala mpala5 = new Maapala();
            maapalat.Add(mpala5);
            mpala5.LocationX = 930; mpala5.LocationY = 620;
            mpala5.SetLocation();

            // LUODAAN ISO MAAPALA
            isotpalat = new List<Isomaapala>();
            //Isotpalat
            Isomaapala isopala1 = new Isomaapala();
            //Isopala1
            isotpalat.Add(isopala1);
            isopala1.LocationX = 200;
            isopala1.LocationY = 570;
            isopala1.SetLocation();
            //Isopala2
            Isomaapala isopala2 = new Isomaapala();
            isotpalat.Add(isopala2);
            isopala2.LocationX = 450;
            isopala2.LocationY = 570;
            isopala2.SetLocation();
            //Isopala3
            Isomaapala isopala3 = new Isomaapala();
            isotpalat.Add(isopala3);
            isopala3.LocationX = 1060;
            isopala3.LocationY = 570;
            isopala3.SetLocation();

            // Luodaan skapparit lista
            skapparit = new List<Skappari>();
            // Luodaan skappari            
            Skappari skappari1 = new Skappari();
            skapparit.Add(skappari1);
            skappari1.LocationX = 610; skappari1.LocationY = 570;
            skappari1.SetLocation();

            //Luodaan autot lista
            autot = new List<Auto>();
            //Luodaan autot
            Auto auto1 = new Auto();
            auto1.LocationX = 670; auto1.LocationY = 545;
            auto1.SetLocation();
            autot.Add(auto1);

            // Luodaan Rynkkylista
            rynkyt = new List<Rynkky>();
            // Luodaan Rynkky1
            Rynkky rynkky1 = new Rynkky();
            rynkyt.Add(rynkky1);
            rynkky1.LocationX = 1160; rynkky1.LocationY = 640;
            rynkky1.SetLocation();

            // alustetaan tellulista
            tellut = new List<Tellu>();
            // Luodaan Tellu1
            Tellu tellu1 = new Tellu();
            tellut.Add(tellu1);
            tellu1.LocationX = 300; tellu1.LocationY = 650;
            tellu1.SetLocation();
            // Luodaan Tellu2
            Tellu tellu2 = new Tellu();
            tellut.Add(tellu2);
            tellu2.LocationX = 160; tellu2.LocationY = 610;
            tellu2.SetLocation();
            // Luodaan Tellu3
            Tellu tellu3 = new Tellu();
            tellut.Add(tellu3);
            tellu3.LocationX = 860; tellu3.LocationY = 650;
            tellu3.SetLocation();
            // Luodaan Tellu4
            Tellu tellu4 = new Tellu();
            tellut.Add(tellu4);
            tellu4.LocationX = 1010; tellu4.LocationY = 650;
            tellu4.SetLocation();

            // Lisätään magehahmo ja muut oliot Canvakselle
            //Kivi
            MyCanvas.Children.Add(kivi);
            //Mage
            MyCanvas.Children.Add(magehahmo);
            //MAA
            MyCanvas.Children.Add(maa1);           
            //MAAPALAT
            MyCanvas.Children.Add(mpala1);
            MyCanvas.Children.Add(mpala2);
            MyCanvas.Children.Add(mpala3);
            MyCanvas.Children.Add(mpala4);
            MyCanvas.Children.Add(mpala5);
            //TELLUT
            MyCanvas.Children.Add(tellu1);
            MyCanvas.Children.Add(tellu2);
            MyCanvas.Children.Add(tellu3);
            MyCanvas.Children.Add(tellu4);
            //Autot
            MyCanvas.Children.Add(auto1);
            //SKAPPARIT
            MyCanvas.Children.Add(skappari1);
            //RYNKKY
            MyCanvas.Children.Add(rynkky1);
            //ISOT PALAT
            MyCanvas.Children.Add(isopala1);
            MyCanvas.Children.Add(isopala2);
            MyCanvas.Children.Add(isopala3);
            

            // Key Listeners,   näppäimien kuuntelua, onko jokin painettuna vai ei?
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;  // Onko näppäimi alhaalla
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp; //Onko näppäimiä "ylhäällä"

            // ladataan äänet
            LoadAudio();
            LoadAudio2();
            LoadAudio3();
            LoadAudio4();
            LoadAudio5();
            // Start game loop,     PELI LÄHTEE HETI KÄYNTIIN
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        //ladataan audio VOITTO-musiikiksi
        private async void LoadAudio5()
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("winwin.mp3");
            var stream = await file.OpenAsync(FileAccessMode.Read);

            mediaElement5 = new MediaElement();      // Ladataan audio valmiiksi muistiin, mutta ei vielä soiteta
            mediaElement5.AutoPlay = false;
            mediaElement5.SetSource(stream, file.ContentType);
        }

        //ladataan audio EPÄONNISTUMIS-musiikiksi
        private async void LoadAudio4()
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("fail-trombone-01.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            
            mediaElement4 = new MediaElement();      // Ladataan audio valmiiksi muistiin, mutta ei vielä soiteta
            mediaElement4.AutoPlay = false;
            mediaElement4.SetSource(stream, file.ContentType);
        }

        //ladataan audio TAUSTA-musiikiksi
        private async void LoadAudio3()
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("marssi.mp3");
            var stream = await file.OpenAsync(FileAccessMode.Read);

            mediaElement3 = new MediaElement();      // Ladataan audio
            mediaElement3.AutoPlay = true;          // Taustamusiikki lähtee heti soimaan
            mediaElement3.SetSource(stream, file.ContentType);
        }
        //ladataan audio SKAPPARIIN törmäystä varten
        private async void LoadAudio2()
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("rage.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);

            mediaElement2 = new MediaElement();      // Ladataan audio valmiiksi muistiin, mutta ei vielä soiteta
            mediaElement2.AutoPlay = false;
            mediaElement2.SetSource(stream, file.ContentType);
        }

        //ladataan audio TELLUUN törmäystä varten
        private async void LoadAudio()
        {
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("tellu.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);

            mediaElement = new MediaElement();      // Ladataan audio valmiiksi muistiin, mutta ei vielä soiteta
            mediaElement.AutoPlay = false;
            mediaElement.SetSource(stream, file.ContentType);
        }

        // KeyUp haistelu
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)    // Tutkii tableteilta, puhelimilta, koneilta
            {
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
            }
        }
        // KeyDown haistelu
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)    // Tutkii tableteilta, puhelimilta, koneilta
            {
                case VirtualKey.Up:
                    UpPressed = true;
                    magehahmo.Jumping = true;
                    break;
                case VirtualKey.Left:
                    LeftPressed = true;
                    //Käännetään magehahmo kun kävellään VASEMMALLE
                    ScaleTransform scaleLeft = new ScaleTransform();
                    scaleLeft.ScaleX = -1;
                    scaleLeft.CenterX = 30;
                    magehahmo.RenderTransform = scaleLeft;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    //Käännetään magehahmo kun kävellään OIKEALLE
                    ScaleTransform scaleRight = new ScaleTransform();
                    scaleRight.ScaleX = 1;
                    scaleRight.CenterX = 30;
                    magehahmo.RenderTransform = scaleRight;
                    break;
            }
        }
        //Peli luuppi
        private void Timer_Tick(object sender, object e)
        {           
            // Liikutetaan magehahmoa jos painettu näppäimiä 
            if (LeftPressed) magehahmo.MoveLeft();
            if (RightPressed) magehahmo.MoveRight();
            if (UpPressed) magehahmo.Jump();

            // magehahmon paikka Canvaksella päivitetään
            magehahmo.SetLocation();
            // Collision, törmääkö mihinkään
            CheckCollision();
        }
        // BUTTON ETUSIVULLE SIIRTYMISEEN
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Etusivu));
            mediaElement3.Pause();  // Lopetetaan pelin taustamusiikki kun siirrytään etusivulle     
        }        
        private void CheckCollision()
        {            
            // Käydään läpi TELLU-LISTA
            foreach (Tellu tellu in tellut)
            {
                // Get Rects, katsotaan osuuko mikään tellulistan telluista magehahmoon
                Rect BRect = new Rect(                                               
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight // magehahmon sijainti ja koko
                    );
                Rect FRect = new Rect(                                              
                    tellu.LocationX, tellu.LocationY, tellu.ActualWidth, tellu.ActualHeight // Tellun sijainti ja koko
                    );
                // Törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    // Poistetaan tellu Canvakselta
                    MyCanvas.Children.Remove(tellu);
                    // Poistetaan myös listasta tellu
                    tellut.Remove(tellu);
                    mediaElement4.Play();
                    mediaElement.Play();
                    mediaElement3.Pause();
                    timer.Stop();
                    Frame.Navigate(typeof(Havisit_tellu));  // Kun Telluun osutaan, siirrytään "Havisit"-sivulle                    
                    break;
                }
            }
            // Käydään läpi MAAT-lista
            foreach (Maata maa in maat)
            {
                // Get Rects, katsotaan osuuko mikään magehahmoon
                Rect BRect = new Rect(                                              
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight // magehahmon sijainti ja koko
                    );
                Rect FRect = new Rect(                                               
                    maa.LocationX, maa.LocationY, maa.ActualWidth, maa.ActualHeight // Maan sijainti ja koko
                    );
                // Törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    magehahmo.Jumping = false;                    
                    break;
                }
                else
                {
                    magehahmo.LocationY = magehahmo.LocationY + 20;
                    break;
                }
            }
            // Käydään läpi MAAPALAT-lista
            foreach (Maapala mpala in maapalat)
            {
                // Get Rects, katsotaan osuuko mikään Maapalat-listasta magehahmoon
                Rect BRect = new Rect(                                              
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight // magehahmon sijainti ja koko
                    );
                Rect FRect = new Rect(                                               
                    mpala.LocationX, mpala.LocationY, mpala.ActualWidth, mpala.ActualHeight // Maapalan sijainti ja koko
                    );
                // Ttörmääkö objektit
                
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    // Collision! Alue ei ole tyhjä
                    magehahmo.Jumping = false; 
                    magehahmo.LocationY = 720 - mpala.Height - magehahmo.Height - 50;
                    magehahmo.SetLocation();
                    // maapalat.Remove(mpala);
                    magehahmo.Jumping = false;
                    break;
                }
            }
            //Käydään läpi Isotmaapalat lista            
            foreach(Isomaapala isopala in isotpalat)
            {
                Rect BRect = new Rect(                                               // magehahmon sijainti ja koko
                   magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight
                   );
                Rect FRect = new Rect(                                               // Tellun sijainti ja koko
                    isopala.LocationX, isopala.LocationY, isopala.ActualWidth, isopala.ActualHeight
                    );

                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    // Collision! Area isn't empty, törmäys - alue ei ole tyhjä
                    magehahmo.Jumping = false;
                    Debug.WriteLine(BRect);
                    magehahmo.LocationY = 720 - isopala.Height - magehahmo.Height - 50;
                    magehahmo.SetLocation();
                    magehahmo.Jumping = false;
                    break;
                }
            }
  
            // Käydään läpi SKAPPARIT-lista
            foreach (Skappari skappari in skapparit)
            {
                // Get Rects, katsotaan osuuko mikään skapparit listasta magehahmoon
                Rect BRect = new Rect(                                               // magehahmon sijainti ja koko
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight
                    );
                Rect FRect = new Rect(                                               // Tellun sijainti ja koko
                    skappari.LocationX, skappari.LocationY, skappari.ActualWidth, skappari.ActualHeight
                    );
                // Does objects intersects, törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    // Collision! Area isn't empty, törmäys - alue ei ole tyhjä
                    MyCanvas.Children.Remove(skappari);
                    // Poistetaan myös listasta skappari
                    skapparit.Remove(skappari);
                    mediaElement4.Play();
                    mediaElement2.Play();
                    mediaElement3.Pause();
                    timer.Stop();
                    Frame.Navigate(typeof(Havisit));  // Kun Telluun osutaan, siirrytään "Havisit"-sivulle
                    break;
                }
            }
            // Käydään läpi AUTOT-lista
            foreach (Auto auto in autot)
            {
                // Get Rects, katsotaan osuuko mikään Auto magehahmoon
                Rect BRect = new Rect(                                               
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight // magehahmon sijainti ja koko
                    );
                Rect FRect = new Rect(                                               
                    auto.LocationX, auto.LocationY, auto.ActualWidth, auto.ActualHeight // Auton sijainti ja koko
                    );
                // Does objects intersects, törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty)
                {
                    // Collision! Area isn't empty, törmäys - alue ei ole tyhjä
                    magehahmo.Jumping = false;
                    Debug.WriteLine(BRect);
                    magehahmo.LocationY = 720 - auto.Height - magehahmo.Height - 50;
                    // magehahmo.LocationY = BRect.Y - magehahmo.Height + 20;
                    //magehahmo.LocationX = BRect.X;
                    magehahmo.SetLocation();
                    magehahmo.Jumping = false;
                    break;
                }
            }

            // Käydään läpi RYNKYT-lista
            foreach (Rynkky rynkky in rynkyt)
            {
                // Get Rects, katsotaan osuuko mikään tellulistan telluista magehahmoon
                Rect BRect = new Rect(                                               // magehahmon sijainti ja koko
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight
                    );
                Rect FRect = new Rect(                                               // Tellun sijainti ja koko
                    rynkky.LocationX, rynkky.LocationY, rynkky.ActualWidth, rynkky.ActualHeight
                    );
                // Does objects intersects, törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    rynkkyloydetty = true;
                    // Collision! Area isn't empty, törmäys - alue ei ole tyhjä
                    MyCanvas.Children.Remove(rynkky);
                    break;
                }
            }
            foreach (Kivi kivi in kivet)
            {
                // Get Rects, katsotaan osuuko mikään magehahmoon
                Rect BRect = new Rect(                                               
                    magehahmo.LocationX, magehahmo.LocationY, magehahmo.ActualWidth, magehahmo.ActualHeight // magehahmon sijainti ja koko
                    );
                Rect FRect = new Rect(                                               
                    kivi.LocationX, kivi.LocationY, kivi.ActualWidth, kivi.ActualHeight // Kiven sijainti ja koko
                    );
                // Törmääkö objektit
                BRect.Intersect(FRect);
                if (!BRect.IsEmpty) // Jos palautettu arvo EI OLE TYHJÄ
                {
                    if (rynkkyloydetty == true){


                        mediaElement3.Pause();
                        mediaElement5.Play();
                        timer.Stop();
                        Frame.Navigate(typeof(Voitit));  // Kun Kiveen osutaan, siirrytään "Voitit"-sivulle
                    }
                    break;
                }
                
            }
        }
    }
}