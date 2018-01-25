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

        public People GetValidPerson(string username, string pwd)
        {
            return _repository.Get(p => p.Email == username && p.Password == pwd);
        }

        public void AddRole(int personId, int roleId)
        {
            var updatedRepository = new PersonRepository(new ContosoDbContext());
            updatedRepository.AddRole(personId, roleId);
            updatedRepository.SaveChanges();
        }
    }

    public interface IPersonService
    {
        void AddPerson(People people);       
        IEnumerable<People> GetAllPeople();
        People GetPersonById(int id);
        void EditPerson(People people);
        void DeletePerson(People people);
        People GetValidPerson(string username, string pwd);
        void AddRole(int personId, int roleId);
    }
}
