$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/game").build();
    var startForm = $('form#start-form');
    var joinForm = $('form#join-form');

    //Disable send button until connection is established
    $(".btn").disabled = true;

    connection.start().then(function () {
        $(".btn").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    // form listeners
    startForm.on('submit', function (event) {
        event.preventDefault();
        var formData = $(this).serializeArray();
        var username = formData[0].value;

        connection
            .invoke("StartGame", username)
            .then(function (wasSuccess) {
                if (wasSuccess) {
                    //redirect

                    console.log('was success');
                }
                else {
                    //showStartError();
                    console.log('failure');
                }
            });
    });

    joinForm.on('submit', function (event) {
        event.preventDefault();
        var formData = $(this).serializeArray();
        var username = formData[1].value;
        var gameId = formData[0].value;

        connection
            .invoke("JoinGame", gameId, username)
            .then(function (wasSuccess) {
                if (wasSuccess) {
                    // redirect

                    console.log('was success');
                }
                else {
                    // showJoinError();
                    console.log('failure');
                }
            });
    });

    function joinGame() {

    }
});


