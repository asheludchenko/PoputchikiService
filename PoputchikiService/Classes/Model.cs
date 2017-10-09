using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class Model
    {
        private int _modelId;
        private int _brandId;
        private string _modelname;

        [DataMember]
        public virtual int ModelID                                                              //id модели автомобиля
        {
            get { return _modelId; }
            set
            {
                _modelId = value;
            }
        }

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
        public virtual string ModelName                                                         //название модели автомобиля
        {
            get { return _modelname; }
            set
            {
                _modelname = value;
            }
        }
    }
}
