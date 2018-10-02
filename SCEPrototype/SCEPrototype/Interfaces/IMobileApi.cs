using SCEPrototype.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCEPrototype.Interfaces
{
    public interface IMobileApi
    {
        //Task<bool> Login(string email, string password);
        //IList<Borrower> GetBorrowers();
        //IList<Borrower> GetBorrowers(string FilterType);
        Task<List<Outage>> GetOutages();
        Task InsertOutage(Outage outage);
        Task UpdateOutage(Outage outage);
    }
}

   