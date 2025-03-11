// Funkcja do obsługi odpowiedzi z serwera
function displayResponse(data) {
    const responseDiv = document.getElementById("response");
    responseDiv.innerHTML = `<p>${data}</p>`;
}

// Funkcja do wczytania pliku konfiguracyjnego
function loadConfig() {
    return fetch('/config.json')
        .then(response => response.json()) 
        .then(config => {
            return config.serverPort;  
        })
        .catch(error => {
            console.error("Błąd podczas wczytywania pliku konfiguracyjnego:", error);
            return 5050;
        });
}

// Obsługuje przycisk "Start pracy"
document.getElementById("StartWorkButton").addEventListener("click", () => {
    loadConfig().then(port => {
        fetch(`https://localhost:${port}/WorkRegistration/StartWork`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
        })
            .then(response => response.text())
            .then(data => {
                displayResponse(data);
            })
            .catch(error => {
                displayResponse("Błąd połączenia z serwerem.");
            });
    });
});

// Obsługuje przycisk "Start przerwy"
document.getElementById("StartBreakButton").addEventListener("click", () => {
    loadConfig().then(port => {
        fetch(`https://localhost:${port}/WorkRegistration/StartBreak`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
        })
            .then(response => response.text())
            .then(data => {
                displayResponse(data);
            })
            .catch(error => {
                displayResponse("Błąd połączenia z serwerem.");
            });
    });
});

// Obsługuje przycisk "Stop pracy"
document.getElementById("StopWorkButton").addEventListener("click", () => {
    loadConfig().then(port => {
        fetch(`https://localhost:${port}/WorkRegistration/StopWork`, {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json"
            },
        })
            .then(response => response.text())
            .then(data => {
                displayResponse(data);
            })
            .catch(error => {
                displayResponse("Błąd połączenia z serwerem.");
            });
    });
});

// Obsługuje przycisk "Stop przerwy"
document.getElementById("StopBreakButton").addEventListener("click", () => {
    loadConfig().then(port => {
        fetch(`https://localhost:${port}/WorkRegistration/StopBreak`, {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json"
            },
        })
            .then(response => response.text())
            .then(data => {
                displayResponse(data);
            })
            .catch(error => {
                displayResponse("Błąd połączenia z serwerem.");
            });
    });
});
