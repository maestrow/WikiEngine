(function() {

    var mod = angular.module('app', [
        'ngRoute',
        'ngResource'
    ]);

    mod.config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/page', {
                templateUrl: 'app/views/page/list.html',
                controller: 'app.views.page.list'
            })
            .when('/page/:pageId', {
                templateUrl: 'app/views/page/item.html',
                controller: 'app.views.page.item'
            })
            .when('/new', {
                templateUrl: 'app/layout/page/edit.html',
                controller: 'app.views.page.edit'
            })
            .otherwise({ redirectTo: '/page' });
    }]);
})();