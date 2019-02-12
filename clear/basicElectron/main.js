var _a = require("electron"), app = _a.app, BrowserWindow = _a.BrowserWindow;
var fs = require("fs");
var win;
function createWindow() {
    win = new BrowserWindow({
        darkTheme: true,
        height: 300,
        width: 400
    });
    win.loadFile("index.html");
    win.on("closed", function () {
        win = null;
    });
}
app.on("ready", createWindow);
app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') {
        app.quit();
    }
});
app.on('activate', function () {
    if (win === null) {
        createWindow();
    }
});
