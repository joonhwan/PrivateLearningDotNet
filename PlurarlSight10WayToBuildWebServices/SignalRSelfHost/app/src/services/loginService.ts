import angular from 'angular';
import {getServiceModule} from './serviceModule';
import {IUserService} from './userService';
import {ILocalAuthStoreService} from './localAuthStoreService';

export interface ILoginServiceResponse {
  success:boolean;
  failReason:string;
}

export interface ILoginService {
  login(userName:string, password:string, callback:(response:ILoginServiceResponse) => void) : void;
  setCredentials(userName:string, password:string) : void ;
  clearCredentials() : void; 
}

class LoginService implements ILoginService {
  static $inject = ['$http', '$timeout', 'userService', 'localAuthStoreService'];

  constructor(
    private $http:angular.IHttpService, 
    private $timeout:angular.ITimeoutService,
    private userService:IUserService,
    private localAuthStoreService:ILocalAuthStoreService
    ) {
  }
  base64: Base64 = new Base64(); // see below

  login(userName:string, password:string, callback:(response:ILoginServiceResponse) => void) : void {
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
      .then(user => {
        if(user.password === password) {
          callback({
            success:true,
            failReason:"",
          });
          this.setCredentials(userName, password);
        } else {
          callback({
            success:false,
            failReason:"invalid password"
          });
        }
      })
      .catch(reason => {
        callback({
          success:false,
          failReason:"invalid user name"
        });
      })
  }

  setCredentials(userName:string, password:string) : void {
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
      id:0, // TODO FixIt
      userName: userName,
      password: password
    })
  }

  clearCredentials() : void {
    // (<any>this.$rootScope).globals = {};
    // this.$cookieStore.remove('globals');
    // this.$http.defaults.headers.common['Authorization'] = 'Basic ';
    // console.log("cleared cookie.");
    this.localAuthStoreService.set(null);
  }
}

class Base64 {
  
  keyStr:string = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
 
  encode(input:string): string  {
    var keyStr = this.keyStr;
    var output = "";
    var chr1:number, chr2:number, chr3:number;
    var enc1:number, enc2:number, enc3:number, enc4:number;
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
        } else if (isNaN(chr3)) {
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
 
  decode(input:string) : string {
    var keyStr = this.keyStr;
    var output = "";
    var chr1:number, chr2:number, chr3:number;
    var enc1:number, enc2:number, enc3:number, enc4:number;
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
  }
}

console.log("registering loginService...");
getServiceModule().service("loginService", LoginService);