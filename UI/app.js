// Funkcja do obsługi odpowiedzi z serwera
function displayResponse(data) {
    const responseDiv = document.getElementById("response");
    responseDiv.innerHTML = `<p>${data}</p>`;
}

// Obsługuje przycisk "Start pracy"
document.getElementById("StartWorkButton").addEventListener("click", () => {
    fetch("https://localhost:5050/WorkRegistration/StartWork", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.text())
        .then(data => {
            displayResponse(data);  // Wyświetl odpowiedź
        })
        .catch(error => {
            displayResponse("Błąd połączenia z serwerem.");
        });
});

// Obsługuje przycisk "Start przerwy"
document.getElementById("StartBreakButton").addEventListener("click", () => {
    fetch("https://localhost:5050/WorkRegistration/StartBreak", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.text())
        .then(data => {
            displayResponse(data);  // Wyświetl odpowiedź
        })
        .catch(error => {
            displayResponse("Błąd połączenia z serwerem.");
        });
});

// Obsługuje przycisk "Stop pracy"
document.getElementById("StopWorkButton").addEventListener("click", () => {
    fetch("https://localhost:5050/WorkRegistration/StopWork", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.text())
        .then(data => {
            displayResponse(data);  // Wyświetl odpowiedź
        })
        .catch(error => {
            displayResponse("Błąd połączenia z serwerem.");
        });
});

// Obsługuje przycisk "Stop przerwy"
document.getElementById("StopBreakButton").addEventListener("click", () => {
    fetch("https://localhost:5050/WorkRegistration/StopBreak", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.text())
        .then(data => {
            displayResponse(data);  // Wyświetl odpowiedź
        })
        .catch(error => {
            displayResponse("Błąd połączenia z serwerem.");
        });
});
