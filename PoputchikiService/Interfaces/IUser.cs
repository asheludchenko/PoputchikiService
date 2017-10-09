using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace PoputchikiService
{
    [ServiceContract]
    public interface IUser
    {

        [OperationContract]
        User GetUserInformationByID( string userId);                                                         //Получение информации о пользователе

        [OperationContract]
        RETURN RegisterUser( User user);                                                                     //Регистрация пользователя

        [OperationContract]
        Auto GetAutoInformationByID( string autoId);                                                         //Получение информации о автомобиле

        [OperationContract]
        void RegisterAuto( Auto auto);                                                                       //Регистрация автомобиля

        [OperationContract]
        IList<Brand> GetBrands();                                                                           //Получение списка Марок автомобилей

        [OperationContract]
        IList<Auto> GetUserAutoByUserID( string userId);                                                     //Получение автомобилей пользователя

        [OperationContract]
        IList<Model> GetModels( string brandId);                                                             //Получение списка Моделей автомобилей нужной Марки 

        [OperationContract]
        void PostUserLocation( string lon, string lat, User user);                                           //Передеча текущих координат пользователя

        [OperationContract]
        void PostRouteInformation( Route route);                                                             //Передача маршрута

        [OperationContract]
        IList<Route> GetRoutes( string userId);                                                              //Получение маршрутов пользователя

        [OperationContract]
        User UserAuthorise( User user);                                                                      //Авторизация пользователя

        [OperationContract]
        RETURN CheckLogin( User user);                                                                       //Проверка Логина

        [OperationContract]
        IList<User> GetAppropriateRoute( Route route);                                                      //Получение подходящих маршрутов

        [OperationContract]
        IList<Route> GetUserRoute( Route route);                                                            //Получение подходящих Маршрутов определённого пользователя

        [OperationContract]
        RETURN RouteUpdate(Route route);                                                                      //Обновление маршрута
    }
}
