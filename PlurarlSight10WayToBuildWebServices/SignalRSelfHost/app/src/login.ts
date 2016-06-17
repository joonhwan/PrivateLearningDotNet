import angular from 'angular';
import * as toastr from 'toastr';
import {ILoginService} from "./services/loginService";
import {IUserService} from "./services/userService";

//console.log("loading login module...");

class LoginController {

  static $inject = ['$location', 'loginService', 'userService'];

  constructor(
    private $location: angular.ILocationService,
    private loginService: ILoginService,
    private userService: IUserService) {

    console.log("creating login controller...");
    //loginService.clearCredentials();

    //this.testE2e();
  }
  userName: string;
  password: string;
  dataLoading: boolean = false;
  loginError: string;
  message: string = "Login message from LoginController";

  login(): void {
    this.dataLoading = true;
    this.loginError = "";
    this.loginService.login(this.userName, this.password, response => {
      if (response.success) {
        this.loginError = "";
        this.$location.path('/');
      } else {
        this.loginError = response.failReason
        this.dataLoading = false;
        // toastr.error(response.failReason);
      }
    });
  }

  private testE2e(): void {

    console.log('testing e2e!!!');
    this.userService.getAll().then(response => {
      for (var i = 0; i < response.length; ++i) {
        console.log("--> user:" + JSON.stringify(response[i]));
      }
    });
    this.userService.getById(4).then(response => {
      console.log("--> id=4 user:" + JSON.stringify(response));
    });
    this.userService.getById(88).then(response => {
      console.log("response:" + JSON.stringify(response) + "--> id=88 user:" + JSON.stringify(response));
    }).catch(reason => {
      console.log("response:" + JSON.stringify(reason) + "--> id=88 user not found");
    });

    this.userService.getByUserName("jhlee")
      .then(response => {
        console.log("get by name response : " + JSON.stringify(response));
      })
      .catch(reason => {
        console.log("get by name failed : reason=" + JSON.stringify(reason));
      })
      ;

    this.userService.create({
      id: 0,
      userName: "seoyoen",
      password: "okmsy"
    })
      .then(response => {
        console.log("create response : " + JSON.stringify(response));
      })
      .catch(reason => {
        console.log("create failed : " + JSON.stringify(reason));
      });
  }

}

angular
  .module("login", [])
  .controller("loginController", LoginController);
