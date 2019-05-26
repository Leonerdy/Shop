using Shop.UIForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace Shop.Common.Models 
{
    public class ContactsInfo : BaseViewModel2
    {
        private string firstName;
        
        private string lastName;
        
        private string email;

        private string address;

        private string phone;

        private string password;

        private string confirm;

        private int cityId;

        private ObservableCollection<Country> countries;
        private Country country;
        private ObservableCollection<City> cities;
        private City city;

        

        public ContactsInfo()
        {

        }


        public Country Country
        {
            get => this.country;
            set
            {
                this.SetValue(ref this.country, value);
                this.Cities = new ObservableCollection<City>(this.Country.Cities.OrderBy(c => c.Name));
            }

        }

        public City City
        {
            get => this.city;
            set => this.SetValue(ref this.city, value);
        }

        public ObservableCollection<Country> Countries
        {
            get => this.countries;
            set => this.SetValue(ref this.countries, value);
        }

        public ObservableCollection<City> Cities
        {
            get => this.cities;
            set => this.SetValue(ref this.cities, value);
        }


        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                this.firstName = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                this.phone = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                this.password = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        public int CityId
        {
            get { return cityId; }
            set
            {
                cityId = value;
            }
        }
        public string Confirm
        {
            get { return confirm; }
            set
            {
                confirm = value;
            }
        }


    }
}
