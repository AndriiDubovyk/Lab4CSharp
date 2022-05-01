using Lab4CSharp.Models;
using Lab4CSharp.Repositories;
using Lab4CSharp.Services;
using Lab4CSharp.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4CSharp.ViewModels
{
    class UserTableViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<User> _users;
        private User _selectedUser;
        private UserCandidate _userAdd = new UserCandidate();
        private UserCandidate _userEdit = new UserCandidate();
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _removeCommand;
        private static FileRepository Repository = new FileRepository();
        #endregion

        #region Properties
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                if(value!=null)
                {
                    FirstNameEdit = value.FirstName;
                    LastNameEdit = value.LastName;
                    EmailEdit = value.Email;
                    BirthdateEdit = value.Birthdate;
                }
            }

        }

        public string FirstNameAdd
        {
            get
            {
                return _userAdd.FirstName;
            }
            set
            {
                _userAdd.FirstName = value;
            }
        }

        public string LastNameAdd
        {
            get
            {
                return _userAdd.LastName;
            }
            set
            {
                _userAdd.LastName = value;
            }
        }

        public string EmailAdd
        {
            get
            {
                return _userAdd.Email;
            }
            set
            {
                _userAdd.Email = value;
            }
        }

        public DateTime? BirthdateAdd
        {
            get
            {
                return _userAdd.Birthdate;
            }
            set
            {
                _userAdd.Birthdate = value;
            }
        }

        public string FirstNameEdit
        {
            get
            {
                return _userEdit.FirstName;
            }
            set
            {
                _userEdit.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastNameEdit
        {
            get
            {
                return _userEdit.LastName;
            }
            set
            {
                _userEdit.LastName = value;
                OnPropertyChanged();
            }
        }

        public string EmailEdit
        {
            get
            {
                return _userEdit.Email;
            }
            set
            {
                _userEdit.Email = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthdateEdit
        {
            get
            {
                return _userEdit.Birthdate;
            }
            set
            {
                _userEdit.Birthdate = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand ??= new RelayCommand<object>(_ => Edit(), CanExecuteEditCommand);
            }
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand<object>(_ => Add(), CanExecuteAddCommand);
            }
        }

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand<object>(_ => Remove(), CanExecuteRemoveCommand);
            }
        }
        #endregion

        public UserTableViewModel()
        {
            _users = new ObservableCollection<User>(new UserService().GetAllUsers());
            if (_users.Count == 0) FillTable();
        }

        private void Add()
        {
            try
            {
                if (IsUniqueEmail(EmailAdd))
                {
                    User user = new User(FirstNameAdd, LastNameAdd, EmailAdd, BirthdateAdd.Value);
                    AddUser(user);
                }
                else
                {
                    MessageBox.Show("User email must be unique");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Process failed: {ex.Message}");
            }
        }

        private void Edit()
        {
            try
            {
                if (EmailEdit == SelectedUser.Email || IsUniqueEmail(EmailEdit))
                {
                    User user = new User(FirstNameEdit, LastNameEdit, EmailEdit, BirthdateEdit.Value);
                    AddUser(user);
                    RemoveUser(SelectedUser);
                } else
                {
                    MessageBox.Show("User email must be unique");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Process failed: {ex.Message}");
            }
        }

        private void Remove()
        {
            RemoveUser(SelectedUser);
            FirstNameEdit = "";
            LastNameEdit = "";
            EmailEdit = "";
            BirthdateEdit = null;
        }

        private bool CanExecuteAddCommand(object obj)
        {
            return !String.IsNullOrWhiteSpace(FirstNameAdd)
                && !String.IsNullOrWhiteSpace(LastNameAdd)
                && !String.IsNullOrWhiteSpace(EmailAdd)
                && BirthdateAdd != null;
        }

        private bool CanExecuteEditCommand(object obj)
        {
            return !String.IsNullOrWhiteSpace(FirstNameEdit)
                && !String.IsNullOrWhiteSpace(LastNameEdit)
                && !String.IsNullOrWhiteSpace(EmailEdit)
                && BirthdateEdit != null
                && SelectedUser != null;
        }

        private bool CanExecuteRemoveCommand(object obj)
        {
            return SelectedUser!=null;
        }

        private async void AddUser(User user)
        {
            Users.Add(user);
            UserCandidate uc = new UserCandidate();
            uc.FirstName = user.FirstName;
            uc.LastName = user.LastName;
            uc.Email = user.Email;
            uc.Birthdate = user.Birthdate;
            await Repository.AddAsync(uc);
        }

        private void RemoveUser(User user)
        {
            Users.Remove(user);
            Repository.Remove(user.Email);
        }

        private bool IsUniqueEmail(string email)
        {
            foreach(var user in Users)
            {
                if (user.Email == email) return false;
            }
            return true;
        }

        private void FillTable()
        {
            AddUser(new User("Jack", "Nicklson", "jnicklson@gmail.com", new DateTime(1990, 5, 3)));
            AddUser(new User("John", "Nicklson", "johnnicklson@gmail.com", new DateTime(1995, 5, 4)));
            AddUser(new User("Nick", "Johnson", "njohnson@gmail.com", new DateTime(2008, 5, 6)));
            AddUser(new User("Kate", "Simpson", "ksimpson@gmail.com", new DateTime(1999, 12, 12)));
            AddUser(new User("Samuel", "Nicklson", "snicklson@gmail.com", new DateTime(1995, 5, 4)));
            AddUser(new User("Ben", "Barkley", "bbarkley@gmail.com", new DateTime(1958, 1, 4)));
            AddUser(new User("Dan", "Barkley", "dbarkley@gmail.com", new DateTime(1966, 12, 4)));
            AddUser(new User("Ben", "Simpson", "bsimpson@gmail.com", new DateTime(2001, 1, 1)));
            AddUser(new User("Ron", "Smith", "smithron@gmail.com", new DateTime(1970, 7, 7)));
            AddUser(new User("Andrew", "Adley", "aadley@gmail.com", new DateTime(1965, 5, 4)));
            AddUser(new User("James", "Baker", "bakerjames@gmail.com", new DateTime(2007, 5, 4)));
            AddUser(new User("Robert", "Baker", "bakerobert2000@gmail.com", new DateTime(2000, 2, 4)));
            AddUser(new User("Mary", "Baker", "mbaker@gmail.com", new DateTime(1980, 9, 4)));
            AddUser(new User("Jennifer", "Baker", "jenbaker@gmail.com", new DateTime(1982, 11, 4)));
            AddUser(new User("William", "Cooper", "wcooper@gmail.com", new DateTime(1995, 5, 24)));
            AddUser(new User("Thomas", "Cooper", "tcooper@gmail.com", new DateTime(1993, 12, 22)));
            AddUser(new User("Elizabeth", "Cooper", "ecooper@gmail.com", new DateTime(1990, 5, 10)));
            AddUser(new User("Mary", "Anderson ", "manderson@gmail.com", new DateTime(2002, 5, 12)));
            AddUser(new User("Emily", "Anderson", "andersonemily1999@gmail.com", new DateTime(1999, 5, 11)));
            AddUser(new User("Anthony", "Anderson", "anderson@gmail.com", new DateTime(2000, 5, 15)));
            AddUser(new User("Kevin", "Davidson", "kdavidson@gmail.com", new DateTime(2002, 7, 14)));
            AddUser(new User("John", "Davidson", "jdavidson@gmail.com", new DateTime(2003, 2, 4)));
            AddUser(new User("James", "Davidson", "jamesdavidson@gmail.com", new DateTime(2000, 1, 4)));
            AddUser(new User("Thomas", "Davidson", "tdavidson@gmail.com", new DateTime(1995, 2, 22)));
            AddUser(new User("Elizabeth", "Davidson", "edavidson@gmail.com", new DateTime(1987, 3, 19)));
            AddUser(new User("William", "Davidson", "wdavidson@gmail.com", new DateTime(1992, 4, 16)));
            AddUser(new User("Rob", "Robinson ", "robrobinson@gmail.com", new DateTime(1993, 12, 4)));
            AddUser(new User("John", "Robinson", "jrobinson@gmail.com", new DateTime(1994, 1, 14)));
            AddUser(new User("Kate", "Robinson", "robinsonkate@gmail.com", new DateTime(1998, 2, 13)));
            AddUser(new User("Nick", "Robinson", "nrobinson@gmail.com", new DateTime(1999, 5, 7)));
            AddUser(new User("Edward", "Evans ", "edwardevans@gmail.com", new DateTime(1985, 5, 4)));
            AddUser(new User("Nick", "Evans", "nickevans@gmail.com", new DateTime(1975, 6, 2)));
            AddUser(new User("Ryan", "Mitchell", "rmitchell@gmail.com", new DateTime(1955, 5, 17)));
            AddUser(new User("Jeffrey", "Mitchell", "jmitchell@gmail.com", new DateTime(1982, 9, 4)));
            AddUser(new User("Gary", "Mitchell", "mitchell@gmail.com", new DateTime(1980, 11, 4)));
            AddUser(new User("Eric", "Tailor ", "etailor@gmail.com", new DateTime(1975, 12, 4)));
            AddUser(new User("Gary", "Tailor", "garytailor@gmail.com", new DateTime(1999, 5, 19)));
            AddUser(new User("Betty", "Tailor", "tailorbetty@gmail.com", new DateTime(1999, 5, 26)));
            AddUser(new User("Scott", "Mason ", "smason@gmail.com", new DateTime(1997, 5, 27)));
            AddUser(new User("Eric", "Mason", "ericmason@gmail.com", new DateTime(1991, 5, 12)));
            AddUser(new User("John", "Mason", "jmason@gmail.com", new DateTime(1992, 5, 10)));
            AddUser(new User("Jack", "Mason", "masonjack@gmail.com", new DateTime(1993, 5, 20)));
            AddUser(new User("Nicole", "Mason", "nmason@gmail.com", new DateTime(1994, 5, 25)));
            AddUser(new User("Olivia", "Mason", "omason@gmail.com", new DateTime(1977, 5, 23)));
            AddUser(new User("Tyler", "Brown", "tbrown@gmail.com", new DateTime(1978, 5, 21)));
            AddUser(new User("Jerry", "Brown", "brownjerry@gmail.com", new DateTime(1979, 5, 22)));
            AddUser(new User("Walter", "Brown", "wbrown@gmail.com", new DateTime(1989, 10, 2)));
            AddUser(new User("Arthur", "Brown", "abrown@gmail.com", new DateTime(1988, 4, 5)));
            AddUser(new User("Larry", "Brown", "lbrown@gmail.com", new DateTime(1991, 3, 11)));
            AddUser(new User("Justin", "Brown", "jbrown@gmail.com", new DateTime(1976, 2, 12)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
