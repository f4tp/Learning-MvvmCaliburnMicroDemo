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

        public ShellViewModel()
        {
            //constructor
        }
        private string _firstName = "Tim";
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

        private string _lastname;
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

        private string _fullname;

        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
            }
            set { _fullname = value; }
        }

        //bindable collection is part of Caliburn.Micro
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }


        private PersonModel _selectedperson;
        public PersonModel SelectedPerson
        {
            get { return _selectedperson; }
            set
            {
                _selectedperson = value;
                NotifyOfPropertyChange(( => SelectedPerson));

            }
        }




    }
}
