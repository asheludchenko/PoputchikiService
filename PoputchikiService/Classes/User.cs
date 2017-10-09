using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PoputchikiService
{
    [DataContract]
    public class User
    {
        private int _userId;
        private int _routes;
        private int _birthyear;
        private int _birthmonth;
        private int _birthday;
        private string _gender;
        private string _firstname;
        private string _secondname;
        private string _lastname;
        private string _login;
        private string _password;
        private string _vkId;
        private string _currentLon;
        private string _currentLat;
        private string _avatar;
        private string _email;
        private string _mobilephone;
        private string _auto;

        [DataMember]
        public virtual int UserID                                                           //id пользователя
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }

        [DataMember]
        public virtual string FirstName                                                     //имя пользователя
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
            }
        }

        [DataMember]
        public virtual string SecondName                                                    //отчество пользователя
        {
            get { return _secondname; }
            set
            {
                _secondname = value;
            }
        }

        [DataMember]
        public virtual string LastName                                                      //фамилия пользователя 
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
            }
        }

        [DataMember]
        public virtual string Login                                                         //login пользователя
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }

        [DataMember]
        public virtual string Password                                                      //пароль пользователя
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        [DataMember]
        public virtual string VKID                                                          //!!!пока не понятно!!!
        {
            get { return _vkId; }
            set
            {
                _vkId = value;
            }
        }

        [DataMember]
        public virtual string CurrentLon                                                    //текущаю координата
        {
            get { return _currentLon; }
            set
            {
                _currentLon = value;
            }
        }

        [DataMember]
        public virtual string CurrentLat                                                    //текущаю координата
        {
            get { return _currentLat; }
            set
            {
                _currentLat = value;
            }
        }

        [DataMember]
        public virtual string Avatar                                                        //Аватар
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
            }
        }

        [DataMember]
        public virtual int Routes                                                           //количество маршрутов
        {
            get { return _routes; }
            set
            {
                _routes = value;
            }
        }

        [DataMember]
        public virtual string Gender                                                        //пол
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        [DataMember]
        public virtual int BirthYear                                                        //год рождения
        {
            get { return _birthyear; }
            set
            {
                _birthyear = value;
            }
        }

        [DataMember]
        public virtual int BirthMonth                                                       //месяц рождения
        {
            get { return _birthmonth; }
            set
            {
                _birthmonth = value;
            }
        }

        [DataMember]
        public virtual int BirthDay                                                         //день рождения
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
            }
        }

        [DataMember]
        public virtual string Email                                                         //email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        [DataMember]
        public virtual string MobilePhone                                                   //номер мобильного телефона
        {
            get { return _mobilephone; }
            set
            {
                _mobilephone = value;
            }
        }

        [DataMember]
        public virtual string Auto                                                          //ник автомобиля
        {
            get { return _auto; }
            set
            {
                _auto = value;
            }
        }
    }
}
