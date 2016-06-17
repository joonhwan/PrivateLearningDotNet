System.register(['./serviceModule'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var serviceModule_1;
    var LocalAuthStoreService;
    return {
        setters:[
            function (serviceModule_1_1) {
                serviceModule_1 = serviceModule_1_1;
            }],
        execute: function() {
            LocalAuthStoreService = (function () {
                function LocalAuthStoreService($cookieStore) {
                    this.$cookieStore = $cookieStore;
                    this.user = $cookieStore.get('globals') || null;
                }
                LocalAuthStoreService.prototype.get = function () {
                    return this.user;
                };
                LocalAuthStoreService.prototype.set = function (user) {
                    this.$cookieStore.put('globals', user);
                    this.user = user;
                };
                LocalAuthStoreService.$inject = ['$cookieStore'];
                return LocalAuthStoreService;
            }());
            console.log("registering localAuthStoreService...");
            serviceModule_1.getServiceModule().service('localAuthStoreService', LocalAuthStoreService);
        }
    }
});
