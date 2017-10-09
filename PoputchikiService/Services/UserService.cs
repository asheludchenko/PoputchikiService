using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Expression;

namespace PoputchikiService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UserService : IUser
    {

        public User GetUserInformationByID(string userId)
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session.Get<User>(Convert.ToInt32(userId));
        }

        public RETURN RegisterUser(User user)
        {
            RETURN usr = new RETURN();
            _session.Save(user);
            return usr;
        }

        public User UserAuthorise(User user)
        {
            IList<User> userlist = _session.CreateQuery("select from User c where c.Login=:uid and c.Password=:up").SetString("uid",Convert.ToString(user.UserID)).SetString("up",user.Password).List<User>();
            int length = userlist.Count();
            return user;
        }

        public RETURN CheckLogin(User user)
        {
            RETURN usr = new RETURN();
            IList<User> userlist = _session.CreateQuery("select from User c where c.Login=:ul")
                .SetString("ul", user.Login)
                .List<User>();
            int count = userlist.Count();
            int userid;
            if (count == 0)
            {
                userid = 1;
            }
            else
            {
                userid = 0;
            }
            usr.UserID = userid;
            return usr;
        }

        public void RegisterAuto(Auto auto)
        {
            _session.Save(auto);
        }

        public Auto GetAutoInformationByID(string autoId)
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session.Get<Auto>(Convert.ToInt32(autoId));
        }

        public IList<Brand> GetBrands()
        {
            return _session.CreateQuery("select all from Brand").List<Brand>();
        }

        public IList<Model> GetModels(string brandId)
        {
            return _session.CreateQuery("select from Brand c where c.BrandID:=bid").SetString("bid", brandId).List<Model>();
        }

        public void PostUserLocation(string lon, string lat, User user)
        {
            User tempUser = GetUserInformationByID(Convert.ToString(user.UserID));
            tempUser.CurrentLat = lat;
            tempUser.CurrentLon = lon;
            UpdateUserInformation(tempUser);
        }

        public void PostRouteInformation(Route route)
        {
            _session.Save(route);
        }

        public IList<Route> GetRoutes(string userId)
        {
            return _session.CreateQuery("select from Route c where c.UserID=:uid").SetString("uid", userId).List<Route>();
        }

        public void UpdateUserInformation(User user)
        {
            _session.Update(user);
        }

        public IList<Auto> GetUserAutoByUserID(string userId)
        {
            return _session.CreateQuery("select from User c where c.UserID=" + userId).List<Auto>();
        }

        public IList<User> GetAppropriateRoute(Route route)
        {
            return _session.CreateQuery("selsect all from User").List<User>();
        }

        private ISession _session;

        private static ISession GetSession()
        {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session;
        }

        public UserService()
        {
            _session = GetSession();
        }

        public IList<Route> GetUserRoute(Route route)
        {
            return _session.CreateQuery("select all from Route").List<Route>();
        }

        public RETURN RouteUpdate(Route route)
        {
            RETURN usr = new RETURN();
            return usr;
        }
    }
}
