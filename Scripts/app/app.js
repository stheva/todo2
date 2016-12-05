var TodoListApp = angular.module('TodoListApp', ['ngRoute', 'TodoListControllers']);
TodoListApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: '/Views/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: '/Views/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: '/Views/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: '/Views/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);