import angular from 'angular';
import {getServiceModule} from './serviceModule';

//여기있는 type들은 server side 와 맞추어야 함. -_-
const baseUri = "/api/users";
export {baseUri as userServiceUri}

export interface IUser {
  id:number;
  userName:string;
  password:string;
}

export interface IUserService {
  create(user:IUser):ng.IPromise<IUser>;
  getByUserName(userName:string):ng.IPromise<IUser>;
  getById(id:number):ng.IPromise<IUser>;
  getAll():ng.IPromise<IUser[]>;
  update(user:IUser):ng.IPromise<IUser>;
  deleteById(id:number):ng.IPromise<IUser>;
}

class UserService implements IUserService {
  static $inject = ['$http', '$q']

  constructor(
    private $http:angular.IHttpService,
    private $q:angular.IQService
    ) {

  }
  create(user:IUser):ng.IPromise<IUser> {
    //return this.$http.post<IUser>(baseUri, user);
    let deferred = this.$q.defer<IUser>();
    this.$http.post<IUser>(baseUri, user)
      .success((data) => deferred.resolve(data))
      .error((data:any, status:any, ...args:any[]) => {
        deferred.reject(status==409 ? "Already registered user name!" : 'ERROR:' + status);
      })
      ;
    return deferred.promise;
  }
  getByUserName(userName:string):ng.IPromise<IUser> {
    // return this.$http.get<IUser>(baseUri + '/' + userName);
    var deferred = this.$q.defer<IUser>();
    this.$http.get<IUser>(baseUri + '/' + userName)
      .success(data => {
        deferred.resolve(data);
      })
      .error((data, status) => {
        deferred.reject(status);
      });
    return deferred.promise;
  }
  getById(id:number):ng.IPromise<IUser> {
    return this.$http.get<IUser>(baseUri + '/' + id);
    // var deferred = this.$q.defer<IUser>();
    // this.$http.get<IUser>(baseUri + '/' + id)
    //   //.success((data: IUser, status: number, headers: angular.IHttpHeadersGetter, config: angular.IRequestConfig) => {
    //   .success((data) => deferred.resolve(data))
    //   // .error((data:any, status: number, headers: angular.IHttpHeadersGetter, config: angular.IRequestConfig) => {
    //   .error((data, status) => deferred.reject('ERROR:' + status));
    // return deferred.promise;
  }
  getAll():ng.IPromise<IUser[]> {

    return this.$http.get<IUser[]>(baseUri);
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
  }
  update(user:IUser):ng.IPromise<IUser>  {
    return this.$http.put<IUser>(baseUri + '/' + user.id, user);
  }
  deleteById(id:number):ng.IPromise<IUser> {
    return this.$http.delete<IUser>(baseUri + '/' + id);
  }

  // handleSuccess(response:ng.IHttpPromiseCallbackArg<IUserServiceResponse>):IUserServiceResponse {
  //   return {
  //     user:response.data,
  //     success: true,
  //     failReason: ''
  //   };
  // }
  // handleError(failReason:string):(reason:any) => IUserServiceResponse {
  //   // reason:any 를 입력받는 함수를 반환한다. 그 함수에서는 원하는 IUserServiceResponse를 반환한다.
  //   return _ => {
  //     return  {
  //       user: null,
  //       success:false,
  //       failReason:failReason
  //     };
  //   }
  // } 
}

class UserServiceDelayed implements IUserService {
  static $inject = ['$q', 'userServiceNoDelayed', 'userServiceDelay'];
  constructor(
    private $q:angular.IQService, 
    private userService:UserService, 
    private delay:number) {
  }
  create(user:IUser):ng.IPromise<IUser>
  {
    let d = this.$q.defer();
    setTimeout(() => this.userService.create(user).then(d.resolve, d.reject), this.delay);
    return d.promise;
  }
  getByUserName(userName:string):ng.IPromise<IUser> {
    let d = this.$q.defer();
    setTimeout(() => this.userService.getByUserName(userName).then(d.resolve, d.reject), this.delay);
    return d.promise;
  }
  getById(id:number):ng.IPromise<IUser> {
    let d = this.$q.defer();
    setTimeout(()=>this.userService.getById(id).then(d.resolve, d.reject), this.delay);
    return d.promise;
  }
  getAll():ng.IPromise<IUser[]> {
    let d = this.$q.defer();
    setTimeout(() => this.userService.getAll().then(d.resolve, d.reject), this.delay);
    return d.promise;
  }
  update(user:IUser):ng.IPromise<IUser> {
    let d = this.$q.defer();
    setTimeout(()=>this.userService.update(user).then(d.resolve, d.reject), this.delay);
    return d.promise;
  }
  deleteById(id:number):ng.IPromise<IUser> {
    return this.deleteById(id);
  }
}

console.log('registering user service..');
getServiceModule()
  .constant('userServiceDelay', 3000)
  .service('userServiceNoDelayed', UserService)
  .service('userServiceDelayed', UserServiceDelayed)
  .config(['$provide', 'userServiceDelay', ($provide:angular.IModule, userServiceDelay:number) => {
    if(userServiceDelay>0) {
      console.log("user service will delay execution!");
      $provide.service("userService", UserServiceDelayed);
    } else {
      console.log("user service in production mode.");
      $provide.service("userService", UserService);
    }
  }])
  //.service('userService', UserServiceDelayed)
  ;
  