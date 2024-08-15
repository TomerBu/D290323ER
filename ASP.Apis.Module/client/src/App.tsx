import "./App.css";

function App() {
  fetch("https://localhost:7257/weatherforecast")
    .then((response) => response.json())
    .then((data) => console.log(data));


    

    //axios.get("https://localhost:7257/weatherforecast")
    //.then((response) => console.log(response.data));
  return <h1>Hello, World</h1>;
}

export default App;
