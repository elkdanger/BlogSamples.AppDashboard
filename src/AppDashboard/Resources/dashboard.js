
(function () {

    var ViewModel = function() {

        this.messages = ko.observableArray();
        this.connected = ko.observable(false);
    }

    ViewModel.prototype = {

        initialise: function () {

            var self = this;

            self.dashHub = $.connection.dashboardHub;

            self.dashHub.client.logMessage = function (message, isError) {
                self.messages.splice(0, 0, message);
            };

            $.connection.hub.start().done(function () {
                self.connected(true);
                self.messages.removeAll();
            });

            $.connection.hub.disconnected(function () {
                self.connected(false);
            });
        },

        formatMessage: function (msg) {
            return msg.DateText + " - " + msg.Text;
        }
    }

    var vm = new ViewModel();
    ko.applyBindings(vm);

    vm.initialise();

})();