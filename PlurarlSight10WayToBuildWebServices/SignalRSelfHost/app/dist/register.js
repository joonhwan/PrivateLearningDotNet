System.register(['angular'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular_1;
    var RegisterController;
    return {
        setters:[
            function (angular_1_1) {
                angular_1 = angular_1_1;
            }],
        execute: function() {
            RegisterController = (function () {
                function RegisterController($location, $rootScope, userService) {
                    this.$location = $location;
                    this.$rootScope = $rootScope;
                    this.userService = userService;
                }
                RegisterController.prototype.register = function () {
                    var _this = this;
                    this.registering = true;
                    this.userService.create(this.user)
                        .then(function (_) {
                        _this.registering = false;
                        _this.$location.path('/login');
                    })
                        .catch(function (reason) {
                        _this.registering = false;
                        _this.lastError = reason;
                    });
                };
                RegisterController.$inject = ['$location', '$rootScope', 'userService'];
                return RegisterController;
            }());
            angular_1.default
                .module('register', [])
                .controller('registerController', RegisterController);
        }
    }
});
