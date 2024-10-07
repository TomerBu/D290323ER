import { Route, Routes } from "react-router-dom";
import Home from "./routes/Home";
import About from "./routes/About";
import Register from "./routes/Register";
import Login from "./routes/Login";
import Products from "./routes/Products";
import NotFound from "./routes/NotFound";
import Navbar from "./components/Navbar";
import "./App.css";
import ProtectedRoute from "./components/ProtectedRoute";
import NoAuthRoute from "./components/NoAuthRoute";
import Product from "./routes/Product";
const App = () => {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route
          path="/register"
          element={
            <NoAuthRoute>
              <Register />
            </NoAuthRoute>
          }
        />
        <Route
          path="/login"
          element={
            <NoAuthRoute>
              <Login />
            </NoAuthRoute>
          }
        />
        <Route
          path="/products"
          element={
            <ProtectedRoute>
              <Products />
            </ProtectedRoute>
          }
        />

        <Route
          path="/products/:id"
          element={
            <ProtectedRoute>
              <Product />
            </ProtectedRoute>
          }
        />

        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default App;
