using Microsoft.VisualStudio.DesignTools.Extensibility.Interaction;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace CustomControlLibrary.DesignTools
{
    class BGAdornerProvider : PrimarySelectionAdornerProvider
    {
        AdornerPanel PanelForAdorners;
        ModelItem AdornedControl;

        private Slider redColorSlider;
        private Slider blueColorSlider;
        private Slider greenColorSlider;

        double Red = 0;
        double Green = 0;
        double Blue = 0;

        public BGAdornerProvider()
        {
            PanelForAdorners = new AdornerPanel();

            redColorSlider = new Slider();
            blueColorSlider = new Slider();
            greenColorSlider = new Slider();

            redColorSlider.ValueChanged += SliderValueChanged;
            blueColorSlider.ValueChanged += SliderValueChanged;
            greenColorSlider.ValueChanged += SliderValueChanged;

            redColorSlider.PreviewMouseLeftButtonUp += MouseUp;
            blueColorSlider.PreviewMouseLeftButtonUp += MouseUp;
            greenColorSlider.PreviewMouseLeftButtonUp += MouseUp;
        }

        private void MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Brush newColor = new SolidColorBrush(Color.FromRgb((byte)Red, (byte)Green, (byte)Blue));
            ModelProperty Background = AdornedControl.Properties["Background"];
            Background.SetValue(newColor);

            MessageBox.Show(newColor.ToString());
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Red = redColorSlider.Value;
            Green = greenColorSlider.Value;
            Blue = blueColorSlider.Value;
        }

        protected override void Activate(ModelItem item)
        {
            AdornedControl = item;
            redColorSlider.Minimum = blueColorSlider.Minimum = greenColorSlider.Minimum = 0;
            redColorSlider.Maximum = blueColorSlider.Maximum = greenColorSlider.Maximum = 255;

            ConfigureSlider(redColorSlider);
            ConfigureSlider(blueColorSlider);
            ConfigureSlider(greenColorSlider);

            Adorners.Add(PanelForAdorners);

            AdornerPlacementCollection redPlacement = ConfigurePlacements(0);
            AdornerPlacementCollection bluePlacement = ConfigurePlacements(20);
            AdornerPlacementCollection greenPlacement = ConfigurePlacements(40);

            AdornerPanel.SetPlacements(redColorSlider, redPlacement);
            AdornerPanel.SetPlacements(blueColorSlider, bluePlacement);
            AdornerPanel.SetPlacements(greenColorSlider, greenPlacement);

            base.Activate(item);
        }

        private void ConfigureSlider(Slider slider)
        {
            PanelForAdorners.Children.Add(slider);
            AdornerPanel.SetHorizontalStretch(slider, AdornerStretch.Stretch);
            AdornerPanel.SetVerticalStretch(slider, AdornerStretch.None);
        }
        private AdornerPlacementCollection ConfigurePlacements(double distance)
        {
            AdornerPlacementCollection placement = new AdornerPlacementCollection();
            placement.SizeRelativeToContentWidth(1.0, 0);
            placement.SizeRelativeToAdornerDesiredHeight(1.0, 0);
            placement.PositionRelativeToAdornerHeight(-1.0, -distance);
            return placement;
        }
    }
}
