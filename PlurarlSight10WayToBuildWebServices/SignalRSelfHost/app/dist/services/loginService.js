System.register(['./serviceModule'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var serviceModule_1;
    var LoginService, Base64;
    return {
        setters:[
            function (serviceModule_1_1) {
                serviceModule_1 = serviceModule_1_1;
            }],
        execute: function() {
            LoginService = (function () {
                function LoginService($http, $timeout, userService, localAuthStoreService) {
                    this.$http = $http;
                    this.$timeout = $timeout;
                    this.userService = userService;
                    this.localAuthStoreService = localAuthStoreService;
                    this.base64 = new Base64(); // see below
                }
                LoginService.prototype.login = function (userName, password, callback) {
                    var _this = this;
                    // dummy impl
                    console.log('loginservice login..');
                    // this.$timeout(_ => {
                    //   var response = {
                    //     success: userName === 'test' && password === 'test',
                    //     failReason: userName !== 'test' ? 'invalid user name' : (password !== 'test' ? 'invalid password' : null)
                    //   };
                    //   if(response.success) {
                    //     this.setCredentials(userName, password);
                    //   }
                    //   callback(response);
                    // }, 1000);
                    this.userService.getByUserName(userName)
                        .then(function (user) {
                        if (user.password === password) {
                            callback({
                                success: true,
                                failReason: "",
                            });
                            _this.setCredentials(userName, password);
                        }
                        else {
                            callback({
                                success: false,
                                failReason: "invalid password"
                            });
                        }
                    })
                        .catch(function (reason) {
                        callback({
                            success: false,
                            failReason: "invalid user name"
                        });
                    });
                };
                LoginService.prototype.setCredentials = function (userName, password) {
                    // var authData = this.base64.encode(userName + ":" + password);
                    // (<any>this.$rootScope).globals = {
                    //   currentUser: {
                    //     userName: userName,
                    //     authData: authData
                    //   }
                    // };
                    // this.$http.defaults.headers.common['Authorization'] = "Basic " + authData;
                    // this.$cookieStore.put('globals', (<any>this.$rootScope).globals);
                    this.localAuthStoreService.set({
                        id: 0,
                        userName: userName,
                        password: password
                    });
                };
                LoginService.prototype.clearCredentials = function () {
                    // (<any>this.$rootScope).globals = {};
                    // this.$cookieStore.remove('globals');
                    // this.$http.defaults.headers.common['Authorization'] = 'Basic ';
                    // console.log("cleared cookie.");
                    this.localAuthStoreService.set(null);
                };
                LoginService.$inject = ['$http', '$timeout', 'userService', 'localAuthStoreService'];
                return LoginService;
            }());
            Base64 = (function () {
                function Base64() {
                    this.keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
                }
                Base64.prototype.encode = function (input) {
                    var keyStr = this.keyStr;
                    var output = "";
                    var chr1, chr2, chr3;
                    var enc1, enc2, enc3, enc4;
                    // var chr1 = "", chr2 = "", chr3 = "";
                    // var enc1 = "", enc2 = "", enc3 = "", enc4 = "";
                    var i = 0;
                    do {
                        chr1 = input.charCodeAt(i++);
                        chr2 = input.charCodeAt(i++);
                        chr3 = input.charCodeAt(i++);
                        enc1 = chr1 >> 2;
                        enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                        enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                        enc4 = chr3 & 63;
                        if (isNaN(chr2)) {
                            enc3 = enc4 = 64;
                        }
                        else if (isNaN(chr3)) {
                            enc4 = 64;
                        }
                        output = output +
                            keyStr.charAt(enc1) +
                            keyStr.charAt(enc2) +
                            keyStr.charAt(enc3) +
                            keyStr.charAt(enc4);
                        chr1 = chr2 = chr3 = 0;
                        enc1 = enc2 = enc3 = enc4 = 0;
                    } while (i < input.length);
                    return output;
                };
                ;
                Base64.prototype.decode = function (input) {
                    var keyStr = this.keyStr;
                    var output = "";
                    var chr1, chr2, chr3;
                    var enc1, enc2, enc3, enc4;
                    var i = 0;
                    // remove all characters that are not A-Z, a-z, 0-9, +, /, or =
                    var base64test = /[^A-Za-z0-9\+\/\=]/g;
                    if (base64test.exec(input)) {
                        window.alert("There were invalid base64 characters in the input text.\n" +
                            "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
                            "Expect errors in decoding.");
                    }
                    input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");
                    do {
                        enc1 = keyStr.indexOf(input.charAt(i++));
                        enc2 = keyStr.indexOf(input.charAt(i++));
                        enc3 = keyStr.indexOf(input.charAt(i++));
                        enc4 = keyStr.indexOf(input.charAt(i++));
                        chr1 = (enc1 << 2) | (enc2 >> 4);
                        chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                        chr3 = ((enc3 & 3) << 6) | enc4;
                        output = output + String.fromCharCode(chr1);
                        if (enc3 != 64) {
                            output = output + String.fromCharCode(chr2);
                        }
                        if (enc4 != 64) {
                            output = output + String.fromCharCode(chr3);
                        }
                        chr1 = chr2 = chr3 = 0;
                        enc1 = enc2 = enc3 = enc4 = 0;
                    } while (i < input.length);
                    return output;
                };
                return Base64;
            }());
            console.log("registering loginService...");
            serviceModule_1.getServiceModule().service("loginService", LoginService);
        }
    }
});
