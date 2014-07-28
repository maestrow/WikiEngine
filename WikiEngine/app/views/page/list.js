(function() {
    angular.module('app')
        .controller('app.views.page.list', [
            '$scope', 'Page',
            function($scope, Page) {
                $scope.items = Page.query();

                $scope.delete = function(item) {

                    var index = this.items.indexOf(item);
                    Page.delete({ id: item.id }, function() {
                        $scope.items.splice(index, 1);
                    });
                };

                $scope.totalItems = 264;
                $scope.currentPage = 1;
                $scope.maxSize = 7;

                $scope.pageChanged = function () {
                    console.log('Page changed to: ' + $scope.currentPage);
                };

                $scope.setPage = function (pageNo) {
                    $scope.currentPage = pageNo;
                };

            }
        ]);


})();

