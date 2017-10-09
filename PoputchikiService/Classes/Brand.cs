using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class Brand
    {
        private int _brandId;
        private string _brandname;

        [DataMember]
        public virtual int BrandID                                                              //id марки автомобиля
        {
            get { return _brandId; }
            set
            {
                _brandId = value;
            }
        }

        [DataMember]
        public virtual string BrandName                                                         //название марки автомобиля
        {
            get { return _brandname; }
            set
            {
                _brandname = value;
            }
        }
    }
}
