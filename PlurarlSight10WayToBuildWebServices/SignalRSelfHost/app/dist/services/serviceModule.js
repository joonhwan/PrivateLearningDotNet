System.register(['angular', './userService', './loginService', './userServiceMock', './localAuthStoreService'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var angular_1;
    var serviceModule;
    function getServiceModule() {
        if (!serviceModule) {
            console.log("creating service modules...");
            serviceModule = angular_1.default.module('serviceModule', [
                'ngCookies'
            ]);
        }
        return serviceModule;
    }
    exports_1("getServiceModule", getServiceModule);
    return {
        setters:[
            function (angular_1_1) {
                angular_1 = angular_1_1;
            },
            function (_1) {},
            function (_2) {},
            function (_3) {},
            function (_4) {}],
        execute: function() {
            serviceModule = null;
        }
    }
});
