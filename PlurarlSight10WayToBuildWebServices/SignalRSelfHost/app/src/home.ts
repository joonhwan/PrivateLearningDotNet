import angular from 'angular';
import {ILoginService} from './services/loginService';
import {ILocalAuthStoreService} from './services/localAuthStoreService';
//console.log("loading home module...");

class HomeController {
  static $inject = ['$location', 'loginService', 'localAuthStoreService'];
  constructor(private $location:angular.ILocationService,
  private loginService:ILoginService,
  private localAuthStoreService:ILocalAuthStoreService) {
    this.message = "Welcome " + localAuthStoreService.get().userName;
  }

  message:string = "Message from Home Controller";
  
  logOut(): void {
    console.log("logout...");
    this.$location.path("/login");
    this.loginService.clearCredentials();
  }
}

angular
  .module("home", [])
  .controller('homeController', HomeController);