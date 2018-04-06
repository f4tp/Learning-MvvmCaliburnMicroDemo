using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _firstName = "Tim";
        private string _lastname;
        private string _fullname;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedperson;

        public ShellViewModel()
        {
                
        }

        
        public string FirstName
        {
            get {
                return _firstName;
            }
            set {
                _firstName = value;
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
        internal BindableCollection<PersonModel> People1
        {
            //shorthand way of doing getter and setter
            get => _people; set => _people = value;
        }
        internal PersonModel SelectedPerson
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
    }
}

        //underneath from video - did not work wth public scope - changed to internal
        // public BindableCollection<PersonModel> People
        //{
        // get { return _people; }
        // set { _people = value; }
        // }
        //public PersonModel SelectedPerson
        //{
        //get { return _selectedperson; }
        //set
        //{
        //_selectedperson = value;


        //}