$(function () {
    //////////////////////////////////////////////////
    // Top bar                                      //
    //////////////////////////////////////////////////
    // Time and date
    if ($('#date').length != 0 && $('#time').length != 0) {
        getTime();
        setInterval(getTime, 1000);
    }

    // Wifi & Start button
    $('.wifiContainer button').on('click', function () {
        $('#wifiPicker').toggleClass('d-none');
    });

    $('.hoverSelect button').on('click', function () {
        $('#homeOpener').toggleClass('d-none');
    });

    // Navigation
    function goToPage(param) {
        $.get(param, function (data) {
            $('.contentApps').html(data);
        })
    }

    $('#mailApp').on('click', function () {
        $.get('/Main/Mailbox', function (data) {
            $('.contentApps').html(data);
        });
    });

    // Register --> Algemene Voorwaarden
    $('#policy').on('click', function() {
        $.get('/Main/Policy', function(data) {
            $('.contentApps').html(data);
        });
    });

    // Login --> Register
    $('#noaccount').on('click', function() {
        goToPage('/Main/Register');
    });

    // Login --> Index
    $('form#login #next').on('click', function () {
        $.post('/Main/IndexPost', function (data) {
            console.log(data);
            if (data == 'Ok') {
                console.log('Ok2');
                goToPage('/Main/Index');
            }
        })
    });
});

function composePopup() {
    let popup = document.getElementsByClassName("pop-up");
    popup[0].style.visibility = "visible";

    setTimeout(function() {
        popup[0].style.visibility = "hidden";
    }, 2000);
}

function getTime() {
    let dateTime = new Date();
    let date = dateTime.getUTCDate();
    let month = dateTime.getUTCMonth() + 1;
    let year = dateTime.getUTCFullYear();
    let hours = dateTime.getUTCHours() + 1;
    let minutes = dateTime.getUTCMinutes();

    if (minutes < 10) {
        let minutesCheck = "0" + minutes;
        let dateString = date + "/" + month + "/" + year;
        let timeString = hours + ":" + minutesCheck;
        document.getElementById("date").innerHTML = dateString;
        document.getElementById("time").innerHTML = timeString;
    } else {
        let dateString = date + "/" + month + "/" + year;
        let timeString = hours + ":" + minutes;
        document.getElementById("date").innerHTML = dateString;
        document.getElementById("time").innerHTML = timeString;
    }
}

