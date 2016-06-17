System.register(['./serviceModule'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var serviceModule_1;
    var baseUri, UserService, UserServiceDelayed;
    return {
        setters:[
            function (serviceModule_1_1) {
                serviceModule_1 = serviceModule_1_1;
            }],
        execute: function() {
            //여기있는 type들은 server side 와 맞추어야 함. -_-
            baseUri = "/api/users";
            exports_1("userServiceUri", baseUri);
            UserService = (function () {
                function UserService($http, $q) {
                    this.$http = $http;
                    this.$q = $q;
                }
                UserService.prototype.create = function (user) {
                    //return this.$http.post<IUser>(baseUri, user);
                    var deferred = this.$q.defer();
                    this.$http.post(baseUri, user)
                        .success(function (data) { return deferred.resolve(data); })
                        .error(function (data, status) {
                        var args = [];
                        for (var _i = 2; _i < arguments.length; _i++) {
                            args[_i - 2] = arguments[_i];
                        }
                        deferred.reject(status == 409 ? "Already registered user name!" : 'ERROR:' + status);
                    });
                    return deferred.promise;
                };
                UserService.prototype.getByUserName = function (userName) {
                    // return this.$http.get<IUser>(baseUri + '/' + userName);
                    var deferred = this.$q.defer();
                    this.$http.get(baseUri + '/' + userName)
                        .success(function (data) {
                        deferred.resolve(data);
                    })
                        .error(function (data, status) {
                        deferred.reject(status);
                    });
                    return deferred.promise;
                };
                UserService.prototype.getById = function (id) {
                    return this.$http.get(baseUri + '/' + id);
                    // var deferred = this.$q.defer<IUser>();
                    // this.$http.get<IUser>(baseUri + '/' + id)
                    //   //.success((data: IUser, status: number, headers: angular.IHttpHeadersGetter, config: angular.IRequestConfig) => {
                    //   .success((data) => deferred.resolve(data))
                    //   // .error((data:any, status: number, headers: angular.IHttpHeadersGetter, config: angular.IRequestConfig) => {
                    //   .error((data, status) => deferred.reject('ERROR:' + status));
                    // return deferred.promise;
                };
                UserService.prototype.getAll = function () {
                    return this.$http.get(baseUri);
                    // // NOTE: 이 메소드의 구현은 결국, 임의의 Promise형을 다른 형태로 변경하는 방법...
                    // var deferred = this.$q.defer<IUser[]>();
                    // this.$http.get(baseUri)
                    //   //원본 success 시그너쳐 (data: T, status: number, headers: IHttpHeadersGetter, config: IRequestConfig):
                    //   // 길게 쓰나..
                    //   // .success((data:IUser[], status:number, headers: angular.IHttpHeadersGetter, config:angular.IRequestConfig) => {
                    //   //   deferred.resolve(<IUser[]>data);
                    //   // })
                    //   // 짧게 쓰나. 비슷
                    //   .success((data, status) => {
                    //       deferred.resolve(<IUser[]>data);
                    //   })
                    //   //(data: T, status: number, headers: IHttpHeadersGetter, config: IRequestConfig):
                    //   .error((data, status) => {
                    //     deferred.reject(null);
                    //   });
                    //   return deferred.promise;
                };
                UserService.prototype.update = function (user) {
                    return this.$http.put(baseUri + '/' + user.id, user);
                };
                UserService.prototype.deleteById = function (id) {
                    return this.$http.delete(baseUri + '/' + id);
                };
                UserService.$inject = ['$http', '$q'];
                return UserService;
            }());
            UserServiceDelayed = (function () {
                function UserServiceDelayed($q, userService, delay) {
                    this.$q = $q;
                    this.userService = userService;
                    this.delay = delay;
                }
                UserServiceDelayed.prototype.create = function (user) {
                    var _this = this;
                    var d = this.$q.defer();
                    setTimeout(function () { return _this.userService.create(user).then(d.resolve, d.reject); }, this.delay);
                    return d.promise;
                };
                UserServiceDelayed.prototype.getByUserName = function (userName) {
                    var _this = this;
                    var d = this.$q.defer();
                    setTimeout(function () { return _this.userService.getByUserName(userName).then(d.resolve, d.reject); }, this.delay);
                    return d.promise;
                };
                UserServiceDelayed.prototype.getById = function (id) {
                    var _this = this;
                    var d = this.$q.defer();
                    setTimeout(function () { return _this.userService.getById(id).then(d.resolve, d.reject); }, this.delay);
                    return d.promise;
                };
                UserServiceDelayed.prototype.getAll = function () {
                    var _this = this;
                    var d = this.$q.defer();
                    setTimeout(function () { return _this.userService.getAll().then(d.resolve, d.reject); }, this.delay);
                    return d.promise;
                };
                UserServiceDelayed.prototype.update = function (user) {
                    var _this = this;
                    var d = this.$q.defer();
                    setTimeout(function () { return _this.userService.update(user).then(d.resolve, d.reject); }, this.delay);
                    return d.promise;
                };
                UserServiceDelayed.prototype.deleteById = function (id) {
                    return this.deleteById(id);
                };
                UserServiceDelayed.$inject = ['$q', 'userServiceNoDelayed', 'userServiceDelay'];
                return UserServiceDelayed;
            }());
            console.log('registering user service..');
            serviceModule_1.getServiceModule()
                .constant('userServiceDelay', 3000)
                .service('userServiceNoDelayed', UserService)
                .service('userServiceDelayed', UserServiceDelayed)
                .config(['$provide', 'userServiceDelay', function ($provide, userServiceDelay) {
                    if (userServiceDelay > 0) {
                        console.log("user service will delay execution!");
                        $provide.service("userService", UserServiceDelayed);
                    }
                    else {
                        console.log("user service in production mode.");
                        $provide.service("userService", UserService);
                    }
                }]);
        }
    }
});
