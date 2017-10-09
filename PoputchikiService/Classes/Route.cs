using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class Route
    {
        private int _routeId;
        private int _userId;
        private string _startLon;
        private string _startLat;
        private string _endLon;
        private string _endLat;
        private string _state;
        private string _regularity;
        private string _routename;
        private string _comment;
        private string _way;
        private string _distance;
        private string _isregular;
        private string _ones;
        private string _startaddress;
        private string _endaddress;

        [DataMember]
        public virtual int RouteID
        {
            get { return _routeId; }
            set
            {
                _routeId = value;
            }
        }

        [DataMember]
        public virtual int UserID
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }

        [DataMember]
        public virtual string StartLon
        {
            get { return _startLon; }
            set
            {
                _startLon = value;
            }
        }

        [DataMember]
        public virtual string StartLat
        {
            get { return _startLat; }
            set
            {
                _startLat = value;
            }
        }

        [DataMember]
        public virtual string EndLon
        {
            get { return _endLon; }
            set
            {
                _endLon = value;
            }
        }

        [DataMember]
        public virtual string EndLat
        {
            get { return _endLat; }
            set
            {
                _endLat = value;
            }
        }

        [DataMember]
        public virtual string State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }

        [DataMember]
        public virtual string Regularity
        {
            get { return _regularity; }
            set
            {
                _regularity = value;
            }
        }

        [DataMember]
        public virtual string RouteName
        {
            get { return _routename; }
            set
            {
                _routename = value;
            }
        }

        [DataMember]
        public virtual string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
            }
        }

        [DataMember]
        public virtual string Way
        {
            get { return _way; }
            set
            {
                _way = value;
            }
        }

        [DataMember]
        public virtual string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
            }
        }

        [DataMember]
        public virtual string IsRegular
        {
            get { return _isregular; }
            set
            {
                _isregular = value;
            }
        }

        [DataMember]
        public virtual string Ones
        {
            get { return _ones; }
            set
            {
                _ones = value;
            }
        }

        [DataMember]
        public virtual string StartAddress
        {
            get { return _startaddress; }
            set
            {
                _startaddress = value;
            }
        }

        [DataMember]
        public virtual string EndAddress
        {
            get { return _endaddress; }
            set
            {
                _endaddress = value;
            }
        }
    }
}
