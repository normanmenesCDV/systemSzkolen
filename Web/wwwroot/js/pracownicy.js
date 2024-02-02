fetch("./api/pracownicy/")
  .then((response) => response.json())
  .then((data) => {
    const employeeListDiv = document.getElementById("employee-list");
    data.forEach((employee) => {
      const employeeBox = document.createElement("div");
      employeeBox.classList.add("employee-box");
      const employeeInfo = `
                        <div>
                            <h2>${employee.imie} ${employee.nazwisko}</h2>
                            <p>Data urodzenia: ${employee.dataUrodzenia}</p>
                        </div>
                        <button onclick="redirectToTraining('${employee.id}')">Informacje</button>
                    `;
      employeeBox.innerHTML = employeeInfo;
      employeeListDiv.appendChild(employeeBox);
    });
  })
  .catch((error) =>
    console.error("Błąd podczas pobierania danych pracowników:", error)
  );

function redirectToTraining(id) {
  window.location.href = "pracownik.html?id=" + id;
}
