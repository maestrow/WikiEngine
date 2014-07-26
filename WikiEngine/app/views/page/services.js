var mod = angular.module('app');

mod.factory('Page', ['$resource', function ($resource) {
    return $resource('api/page/:id', {
        id: '@id'
    }, {
        save: { method: 'PUT' }
    });
}])