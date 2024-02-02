function getParameterByName(name, url) {
  if (!url) url = window.location.href;
  name = name.replace(/[\[\]]/g, "\\$&");
  var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
    results = regex.exec(url);
  if (!results) return null;
  if (!results[2]) return "";
  return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function fetchEmployeeDetails(id) {
  fetch(`./api/pracownicy/${id}`)
    .then((response) => response.json())
    .then((data) => {
      document.getElementById(
        "imie"
      ).innerHTML = `<span>Imię:</span> ${data.imie}`;
      document.getElementById(
        "nazwisko"
      ).innerHTML = `<span>Nazwisko:</span> ${data.nazwisko}`;
      document.getElementById("plec").innerHTML = `<span>Płeć:</span> ${
        data.plec == "M" ? "Mężczyzna" : "Kobieta"
      } `;
      document.getElementById(
        "data-urodzenia"
      ).innerHTML = `<span>Data urodzenia:</span> ${data.dataUrodzenia}`;
      document.getElementById(
        "pesel"
      ).innerHTML = `<span>Pesel:</span> ${data.pesel}`;
      document.getElementById("uwagi").innerHTML = `<span>Uwagi:</span> ${
        data.uwagi ?? "Brak uwag"
      }`;
    })
    .catch((error) =>
      console.error("Błąd podczas pobierania danych pracownika:", error)
    );
}

window.onload = function () {
  var employeeId = getParameterByName("id");
  if (employeeId) {
    fetchEmployeeDetails(employeeId);
  }
  document
    .getElementById("editForm")
    .addEventListener("submit", function (event) {
      event.preventDefault();
      saveChanges();
      closeModal();
      location.reload();
    });
};

function openModal() {
  document.getElementById("myModal").style.display = "block";
  fillForm();
}

function closeModal() {
  document.getElementById("myModal").style.display = "none";
}

function fillForm() {
  var id = getParameterByName("id");
  fetch(`./api/pracownicy/${id}`)
    .then((response) => response.json())
    .then((data) => {
      var parts = data.dataUrodzenia.split(".");
      var dataUrodzenia = parts[2] + "-" + parts[1] + "-" + parts[0];
      document.getElementById("imieInput").value = data.imie;
      document.getElementById("nazwiskoInput").value = data.nazwisko;
      document.getElementById("plecInput").value = data.plec;
      document.getElementById("dataUrodzeniaInput").value = dataUrodzenia;
      document.getElementById("peselInput").value = data.pesel;
      document.getElementById("uwagiInput").value = data.uwagi;
    })
    .catch((error) =>
      console.error("Błąd podczas pobierania danych pracownika:", error)
    );
}

function saveChanges() {
  var imie = document.getElementById("imieInput").value;
  var nazwisko = document.getElementById("nazwiskoInput").value;
  var plec = document.getElementById("plecInput").value;
  var dataUrodzenia = document.getElementById("dataUrodzeniaInput").value;
  var pesel = document.getElementById("peselInput").value;
  var uwagi = document.getElementById("uwagiInput").value;

  var idPracownika = getParameterByName("id");
  var url = "./api/pracownicy/" + idPracownika;

  var dane = {
    imie: imie,
    nazwisko: nazwisko,
    plec: plec,
    dataUrodzenia: dataUrodzenia,
    pesel: pesel,
    uwagi: uwagi,
  };

  var requestOptions = {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(dane),
  };
  fetch(url, requestOptions)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Wystąpił problem z aktualizacją danych pracownika.");
      }
      return response.json();
    })
    .then((data) => {
      // Tutaj możesz obsłużyć odpowiedź serwera po udanej aktualizacji
      console.log("Dane pracownika zostały zaktualizowane:", data);
    })
    .catch((error) => {
      console.error("Błąd podczas aktualizacji danych pracownika:", error);
    });
}
