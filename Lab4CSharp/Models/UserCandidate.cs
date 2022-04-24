using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.Models
{
    class UserCandidate
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime? _birthdate;
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public DateTime? Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }
        #endregion
    }
}
