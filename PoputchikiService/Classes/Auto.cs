using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class Auto
    {
        private int _autoId;
        private int _userId;
        private int _brandId;
        private int _modelId;
        private string _autonickname;

        [DataMember]
        public virtual int AutoID                                                               //id автомобиля
        {
            get { return _autoId; }
            set
            {
                _autoId = value;
            }
        }

        [DataMember]
        public virtual int UserID                                                               //id пользователя
        {
            get { return _userId; }
            set
            {
                _userId = value;
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
        public virtual int ModelID                                                              //id модели автомобиля
        {
            get { return _modelId; }
            set
            {
                _modelId = value;
            }
        }

        [DataMember]
        public virtual string AutoNickName                                                      //ник автомобиля
        {
            get { return _autonickname; }
            set
            {
                _autonickname = value;
            }
        }
    }
}
