/// <reference path="scripts/angular-1.3.15/angular.js" />
/// <reference path="scripts/angular-1.3.15/angular-route.js" />

var app = angular.module("ApiDocApp", ["ngRoute"]);
app.factory("ApiSvc", function ($http, $q) {
    var apis = [];
    var queryPromise = undefined;
    var service = {
        get: function () {
            var defer = $q.defer();
            if (apis && apis.length) {
                defer.resolve(apis);
                return defer.promise;
            }
            if (queryPromise) {
                return queryPromise;
            }

            $http({
                method: "GET",
                url: "/"
            }).then(function (ngResponse) {
                apis = ngResponse.data;
                defer.resolve(apis);
            }, function (err) {
                defer.reject(err);
            });

            queryPromise = defer.promise;
            return this.get();
        }
    };
    return service;
});
app.controller("BodyCtrl", function () { });
app.controller("NavCtrl", function (ApiSvc) {
    var main = this;
    ApiSvc.get().then(function (data) {
        main.apis = data.map(function (item) { return item; });

        main.selectedApi = main.apis[0];
        main.selectedApi.isSelected = true;
    });

    this.selectedApi = {};
    this.selectApi = function (api) {
        this.selectedApi.isSelected = false;;

        api.isSelected = true;
        this.selectedApi = api;
    };
});


//app.config(function ($routeProvider) {
//    $routeProvider.when("/", {
//        controller: "HomeCtrl",
//        template: "<h1>Hello</h1>"
//    }).when('/api/:id', {
//        controller: 'ApiDetailCtrl',
//        templateUrl: 'apidetail.html'
//    }).otherwise({
//        redirectTo: '/'
//    });
//});