$(function () {
    //////////////////////////////////////////////////
    // Top bar                                      //
    //////////////////////////////////////////////////
    // Time and date
    getTime();
    setInterval(getTime, 1000);

    // Wifi & Start button
    $('.wifiContainer button').on('click', function () {
        $('#wifiPicker').toggleClass('d-none');
    });

    $('.hoverSelect button').on('click', function () {
        $('#homeOpener').toggleClass('d-none');
    });

    // Navigation
    $('#mailApp').on('click', function () {
        $.get('/Main/Mailbox', function (data) {
            $('.contentApps').html(data);
        });
    });
});

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

