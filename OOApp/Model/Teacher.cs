using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOApp.Model
{
    internal class Teacher
    {
        /// <summary>
        /// POCO class
        /// </summary>
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; }

        public Teacher()
        {

        }

        public Teacher(int id, string? firstname, string? lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
