using SCEPrototype.Interfaces;
using SCEPrototype.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCEPrototype.Services
{
    public class MobileApi:IMobileApi
    {
      
       
        public async Task InsertOutage(Outage outage)
        {
            try
            {
                await App.MobileService.GetTable<Outage>().InsertAsync(outage);
            }
            catch(Exception ex)
            {

            }
        }

        public async Task UpdateOutage(Outage outage)
        {
            try
            {

                var updateOutage = await App.MobileService.GetTable<Outage>().Where(p => p.Id == outage.Id)
                        .ToListAsync();

                foreach (var item in updateOutage)
                {
                    item.OutageResolved = outage.OutageResolved;
                   
                    await App.MobileService.GetTable<Outage>().UpdateAsync(item);
                }
              
            }
            catch (Exception ex)
            {

            }
        }

        public Task<List<Outage>> GetOutages()
        {

           var getOutages = App.MobileService.GetTable<Outage>().ToListAsync();

            return getOutages;
        }
        
    }
}
