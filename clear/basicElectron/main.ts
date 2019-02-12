const {
    app,
    BrowserWindow
} = require("electron")
const fs = require("fs");


let win: any | null;

function createWindow() {
    win = new BrowserWindow({
        darkTheme: true,
        height: 300,
        width: 400
    });

    win.loadFile("index.html");
    win.on("closed", () => {
        win = null
    });
}

app.on("ready", createWindow);
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
})
app.on('activate', () => {
    if (win === null) {
        createWindow()
    }
})