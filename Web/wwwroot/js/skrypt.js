async function fetchData(method, url, data = null) {
  try {
    const options = {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
      body: data ? JSON.stringify(data) : null,
    };

    const response = await fetch(url, options);
    const responseData = await response.json();

    console.log(`Response for ${method} ${url}:`, responseData);
  } catch (error) {
    console.error("Error:", error);
  }
}

// Przykłady użycia:

// Przygotowanie danych w formie obiektu
const postData = {
  title: "foo",
  body: "bar",
  userId: 1,
};

// Zamiana obiektu na string JSON
const jsonString = JSON.stringify(postData);

// Wywołanie funkcji fetchData z danymi
fetchData("POST", "https://jsonplaceholder.typicode.com/posts", postData);

// Dla celów demonstracyjnych wyświetlenie stringa JSON w konsoli
console.log("JSON String:", jsonString);
