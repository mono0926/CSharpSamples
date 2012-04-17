using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperSample.ViewModel
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string FullName { get; set; }

        //便宜上、あえて下記のようには書いていません
        //public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); }

        //CompanyのNameをフラットにしてマッピングします
        public string CompanyName { get; set; }
    }
}