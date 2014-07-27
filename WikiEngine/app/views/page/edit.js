(function() {
    var mod = angular.module('app');

    mod.controller('app.views.page.edit', ['$scope', '$routeParams', '$location', 'Page',
        function ($scope, $routeParams, $location, Page) {

            var goTo = function(id) {
                $location.path('/page/' +id);
            };

            $scope.isNew = !angular.isDefined($routeParams.id);

            $scope.item = !$scope.isNew
                ? Page.get({ id: $routeParams.id })
                : new Page();

            $scope.save = function () {
                if (this.isNew)
                    this.item.$save(function(data) {
                        goTo(data.id);
                    });
                else
                    this.item.$update({ id: this.item.id }, function() {
                        goTo($scope.item.id);
                    });
            };
        }
    ]);
})();
