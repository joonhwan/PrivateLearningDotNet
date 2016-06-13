(function () {

    var connection = $.connection('http://localhost:28081/echo');

    connection.received(function (data) {
        $('#messages').append('<li>' + data + '</li>');
    });

    connection.start().done(function () {
        $("#broadcast").click(function () {
            connection.send($("#msg").val());
        });
    });

}());