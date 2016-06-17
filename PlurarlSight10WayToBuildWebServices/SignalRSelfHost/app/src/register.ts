import angular from 'angular';

interface IUserServiceResponse {
    success:boolean;
    failReason:string;
}

interface IUserService {
  create(user:IUser):angular.IPromise<IUserServiceResponse>;
}

interface IUser {
  
}

class RegisterController {
  static $inject = ['$location', '$rootScope', 'userService'];
  constructor(
    private $location: angular.ILocationService,
    private $rootScope: angular.IRootScopeService,
    private userService: IUserService
  ) {

  }
  user: IUser;
  registering: boolean;
  lastError: string;

  register(): void {
    this.registering = true;
    this.userService.create(this.user)
      .then(_ => {
        this.registering = false;
        this.$location.path('/login');
      })
      .catch((reason:any) => {
        this.registering = false;
        this.lastError = reason;
      })
      ;
  }
}

angular
  .module('register', [])
  .controller('registerController', RegisterController)
  ;