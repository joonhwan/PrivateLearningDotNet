$(document).ready(function() {

    function print(msg) {
        $("#output").html($("#output").html() + msg + "<br/>");
    }

    print('Invoking...');
    var json = JSON.stringify({
        "parameter": {
            "Name": "Jame Cameron",
            "Age": 52,
            "Degree": 2.4,
            "IsActive": false
        }
    });
    $.ajax({
        type: 'POST',
        url: 'http://localhost:18081/punservice/cookieComplex',
        data: json,
        contentType: "application/json",
        //dataType: 'json',
        success: function (data) {
            print(JSON.stringify(data));
        }
    });
}());