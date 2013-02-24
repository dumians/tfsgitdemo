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
using Windows.UI.Xaml.Navigation;

namespace Visifire.Dashboards.ProductAndSales.ViewModels
{
    public class ProductWiseRevenueInfo : Visifire.Dashboards.Commons.ModelBase
    {
        public Double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        public Boolean Exploded
        {   
            get
            {
                return _exploded;
            }
            set
            {
                _exploded = value;
                NotifyPropertyChanged("Exploded");
            }
        }

        public String Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                NotifyPropertyChanged("Product");
            }
        }

        Double _amount;
        Boolean _exploded;
        String _product;       
    }
}
