using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.DeliveryAddress;

namespace Website.Library.Classes
{
    public class DeliveryAddressEventArgs : EventArgs
    {
        private DeliveryAddress _address;

        public DeliveryAddressEventArgs(DeliveryAddress Address)
        {
            _address = Address;
        }

        public DeliveryAddress Address
        {
            get
            {
                return (_address);
            }
        }
    }

    public delegate void SelectAddressDelegate(object sender, DeliveryAddressEventArgs e);
}
