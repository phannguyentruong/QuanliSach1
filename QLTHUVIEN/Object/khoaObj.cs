using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTHUVIEN.Object
{
    class khoaObj
    {
        string makhoa, tenkhoa, diachi, sdt;


        public khoaObj()
        { }
        public khoaObj(string makhoa, string tenkhoa, string diachi, string sdt)
        {
            this.makhoa = makhoa;
            this.tenkhoa = tenkhoa;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string Makhoa
        {
            get
            {
                return makhoa;
            }

            set
            {
                makhoa = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public string Tenkhoa
        {
            get
            {
                return tenkhoa;
            }

            set
            {
                tenkhoa = value;
            }
        }
    }
}
