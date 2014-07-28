(function() {

    // Получение данных
    var loadData = function ($scope, Page) {
        Page.query({
            q: $scope.search,
            p: $scope.currentPage
        }, function (data) {
            $scope.items = data.items;
            $scope.totalItems = data.count;
        });
    };

    angular.module('app')
        .controller('app.views.page.list', [
            '$scope', 'Page',
            function($scope, Page) {

                $scope.refresh = function () {
                    loadData($scope, Page);
                };

                $scope.delete = function(item) {

                    var index = this.items.indexOf(item);
                    Page.delete({ id: item.id }, function() {
                        $scope.items.splice(index, 1);
                    });
                };

                // Paging
                $scope.currentPage = 1;
                $scope.maxSize = 7;

                $scope.setPage = function (pageNo) {
                    $scope.currentPage = pageNo;
                };

                $scope.refresh();

            }
        ]);


})();

