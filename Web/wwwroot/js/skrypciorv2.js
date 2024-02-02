document.addEventListener("DOMContentLoaded", function () {
  // Pobierz identyfikator pracownika z adresu URL
  var urlParams = new URLSearchParams(window.location.search);
  var employeeId = urlParams.get("id");

  // Tutaj możesz użyć employeeId, aby pobrać informacje o pracowniku z serwera lub lokalnej bazy danych

  // Przykład wyświetlenia informacji na stronie
  var employeeInfoContainer = document.getElementById("employee-info");
  employeeInfoContainer.innerHTML =
    "<p>Informacje o pracowniku o identyfikatorze " + employeeId + "</p>";
});
