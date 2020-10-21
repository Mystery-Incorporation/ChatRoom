using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatRoom
{

    /// <summary>
    /// Stores the data from profile pages textboxes
    /// </summary>
    public class StoredData
    {
        public string _userNameBox;
        public string _nameBox;
        public string _cityBox;

        public string userName
        {
            get { return _userNameBox; }
            set { _userNameBox = value; }
        }

        public string name
        {
            get { return _userNameBox; }
            set { _nameBox = value; }
        }

        public string city
        {
            get { return _cityBox; }
            set { _cityBox = value; }        
        }
    }
}
