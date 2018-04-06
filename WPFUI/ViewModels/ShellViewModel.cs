using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstname = "Tim";
        private string _lastname;
        private string _fullname;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedperson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Paul", LastName = "Treadwell" });
            People.Add(new PersonModel { FirstName = "Sidney", LastName = "tRex" });
        }
        public string FirstName
        {
            get {
                return _firstname;
            }
            set {
                _firstname = value;
                //this part below auto changes any bindign items
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string LastName
        {
            get {
                return _lastname;
            }
            set {
                _lastname = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
            }
            set { _fullname = value; }
        }

        //bindable collection is part of Caliburn.Micro
        public BindableCollection<PersonModel> People
        {
            //shorthand way of doing getter and setter
            get => _people; set => _people = value;
        }
        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedperson;
            }
            set
            {
                _selectedperson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }

        }


        //the firstName and lastName parameter by convention, because of caliburn Micro, connect to the FirstName and LastName properties defined in here, which saves you some coding / logic as it handles things for you

        
        //also, I think the CanClearText recognises that there is a button component called ClearText, and a corresponding method, and again, connects together

        public bool CanClearText(string firstName, string lastName) //=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        //{
        //    return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        //}
        {
           if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public void ClearText(string firstName, string lastName)
        {
   
                FirstName = "";
                LastName = "";

           
            //NotifyOfPropertyChange(() => FirstName);
        }

      
        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}