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

    $('#logout button').on('click', function () {
        $('#homeOpener').toggleClass('d-none');
    });

    //////////////////////////////////////////////////
    // Mailbox                                      //
    //////////////////////////////////////////////////
    // Add class selected to selected inbox e-mail
    $('.contentApps').on('click', '.inbox', function () {
        $('.inbox').removeClass('selected');
        $(this).addClass('selected');
    });

    // Compose mail limit pop-up
    $('.compose').click(function () {
        $('.compose-pop-up').css('visibility', 'visible');

        setTimeout(function () {
            $('.compose-pop-up').css('visibility', 'hidden');
        }, 2000);
    });

    // Search bar filter function
    $("#search-bar").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#b1 .inbox").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });

        var value = $(this).val().toLowerCase();
        $("#b2 .inbox").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    // Open selected mail on right side function
    $('.inbox').on('click', function () {
        $('#i' + $(this).attr('id')).show();
        $('.mailbox-container').not('#i' + $(this).attr('id')).hide();
    });

    // auto add class selected to inbox on load
    $('#inbox').addClass('selected');
    
    // Open selected inbox / sent / draft box
    $('#inbox').on('click', function () {
        $('#b1').show();
        $('.inbox-container').not('#b1').hide();
        $(this).addClass('selected');
        $('.mail-left-box').not(this).removeClass('selected');
    });

    $('#sent').on('click', function () {
        $('#b2').show();
        $('.inbox-container').not('#b2').hide();
        $(this).addClass('selected');
        $('.mail-left-box').not(this).removeClass('selected');
    });

    $('#draft').on('click', function () {
        $('#b3').show();
        $('.inbox-container').not('#b3').hide();
        $(this).addClass('selected');
        $('.mail-left-box').not(this).removeClass('selected');
    });

    // Remove selected email with trash icon
    $('.trash').on('click', function () {
        $(this).closest('.inbox').remove();
        $('.mailbox-container').hide();
    });

    $('.trash-openmail').on('click', function () {
        $(this).closest('.inbox').remove();
        $('.mailbox-container').hide();
        let deleteMail = $(this).closest('.mailbox-container').attr('id').replace('i', '');
        $('#' + deleteMail).remove();
    });
      

    if ($('.paginaprivacy').length > 0) {
        $('body').css('background-image', 'none');
    }

    $('.hoi').on('click', function () {
        $.get("/Main/OverlayGood", function (data) {
            $(".contentApps").prepend(data)
            let myMusic = new Audio("sounds/positive.mp3");
            myMusic.play();
            console.log(data);
        });
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

// Virus countdown timer 
function countdownVirusTimer(){
    let virusTimer = 120;
    let virusTimerText = virusTimer;
    document.getElementById("virus-timer").innerHTML = virusTimerText + " seconds";
    let virusTimerInterval = setInterval(function(){
        virusTimer--;
        virusTimerText = virusTimer;
        document.getElementById("virus-timer").innerHTML = virusTimerText + " seconds";
        if(virusTimer == 0){
            clearInterval(virusTimerInterval);
            document.getElementById("virus-timer").innerHTML = "0";
        }
    }, 1000);
}     
countdownVirusTimer();

function goHome(page) {
    if (page == null) {
        window.location.replace("/Main/Index");
    } else {
        window.location.replace("/Main/" + page);
    }
}
