using System;
using Xamarin.Forms;

namespace FitToSizeClock
{
    public class FitToSizeClockPage : ContentPage
    {
  
        public FitToSizeClockPage()
        {
            Label clockLabel = new Label
            {
                //added background and text color to the clock app
                BackgroundColor = Color.Black,
                TextColor = Color.IndianRed,
                HorizontalOptions = LayoutOptions.Center,    
                VerticalOptions = LayoutOptions.Center
            };


            Content = clockLabel;

            // Handle the SizeChanged event for the page.
            SizeChanged += (object sender, EventArgs args) =>
                {
                    // Scale the font size to the page width
                    //      (based on 11 characters in the displayed string).
                    if (this.Width > 0)
                        //made a change tot he FontSize width to 12 halfing original
                        clockLabel.FontSize = this.Width / 12;
                };

            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(.15), () =>
                {
                    // Set the Text property of the Label.
                    // Attempted to do miliseconds, but could not get the right timing on the response to look good
                    clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                    return true;
                });
        }
    }
}
