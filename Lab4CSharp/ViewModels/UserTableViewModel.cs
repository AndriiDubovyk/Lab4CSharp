using Lab4CSharp.Models;
using Lab4CSharp.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4CSharp.ViewModels
{
    class UserTableViewModel
    {
        #region Fields
        private ObservableCollection<User> _users;
        private User _selectedUser;
        private UserCandidate _userAdd = new UserCandidate();
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _removeCommand;
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

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand<object>(_ => Remove(), CanExecuteRemoveCommand);
            }
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand<object>(_ => Add(), CanExecuteAddCommand);
            }
        }
        #endregion

        public UserTableViewModel()
        {
            this.Users = new ObservableCollection<User>();
            Users.Add(new User("Andrii", "Dubovyk", "example@gmail.com", new DateTime(2003, 08, 01)));
            Users.Add(new User("John", "Smith", "jsmith@gmail.com", new DateTime(2000, 04, 30)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
            Users.Add(new User("Jack", "Nicklson", "nicklson@gmail.com", new DateTime(2010, 05, 15)));
        }

        private void Remove()
        {
            Users.Remove(SelectedUser);
        }

        private void Add()
        {
           try
            {
                Users.Add(new User(FirstNameAdd, LastNameAdd, EmailAdd, BirthdateAdd.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Process failed: {ex.Message}");
            }
        }

        private bool CanExecuteRemoveCommand(object obj)
        {
            return SelectedUser!=null;
        }

        private bool CanExecuteAddCommand(object obj)
        {
            return !String.IsNullOrWhiteSpace(FirstNameAdd)
                && !String.IsNullOrWhiteSpace(LastNameAdd)
                && !String.IsNullOrWhiteSpace(EmailAdd)
                && BirthdateAdd != null;
        }

    }
}
