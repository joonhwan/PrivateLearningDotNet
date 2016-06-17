import angular from 'angular';
import {getServiceModule} from './serviceModule';
import {IUser} from './userService';

export interface ILocalAuthStoreService {
  get(): IUser;
  set(user:IUser): void;
}

class LocalAuthStoreService implements ILocalAuthStoreService {
  static $inject : string[] = ['$cookieStore'];
  constructor(
    private $cookieStore: angular.cookies.ICookieStoreService
  ) {
    this.user = $cookieStore.get('globals') || null;
  }

  private user:IUser;

  get(): IUser {
    return this.user; 
  }

  set(user:IUser) : void {
    this.$cookieStore.put('globals', user);
    this.user = user;
  }
}

console.log("registering localAuthStoreService...");
getServiceModule().service('localAuthStoreService', LocalAuthStoreService);