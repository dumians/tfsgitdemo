﻿using System;
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

namespace Visifire.Dashboards.ProductAndSales.BusinessObjects
{
    public class Order : Visifire.Dashboards.Commons.ModelBase
    {
        #region Public Methods

        /// <summary>
        /// Order
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="product">Product Id</param>
        /// <param name="licenseType">Type of license</param>
        /// <param name="withSupport">Whether the license-sold includes support option.</param>
        /// <param name="newLicense">Whether it is a new license</param>
        /// <param name="amount">Total amount</param>
        public Order(DateTime date, String product, String licenseType, Boolean withSupport, Boolean newLicense, Double amount)
        {   
            Date = date;
            Product = product;
            LicenseType = licenseType;
            NewLicense = newLicense;
            WithSupport = withSupport;
            Amount = amount;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Whether the license-sold includes support option.
        /// </summary>
        public Boolean WithSupport
        {   
            get
            {   
                return _withSupport;
            }
            set
            {   
                _withSupport = value;
                NotifyPropertyChanged("WithSupport");
            }
        }

        /// <summary>
        /// Amount in $
        /// </summary>
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

        /// <summary>
        /// Whether it is a new license
        /// </summary>
        public Boolean NewLicense
        {
            get
            {
                return _newLicense;
            }
            set
            {
                _newLicense = value;
                NotifyPropertyChanged("NewLicense");
            }
        }

        /// <summary>
        /// Product Id
        /// </summary>
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

        /// <summary>
        /// Type of license
        /// </summary>
        public String LicenseType
        {
            get
            {
                return _licenseType;
            }
            set
            {
                _licenseType = value;
                NotifyPropertyChanged("LicenseType");
            }
        }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public int TempValue
        {
            get;
            set;
        }

        #endregion

        #region Data

        Boolean _withSupport;
        Double _amount;
        Boolean _newLicense;
        String _product;
        String _licenseType;
        DateTime _date;
        
        #endregion
    }
}
