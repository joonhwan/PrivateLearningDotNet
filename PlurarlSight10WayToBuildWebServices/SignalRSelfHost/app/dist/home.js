System.register(['angular'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular_1;
    var HomeController;
    return {
        setters:[
            function (angular_1_1) {
                angular_1 = angular_1_1;
            }],
        execute: function() {
            //console.log("loading home module...");
            HomeController = (function () {
                function HomeController($location, loginService, localAuthStoreService) {
                    this.$location = $location;
                    this.loginService = loginService;
                    this.localAuthStoreService = localAuthStoreService;
                    this.message = "Message from Home Controller";
                    this.message = "Welcome " + localAuthStoreService.get().userName;
                }
                HomeController.prototype.logOut = function () {
                    console.log("logout...");
                    this.$location.path("/login");
                    this.loginService.clearCredentials();
                };
                HomeController.$inject = ['$location', 'loginService', 'localAuthStoreService'];
                return HomeController;
            }());
            angular_1.default
                .module("home", [])
                .controller('homeController', HomeController);
        }
    }
});
