/// <reference path="../../typings/tsd.d.ts" />

import * as angular from 'angular';
import 'angular-route';
import 'angular-cookies';
import 'bootstrap/css/bootstrap.min.css!';
//import 'font-awesome/css/font-awesome.min.css!';
//import 'bootstrap';
import 'font-awesome';

//import {ILoginRootScopeService, ILoginGlobalData, LoginGlobalData} from './services/loginRootScopeService';

// declare modules
import './login';
import './home';
import './register';
import './services/serviceModule';
import {ILocalAuthStoreService} from './services/localAuthStoreService';

console.log("registering main module...");

var app = 
angular
    .module("AngularSimpleAuthApp", [
        'serviceModule',
        'userServiceMock',
        'login',
        'home',
        'register',
        'ngRoute',
    ]);
   
app
    .config(['$routeProvider', function ($routeProvider: ng.route.IRouteProvider) {

        console.log('configuring router...');
        $routeProvider
            .when('/login', {
                controller: 'loginController',
                controllerAs: 'vm',
                templateUrl: 'app/views/login.html'
                //hideMenus: true
            })
            .when('/register', {
                controller: 'registerController',
                controllerAs: 'vm',
                templateUrl: 'app/views/register.html'
            })
            .when('/', {
                controller: 'homeController as vm', // 별도의 controllerAs 말고..한번에.
                templateUrl: 'app/views/home.html'
            })
            .otherwise({
                redirectTo: '/login'
            })
            ;
        console.log('configured rounter.');
    }])
    .run(['$rootScope', '$location', '$http', 'localAuthStoreService',
        function (
            $rootScope: angular.IRootScopeService,
            $location: angular.ILocationService,
            $http: angular.IHttpService,
            localAuthStoreService:ILocalAuthStoreService
            ) {

            console.log("app module run start..");
    
            $rootScope.$on('$locationChangeStart', function (event, next, current) {
                
                var isNonRestrictedPage = _.find(['/login', '/register'], s => s===$location.path());
                var loggedIn = localAuthStoreService.get();
                if (!isNonRestrictedPage && !loggedIn) {
                    $location.path('/login');
                }
            });
        }]);

console.log("loaded main module");
