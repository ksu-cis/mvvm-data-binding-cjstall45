using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CashRegister;

namespace MVVMDataBinding
{
    public class CashRegisterModleView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// the CashDrawer this class uses
        /// </summary>
        CashDrawer drawer = new CashDrawer();
        /// <summary>
        /// total current value of the drawer
        /// </summary>
        public double TotalValue => drawer.TotalValue;

        public int Pennies
        {
            get => drawer.Pennies;

            set
            {
                if (drawer.Pennies == value|| value < 0) return;
                var quantity = value - drawer.Pennies;
                if (quantity > 0) drawer.AddCoin(Coins.Penny, quantity);
                else drawer.RemoveCoin(Coins.Penny, -quantity);
                invokePropertyChanged("Pennies");
                
            }
        }


        void invokePropertyChanged(string demonination)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(demonination));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }
    }
}
