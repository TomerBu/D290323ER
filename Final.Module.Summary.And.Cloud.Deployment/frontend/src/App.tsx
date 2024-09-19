import { Route, Routes } from "react-router-dom";
import Home from "./routes/Home";
import About from "./routes/About";
import Register from "./routes/Register";
import Login from "./routes/Login";
import Products from "./routes/Products";
import NotFound from "./routes/NotFound";
import Navbar from "./components/Navbar";
import "./App.css";
const App = () => {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/products" element={<Products />} />

        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default App;
