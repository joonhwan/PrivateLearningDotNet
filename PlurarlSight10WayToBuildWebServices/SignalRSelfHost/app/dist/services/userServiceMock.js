System.register(['angular-mocks', 'lodash', './userService'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var _, userService_1;
    var baseUri, UserServiceMock;
    function populateData() {
        return [
            {
                id: 1,
                userName: "jhlee",
                password: "winkler7"
            },
            {
                id: 2,
                userName: "guguboy",
                password: "guguboymirero"
            },
            {
                id: 3,
                userName: "hacho",
                password: "hachomirero"
            },
            {
                id: 4,
                userName: "limhs",
                password: "limhsmirero"
            },
            {
                id: 5,
                userName: "mirero",
                password: "mirero"
            }
        ];
    }
    return {
        setters:[
            function (_1) {},
            function (_2) {
                _ = _2;
            },
            function (userService_1_1) {
                userService_1 = userService_1_1;
            }],
        execute: function() {
            baseUri = userService_1.userServiceUri;
            UserServiceMock = (function () {
                function UserServiceMock($httpBackend, $timeout) {
                    var _this = this;
                    this.$httpBackend = $httpBackend;
                    this.$timeout = $timeout;
                    console.log("configuring user service mock e2e ....");
                    this.users = populateData();
                    this.$httpBackend.whenGET(userService_1.userServiceUri).respond(function (method, url, data, header, params) {
                        return [
                            200,
                            _this.users,
                            header,
                            "OK",
                        ];
                    });
                    var uriWithId = new RegExp(userService_1.userServiceUri + "/[0-9]+");
                    this.$httpBackend.whenGET(uriWithId).respond(function (metehod, url, data, header, params) {
                        var id = parseInt(url.split("/").slice(-1)[0]);
                        var found = _.find(_this.users, function (user) { return user.id === id; });
                        if (found) {
                            return [
                                200,
                                found,
                                header,
                                "OK",
                            ];
                        }
                        else {
                            return [404, null, header, "NOT FOUND"];
                        }
                    });
                    // var timeoutService = $timeout;
                    // console.log('timeout =' + timeoutService);
                    var uriWithName = new RegExp(userService_1.userServiceUri + "/[a-zA-Z].*");
                    this.$httpBackend.whenGET(uriWithName).respond(function (method, url, data, header, params) {
                        var name = url.split("/").slice(-1)[0];
                        var found = _.find(_this.users, function (user) {
                            return user.userName === name;
                        });
                        if (found) {
                            return [200, found, header, "OK"];
                        }
                        else {
                            return [404, null, header, "NOTFOUND!"];
                        }
                    });
                    this.$httpBackend.whenPOST(userService_1.userServiceUri).respond(function (method, url, data, header) {
                        var newUser = JSON.parse(data);
                        var existingUserWithSameName = _.find(_this.users, function (user) { return user.userName === newUser.userName; });
                        if (existingUserWithSameName) {
                            return [409, null, header, "Conflicted id"];
                        }
                        else {
                            var maxId = (_.maxBy(_this.users, function (user) { return user.id; })).id;
                            newUser.id = maxId + 1;
                            _this.users.push(newUser);
                            return [200, newUser, header, "OK"];
                        }
                    });
                    this.$httpBackend.whenGET(/app/).passThrough();
                    console.log("configured user service mock e2e ....");
                }
                UserServiceMock.$inject = ['$httpBackend', '$timeout'];
                return UserServiceMock;
            }());
            angular
                .module("userServiceMock", ["ngMockE2E"])
                .service('userServiceMock', UserServiceMock)
                .run(['userServiceMock', function (userServiceMock) {
                    // no-op. just instantiate userServiceMock...
                }]);
        }
    }
});
