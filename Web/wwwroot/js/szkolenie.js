function getParameterByName(name, url) {
  if (!url) url = window.location.href;
  name = name.replace(/[\[\]]/g, "\\$&");
  var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
    results = regex.exec(url);
  if (!results) return null;
  if (!results[2]) return "";
  return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function fetchSzkolenieDetails(id) {
  fetch(`./api/szkolenia/${id}`)
    .then((response) => response.json())
    .then((data) => {
      document.getElementById(
        "nazwa"
      ).innerHTML = `<span>Nazwa:</span> ${data.nazwa}`;
      document.getElementById(
        "organizator"
      ).innerHTML = `<span>Organizator:</span> ${data.organizator}`;
      document.getElementById(
        "dataOd"
      ).innerHTML = `<span>Data rozpoczęcia:</span> ${
        data.dataRozpoczecia ?? "-----"
      } `;
      document.getElementById(
        "dataDo"
      ).innerHTML = `<span>Data zakończenia:</span> ${
        data.dataZakonczenia ?? "-----"
      }`;
      document.getElementById("uwagi").innerHTML = `<span>Uwagi:</span> ${
        data.uwagi ?? "Brak uwag"
      }`;
    })
    .catch((error) =>
      console.error("Błąd podczas pobierania danych szkolenia:", error)
    );
}

window.onload = function () {
  var szkolenieId = getParameterByName("id");
  if (szkolenieId) {
    fetchSzkolenieDetails(szkolenieId);
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
  fetch(`./api/szkolenia/${id}`)
    .then((response) => response.json())
    .then((data) => {
      var partsOd = data.dataRozpoczecia.split(".");
      var dataRozpoczecia = partsOd[2] + "-" + partsOd[1] + "-" + partsOd[0];
      var partsOd = data.dataZakonczenia.split(".");
      var dataZakonczenia = partsOd[2] + "-" + partsOd[1] + "-" + partsOd[0];

      document.getElementById("nazwaInput").value = data.nazwa;
      document.getElementById("organizatorInput").value = data.organizator;
      document.getElementById("dataOdInput").value = dataRozpoczecia;
      document.getElementById("dataDoInput").value = dataZakonczenia;
      document.getElementById("uwagiInput").value = data.uwagi;
    })
    .catch((error) =>
      console.error("Błąd podczas pobierania danych szkolenia:", error)
    );
}

function saveChanges() {
  var nazwa = document.getElementById("nazwaInput").value;
  var organizator = document.getElementById("organizatorInput").value;
  var dataOd = document.getElementById("dataOdInput").value;
  var dataDo = document.getElementById("dataDoInput").value;
  var uwagi = document.getElementById("uwagiInput").value;

  var idSzkolenia = getParameterByName("id");
  var url = "./api/szkolenia/" + idSzkolenia;

  var dane = {
    nazwa: nazwa,
    organizator: organizator,
    dataOd: dataOd,
    dataDo: dataDo,
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
        throw new Error("Wystąpił problem z aktualizacją danych szkolenia.");
      }
      return response.json();
    })
    .then((data) => {
      // Tutaj możesz obsłużyć odpowiedź serwera po udanej aktualizacji
      console.log("Dane szkolenia zostały zaktualizowane:", data);
    })
    .catch((error) => {
      console.error("Błąd podczas aktualizacji danych szkolenia:", error);
    });
}
