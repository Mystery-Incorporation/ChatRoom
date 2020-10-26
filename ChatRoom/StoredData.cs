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
        private string _userNameBox;
        private string _nameBox;
        private string _cityBox;

        //public StoredData() { }
        //public StoredData(StoredData readXmlData)
        //{
        //    userName = readXmlData.userName;
        //    name = readXmlData.name;
        //    city = readXmlData.city;
        //}

        public string userName
        {
            get { return _userNameBox; }
            set { _userNameBox = value; }
        }

        public string name
        {
            get { return _nameBox; }
            set { _nameBox = value; }
        }

        public string city
        {
            get { return _cityBox; }
            set { _cityBox = value; }        
        }
    }
}
