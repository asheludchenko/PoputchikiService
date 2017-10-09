using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Expression;


namespace PoputchikiService
{
    public class AppropriateRoutes
    {

        public IList<User> GetAppropriateRoutes(Route route, double appropriateDistance)
        {
            double distance;
            User user;
            List<Route> AppropriateRoutes = new List<Route>();
            List<User> ApproprateUser = new List<User>();
            int count=0;
            int flag = 1;

            IList<Route> RouteList = _session.CreateQuery("select from Route c where c.State=:st")
                .SetString("st", "true")
                .List<Route>();                                                                                             //Считыванине всех Маршрутов из БД в Список
            
            if (RouteList.Count() != 0)
            {
                foreach (Route _route in RouteList)
                {
                    distance = Distance(route.StartLat, route.StartLon, _route.StartLat, _route.StartLon);                 //Рассчёт Расстояния между начальными точками Маршрутов

                    //Если Расстояние между начальными точками меньше заданного значения
                    if (distance < appropriateDistance && route.UserID != _route.UserID)
                    {
                        _route.Distance = Convert.ToString(distance);
                        AppropriateRoutes.Add(_route);
                        user = _session.Get<User>(Convert.ToInt32(_route.UserID));
                        ApproprateUser.Add(user);

                        foreach (User _user in ApproprateUser)
                        {
                            if (_user.UserID == user.UserID)
                                count++;
                        }

                        if (count == 0 && flag != 1)
                            ApproprateUser.Add(user);
                        else
                            count = 0;

                        flag = 0;
                    }
                }
            }

            return ApproprateUser;
        }

        public double Distance(string startX, string startY, string endX, string endY)                                  //Расстояние от точки Start до точки End
        {
            return Math.Sqrt(
                Math.Pow(Math.Abs(Convert.ToDouble(startX)) - Math.Abs( Convert.ToDouble(endX)), 2)
                + Math.Pow(Math.Abs(Convert.ToDouble(startY)) - Math.Abs( Convert.ToDouble(endY)), 2)
                );
        }

        public AppropriateRoutes()
        {
            _session = GetSession();                                                                                    //Открытие сессии
        }

        private ISession _session;

        private static ISession GetSession()                                                                            //Открытие сессии
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }
    }
}
