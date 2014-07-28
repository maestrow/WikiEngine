var mod = angular.module('app');

mod.factory('Page', ['$resource', function ($resource) {
    return $resource('api/page/:id', {
        id: '@id'
    }, {
        query: { method: 'GET', isArray: false },
        update: { method: 'PUT' }
    });
}])