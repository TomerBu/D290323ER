import { BsGithub } from "react-icons/bs";
import { SiHomebridge } from "react-icons/si";
import { NavLink } from "react-router-dom";
import './Navbar.scss';
import { useContext } from "react";
import { DarkModeContext } from "../contexts/DarkModeContext";

//rafce
const Navbar = () => {

  const {darkMode, toggle} = useContext(DarkModeContext);
  return (
    <nav id="app-nav" className="shadow-2xl p-8 flex gap-3 bg-fuchsia-50 text-fuchsia-900 dark:bg-fuchsia-900 dark:text-fuchsia-50">
      
      <button onClick={toggle} className="rounded-lg p-2">
         {darkMode ? "🌞" : "🌚"}
      </button>
      
      <NavLink className="rounded-lg p-2" to="/">
        <SiHomebridge aria-description="Home" />
      </NavLink>

      <div className="flex-1"></div>

      <div className="hidden sm:flex items-center">
        <NavLink className="rounded-lg p-2" to="/about">
          About
        </NavLink>
        <NavLink className="rounded-lg p-2" to="/products">
          Products
        </NavLink>
        <NavLink className="rounded-lg p-2" to="/login">
          Login
        </NavLink>
        <NavLink className="rounded-lg p-2" to="/register">
          Register
        </NavLink>
        <a href="https://github.com/TomerBu/D290323ER" className="px-2">
          <BsGithub aria-description="Github" />
        </a>
      </div>
    </nav>
  );
};

export default Navbar;
