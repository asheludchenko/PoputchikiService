using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PoputchikiService;
using System.ServiceModel.Activation;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Expression;

namespace UserService.Web
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "UserServiceJSON" в коде, SVC-файле и файле конфигурации.
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class UserServiceJSON : IUser
    {

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetUserInformationById, 
            ResponseFormat = WebMessageFormat.Json)]
        public User GetUserInformationByID(string userId)                                                               //Получение информации о пользователе через id
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            IList<Route> routelist = GetRoutes(userId);
            int count = routelist.Count();
            User user = session.Get<User>(Convert.ToInt32(userId));
            user.Routes = count;
            return user;
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.PostUserInformation, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public RETURN RegisterUser(User user)                                                                           //Регистрация пользователя
        {
            int userId = (int)_session.Save(user);
            RETURN usr = new RETURN();
            usr.UserID = userId;
            return usr;
        }

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetAutoInformation, 
            ResponseFormat = WebMessageFormat.Json)]
        public Auto GetAutoInformationByID(string autoId)                                                               //Получение информации об автомобиле по id автомобиля
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session.Get<Auto>(Convert.ToInt32(autoId));
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.PostAutoInformation, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void RegisterAuto(Auto auto)                                                                             //Регистрация автомобиля
        {
            _session.Save(auto);
        }

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetBrands, 
            ResponseFormat = WebMessageFormat.Json)]
        public IList<Brand> GetBrands()                                                                                 //Получение списка Марок автомобилей
        {
            return _session.CreateQuery("select all from Brand").List<Brand>();
        }

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetModels, 
            ResponseFormat = WebMessageFormat.Json)]
        public IList<Model> GetModels(string brandId)                                                                   //Получение списка Моделей автомобилей определённой Марки
        {
            return _session.CreateQuery("select from Model c where c.BrandID=:bid").SetString("bid",brandId).List<Model>();
        }

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetUserAutoByUserID, 
            ResponseFormat = WebMessageFormat.Json)]
        public IList<Auto> GetUserAutoByUserID(string userId)                                                           //Получение списка Автомобилей определённого пользователя
        {
            return _session.CreateQuery("select from Auto c where c.UserID=:uid").SetString("uid",userId).List<Auto>();
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.PostUserLocation, 
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void PostUserLocation(string lon, string lat, User user)                                                 //Отправление текущих Координат пользователя
        {
            User tempUser = GetUserInformationByID(Convert.ToString(user.UserID));
            tempUser.CurrentLat = lat;
            tempUser.CurrentLon = lon;
            UpdateUserInformation(tempUser);
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.PostRouteInformarion,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void PostRouteInformation(Route route)                                                                   //Добавление нового Маршрута
        {
            _session.Save(route);
        }

        [WebInvoke(Method = "GET", UriTemplate = Routing.GetRoutes,
            ResponseFormat = WebMessageFormat.Json)]
        public IList<Route> GetRoutes(string userId)                                                                    //Получение Маршрутов определённого пользователя
        {
            ISession session;
            session = GetSession(); 
            return session.CreateQuery("select from Route c where c.UserID=:uid")
                .SetString("uid", userId)
                .List<Route>();
        }
        
        [WebInvoke(Method = "POST", UriTemplate = Routing.GetAppropriateRoutes,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IList<User> GetAppropriateRoute(Route route)                                                            //Получение подходящих Попутчиков
        {
            AppropriateRoutes _tempFunction = new AppropriateRoutes();
            return _tempFunction.GetAppropriateRoutes( route, Convert.ToDouble(route.Distance));
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.UserAuthorisation,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public User UserAuthorise(User user)                                                                            //Авторизация Пользователя
        {
            IList<User> userlist = _session.CreateQuery("select from User c where c.Login=:ul and c.Password=:up")
                .SetString("ul", user.Login)
                .SetString("up", user.Password)
                .List<User>();
            if (userlist.Count() == 0)
            {
                user.UserID = -1;
            }
            else
            {
                user = userlist.ElementAt(0);
                user = GetUserInformationByID(Convert.ToString(user.UserID));
            }
            return user;
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.CheckLogin,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public RETURN CheckLogin(User user)                                                                             //Проверка уникальности Логина
        {
            RETURN usr = new RETURN();
            IList<User> userlist = _session.CreateQuery("select from User c where c.Login=:ul")
                .SetString("ul", user.Login)
                .List<User>();
            int count = userlist.Count();
            int checklogin;
            if (count == 0)
            {
                checklogin = 1;                                                                             //Логин уникален
            }
            else
            {
                checklogin = 0;                                                                             //Логин не уникален                                                                  
            }
            usr.CheckLogin = checklogin;
            return usr;
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.GetUserRoutes,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IList<Route> GetUserRoute(Route route)
        {
            AppropriateRoutes routes = new AppropriateRoutes();
            List<Route> AppropriateRoutes = new List<Route>();
            double appropriateDistance = Convert.ToDouble( route.Distance);
            double distance;

            IList<Route> RouteList = _session.CreateQuery("select from Route c where c.UserID=:uid and c.State=:st")
                .SetString("st", "true")
                .SetString("uid", Convert.ToString( route.UserID))
                .List<Route>();                                                                                                 //Считыванине всех Маршрутов из БД в Список

            foreach (Route _route in RouteList)
            {
                distance = routes.Distance(route.StartLat, route.StartLon, _route.StartLat, _route.StartLon);                   //Рассчёт Расстояния между начальными точками Маршрутов

                //Если Расстояние между начальными точками меньше заданного значения
                if (distance < appropriateDistance)
                {
                    _route.Distance = Convert.ToString(distance);
                    AppropriateRoutes.Add(_route); 
                }
            }

            return AppropriateRoutes;
        }

        [WebInvoke(Method = "POST", UriTemplate = Routing.RouteUpdate,
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public RETURN RouteUpdate(Route route)
        {
            RETURN _route = new RETURN();
            ISession session;
            session = GetSession();
            session.Update(route);
            session.Flush();
            _route.UserID = route.UserID;
            return _route;
        }

        //Вспомогательные функции для работы с Базой Данных

        //Обновление любых полей пользователя по его id пользователя
        public void UpdateUserInformation(User user)
        {
            ISession session;
            session = GetSession();
            session.Update(user);
            session.Flush();
        } 

        private ISession _session;

        //конструктор класса
        public UserServiceJSON()
        {
            _session = GetSession();                                                                                    //Открытие сессии
        }

        private static ISession GetSession()                                                                            //Открытие сессии
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }
    }
}