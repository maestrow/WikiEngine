var mod = angular.module('app');

mod.factory('Page', ['$resource', function ($resource) {
    return $resource('api/Page/:pageId', {}, {
        save: { method: 'PUT' }
    });
}])