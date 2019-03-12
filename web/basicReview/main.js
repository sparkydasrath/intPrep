// window.addEventListener('load', handleload);

// function handleload(e) {
//     console.log("loaded");
// }
window.addEventListener('DOMContentLoaded', function () {
    console.log('window - DOMContentLoaded - capture'); // 1st
}, true);
document.addEventListener('DOMContentLoaded', function () {
    console.log('document - DOMContentLoaded - capture'); // 2nd
}, true);
document.addEventListener('DOMContentLoaded', function () {
    console.log('document - DOMContentLoaded - bubble'); // 2nd
});
window.addEventListener('DOMContentLoaded', function () {
    console.log('window - DOMContentLoaded - bubble'); // 3rd
});

window.addEventListener('load', function () {
    console.log('window - load - capture'); // 4th
}, true);
document.addEventListener('load', function (e) {
    /* Filter out load events not related to the document */
    if (['style', 'script'].indexOf(e.target.tagName.toLowerCase()) < 0)
        console.log('document - load - capture'); // DOES NOT HAPPEN
}, true);
document.addEventListener('load', function () {
    console.log('document - load - bubble'); // DOES NOT HAPPEN
});
window.addEventListener('load', function () {
    console.log('window - load - bubble'); // 4th
});

window.onload = function () {
    console.log('window - onload'); // 4th
};
document.onload = function () {
    console.log('document - onload'); // DOES NOT HAPPEN
};