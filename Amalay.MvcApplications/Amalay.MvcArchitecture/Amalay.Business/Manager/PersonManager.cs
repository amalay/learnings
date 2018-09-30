using Amalay.Model;
using Amalay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public class PersonManager : EntityManager<Person>, IPersonManager
    {
        IUnitOfWork _unitOfWork;
        IPersonRepository _personRepository;

        public PersonManager(IUnitOfWork unitOfWork, IPersonRepository personRepository) : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }


        public Person GetById(long Id)
        {
            return _personRepository.GetById(Id);
        }
    }
}
