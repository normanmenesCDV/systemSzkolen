fetch("./api/szkolenia")
  .then((response) => response.json())
  .then((data) => {
    const trainingListDiv = document.getElementById("training-list");
    data.forEach((training) => {
      const trainingBox = document.createElement("div");
      trainingBox.classList.add("employee-box");
      const trainingInfo = `
                    <div>
                        <h2>${training.nazwa}</h2>
                    </div>
                    <button onclick="redirectToTraining('${training.id}')">Informacje</button>
                `;
      trainingBox.innerHTML = trainingInfo;
      trainingListDiv.appendChild(trainingBox);
    });
  })
  .catch((error) =>
    console.error("Błąd podczas pobierania danych szkoleń:", error)
  );

function redirectToTraining(id) {
  window.location.href = "szkolenie.html?id=" + id;
}
