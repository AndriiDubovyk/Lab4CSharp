using Lab4CSharp.Models;
using Lab4CSharp.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.ViewModels
{
    class UserTableViewModel
    {
        #region Fields
        private ObservableCollection<User> _users;
        private User _selectedUser;
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

        private void Remove()
        {
            Users.Remove(SelectedUser);
        }

        private bool CanExecuteRemoveCommand(object obj)
        {
            return SelectedUser!=null;
        }

    }
}
