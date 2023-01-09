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

// Chat functions

let number = 1;

function getEmma() {
    number = 1;
    switchData(number);
}
function getPleun() {
    number = 2;
    switchData(number);
}
function getLeon() {
    number = 3;
    switchData(number);
}
function getTess() {
    number = 4;
    switchData(number);
}
function getDirk() {
    number = 5;
    switchData(number);
}

function switchData(number) {
    let getProfileDiv = document.getElementById("userInfo")

    let getDiv = document.getElementById("chatClass")
    switch (number) {
        case 1:
            getProfileDiv.innerHTML = `
                <img class="imgClassPhotogram" src="chatIcons/emma.jpg">
                <div class="userNameLastSeen">
                    <p> Emma </p>
                    <p class="lastSeenHoverEffect">6 minuten geleden actief</p>
                </div>`
            getDiv.innerHTML = `
                <div>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ja je weer hoe meneer van kuijk is eh</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Hij stuurde me er gister weer uit :(</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ik leg morgen wel uit opschool</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Haha moet je dit filmpje zien</p>
                    <p class="userRecieved"><a href="https://ditiszosupergrappig.nl/watleuk">https://ditiszosupergrappig.nl/watleuk</a></p>
                </div>
                <div>
                    <p class="userSend">Zo gaat dat tijdens wiskunde ook alitjd</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Jaaaa</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Hoezo</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Isgoed</p>
                </div>`;
            break;
        case 2:
            getProfileDiv.innerHTML = `
                <img class="imgClassPhotogram" src="chatIcons/pleun.jpg">
                <div class="userNameLastSeen">
                    <p> Pleun </p>
                    <p class="lastSeenHoverEffect">53 minuten geleden actief</p>
                </div>`
            getDiv.innerHTML = `
                <div>
                    <p class="userRecieved">Hey, weet jij nog welke dag de opendag is?</p>
                    <p class="emptySpace"></p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ga jij helpen?</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Kom anders samen helpen</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ja dan heb je meteen je vrijwilligers uren gehaald</p>
                    <p class="userRecieved">Zijn we daar ook weer vanaf</p>
                </div>
                <div>
                    <p class="emptySpace"></p>
                    <p class="userSend">Ff kijke </p>
                    <p class="userSend">Ze stuurde een mailtje dat het 21 feb is</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Heb nog niet gereageerd</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Ja kan wel</p>
                </div>`;
            break;
        case 3:
            getProfileDiv.innerHTML = `
                <img class="imgClassPhotogram" src="chatIcons/leon.jpg">
                <div class="userNameLastSeen">
                    <p> Leon </p>
                    <p class="lastSeenHoverEffect">9 uur geleden actief</p>
                </div>`
            getDiv.innerHTML = `
                <div>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">3A samen met Sarah</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Zit je dan niet bij pieter?</p>
                    <p class="userRecieved">Onee lm die zit in 3D</p>
                    <p class="emptySpace"></p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Moet je ff aan van bladel vragen</p>
                    <p class="userRecieved">Die weet dat wel te fixen deed die vorig jaar ook voor mij</p>
                </div>
                <div>
                    <p class="userSend">Leon welke klas zit jij?</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Die had mij al gecontact</p>
                    <p class="userSend">Ik zit 3C maar ga vragen of ik naar a mag</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Ja klopt</p>
                </div>`;
            break;
        case 4:
            getProfileDiv.innerHTML = `
                <img class="imgClassPhotogram" src="chatIcons/tess.jpg">
                <div class="userNameLastSeen">
                    <p> Tess </p>
                    <p class="lastSeenHoverEffect">19 minuten geleden actief</p>
                </div>`
            getDiv.innerHTML = `
                <div>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Lig aan of maud en chantal meegaan</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ga alleen als hun ook gaan</p>
                    <p class="userRecieved">Met wie ga jij dan?</p>
                    <p class="emptySpace"></p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ja ik laat wel weten wat hun doen</p>
                    <p class="userRecieved">Anders zie ik jullie daar wel</p>
                </div>
                <div>
                    <p class="userSend">Ga jij naar dat feest vrijdag?</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">btr wel</p>
                    <p class="emptySpace"></p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Met zelfde groep als altijd</p>
                    <p class="userSend">Alleen Rik en Mara kunne niet</p>
                </div>`;
            break;
        case 5:
            getProfileDiv.innerHTML = `
                <img class="imgClassPhotogram" src="chatIcons/dirk.jpg">
                <div class="userNameLastSeen">
                    <p> Dirk </p>
                    <p class="lastSeenHoverEffect">3 uur geleden actief</p>
                </div>`
            getDiv.innerHTML = `
                <div>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Jaa en heel het weekend ook</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Op rooster sta 13:00 tot 22:30</p>
                    <p class="userRecieved">Ma zal wel uitlopen</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">gw ma hlt jij dan?</p>
                    </div>
                    <div>
                    <p class="userSend">Moet jij morgen werken?</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">hlt tot hlt morgen</p>
                    <p class="emptySpace"></p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Hoezo?</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Uhmm van 13 to 21 denk </p>
                </div>`;
            break;
        default:
            getDiv.innerHTML = `
                <div>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ja je weer hoe meneer van kuijk is eh</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Hij stuurde me er gister weer uit :(</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Ik leg morgen wel uit opschool</p>
                    <p class="emptySpace"></p>
                    <p class="userRecieved">Haha moet je dit filmpje zien</p>
                    <p class="userRecieved"><a href="https://ditiszosupergrappig.nl/watleuk">https://ditiszosupergrappig.nl/watleuk</a></p>
                </div>
                <div>
                    <p class="userSend">Zo gaat dat tijdens wiskunde ook alitjd</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Jaaaa</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Hoezo</p>
                    <p class="emptySpace"></p>
                    <p class="userSend">Isgoed</p>
                </div>`;
            break;
    }
}
switchData(number);