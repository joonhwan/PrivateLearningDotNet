/// <reference path="../../typings/tsd.d.ts" />
System.register(['angular', 'angular-route', 'angular-cookies', 'bootstrap/css/bootstrap.min.css!', 'font-awesome/css/font-awesome.min.css!', './login', './home', './register', './services/serviceModule'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular;
    var app;
    return {
        setters:[
            function (angular_1) {
                angular = angular_1;
            },
            function (_1) {},
            function (_2) {},
            function (_3) {},
            function (_4) {},
            function (_5) {},
            function (_6) {},
            function (_7) {},
            function (_8) {}],
        execute: function() {
            console.log("registering main module...");
            app = angular
                .module("AngularSimpleAuthApp", [
                'serviceModule',
                'userServiceMock',
                'login',
                'home',
                'register',
                'ngRoute',
            ]);
            app
                .config(['$routeProvider', function ($routeProvider) {
                    console.log('configuring router...');
                    $routeProvider
                        .when('/login', {
                        controller: 'loginController',
                        controllerAs: 'vm',
                        templateUrl: 'app/views/login.html'
                    })
                        .when('/register', {
                        controller: 'registerController',
                        controllerAs: 'vm',
                        templateUrl: 'app/views/register.html'
                    })
                        .when('/', {
                        controller: 'homeController as vm',
                        templateUrl: 'app/views/home.html'
                    })
                        .otherwise({
                        redirectTo: '/login'
                    });
                    console.log('configured rounter.');
                }])
                .run(['$rootScope', '$location', '$http', 'localAuthStoreService',
                function ($rootScope, $location, $http, localAuthStoreService) {
                    console.log("app module run start..");
                    $rootScope.$on('$locationChangeStart', function (event, next, current) {
                        var isNonRestrictedPage = _.find(['/login', '/register'], function (s) { return s === $location.path(); });
                        var loggedIn = localAuthStoreService.get();
                        if (!isNonRestrictedPage && !loggedIn) {
                            $location.path('/login');
                        }
                    });
                    console.log("app module run stop..");
                }]);
            console.log("loaded main module");
        }
    }
});
