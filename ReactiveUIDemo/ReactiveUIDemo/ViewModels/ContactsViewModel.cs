using ReactiveUI;
using ReactiveUIDemo.Models;
using ReactiveUIDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;

namespace ReactiveUIDemo.ViewModels
{
    public class ContactsViewModel : ReactiveObject
    {
        private IContactsService _contactsService; 
        
        public ContactsViewModel(IContactsService contactsService = null)
        {
            _contactsService = contactsService ?? (IContactsService)Splat.Locator.Current.GetService(typeof(IContactsService));

            var allContacts = _contactsService.GetAllContacts(); 
            _contacts = new ObservableCollection<Contact>(allContacts);

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(1))
                .Subscribe(query =>
                {
                    var filteredContacts = allContacts.Where(c => c.FullName.ToLower().Contains(query) || c.Phone.Contains(query) || c.Email.Contains(query)).ToList();

                    Contacts = new ObservableCollection<Contact>(filteredContacts); 
                });

            this.WhenAnyValue(vm => vm.Contacts)
                .Select(conacts =>
                {
                    if (Contacts.Count == allContacts.Count())
                        return "No filters applied";

                    return $"{Contacts.Count} have been found in result for '{SearchQuery}'";
                })
                .ToProperty(this, vm => vm.SearchResult, out _searchResult);

            ClearCommand = ReactiveCommand.Create(ClearSearch);
            // HAndle the Exceptions 
            ClearCommand.ThrownExceptions.Subscribe(ex =>
            {
                Debug.WriteLine(ex.Message); 
            });
        }

        #region Properties
        private string _searchQuery = ""; 
        public string SearchQuery
        {
            get => _searchQuery; 
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value);  }
        }

        private readonly ObservableAsPropertyHelper<string> _searchResult;
        public string SearchResult => _searchResult.Value; 


        private ObservableCollection<Contact> _contacts; 
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set { this.RaiseAndSetIfChanged(ref _contacts, value); }
        }

        #endregion

        #region Commands
        public ReactiveCommand<Unit, Unit> ClearCommand { get; }
        #endregion 

        #region Methods
        private void ClearSearch()
        {
            throw new Exception("This is an example"); 
            //SearchQuery = string.Empty; 
        }
        #endregion 
    }
}
