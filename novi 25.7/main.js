//menjava pageov
function showPage(pageId) {
    const currentPage = document.querySelector(".content-container:not([hidden])");
    const newPage = document.getElementById(pageId);
    updatePageProgressTab(pageId);
    if (currentPage) {
        currentPage.classList.add('swooshOutToLeft');
        
        currentPage.addEventListener('animationend', function onAnimationEnd() {
            currentPage.hidden = true;  
            currentPage.classList.remove('swooshOutToLeft'); 
            currentPage.removeEventListener('animationend', onAnimationEnd); 
            showNewPage(newPage);
        });
    } else {
        showNewPage(newPage);
    }

    function showNewPage(newPage) {
        newPage.hidden = false;
        newPage.classList.add('showUp');
        newPage.addEventListener('animationend', function onAnimationEnd() {
            newPage.classList.remove('showUp');  
            newPage.removeEventListener('animationend', onAnimationEnd); 
        });

    }
}

// sam za testirat, kje zacnes ko startas
function FirstPage(pageId) {
    document.querySelectorAll('.content-container').forEach(page => {
        page.hidden = true;
    });

    document.getElementById(pageId).hidden = false;
}
function updatePageProgressTab(pageID) {
    let progressTabText = document.getElementById('page-number-progress').querySelector('h1');
    let regex = /page-(\d)(\d)/;
    let matches = pageID.match(regex);

    if (matches) {
        let path = matches[1]; //0 - check in, 1 - check out
        let currentPageNumber = matches[2];
        if (path == 0 && currentPageNumber == 0) {
            progressTabText.textContent = "--/--";
        }
        else {
            let lastPage = (path == 0) ? 9 : 6;
            progressTabText.textContent = currentPageNumber + "/" + lastPage;
        }
    }
    else {
        progressTabText.textContent = "--/--";
    }
}

// buttons set up
document.addEventListener('DOMContentLoaded', setupLongPressForAllButtons);
function setupLongPressForAllButtons() {
    const buttons = document.querySelectorAll('button');
    const LONG_PRESS_DURATION = 1000; // Define long press duration
    let timeout;

    buttons.forEach(button => {
        button.addEventListener('mousedown', startPress);
        button.addEventListener('touchstart', startPress);
        button.addEventListener('mouseup', endPress);
        button.addEventListener('touchend', endPress);
        button.addEventListener('click', () => { 
            console.log('Click event triggered');
            disableError(); //to mby zbrisat
            //resetTimer();
        });
    });

    function startPress(event) {
        event.preventDefault();
        disableError();
        const pressedButton = event.target;
        const btnId = pressedButton.id;
        const targetPageId = pressedButton.getAttribute('data-target-page');
        const extraFunction = pressedButton.getAttribute('data-extra-info');
        let additionalInfo = extraFunction ? functionMap[extraFunction]() : '';
        pressedButton.classList.add('clicked');
        
        // Logging
        console.log('Start press on button:', btnId, 'targetPageId:', targetPageId, 'additionalInfo:', additionalInfo);

        // ZA SWAP PAGE Z PREDPOGOJI
        if (additionalInfo && targetPageId) { 
            timeout = setTimeout(() => {
                showPage(targetPageId) //temp
                const btnData = {action: 'swapPage', id: btnId, nextPage: targetPageId, extraInfo: additionalInfo};   
                sendData(btnData); // posljes na backend
                removeClickedClassFromAllButtons();
            }, LONG_PRESS_DURATION); 
        }
        // SAMO ZA BASIC SWAP PAGE
        else if (targetPageId) { 
            timeout = setTimeout(() => {
                showPage(targetPageId); //temp
                const btnData = {action: 'swapPage', id: btnId, nextPage: targetPageId, extraInfo: null};   
                sendData(btnData); // posljes na backend
                removeClickedClassFromAllButtons();
            }, LONG_PRESS_DURATION); 
        }
        // ZA GUMBE K NISO ZA SWAP PAGE add guest notr pa take
        else {
            console.log('alo')
        }
    }

    function endPress(event) {
        clearTimeout(timeout);
        const pressedButton = event.target;
        pressedButton.classList.remove('clicked');
    }
}

