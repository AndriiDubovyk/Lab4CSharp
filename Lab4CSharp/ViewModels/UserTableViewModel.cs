﻿using Lab4CSharp.Models;
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

        private void Edit()
        {
            try
            {
                Users.Add(new User(FirstNameEdit, LastNameEdit, EmailEdit, BirthdateEdit.Value));
                Users.Remove(SelectedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Process failed: {ex.Message}");
            }
        }

        private void Remove()
        {
            Users.Remove(SelectedUser);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
