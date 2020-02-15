using DynamicData;
using ReactiveUI;
using ReactiveUIDemo.Models;
using ReactiveUIDemo.Services;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class CollectionViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Collections";

        public IScreen HostScreen { get; }
        private readonly IContactsService _contactsService; 
        public CollectionViewModel(IScreen screen = null, IContactsService contactsService = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _contactsService = contactsService ?? Locator.Current.GetService<IContactsService>();


            _contacts.AddRange(_contactsService.GetAllContacts());

            _contacts.Connect().Bind(out _contactsList).Subscribe();

            _contacts.ReplaceAt(2, new Contact
            {
                Email = "replaced@test.com",
                FullName = "Replace Contact",
                Phone = "123456789"
            });
            _contacts.Move(0, 3);
        }

        private SourceList<Contact> _contacts = new SourceList<Contact>();

        private readonly ReadOnlyObservableCollection<Contact> _contactsList;
        public ReadOnlyObservableCollection<Contact> Contacts => _contactsList;
    }
}
