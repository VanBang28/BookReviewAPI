using BooksReview.BL.Interfaces;
using BooksReview.Common.Models;
using BooksReview.DL.Interfaces;
using BooksReview.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.BL.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionDL _regionDL;
        public RegionService(IRegionDL regionDL)
        {
            _regionDL = regionDL;
        }
        public List<Region> getByParentId(int id)
        {
            return _regionDL.getByParentId(id);
        }
    }
}
