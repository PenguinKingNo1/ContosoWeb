using ContosoWeb.Models;
using ContosoWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContosoWeb.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void AddPerson(People people)
        {
            _repository.Add(people);
            _repository.SaveChanges();
        }

        public void DeletePerson(People people)
        {
            _repository.Delete(people);
            _repository.SaveChanges();
        }

        public void EditPerson(People people)
        {
            _repository.Update(people);
            _repository.SaveChanges();
        }

        public IEnumerable<People> GetAllPeople()
        {
            return _repository.GetAll();
        }

        public People GetPersonById(int id)
        {
            return _repository.GetById(id);
        }


    }

    public interface IPersonService
    {
        void AddPerson(People people);       
        IEnumerable<People> GetAllPeople();
        People GetPersonById(int id);
        void EditPerson(People people);
        void DeletePerson(People people);
    }
}