// clearas vse buttone da so non clicked
function removeClickedClassFromAllButtons() {
    document.querySelectorAll('.clicked').forEach(button => {
        button.classList.remove('clicked');
    });
}

// posiljanje JSONA na backend
function sendData(object) {
    messageQueue.push(object.id);
    object.side = 'FE';
    socket.send(JSON.stringify(object)); 
}
// display errorja v primeru napake
function displayError(error) {
    if (error) {
        const errorText = document.getElementById('error-text');
        errorText.innerHTML = error;
        console.log('Display error:', error);
    }
}
//onclick se zbrise error
function disableError() {
    const errorText = document.getElementById('error-text');
    errorText.innerHTML = "";
}

/* SEND DATA DOCS
to fjo klices vsakic ko rabis kej dobit/preverit na backendu
parameter je objekt z podatki k jih posles na backend, 1. action, 2. id, naprej odvisno
na backendu preveris kaksen action je, in glede na to izvedes nek del kode
backend poslje nazaj svoj objekt trenutno je tko: {action: 'swapPage', accepted: true, newPageId: 'id', extraInfo: ---}
backend na roke simuliras na pie socketu
SWAP PAGE:
{
"action": "swapPage",
"accepted": true,
"newPageId": "id"
}
V PRIMERU NAPAKE:
{"action":"swapPage","accepted": false,"newPageId":"page-00","error":"Wrong ID"}
*/

//VSE FUNCKIJE ZA EXTRA INFO DODAT V OBJEKT
const functionMap = { //skos returnaj objecte
    //proceed po bookingIDju
    getInputValue: function() {
        const inputField = document.querySelector('.input-bar'); // More specific selector
        return { inputValue: inputField ? inputField.value : ''} 
    },

};


//DISABLANJE DA LAHKO Z VEC KOT ENIM PRSTOM KAJ NAREDIŠ
let touchEnabled = true;
function handleTouchStart(event) {
    if (event.touches.length > 1) {
        event.preventDefault(); 
        if (touchEnabled) {
            console.log('Multiple touches detected. Action blocked.');
            touchEnabled = false;
        }
    }
    //
    //resetTimer(); //vsakic k kliknes se timeout reseta - ENABLI KO BO TREBA
    // 
}
function handleTouchEnd(event) {
    touchEnabled = true; 
}
document.addEventListener('touchstart', handleTouchStart, { passive: false });
document.addEventListener('touchend', handleTouchEnd, { passive: false });


//timeout po 1 minuti brez klika/toucha
//TO FJO ENABLI PROTI KONCU MAS 3X COMMENT TAKOJ VIDIS, SAM ENABLI DA BO DELALA, NA VSAK TOUCH SE BO
//TIMER RESETIRU, DELA VSE - v fji handleTouchStart enabli
let resetTime = 30000;
let inactivityTimer;
touchErrorUp = false;
function resetTimer() {
    console.log('reseted')
    if (touchErrorUp) {
        document.getElementById('error-text').innerText = '';
        touchErrorUp = false;
    }   
    clearTimeout(inactivityTimer); 
    inactivityTimer = setTimeout(() => {
        //WARNING FIRST!
        document.getElementById('error-text').innerText = "TOUCH THE SCREEN"
        touchErrorUp = true;

        inactivityTimer = setTimeout(() => {
            console.log('resetal se je');
            ResetApp();
        }, resetTime);
    }, resetTime);
      
}



//PO KONCU UPORABE DA JE HARD RESET VSEH PODATKOV, SETTINGSOV IN PRIPRAVLJENO ZA NOVEGA UPORABNIKA
function ResetApp() {
    showPage('page-00');
    document.getElementById('error-text').innerText = '';
    //zbrises vse info o prejsnem poteku uporabnika, vse settingse, rezervacije itd itd
}



//DISPLAY LIST
let numOfElements = 6;
let pageHold = 4;

function displayList() {
    let list = ``;
    counter = 0;
    for (let i = 1; i <= numOfElements; i++) {
        counter++;
        if (counter > pageHold) {
            //NAREDIS NOV PAGE
            counter = 1; //Das na ena, ker bo ta element ze notri v ta novem pagu
        }
        
    }

}



