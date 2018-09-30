using Amalay.Model;
using Amalay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public class CountryManager : EntityManager<Country>, ICountryManager
    {
        IUnitOfWork _unitOfWork;
        ICountryRepository _countryRepository;

        public CountryManager(IUnitOfWork unitOfWork, ICountryRepository countryRepository) : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }


        public Country GetById(int Id)
        {
            return _countryRepository.GetById(Id);
        }
    }
}
