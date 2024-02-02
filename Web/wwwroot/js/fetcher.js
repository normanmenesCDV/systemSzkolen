function nazwaFunkcji(urlJson) {
  fetch(urlJson)
    .then((response) => response.json())
    .then((data) => {
      return data;
    })
    .catch((error) => console.error("Błąd podczas pobierania danych", error));
}
