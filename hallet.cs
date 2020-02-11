using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlabpuzzle
{
    class hallet:PictureBox
    {

        int yer = 0;
        public int Yer
        {

            get { return yer; }
            set { yer = value; }


        }
        int resYer = 0;
        public int ResYer
        {
            get { return resYer; }
            set { resYer = value; }


        }


        public bool Match()
        {

            return (yer == resYer);
        }
    }
}
