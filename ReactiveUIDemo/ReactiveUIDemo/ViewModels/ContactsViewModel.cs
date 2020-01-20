using ReactiveUI;
using ReactiveUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class ContactsViewModel : ReactiveObject
    {

        private List<Contact> _samples = new List<Contact>()
        {
            new Contact {FullName = "Ahmad Mozaffar", Email = "aksoftware98@hotmail.com", Phone = "093422342"},
            new Contact {FullName = "Sami Contact", Email = "sami@test.com", Phone = "2345453"},
            new Contact { FullName = "Sarah Contact", Email = "sarah@test.com", Phone = "23543343"},
            new Contact { FullName = "Jouli Smith", Email = "jouli@test.com", Phone = "4643256"},
            new Contact { FullName = "John Smith", Email = "john@test.com", Phone = "832525354"}
        };

        public ContactsViewModel()
        {
            _contacts = new ObservableCollection<Contact>(_samples);

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(1))
                .Subscribe(query =>
                {
                    var filteredContacts = _samples.Where(c => c.FullName.ToLower().Contains(query) || c.Phone.Contains(query) || c.Email.Contains(query)).ToList();

                    Contacts = new ObservableCollection<Contact>(filteredContacts); 
                });
        }

        #region Properties
        private string _searchQuery = ""; 
        public string SearchQuery
        {
            get => _searchQuery; 
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value);  }
        }

        private ObservableCollection<Contact> _contacts; 
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set { this.RaiseAndSetIfChanged(ref _contacts, value); }
        }

        #endregion

    }
}
