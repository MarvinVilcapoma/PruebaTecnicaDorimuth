using Domain;
using Infraestructure.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implements
{
    public class DistrictService : IDistrictInterface
    {
        private readonly ClientDBContext _context;

        public DistrictService(ClientDBContext context)
        {
            _context = context;
        }

        public List<District> GetDistricts()
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Districts.Where(x => x.Enabled == true).OrderBy(x => x.DistrictName).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
