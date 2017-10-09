using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class RETURN
    {
        private int _userid;
        private int _checklogin;

        [DataMember]
        public virtual int UserID
        {
            get { return _userid; }
            set
            {
                _userid = value;
            }
        }

        [DataMember]
        public virtual int CheckLogin
        {
            get { return _checklogin; }
            set
            {
                _checklogin = value;
            }
        }
    }
}
