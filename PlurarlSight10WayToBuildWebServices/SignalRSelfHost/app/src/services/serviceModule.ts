import angular from 'angular';
import './userService';
import './loginService';
import './userServiceMock';
import './localAuthStoreService';

var serviceModule:angular.IModule = null;
export function getServiceModule() : angular.IModule {
  if(!serviceModule) {
    console.log("creating service modules...");
    serviceModule = angular.module('serviceModule', [
      'ngCookies'
    ]);
  }
  return serviceModule;
}
