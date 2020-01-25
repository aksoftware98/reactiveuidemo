using ReactiveUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo.Services
{
    public interface IContactsService
    {

        IEnumerable<Contact> GetAllContacts();  

    }

    public class StaticContactsService : IContactsService
    {
        private static List<Contact> _samples = new List<Contact>()
        {
            new Contact {FullName = "Ahmad Mozaffar", Email = "aksoftware98@hotmail.com", Phone = "093422342"},
            new Contact {FullName = "Sami Contact", Email = "sami@test.com", Phone = "2345453"},
            new Contact { FullName = "Sarah Contact", Email = "sarah@test.com", Phone = "23543343"},
            new Contact { FullName = "Jouli Smith", Email = "jouli@test.com", Phone = "4643256"},
            new Contact { FullName = "John Smith", Email = "john@test.com", Phone = "832525354"}
        };

        public IEnumerable<Contact> GetAllContacts()
        {
            return _samples;
        }
    }

}
