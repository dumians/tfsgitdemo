using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Visifire.Charts;

namespace Visifire.Dashboards.ProductAndSales.Views
{
    public partial class ProductWiseSalesView : Page
    {
        #region Public Methods

        public ProductWiseSalesView()
        {
            // Required to initialize variables
            InitializeComponent();
            ChartProductWiseRevenue.Rendered += new EventHandler(ChartProductWiseRevenue_Rendered);

            this.Loaded += new RoutedEventHandler(ProductWiseSalesView_Loaded);
            StoryboardArrowAnimation.Completed += StoryboardArrowAnimation_Completed;
        }

        void StoryboardArrowAnimation_Completed(object sender, object e)
        {
            Storyboard storyboard = sender as Storyboard;
            storyboard.Stop();
            path.Opacity = 1;
            textBlock.Opacity = 1;
        }

        void ProductWiseSalesView_Loaded(object sender, RoutedEventArgs e)
        {
            StoryboardArrowAnimation.Begin();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Selected product
        /// </summary>
        public String SelectedProduct
        {   
            get
            {
                return (String)GetValue(SelectedProductProperty);
            }
            set
            {
                SetValue(SelectedProductProperty, value);
            }
        }

        /// <summary>
        /// Visifire.Dashboards.ProductAndSales.Views.ProductWiseSalesView.SelectedProductProperty
        /// </summary>
        public static readonly DependencyProperty SelectedProductProperty = DependencyProperty.Register
            ("SelectedProduct",
            typeof(String),
            typeof(ProductWiseSalesView), null);

        #endregion

        #region Private Methods

        /// <summary>
        /// On render event handler for the chart "ChartProductWiseRevenue"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartProductWiseRevenue_Rendered(object sender, EventArgs e)
        {
            HighlightSelectedProduct(null);
        }

        /// <summary>
        /// Select a Pie and Expload
        /// </summary>
        /// <param name="selectedDataPoint"></param>
        private void SelectOnlyOnePieSegment(DataPoint selectedDataPoint)
        {
            foreach (DataPoint dp in ChartProductWiseRevenue.Series[0].DataPoints)
            {
                if (selectedDataPoint != dp)
                    dp.Exploded = false;
                else
                    selectedDataPoint.Exploded = true;
            }

            HighlightSelectedProduct(selectedDataPoint);
        }

        /// <summary>
        /// Highlight the name of the selected product
        /// </summary>
        /// <param name="selectedDataPoint">Selected DataPoint</param>
        private void HighlightSelectedProduct(DataPoint selectedDataPoint)
        {
            if (selectedDataPoint == null)
            {
                foreach (DataPoint dp in ChartProductWiseRevenue.Series[0].DataPoints)
                {
                    if (Convert.ToBoolean(dp.Exploded) == true)
                    {
                        selectedDataPoint = dp;
                        break;
                    }
                }
            }

            if (selectedDataPoint == null)
                return;

        }

        #endregion

        private void Pie_DataSeries_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            DataPoint clickedDataPoint = sender as DataPoint;
            SelectedProduct = clickedDataPoint.AxisXLabel;
            SelectOnlyOnePieSegment(clickedDataPoint);
        }

        #region Data

        #endregion
    }
}