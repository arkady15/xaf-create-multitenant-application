﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.Persistent.Base;
using EditorAliases = OutlookInspired.Module.Services.EditorAliases;


namespace OutlookInspired.Module.BusinessObjects{
    [ImageName("BO_Quote")]
    public class Quote :MigrationBaseObject, IViewFilter{
        public  virtual string Number { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerStore CustomerStore { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public  virtual decimal SubTotal { get; set; }
        [DataType(DataType.Currency)]
        public  virtual decimal ShippingAmount { get; set; }
        [DataType(DataType.Currency)]
        public  virtual decimal Total { get; set; }
        [EditorAlias(EditorAliases.ProgressEditor)]
        public virtual  double Opportunity { get; set; }
        [DevExpress.ExpressApp.DC.Aggregated]
        public virtual ObservableCollection<QuoteItem> QuoteItems{ get; set; } = new();
    }



}