using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoputchikiService
{
    public static class Routing
    {

        public const string PostUserInformation = "/user/register";                                     //регистрация пользователя                              !

        public const string GetUserInformationById = "/user/{userId}";                                  //получение информации о пользователе                   !

        public const string PostAutoInformation = "/user/auto/register";                                //регистрация автомобиля пользователя                   !

        public const string GetAutoInformation = "/user/auto/{autoId}";                                 //получение информации об автомобилях пользователя      !

        public const string GetUserAutoByUserID = "/user/auto/find/{userId}";                           //получение автомоилей потльзователя                    !

        public const string PostUserLocation = "/user/location/?lon={lon}&lat={lat}";                   //передача текущич координат пользователя               !

        public const string GetBrands = "/brands";                                                      //Марки автомобилей                                     !

        public const string GetModels = "/models/{brandId}";                                            //Марки автомобилей                                     !

        public const string PostRouteInformarion = "/route/add";                                        //отправка маршрута                                     !

        public const string GetRoutes = "/route/{userId}";                                              //Получение маршрута                                    !

        public const string UserAuthorisation = "/user/authorise";                                      //Авторизация пользователя                              !

        public const string CheckLogin = "/user/checklogin";                                            //Проверка Логина                                       !

        public const string GetAppropriateRoutes = "/find/list";                                        //подходящие попутчики                                  !

        public const string GetMostAppropriateRoutes = "/find/best";                                    //самые подходящие попутчики

        public const string GetUserRoutes = "/find/userroute";                                          //подходящие маршруты выбранного пользователя           !

        public const string RouteUpdate = "/route/update";                                              //Обновление Маршрута                                   ! 

    }
}
