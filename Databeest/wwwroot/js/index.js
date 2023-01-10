function openHome() {
    var homePickerNB = document.getElementById("homeOpener");
    if (homePickerNB.style.display === "block") {
        homePickerNB.style.display = "none";
    } else if (homePickerNB.style.display === "none") {
        homePickerNB.style.display = "block";
    }
}

function openWifi() {
    let wifiPickerNB = document.getElementById("wifiPicker");
    if (wifiPickerNB.style.display === "block") {
        wifiPickerNB.style.display = "none";
    } else if (wifiPickerNB.style.display === "none") {
        wifiPickerNB.style.display = "block";
    }
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

setInterval(getTime, 1000);
