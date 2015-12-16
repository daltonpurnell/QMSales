using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMSales
{
    /// <summary>
    /// The Address Book Information interface.
    /// </summary>
    public interface IAddressBookInformation
    {
        Task<List<QMSalesContact>> GetContacts();

		void DisplayContactScreen ();

    }
}
