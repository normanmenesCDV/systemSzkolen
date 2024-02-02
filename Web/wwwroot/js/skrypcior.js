function redirectToEmployeePage(button) {
    // Pobierz identyfikator pracownika z atrybutu data-employee-id
    var employeeId = button.parentElement.getAttribute("data-employee-id");

    // Przenieś użytkownika na stronę z informacjami o pracowniku z odpowiednim identyfikatorem
    window.location.href = "Pracownik.html?id=" + employeeId;
}