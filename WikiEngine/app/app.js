(function() {

    var mod = angular.module('app', [
        'ngSanitize',
        'ngRoute',
        'ngResource',
        'ui.bootstrap',
        'ui.utils',
        'ui.codemirror'
    ]);

    mod.config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/page', {
                templateUrl: 'app/views/page/list.html',
                controller: 'app.views.page.list'
            })
            .when('/page/new', {
                templateUrl: 'app/views/page/edit.html',
                controller: 'app.views.page.edit'
            })
            .when('/page/:id', {
                templateUrl: 'app/views/page/item.html',
                controller: 'app.views.page.item'
            })
            .when('/page/edit/:id', {
                templateUrl: 'app/views/page/edit.html',
                controller: 'app.views.page.edit'
            })
            .otherwise({ redirectTo: '/page' });
    }]);
})();