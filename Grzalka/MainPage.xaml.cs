using Windows.UI.Xaml.Controls;

namespace Grzalka
{
    public sealed partial class MainPage : Page
    {
        double temp = 0;
        double hotTemp = 0;
        double coldTemp = 0;
        public MainPage()
        {
            InitializeComponent();
            HotTS.IsOn = false;
            ColdTS.IsOn = false;
            BlueRect.Fill.Opacity = 0;
            RedRect.Fill.Opacity = 0;
        }

        private void HotTS_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (HotTS.IsOn)
            {
                HotSlider.Visibility = Windows.UI.Xaml.Visibility.Visible;
                hotTemp = HotSlider.Value;
            }
            else
            {
                HotSlider.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hotTemp = 0;
            }
            countTemp();
        }

        private void ColdTS_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ColdTS.IsOn)
            {
                ColdSlider.Visibility = Windows.UI.Xaml.Visibility.Visible;
                coldTemp = ColdSlider.Value;
            }
            else
            {
                ColdSlider.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                coldTemp = 0;
            }
            countTemp();
        }

        private void ColdSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            coldTemp = ColdSlider.Value;
            countTemp();
        }

        private void HotSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            hotTemp = HotSlider.Value;
            countTemp();
        }

        void countTemp()
        {
            temp = hotTemp - coldTemp;
            if(temp > 0)
            {
                RedRect.Fill.Opacity = temp / 100;
                BlueRect.Fill.Opacity = 0;
            }
            else
            {
                RedRect.Fill.Opacity = 0;
                BlueRect.Fill.Opacity = (-temp) / 100;
            }
            temperaturePB.Value = temp;
        }
    }
}
